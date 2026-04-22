using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Gym_Management.Main.Staff
{
    public partial class PTScheduleEditForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int staffId;
        private readonly int scheduleId;
        private bool isLoading;

        public PTScheduleEditForm(int userId, int editingScheduleId = 0)
        {
            InitializeComponent();
            staffId = userId;
            scheduleId = editingScheduleId;
        }

        private void PTScheduleEditForm_Load(object sender, EventArgs e)
        {
            isLoading = true;
            LoadMemberships();
            LoadStatus();
            dtpDate.Value = DateTime.Today;
            dtpStart.Value = DateTime.Today.Date.AddHours(6);
            dtpEnd.Value = DateTime.Today.Date.AddHours(7);

            if (scheduleId > 0)
            {
                this.Text = "Sửa lịch PT";
                btnSave.Text = "Cập nhật";
                LoadScheduleDetail();
            }
            else
            {
                this.Text = "Thêm lịch PT";
                btnSave.Text = "Lưu lịch";
                cboStatus.SelectedItem = "Booked";
            }

            UpdateMembershipInfo();
            isLoading = false;
        }

        private void LoadMemberships()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT
                    m.MembershipId,
                    CONCAT(
                        c.FullName,
                        N' - PT: ',
                        t.Name,
                        N' - Hạn: ',
                        CONVERT(VARCHAR(10), m.EndDate, 103)
                    ) AS DisplayText
                FROM Memberships m
                INNER JOIN Customers c ON c.CustomerId = m.CustomerId
                INNER JOIN Trainers t ON t.TrainerId = m.TrainerId
                WHERE m.Status = 'Active'
                  AND m.EndDate >= CAST(GETDATE() AS DATE)
                  AND m.TrainerId IS NOT NULL
                ORDER BY c.FullName, m.EndDate DESC");

            cboMembership.DataSource = dt;
            cboMembership.DisplayMember = "DisplayText";
            cboMembership.ValueMember = "MembershipId";
        }

        private void LoadStatus()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Booked");
            cboStatus.Items.Add("Done");
            cboStatus.Items.Add("Cancelled");
        }

        private void LoadScheduleDetail()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT TOP 1
                    ScheduleId,
                    MembershipId,
                    ScheduledDate,
                    StartTime,
                    EndTime,
                    Status,
                    Note
                FROM PTSchedules
                WHERE ScheduleId = @ScheduleId",
                new SqlParameter[]
                {
                    new SqlParameter("@ScheduleId", scheduleId)
                });

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy lịch PT cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            DataRow row = dt.Rows[0];
            cboMembership.SelectedValue = Convert.ToInt32(row["MembershipId"]);
            dtpDate.Value = Convert.ToDateTime(row["ScheduledDate"]);

            TimeSpan start = (TimeSpan)row["StartTime"];
            TimeSpan end = (TimeSpan)row["EndTime"];
            dtpStart.Value = DateTime.Today.Date.Add(start);
            dtpEnd.Value = DateTime.Today.Date.Add(end);

            cboStatus.SelectedItem = row["Status"].ToString();
            txtNote.Text = row["Note"] == DBNull.Value ? string.Empty : row["Note"].ToString();
        }

        private void UpdateMembershipInfo()
        {
            if (cboMembership.SelectedValue == null)
                return;

            int membershipId;
            if (!int.TryParse(cboMembership.SelectedValue.ToString(), out membershipId))
                return;

            DataTable dt = db.ExecuteQuery(@"
                SELECT TOP 1
                    m.MembershipId,
                    c.CustomerId,
                    c.FullName,
                    ISNULL(c.Phone, '') AS Phone,
                    t.TrainerId,
                    t.Name AS TrainerName,
                    p.Name AS PackageName,
                    m.StartDate,
                    m.EndDate
                FROM Memberships m
                INNER JOIN Customers c ON c.CustomerId = m.CustomerId
                INNER JOIN Trainers t ON t.TrainerId = m.TrainerId
                INNER JOIN Packages p ON p.PackageId = m.PackageId
                WHERE m.MembershipId = @MembershipId",
                new SqlParameter[]
                {
                    new SqlParameter("@MembershipId", membershipId)
                });

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];
            lblMemberValue.Text = row["FullName"].ToString();
            lblPhoneValue.Text = row["Phone"].ToString();
            lblTrainerValue.Text = row["TrainerName"].ToString();
            lblPackageValue.Text = row["PackageName"].ToString();
            lblExpireValue.Text = Convert.ToDateTime(row["EndDate"]).ToString("dd/MM/yyyy");
        }

        private bool ValidateInput(out int membershipId, out int customerId, out int trainerId)
        {
            membershipId = 0;
            customerId = 0;
            trainerId = 0;

            if (cboMembership.SelectedValue == null || !int.TryParse(cboMembership.SelectedValue.ToString(), out membershipId) || membershipId <= 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên có PT.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpEnd.Value.TimeOfDay <= dtpStart.Value.TimeOfDay)
            {
                MessageBox.Show("Giờ kết thúc phải lớn hơn giờ bắt đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DataTable dt = db.ExecuteQuery(@"
                SELECT TOP 1 CustomerId, TrainerId, EndDate
                FROM Memberships
                WHERE MembershipId = @MembershipId",
                new SqlParameter[]
                {
                    new SqlParameter("@MembershipId", membershipId)
                });

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Membership không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            customerId = Convert.ToInt32(dt.Rows[0]["CustomerId"]);
            trainerId = Convert.ToInt32(dt.Rows[0]["TrainerId"]);
            DateTime endDate = Convert.ToDateTime(dt.Rows[0]["EndDate"]);

            if (dtpDate.Value.Date > endDate.Date)
            {
                MessageBox.Show("Ngày lịch tập vượt quá hạn gói hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            object overlap = db.ExecuteScalar(@"
                SELECT COUNT(*)
                FROM PTSchedules
                WHERE TrainerId = @TrainerId
                  AND ScheduledDate = @ScheduledDate
                  AND Status <> 'Cancelled'
                  AND (@ScheduleId = 0 OR ScheduleId <> @ScheduleId)
                  AND (
                        @StartTime < EndTime
                        AND @EndTime > StartTime
                      )",
                new SqlParameter[]
                {
                    new SqlParameter("@TrainerId", trainerId),
                    new SqlParameter("@ScheduledDate", dtpDate.Value.Date),
                    new SqlParameter("@ScheduleId", scheduleId),
                    new SqlParameter("@StartTime", dtpStart.Value.TimeOfDay),
                    new SqlParameter("@EndTime", dtpEnd.Value.TimeOfDay)
                });

            if (Convert.ToInt32(overlap) > 0)
            {
                MessageBox.Show("PT đã có lịch bị trùng trong khung giờ này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int membershipId;
            int customerId;
            int trainerId;

            if (!ValidateInput(out membershipId, out customerId, out trainerId))
                return;

            SqlParameter[] pr =
            {
                new SqlParameter("@MembershipId", membershipId),
                new SqlParameter("@CustomerId", customerId),
                new SqlParameter("@TrainerId", trainerId),
                new SqlParameter("@ScheduledDate", dtpDate.Value.Date),
                new SqlParameter("@StartTime", dtpStart.Value.TimeOfDay),
                new SqlParameter("@EndTime", dtpEnd.Value.TimeOfDay),
                new SqlParameter("@Status", cboStatus.Text),
                new SqlParameter("@Note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text.Trim()),
                new SqlParameter("@CreatedByStaffId", staffId)
            };

            if (scheduleId > 0)
            {
                db.ExecuteNonQuery(@"
                    UPDATE PTSchedules
                    SET MembershipId = @MembershipId,
                        CustomerId = @CustomerId,
                        TrainerId = @TrainerId,
                        ScheduledDate = @ScheduledDate,
                        StartTime = @StartTime,
                        EndTime = @EndTime,
                        Status = @Status,
                        Note = @Note,
                        UpdatedAt = GETDATE()
                    WHERE ScheduleId = @ScheduleId",
                    new SqlParameter[]
                    {
                        new SqlParameter("@MembershipId", membershipId),
                        new SqlParameter("@CustomerId", customerId),
                        new SqlParameter("@TrainerId", trainerId),
                        new SqlParameter("@ScheduledDate", dtpDate.Value.Date),
                        new SqlParameter("@StartTime", dtpStart.Value.TimeOfDay),
                        new SqlParameter("@EndTime", dtpEnd.Value.TimeOfDay),
                        new SqlParameter("@Status", cboStatus.Text),
                        new SqlParameter("@Note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text.Trim()),
                        new SqlParameter("@ScheduleId", scheduleId)
                    });
            }
            else
            {
                db.ExecuteNonQuery(@"
                    INSERT INTO PTSchedules
                    (
                        MembershipId, CustomerId, TrainerId, ScheduledDate,
                        StartTime, EndTime, Status, Note, CreatedByStaffId
                    )
                    VALUES
                    (
                        @MembershipId, @CustomerId, @TrainerId, @ScheduledDate,
                        @StartTime, @EndTime, @Status, @Note, @CreatedByStaffId
                    )", pr);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cboMembership_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
                UpdateMembershipInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
