using Gym_Management.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.StaffManagement
{
    public partial class frmPendingApprovals : Form
    {
        DBHelper db = new DBHelper();

        public frmPendingApprovals()
        {
            InitializeComponent();
        }

        private void frmPendingApprovals_Load(object sender, EventArgs e)
        {
            LoadStatusFilter();
            LoadPendingUsers();
        }

        private void LoadStatusFilter()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Tất cả");
            cboStatus.Items.Add("Pending");
            cboStatus.Items.Add("Approved");
            cboStatus.Items.Add("Rejected");
            cboStatus.SelectedIndex = 0;
        }

        private void LoadPendingUsers()
        {
            try
            {
                string keyword = txtSearch.Text.Trim().Replace("'", "''");
                string status = cboStatus.SelectedItem != null ? cboStatus.SelectedItem.ToString() : "Tất cả";

                string sql = @"
                    SELECT
                        Id AS [Mã chờ],
                        Username AS [Tên đăng nhập],
                        FullName AS [Họ tên],
                        Phone AS [SĐT],
                        Email AS [Email],
                        Status AS [Trạng thái]
                    FROM PendingUsers
                    WHERE 1 = 1
                ";

                if (!string.IsNullOrEmpty(keyword))
                {
                    sql += $@"
                        AND (
                            Username LIKE N'%{keyword}%'
                            OR FullName LIKE N'%{keyword}%'
                            OR Phone LIKE N'%{keyword}%'
                            OR Email LIKE N'%{keyword}%'
                        )
                    ";
                }

                if (status != "Tất cả")
                {
                    sql += $" AND Status = N'{status}' ";
                }

                sql += " ORDER BY Id DESC";

                dgvPendingUsers.DataSource = db.ExecuteQuery(sql);
                dgvPendingUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tài khoản chờ: " + ex.Message);
            }
        }

        private void ClearInput()
        {
            txtPendingId.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPendingUsers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboStatus.SelectedIndex = 0;
            ClearInput();
            LoadPendingUsers();
        }

        private void dgvPendingUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvPendingUsers.Rows[e.RowIndex];
                txtPendingId.Text = row.Cells["Mã chờ"].Value?.ToString();

                if (string.IsNullOrEmpty(txtPendingId.Text)) return;

                string sql = $@"
                    SELECT Id, Username, Password, FullName, Phone, Email, Status
                    FROM PendingUsers
                    WHERE Id = {txtPendingId.Text}
                ";

                DataTable dt = db.ExecuteQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    txtUsername.Text = dt.Rows[0]["Username"].ToString();
                    txtPassword.Text = dt.Rows[0]["Password"].ToString();
                    txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtStatus.Text = dt.Rows[0]["Status"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn dữ liệu: " + ex.Message);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPendingId.Text))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần duyệt.");
                    return;
                }

                int pendingId = int.Parse(txtPendingId.Text);

                object statusObj = db.ExecuteScalar($@"
                    SELECT Status
                    FROM PendingUsers
                    WHERE Id = {pendingId}
                ");

                if (statusObj == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản chờ.");
                    return;
                }

                if (statusObj.ToString() != "Pending")
                {
                    MessageBox.Show("Chỉ duyệt được tài khoản đang ở trạng thái Pending.");
                    return;
                }

                string username = txtUsername.Text.Trim().Replace("'", "''");
                string password = txtPassword.Text.Trim().Replace("'", "''");
                string fullName = txtFullName.Text.Trim().Replace("'", "''");
                string phone = txtPhone.Text.Trim().Replace("'", "''");
                string email = txtEmail.Text.Trim().Replace("'", "''");

                object existedUser = db.ExecuteScalar($@"
                    SELECT COUNT(*)
                    FROM Users
                    WHERE Username = N'{username}'
                ");

                if (Convert.ToInt32(existedUser) > 0)
                {
                    MessageBox.Show("Username đã tồn tại trong bảng Users.");
                    return;
                }

                if (!string.IsNullOrEmpty(phone))
                {
                    object existedPhone = db.ExecuteScalar($@"
                        SELECT COUNT(*)
                        FROM Users
                        WHERE Phone = N'{phone}'
                    ");

                    if (Convert.ToInt32(existedPhone) > 0)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại trong hệ thống.");
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(email))
                {
                    object existedEmail = db.ExecuteScalar($@"
                        SELECT COUNT(*)
                        FROM Users
                        WHERE Email = N'{email}'
                    ");

                    if (Convert.ToInt32(existedEmail) > 0)
                    {
                        MessageBox.Show("Email đã tồn tại trong hệ thống.");
                        return;
                    }
                }

                string insertUserSql = $@"
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
                        N'Staff', N'Active', 0, NULL
                    )
                ";

                string updatePendingSql = $@"
                    UPDATE PendingUsers
                    SET Status = N'Approved'
                    WHERE Id = {pendingId}
                ";

                db.ExecuteNonQuery(insertUserSql);
                db.ExecuteNonQuery(updatePendingSql);

                MessageBox.Show("Duyệt tài khoản thành công.");
                LoadPendingUsers();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi duyệt tài khoản: " + ex.Message);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPendingId.Text))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần từ chối.");
                    return;
                }

                int pendingId = int.Parse(txtPendingId.Text);

                object statusObj = db.ExecuteScalar($@"
                    SELECT Status
                    FROM PendingUsers
                    WHERE Id = {pendingId}
                ");

                if (statusObj == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản.");
                    return;
                }

                if (statusObj.ToString() != "Pending")
                {
                    MessageBox.Show("Chỉ từ chối được tài khoản đang ở trạng thái Pending.");
                    return;
                }

                string sql = $@"
                    UPDATE PendingUsers
                    SET Status = N'Rejected'
                    WHERE Id = {pendingId}
                ";

                db.ExecuteNonQuery(sql);

                MessageBox.Show("Đã từ chối tài khoản.");
                LoadPendingUsers();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi từ chối tài khoản: " + ex.Message);
            }
        }
    }
}