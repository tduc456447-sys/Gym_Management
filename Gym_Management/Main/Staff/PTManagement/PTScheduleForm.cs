using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Staff
{
    public partial class PTScheduleForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int staffId;

        public PTScheduleForm(int userId)
        {
            InitializeComponent();
            staffId = userId;
        }

        private void PTScheduleForm_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddDays(7);
            LoadStatusFilter();
            LoadTrainerFilter();
            InitGrid();
            LoadSchedules();
        }

        private void InitGrid()
        {
            dgvSchedules.ReadOnly = true;
            dgvSchedules.AllowUserToAddRows = false;
            dgvSchedules.AllowUserToDeleteRows = false;
            dgvSchedules.MultiSelect = false;
            dgvSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedules.RowHeadersVisible = false;
            dgvSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedules.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvSchedules.BackgroundColor = Color.White;
            dgvSchedules.BorderStyle = BorderStyle.FixedSingle;
            dgvSchedules.RowTemplate.Height = 30;
            dgvSchedules.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSchedules.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
        }

        private void LoadStatusFilter()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Tất cả");
            cboStatus.Items.Add("Booked");
            cboStatus.Items.Add("Done");
            cboStatus.Items.Add("Cancelled");
            cboStatus.SelectedIndex = 0;
        }

        private void LoadTrainerFilter()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT 0 AS TrainerId, N'Tất cả PT' AS Name
                UNION ALL
                SELECT TrainerId, Name
                FROM Trainers
                WHERE Status = 'Active'
                ORDER BY Name");

            cboTrainer.DataSource = dt;
            cboTrainer.DisplayMember = "Name";
            cboTrainer.ValueMember = "TrainerId";
        }

        private void LoadSchedules()
        {
            int trainerId = 0;
            if (cboTrainer.SelectedValue != null)
                int.TryParse(cboTrainer.SelectedValue.ToString(), out trainerId);

            string sql = @"
                SELECT
                    s.ScheduleId AS [Mã lịch],
                    s.ScheduledDate AS [Ngày tập],
                    CONVERT(VARCHAR(5), s.StartTime, 108) AS [Bắt đầu],
                    CONVERT(VARCHAR(5), s.EndTime, 108) AS [Kết thúc],
                    c.FullName AS [Hội viên],
                    ISNULL(c.Phone, '') AS [SĐT],
                    t.Name AS [PT],
                    p.Name AS [Gói tập],
                    s.Status AS [Trạng thái],
                    ISNULL(s.Note, '') AS [Ghi chú]
                FROM PTSchedules s
                INNER JOIN Customers c ON c.CustomerId = s.CustomerId
                INNER JOIN Trainers t ON t.TrainerId = s.TrainerId
                INNER JOIN Memberships m ON m.MembershipId = s.MembershipId
                INNER JOIN Packages p ON p.PackageId = m.PackageId
                WHERE s.ScheduledDate BETWEEN @FromDate AND @ToDate
                  AND (@TrainerId = 0 OR s.TrainerId = @TrainerId)
                  AND (@Status = N'Tất cả' OR s.Status = @Status)
                  AND (
                        @Keyword = ''
                        OR c.FullName LIKE N'%' + @Keyword + N'%'
                        OR ISNULL(c.Phone, '') LIKE N'%' + @Keyword + N'%'
                        OR t.Name LIKE N'%' + @Keyword + N'%'
                      )
                ORDER BY s.ScheduledDate, s.StartTime, c.FullName";

            SqlParameter[] pr =
            {
                new SqlParameter("@FromDate", dtpFrom.Value.Date),
                new SqlParameter("@ToDate", dtpTo.Value.Date),
                new SqlParameter("@TrainerId", trainerId),
                new SqlParameter("@Status", cboStatus.Text),
                new SqlParameter("@Keyword", txtKeyword.Text.Trim())
            };

            dgvSchedules.DataSource = db.ExecuteQuery(sql, pr);
            FormatGrid();
            UpdateSummary();
        }

        private void FormatGrid()
        {
            if (dgvSchedules.Columns.Count == 0)
                return;

            if (dgvSchedules.Columns.Contains("Mã lịch"))
                dgvSchedules.Columns["Mã lịch"].Width = 70;
            if (dgvSchedules.Columns.Contains("Ngày tập"))
                dgvSchedules.Columns["Ngày tập"].Width = 95;
            if (dgvSchedules.Columns.Contains("Bắt đầu"))
                dgvSchedules.Columns["Bắt đầu"].Width = 80;
            if (dgvSchedules.Columns.Contains("Kết thúc"))
                dgvSchedules.Columns["Kết thúc"].Width = 80;
            if (dgvSchedules.Columns.Contains("SĐT"))
                dgvSchedules.Columns["SĐT"].Width = 110;
            if (dgvSchedules.Columns.Contains("Trạng thái"))
                dgvSchedules.Columns["Trạng thái"].Width = 95;
        }

        private void UpdateSummary()
        {
            int total = dgvSchedules.Rows.Count;
            int booked = 0;
            int done = 0;
            int cancelled = 0;

            foreach (DataGridViewRow row in dgvSchedules.Rows)
            {
                string status = Convert.ToString(row.Cells["Trạng thái"].Value);
                if (status == "Booked") booked++;
                else if (status == "Done") done++;
                else if (status == "Cancelled") cancelled++;
            }

            lblSummary.Text = string.Format(
                "Tổng lịch: {0} | Đã đặt: {1} | Hoàn thành: {2} | Hủy: {3}",
                total, booked, done, cancelled);
        }

        private int GetSelectedScheduleId()
        {
            if (dgvSchedules.CurrentRow == null || dgvSchedules.CurrentRow.Cells["Mã lịch"].Value == null)
                return 0;

            return Convert.ToInt32(dgvSchedules.CurrentRow.Cells["Mã lịch"].Value);
        }

        private string GetSelectedStatus()
        {
            if (dgvSchedules.CurrentRow == null || dgvSchedules.CurrentRow.Cells["Trạng thái"].Value == null)
                return string.Empty;

            return dgvSchedules.CurrentRow.Cells["Trạng thái"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (PTScheduleEditForm f = new PTScheduleEditForm(staffId))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadSchedules();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int scheduleId = GetSelectedScheduleId();
            if (scheduleId == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch PT cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (PTScheduleEditForm f = new PTScheduleEditForm(staffId, scheduleId))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadSchedules();
            }
        }

        private void btnMarkDone_Click(object sender, EventArgs e)
        {
            int scheduleId = GetSelectedScheduleId();
            if (scheduleId == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch PT.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (GetSelectedStatus() == "Done")
            {
                MessageBox.Show("Lịch này đã hoàn thành rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Đánh dấu lịch này là hoàn thành?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            db.ExecuteNonQuery(@"
                UPDATE PTSchedules
                SET Status = 'Done', UpdatedAt = GETDATE()
                WHERE ScheduleId = @ScheduleId",
                new SqlParameter[]
                {
                    new SqlParameter("@ScheduleId", scheduleId)
                });

            LoadSchedules();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int scheduleId = GetSelectedScheduleId();
            if (scheduleId == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch PT.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (GetSelectedStatus() == "Cancelled")
            {
                MessageBox.Show("Lịch này đã hủy rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn hủy lịch này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            db.ExecuteNonQuery(@"
                UPDATE PTSchedules
                SET Status = 'Cancelled', UpdatedAt = GETDATE()
                WHERE ScheduleId = @ScheduleId",
                new SqlParameter[]
                {
                    new SqlParameter("@ScheduleId", scheduleId)
                });

            LoadSchedules();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            cboStatus.SelectedIndex = 0;
            if (cboTrainer.Items.Count > 0)
                cboTrainer.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddDays(7);
            LoadSchedules();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            LoadSchedules();
        }

        private void btnThisWeek_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime monday = today.AddDays(-diff).Date;
            dtpFrom.Value = monday;
            dtpTo.Value = monday.AddDays(6);
            LoadSchedules();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            LoadSchedules();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSchedules();
        }

        private void cboTrainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTrainer.Focused)
                LoadSchedules();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
                dtpTo.Value = dtpFrom.Value.Date;
            LoadSchedules();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTo.Value.Date < dtpFrom.Value.Date)
                dtpFrom.Value = dtpTo.Value.Date;
            LoadSchedules();
        }

        private void dgvSchedules_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEdit.PerformClick();
        }
    }
}
