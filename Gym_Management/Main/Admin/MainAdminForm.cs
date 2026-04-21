using Gym_Management.Main.Admin;
using Gym_Management.Main.Admin.ImportManagement;
using Gym_Management.Main.Admin.ProductManagement;
using Gym_Management.Main.Admin.StaffManagement;
using Gym_Management.Main.Staff;
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
            LoadFormToPanel(new frmImportReceipt());
        }

        private void btnSystemConfig_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmProductManagement());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Báo cáo sẽ làm ở bước tiếp theo.");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnHLV_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmManagingPT());
        }

        private void btnHangDaNhap_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new frmimportgoods());
        }
    }
}