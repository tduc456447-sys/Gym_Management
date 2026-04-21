using Gym_Management.Main.Admin;
using Gym_Management.Main.Admin.ProductManagement;
using Gym_Management.Main.Admin.StaffManagement;
using Gym_Management.TaiKhoan;
using System;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin
{
    public partial class MainAdminForm : Form
    {
        private int _userId;
        private string _fullName;

        public MainAdminForm(int userId, string fullName)
        {
            InitializeComponent();
            _userId = userId;
            _fullName = fullName;
        }

        private void MainAdminForm_Load(object sender, EventArgs e)
        {
            lblAdminName.Text = "Xin chào, " + _fullName;
            lblTitle.Text = "GYM MANAGEMENT - ADMIN";

            LoadControl(new ucAdminDashboard());
        }

        public void LoadControl(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        public void LoadFormToPanel(Form frm)
        {
            panelContent.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadControl(new ucAdminDashboard());
        }

        private void btnStaffManagement_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmStaffManagement());
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new ImportForm(_userId,_fullName));
        }

        private void btnSystemConfig_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmProductManagement());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new TrainerManagementForm(_userId,_fullName));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn đăng xuất không?",
                "Đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}