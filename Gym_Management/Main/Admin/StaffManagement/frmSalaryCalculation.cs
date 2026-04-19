using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.StaffManagement
{
    public partial class frmSalaryCalculation : Form
    {
        private DBHelper db = new DBHelper();

        public frmSalaryCalculation()
        {
            InitializeComponent();
        }

        private void frmSalaryCalculation_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadMonthYear();
            LoadSalaryReport();
        }

        private void LoadEmployees()
        {
            try
            {
                DataTable dt = db.ExecuteQuery(@"
                    SELECT 0 AS UserId, N'Tất cả nhân viên' AS FullName
                    UNION ALL
                    SELECT UserId, FullName
                    FROM Users
                    WHERE Role IN ('Staff', 'Admin')
                    ORDER BY UserId
                ");

                cboEmployee.DataSource = dt;
                cboEmployee.DisplayMember = "FullName";
                cboEmployee.ValueMember = "UserId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void LoadMonthYear()
        {
            cboMonth.Items.Clear();
            for (int i = 1; i <= 12; i++)
                cboMonth.Items.Add(i);

            cboMonth.SelectedItem = DateTime.Now.Month;

            cboYear.Items.Clear();
            for (int y = DateTime.Now.Year - 3; y <= DateTime.Now.Year + 1; y++)
                cboYear.Items.Add(y);

            cboYear.SelectedItem = DateTime.Now.Year;
        }

        private void LoadSalaryReport()
        {
            try
            {
                if (cboMonth.SelectedItem == null || cboYear.SelectedItem == null)
                    return;

                int month = Convert.ToInt32(cboMonth.SelectedItem);
                int year = Convert.ToInt32(cboYear.SelectedItem);

                int userId = 0;
                if (cboEmployee.SelectedValue != null)
                    int.TryParse(cboEmployee.SelectedValue.ToString(), out userId);

                string sql = @"
            SELECT
                u.UserId AS [Mã NV],
                u.FullName AS [Nhân viên],
                ISNULL(sl.Name, N'Chưa có') AS [Cấp bậc],
                COUNT(a.AttendanceId) AS [Số ca đã làm],
                sc.BaseSalaryPerShift AS [Lương cơ bản/ca],
                ISNULL(sl.SalaryPercentIncrease, 0) AS [% tăng lương],
                COUNT(a.AttendanceId) * sc.BaseSalaryPerShift * (1 + ISNULL(sl.SalaryPercentIncrease, 0) / 100.0) AS [Tổng lương]
            FROM Users u
            CROSS JOIN SystemConfig sc
            LEFT JOIN StaffLevels sl ON u.LevelId = sl.LevelId
            LEFT JOIN Attendances a
                ON u.UserId = a.UserId
                AND MONTH(a.WorkDate) = @Month
                AND YEAR(a.WorkDate) = @Year
            WHERE u.Role IN ('Staff', 'Admin')
              AND (@UserId = 0 OR u.UserId = @UserId)
            GROUP BY
                u.UserId,
                u.FullName,
                sl.Name,
                sc.BaseSalaryPerShift,
                sl.SalaryPercentIncrease
            ORDER BY [Tổng lương] DESC, u.FullName
        ";

                SqlParameter[] pr1 =
                {
            new SqlParameter("@Month", month),
            new SqlParameter("@Year", year),
            new SqlParameter("@UserId", userId)
        };

                DataTable dt = db.ExecuteQuery(sql, pr1);
                dgvSalary.DataSource = dt;
                dgvSalary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvSalary.Columns.Contains("Lương cơ bản/ca"))
                    dgvSalary.Columns["Lương cơ bản/ca"].DefaultCellStyle.Format = "N0";

                if (dgvSalary.Columns.Contains("Tổng lương"))
                    dgvSalary.Columns["Tổng lương"].DefaultCellStyle.Format = "N0";

                string totalSql = @"
            SELECT ISNULL(SUM(x.TotalSalary), 0)
            FROM
            (
                SELECT
                    u.UserId,
                    COUNT(a.AttendanceId) * sc.BaseSalaryPerShift * (1 + ISNULL(sl.SalaryPercentIncrease, 0) / 100.0) AS TotalSalary
                FROM Users u
                CROSS JOIN SystemConfig sc
                LEFT JOIN StaffLevels sl ON u.LevelId = sl.LevelId
                LEFT JOIN Attendances a
                    ON u.UserId = a.UserId
                    AND MONTH(a.WorkDate) = @Month
                    AND YEAR(a.WorkDate) = @Year
                WHERE u.Role IN ('Staff', 'Admin')
                  AND (@UserId = 0 OR u.UserId = @UserId)
                GROUP BY
                    u.UserId,
                    sc.BaseSalaryPerShift,
                    sl.SalaryPercentIncrease
            ) x
        ";

                SqlParameter[] pr2 =
                {
            new SqlParameter("@Month", month),
            new SqlParameter("@Year", year),
            new SqlParameter("@UserId", userId)
        };

                object totalObj = db.ExecuteScalar(totalSql, pr2);
                lblTotalSalary.Text = "Tổng lương tháng: " + Convert.ToDecimal(totalObj).ToString("N0") + " VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bảng lương: " + ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadSalaryReport();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboMonth.SelectedItem = DateTime.Now.Month;
            cboYear.SelectedItem = DateTime.Now.Year;

            if (cboEmployee.Items.Count > 0)
                cboEmployee.SelectedIndex = 0;

            LoadSalaryReport();
        }
    }
}