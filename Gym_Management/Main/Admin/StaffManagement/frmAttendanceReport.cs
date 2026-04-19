using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.StaffManagement
{
    public partial class frmAttendanceReport : Form
    {
        private DBHelper db = new DBHelper();

        public frmAttendanceReport()
        {
            InitializeComponent();
        }

        private void frmAttendanceReport_Load(object sender, EventArgs e)
        {
            LoadEmployees();

            DateTime today = DateTime.Now.Date;
            dtFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtTo.Value = today;

            LoadAttendanceReport();
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

        private void LoadAttendanceReport()
        {
            try
            {
                DateTime fromDate = dtFrom.Value.Date;
                DateTime toDate = dtTo.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.");
                    return;
                }

                int userId = 0;
                if (cboEmployee.SelectedValue != null)
                    int.TryParse(cboEmployee.SelectedValue.ToString(), out userId);

                string sql = @"
                    SELECT
                        u.UserId AS [Mã NV],
                        u.FullName AS [Nhân viên],
                        COUNT(us.Id) AS [Ca được phân],
                        COUNT(a.AttendanceId) AS [Ca đã đi],
                        COUNT(us.Id) - COUNT(a.AttendanceId) AS [Ca vắng],
                        CASE 
                            WHEN COUNT(us.Id) = 0 THEN 0
                            ELSE ROUND(COUNT(a.AttendanceId) * 100.0 / COUNT(us.Id), 2)
                        END AS [Tỷ lệ chuyên cần (%)]
                    FROM Users u
                    LEFT JOIN UserShifts us
                        ON u.UserId = us.UserId
                        AND us.WorkDate BETWEEN @FromDate AND @ToDate
                    LEFT JOIN Attendances a
                        ON u.UserId = a.UserId
                        AND a.WorkDate = us.WorkDate
                    WHERE u.Role IN ('Staff', 'Admin')
                      AND (@UserId = 0 OR u.UserId = @UserId)
                    GROUP BY u.UserId, u.FullName
                    ORDER BY [Tỷ lệ chuyên cần (%)] DESC, u.FullName
                ";

                SqlParameter[] pr =
                {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate),
                    new SqlParameter("@UserId", userId)
                };

                DataTable dt = db.ExecuteQuery(sql, pr);
                dgvAttendance.DataSource = dt;
                dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvAttendance.Columns.Contains("Tỷ lệ chuyên cần (%)"))
                    dgvAttendance.Columns["Tỷ lệ chuyên cần (%)"].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo chuyên cần: " + ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadAttendanceReport();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now.Date;
            dtFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtTo.Value = today;

            if (cboEmployee.Items.Count > 0)
                cboEmployee.SelectedIndex = 0;

            LoadAttendanceReport();
        }
    }
}