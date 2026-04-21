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

            cboShift.DataSource = dt;
            cboShift.DisplayMember = "DisplayText";
            cboShift.ValueMember = "ShiftId";
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (cboShift.SelectedValue == null)
            {
                MessageBox.Show("Hôm nay bạn chưa đăng ký ca.");
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
                MessageBox.Show("Lỗi check-in: " + ex.Message);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (cboShift.SelectedValue == null)
            {
                MessageBox.Show("Hôm nay bạn chưa đăng ký ca.");
                return;
            }

            try
            {
                db.ExecuteNonQuery("sp_CheckOutShift",
                    new SqlParameter[]
                    {
                        new SqlParameter("@UserId", userId),
                        new SqlParameter("@ShiftId", Convert.ToInt32(cboShift.SelectedValue)),
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