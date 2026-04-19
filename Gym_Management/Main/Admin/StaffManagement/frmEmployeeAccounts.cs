using Gym_Management.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.StaffManagement
{
    public partial class frmEmployeeAccounts : Form
    {
        DBHelper db = new DBHelper();

        public frmEmployeeAccounts()
        {
            InitializeComponent();
        }

        private void frmEmployeeAccounts_Load(object sender, EventArgs e)
        {
            LoadStatusFilter();
            LoadEmployeeAccounts();
        }

        private void LoadStatusFilter()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Tất cả");
            cboStatus.Items.Add("Active");
            cboStatus.Items.Add("Inactive");
            cboStatus.SelectedIndex = 0;
        }

        private void LoadEmployeeAccounts()
        {
            try
            {
                string keyword = txtSearch.Text.Trim().Replace("'", "''");
                string status = cboStatus.SelectedItem != null ? cboStatus.SelectedItem.ToString() : "Tất cả";

                string sql = @"
                    SELECT 
                        u.UserId AS [Mã NV],
                        u.Username AS [Tên đăng nhập],
                        u.FullName AS [Họ tên],
                        u.Phone AS [SĐT],
                        u.Email AS [Email],
                        u.Role AS [Vai trò],
                        u.Status AS [Trạng thái],
                        u.Experience AS [Kinh nghiệm],
                        ISNULL(sl.Name, N'Chưa có') AS [Cấp bậc]
                    FROM Users u
                    LEFT JOIN StaffLevels sl ON u.LevelId = sl.LevelId
                    WHERE 1=1
                ";

                if (!string.IsNullOrEmpty(keyword))
                {
                    sql += $@"
                        AND (
                            u.Username LIKE N'%{keyword}%'
                            OR u.FullName LIKE N'%{keyword}%'
                            OR u.Phone LIKE N'%{keyword}%'
                            OR u.Email LIKE N'%{keyword}%'
                        )
                    ";
                }

                if (status != "Tất cả")
                {
                    sql += $" AND u.Status = N'{status}' ";
                }

                sql += " ORDER BY u.UserId DESC";

                DataTable dt = db.ExecuteQuery(sql);
                dgvEmployees.DataSource = dt;

                if (dgvEmployees.Columns.Count > 0)
                {
                    dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void ClearInput()
        {
            txtUserId.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtExperience.Text = "0";
            cboRole.SelectedIndex = 0;
            cboAccountStatus.SelectedIndex = 0;
            cboLevel.SelectedIndex = -1;
        }

        private void LoadLevelCombo()
        {
            try
            {
                DataTable dt = db.ExecuteQuery("SELECT LevelId, Name FROM StaffLevels ORDER BY LevelId");

                cboLevel.DataSource = dt;
                cboLevel.DisplayMember = "Name";
                cboLevel.ValueMember = "LevelId";
                cboLevel.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải cấp bậc: " + ex.Message);
            }
        }

        private void LoadRoleCombo()
        {
            cboRole.Items.Clear();
            cboRole.Items.Add("Admin");
            cboRole.Items.Add("Staff");
            cboRole.SelectedIndex = 1;
        }

        private void LoadAccountStatusCombo()
        {
            cboAccountStatus.Items.Clear();
            cboAccountStatus.Items.Add("Active");
            cboAccountStatus.Items.Add("Inactive");
            cboAccountStatus.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadEmployeeAccounts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboStatus.SelectedIndex = 0;
            ClearInput();
            LoadEmployeeAccounts();
        }

        private void btnInitAdd_Click(object sender, EventArgs e)
        {
            LoadRoleCombo();
            LoadAccountStatusCombo();
            LoadLevelCombo();
            ClearInput();
            txtUsername.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim().Replace("'", "''");
                string password = txtPassword.Text.Trim().Replace("'", "''");
                string fullName = txtFullName.Text.Trim().Replace("'", "''");
                string phone = txtPhone.Text.Trim().Replace("'", "''");
                string email = txtEmail.Text.Trim().Replace("'", "''");
                string role = cboRole.Text;
                string accountStatus = cboAccountStatus.Text;

                int experience = 0;
                int.TryParse(txtExperience.Text.Trim(), out experience);

                string levelValue = cboLevel.SelectedValue != null ? cboLevel.SelectedValue.ToString() : "NULL";

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fullName))
                {
                    MessageBox.Show("Vui lòng nhập Username, Password và Họ tên.");
                    return;
                }

                string sql = $@"
                    INSERT INTO Users
                    (
                        Username, Password, FullName, Phone, Email,
                        Role, Status, Experience, LevelId
                    )
                    VALUES
                    (
                        N'{username}', N'{password}', N'{fullName}',
                        {(string.IsNullOrEmpty(phone) ? "NULL" : $"N'{phone}'")},
                        {(string.IsNullOrEmpty(email) ? "NULL" : $"N'{email}'")},
                        N'{role}', N'{accountStatus}', {experience},
                        {(levelValue == "NULL" ? "NULL" : levelValue)}
                    )
                ";

                db.ExecuteNonQuery(sql);
                MessageBox.Show("Thêm tài khoản thành công.");
                LoadEmployeeAccounts();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm tài khoản: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserId.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa.");
                    return;
                }

                int userId = int.Parse(txtUserId.Text);
                string fullName = txtFullName.Text.Trim().Replace("'", "''");
                string phone = txtPhone.Text.Trim().Replace("'", "''");
                string email = txtEmail.Text.Trim().Replace("'", "''");
                string role = cboRole.Text;
                string accountStatus = cboAccountStatus.Text;

                int experience = 0;
                int.TryParse(txtExperience.Text.Trim(), out experience);

                string levelValue = cboLevel.SelectedValue != null ? cboLevel.SelectedValue.ToString() : "NULL";

                string sql = $@"
                    UPDATE Users
                    SET
                        FullName = N'{fullName}',
                        Phone = {(string.IsNullOrEmpty(phone) ? "NULL" : $"N'{phone}'")},
                        Email = {(string.IsNullOrEmpty(email) ? "NULL" : $"N'{email}'")},
                        Role = N'{role}',
                        Status = N'{accountStatus}',
                        Experience = {experience},
                        LevelId = {(levelValue == "NULL" ? "NULL" : levelValue)}
                    WHERE UserId = {userId}
                ";

                db.ExecuteNonQuery(sql);
                MessageBox.Show("Cập nhật thành công.");
                LoadEmployeeAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật tài khoản: " + ex.Message);
            }
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserId.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên.");
                    return;
                }

                int userId = int.Parse(txtUserId.Text);
                string newStatus = cboAccountStatus.Text == "Active" ? "Inactive" : "Active";

                string sql = $@"
                    UPDATE Users
                    SET Status = N'{newStatus}'
                    WHERE UserId = {userId}
                ";

                db.ExecuteNonQuery(sql);
                MessageBox.Show("Đổi trạng thái thành công.");
                LoadEmployeeAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đổi trạng thái: " + ex.Message);
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];

            txtUserId.Text = row.Cells["Mã NV"].Value?.ToString();
            txtUsername.Text = row.Cells["Tên đăng nhập"].Value?.ToString();
            txtFullName.Text = row.Cells["Họ tên"].Value?.ToString();
            txtPhone.Text = row.Cells["SĐT"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            cboRole.Text = row.Cells["Vai trò"].Value?.ToString();
            cboAccountStatus.Text = row.Cells["Trạng thái"].Value?.ToString();
            txtExperience.Text = row.Cells["Kinh nghiệm"].Value?.ToString();

            string levelName = row.Cells["Cấp bậc"].Value?.ToString();
            if (!string.IsNullOrEmpty(levelName))
            {
                cboLevel.Text = levelName;
            }

            txtPassword.Text = "";
        }
    }
}