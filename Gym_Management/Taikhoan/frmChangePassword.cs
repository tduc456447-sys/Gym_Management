using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.TaiKhoan
{
    public partial class frmChangePassword : Form
    {
        private DBHelper db = new DBHelper();

        bool showOld = false;
        bool showNew = false;
        bool showConfirm = false;

        public frmChangePassword(string username)
        {
            InitializeComponent();
            txtUsername.Text = username;

            txtOldPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            picOldEye.Image = Properties.Resources.eye_close;
            picNewEye.Image = Properties.Resources.eye_close;
            picConfirmEye.Image = Properties.Resources.eye_close;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void picOldEye_Click(object sender, EventArgs e)
        {
            showOld = !showOld;
            txtOldPassword.UseSystemPasswordChar = !showOld;
            picOldEye.Image = showOld ? Properties.Resources.eye_open : Properties.Resources.eye_close;
        }

        private void picNewEye_Click(object sender, EventArgs e)
        {
            showNew = !showNew;
            txtNewPassword.UseSystemPasswordChar = !showNew;
            picNewEye.Image = showNew ? Properties.Resources.eye_open : Properties.Resources.eye_close;
        }

        private void picConfirmEye_Click(object sender, EventArgs e)
        {
            showConfirm = !showConfirm;
            txtConfirmPassword.UseSystemPasswordChar = !showConfirm;
            picConfirmEye.Image = showConfirm ? Properties.Resources.eye_open : Properties.Resources.eye_close;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string oldPass = txtOldPassword.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();
            string confirm = txtConfirmPassword.Text.Trim();

            if (username == "" || oldPass == "" || newPass == "" || confirm == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin!");
                return;
            }

            if (newPass.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải >= 6 ký tự!");
                return;
            }

            if (newPass != confirm)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!");
                return;
            }

            try
            {
                string sqlCheck = @"
                    SELECT TOP 1 UserId, Password
                    FROM Users
                    WHERE Username = @Username";

                SqlParameter[] prCheck =
                {
                    new SqlParameter("@Username", username)
                };

                DataTable dt = db.ExecuteQuery(sqlCheck, prCheck);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tài khoản không tồn tại!");
                    return;
                }

                DataRow row = dt.Rows[0];
                string currentPasswordInDb = row["Password"].ToString();

                string oldHash = SecurityHelper.HashPassword(oldPass);

                if (currentPasswordInDb != oldHash)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!");
                    return;
                }

                string newHash = SecurityHelper.HashPassword(newPass);

                string sqlUpdate = @"
                    UPDATE Users
                    SET Password = @Password
                    WHERE Username = @Username";

                SqlParameter[] prUpdate =
                {
                    new SqlParameter("@Password", newHash),
                    new SqlParameter("@Username", username)
                };

                int result = db.ExecuteNonQuery(sqlUpdate, prUpdate);

                if (result > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đổi mật khẩu: " + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister f = new frmRegister();
            f.ShowDialog();
        }
    }
}