using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Staff
{
    public partial class ShiftRegisterForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int userId;
        private readonly DateTime workDate;
        private readonly int preselectedShiftId;

        public ShiftRegisterForm(int userId, DateTime workDate, int shiftId = 0)
        {
            InitializeComponent();
            this.userId = userId;
            this.workDate = workDate.Date;
            this.preselectedShiftId = shiftId;
        }

        private void ShiftRegisterForm_Load(object sender, EventArgs e)
        {
            txtDate.Text = workDate.ToString("dd/MM/yyyy");
            LoadShifts();

            if (preselectedShiftId > 0)
                cboShift.SelectedValue = preselectedShiftId;
        }

        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-diff).Date;
        }

        private bool IsNextWeek(DateTime date)
        {
            DateTime nextWeekStart = GetStartOfWeek(DateTime.Today).AddDays(7);
            DateTime nextWeekEnd = nextWeekStart.AddDays(6);
            return date.Date >= nextWeekStart && date.Date <= nextWeekEnd;
        }

        private void LoadShifts()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT 
                    ShiftId,
                    Name + ' (' + CONVERT(VARCHAR(5), StartTime, 108) + ' - ' 
                         + CONVERT(VARCHAR(5), EndTime, 108) + ')' AS DisplayText
                FROM WorkShifts
                ORDER BY StartTime");

            cboShift.DataSource = dt;
            cboShift.DisplayMember = "DisplayText";
            cboShift.ValueMember = "ShiftId";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!IsNextWeek(workDate))
            {
                MessageBox.Show("Staff chỉ được đăng ký ca cho tuần sau.");
                return;
            }

            if (cboShift.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn ca.");
                return;
            }

            try
            {
                int shiftId = Convert.ToInt32(cboShift.SelectedValue);

                db.ExecuteNonQuery("sp_RegisterShift",
                    new SqlParameter[]
                    {
                        new SqlParameter("@UserId", userId),
                        new SqlParameter("@ShiftId", shiftId),
                        new SqlParameter("@WorkDate", workDate)
                    },
                    CommandType.StoredProcedure);

                MessageBox.Show("Đăng ký ca thành công.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký ca: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}