using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    public partial class MainStaffForm : Form
    {
        private int _userId;
        private string _fullName;

        public MainStaffForm(int userId, string fullName)
        {
            InitializeComponent();
            _userId = userId;
            _fullName = fullName;
        }

        private void MainStaffForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "👋 Xin chào, " + _fullName;

            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += (s, ev) =>
            {
                lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            };
            t.Start();

            LoadForm(new DashboardForm(_userId));
        }

        private void LoadForm(Form f)
        {
            panelContent.Controls.Clear();

            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;

            panelContent.Controls.Add(f);
            f.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadForm(new DashboardForm(_userId));
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            LoadForm(new MembersForm(_userId));
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            LoadForm(new ShiftCalendarForm(_userId));
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            LoadForm(new SalesForm(_userId, _fullName));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}