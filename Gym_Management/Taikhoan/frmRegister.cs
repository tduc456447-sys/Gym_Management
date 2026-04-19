using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.TaiKhoan
{
    public partial class frmRegister : Form
    {
        private DBHelper db = new DBHelper();

        public frmRegister()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
        }

        private bool IsUsernameExistsInUsers(string username)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM Users
                WHERE Username = @Username";

            SqlParameter[] pr =
            {
                new SqlParameter("@Username", username)
            };

            object result = db.ExecuteScalar(sql, pr);
            return Convert.ToInt32(result) > 0;
        }

        private string GetPendingStatus(string username)
        {
            string sql = @"
                SELECT TOP 1 Status
                FROM PendingUsers
                WHERE Username = @Username
                ORDER BY Id DESC";

            SqlParameter[] pr =
            {
                new SqlParameter("@Username", username)
            };

            object result = db.ExecuteScalar(sql, pr);
            return result == null ? "" : result.ToString();
        }

        private bool IsPhoneExistsInUsers(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;

            string sql = @"
                SELECT COUNT(*)
                FROM Users
                WHERE Phone = @Phone";

            SqlParameter[] pr =
            {
                new SqlParameter("@Phone", phone)
            };

            object result = db.ExecuteScalar(sql, pr);
            return Convert.ToInt32(result) > 0;
        }

        private bool IsEmailExistsInUsers(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            string sql = @"
                SELECT COUNT(*)
                FROM Users
                WHERE Email = @Email";

            SqlParameter[] pr =
            {
                new SqlParameter("@Email", email)
            };

            object result = db.ExecuteScalar(sql, pr);
            return Convert.ToInt32(result) > 0;
        }

        private bool IsPhoneExistsInPending(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;

            string sql = @"
                SELECT COUNT(*)
                FROM PendingUsers
                WHERE Phone = @Phone
                  AND Status = 'Pending'";

            SqlParameter[] pr =
            {
                new SqlParameter("@Phone", phone)
            };

            object result = db.ExecuteScalar(sql, pr);
            return Convert.ToInt32(result) > 0;
        }

        private bool IsEmailExistsInPending(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            string sql = @"
                SELECT COUNT(*)
                FROM PendingUsers
                WHERE Email = @Email
                  AND Status = 'Pending'";

            SqlParameter[] pr =
            {
                new SqlParameter("@Email", email)
            };

            object result = db.ExecuteScalar(sql, pr);
            return Convert.ToInt32(result) > 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirmPassword.Text.Trim();

            if (username == "" || fullName == "" || phone == "" || email == "" || password == "" || confirm == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (username.Length < 4)
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 4 ký tự!");
                return;
            }

            if (phone.Length < 9)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return;
            }

            if (!email.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!");
                return;
            }

            try
            {
                if (IsUsernameExistsInUsers(username))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại trong hệ thống!");
                    return;
                }

                string pendingStatus = GetPendingStatus(username);

                if (pendingStatus == "Pending")
                {
                    MessageBox.Show("Tài khoản này đang chờ duyệt, không thể đăng ký lại!");
                    return;
                }
                else if (pendingStatus == "Approved")
                {
                    MessageBox.Show("Tài khoản này đã được duyệt trước đó!");
                    return;
                }

                if (IsPhoneExistsInUsers(phone))
                {
                    MessageBox.Show("Số điện thoại đã tồn tại trong hệ thống!");
                    return;
                }

                if (IsEmailExistsInUsers(email))
                {
                    MessageBox.Show("Email đã tồn tại trong hệ thống!");
                    return;
                }

                if (IsPhoneExistsInPending(phone))
                {
                    MessageBox.Show("Số điện thoại này đang được dùng cho một tài khoản chờ duyệt!");
                    return;
                }

                if (IsEmailExistsInPending(email))
                {
                    MessageBox.Show("Email này đang được dùng cho một tài khoản chờ duyệt!");
                    return;
                }

                string hashedPassword = SecurityHelper.HashPassword(password);

                string sql = @"
                    INSERT INTO PendingUsers
                    (
                        Username, Password, FullName, Phone, Email, Status
                    )
                    VALUES
                    (
                        @Username, @Password, @FullName, @Phone, @Email, 'Pending'
                    )";

                SqlParameter[] pr =
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", hashedPassword),
                    new SqlParameter("@FullName", fullName),
                    new SqlParameter("@Phone", phone),
                    new SqlParameter("@Email", email)
                };

                int result = db.ExecuteNonQuery(sql, pr);

                if (result > 0)
                {
                    MessageBox.Show("Đăng ký thành công. Vui lòng chờ admin duyệt tài khoản!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký: " + ex.Message);
            }
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void chkShowConfirm_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = !chkShowConfirm.Checked;
        }
    }
}