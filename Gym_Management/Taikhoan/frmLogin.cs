using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Gym_Management.Data;
using Gym_Management.Main.Staff;

namespace Gym_Management.TaiKhoan
{
    public partial class frmLogin : Form
    {
        private DBHelper db = new DBHelper();
        private bool isShow = false;

        public frmLogin()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            picEye.Image = Properties.Resources.eye_close;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private DataRow CheckLogin(string username, string password)
        {
            string hashed = SecurityHelper.HashPassword(password);

            string sql = @"
                SELECT TOP 1 UserId, FullName, Role, Username, Status
                FROM Users
                WHERE Username = @Username
                  AND Password = @Password
                  AND Status = 'Active'";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", hashed)
            };

            DataTable dt = db.ExecuteQuery(sql, parameters);

            if (dt.Rows.Count > 0)
                return dt.Rows[0];

            return null;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Nhập đầy đủ!");
                return;
            }

            try
            {
                DataRow user = CheckLogin(username, password);

                if (user != null)
                {
                    MessageBox.Show("Đăng nhập thành công");

                    int userId = Convert.ToInt32(user["UserId"]);
                    string fullName = user["FullName"].ToString();
                    string role = user["Role"].ToString();

                    if (role == "Staff")
                    {
                        MainStaffForm f = new MainStaffForm(userId, fullName);
                        f.Show();
                        this.Hide();
                    }
                    else if (role == "Admin")
                    {
                        Main.Admin.MainAdminForm f = new Main.Admin.MainAdminForm(userId, fullName);
                        f.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }

        private void picEye_Click(object sender, EventArgs e)
        {
            isShow = !isShow;

            if (isShow)
            {
                txtPassword.UseSystemPasswordChar = false;
                picEye.Image = Properties.Resources.eye_open;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                picEye.Image = Properties.Resources.eye_close;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            frmChangePassword f = new frmChangePassword(txtUsername.Text);
            f.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister f = new frmRegister();
            f.ShowDialog();
        }
    }
}