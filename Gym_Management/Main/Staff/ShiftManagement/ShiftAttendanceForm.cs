using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Staff
{
    public partial class ShiftAttendanceForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int userId;

        public ShiftAttendanceForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void ShiftAttendanceForm_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            LoadTodayShifts();
        }

        private void LoadTodayShifts()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT 
                    us.ShiftId,
                    ws.Name + ' (' + CONVERT(VARCHAR(5), ws.StartTime, 108) + ' - ' 
                             + CONVERT(VARCHAR(5), ws.EndTime, 108) + ')' AS DisplayText
                FROM UserShifts us
                JOIN WorkShifts ws ON us.ShiftId = ws.ShiftId
                WHERE us.UserId = @UserId
                  AND us.WorkDate = CAST(GETDATE() AS DATE)
                ORDER BY ws.StartTime",
                new SqlParameter[]
                {
                    new SqlParameter("@UserId", userId)
                });

            cboShift.DataSource = null;

            if (dt.Rows.Count == 0)
            {
                btnCheckIn.Enabled = false;
                btnCheckOut.Enabled = false;
                MessageBox.Show("Hôm nay bạn không có ca trực.");
                return;
            }

            cboShift.DataSource = dt;
            cboShift.DisplayMember = "DisplayText";
            cboShift.ValueMember = "ShiftId";

            btnCheckIn.Enabled = true;
            btnCheckOut.Enabled = true;
        }

        private bool HasTodayShift()
        {
            return cboShift.DataSource != null && cboShift.SelectedValue != null;
        }

        private bool HasCheckedInToday(int shiftId)
        {
            object result = db.ExecuteScalar(@"
        SELECT COUNT(*)
        FROM Attendances
        WHERE UserId = @UserId
          AND ShiftId = @ShiftId
          AND WorkDate = @WorkDate
          AND CheckIn IS NOT NULL",
                new SqlParameter[]
                {
            new SqlParameter("@UserId", userId),
            new SqlParameter("@ShiftId", shiftId),
            new SqlParameter("@WorkDate", DateTime.Today)
                });

            return Convert.ToInt32(result) > 0;
        }


        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (!HasTodayShift())
            {
                MessageBox.Show("Hôm nay bạn không có ca trực.");
                return;
            }

            try
            {
                db.ExecuteNonQuery("sp_CheckInShift",
                    new SqlParameter[]
                    {
                        new SqlParameter("@UserId", userId),
                        new SqlParameter("@ShiftId", Convert.ToInt32(cboShift.SelectedValue)),
                        new SqlParameter("@WorkDate", DateTime.Today)
                    },
                    CommandType.StoredProcedure);

                MessageBox.Show("Check-in thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Không thể check-in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (cboShift.SelectedValue == null)
            {
                MessageBox.Show("Hôm nay bạn không có ca trực.");
                return;
            }

            int shiftId = Convert.ToInt32(cboShift.SelectedValue);

            if (!HasCheckedInToday(shiftId))
            {
                MessageBox.Show("Bạn chưa check-in ca này.");
                return;
            }

            try
            {
                db.ExecuteNonQuery("sp_CheckOutShift",
                    new SqlParameter[]
                    {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@ShiftId", shiftId),
                new SqlParameter("@WorkDate", DateTime.Today)
                    },
                    CommandType.StoredProcedure);

                MessageBox.Show("Check-out thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi check-out: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}