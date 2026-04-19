using System;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.StaffManagement
{
    public partial class frmStaffManagement : Form
    {
        public frmStaffManagement()
        {
            InitializeComponent();
        }

        private void frmStaffManagement_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "QUẢN LÝ NHÂN VIÊN";
            OpenChildForm(new frmEmployeeAccounts());
        }

        private void OpenChildForm(Form childForm)
        {
            panelContent.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(childForm);
            childForm.Show();
        }

        private void OpenPlaceholder(string featureName)
        {
            panelContent.Controls.Clear();

            Label lbl = new Label();
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            lbl.Text = featureName + "\n\nChức năng này sẽ làm ở file tiếp theo.";

            panelContent.Controls.Add(lbl);
        }

        private void btnEmployeeAccounts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmEmployeeAccounts()); ;
        }

        private void btnPendingApprovals_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPendingApprovals());
        }

        private void btnCurrentWeekSchedule_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCurrentWeekSchedule());
        }

        private void btnNextWeekSchedule_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNextWeekSchedule());
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAttendanceReport());
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSalaryCalculation());
        }
    }
}