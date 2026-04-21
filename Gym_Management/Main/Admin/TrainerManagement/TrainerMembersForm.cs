using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Admin
{
    public partial class TrainerMembersForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int trainerId;
        private readonly string trainerName;

        public TrainerMembersForm(int trainerId, string trainerName)
        {
            InitializeComponent();
            this.trainerId = trainerId;
            this.trainerName = trainerName;
        }

        private void TrainerMembersForm_Load(object sender, EventArgs e)
        {
            lblTrainerName.Text = "Huấn luyện viên: " + trainerName;
            InitGrid();
            LoadStatusFilter();
            LoadMembers();
        }

        private void InitGrid()
        {
            dgvMembers.RowHeadersVisible = false;
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.AllowUserToDeleteRows = false;
            dgvMembers.ReadOnly = true;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.MultiSelect = false;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembers.AllowUserToResizeRows = false;
            dgvMembers.RowTemplate.Height = 32;
            dgvMembers.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void LoadStatusFilter()
        {
            cboMembershipStatus.Items.Clear();
            cboMembershipStatus.Items.Add("Tất cả");
            cboMembershipStatus.Items.Add("Active");
            cboMembershipStatus.Items.Add("Pending");
            cboMembershipStatus.Items.Add("Expired");
            cboMembershipStatus.Items.Add("Cancelled");
            cboMembershipStatus.SelectedIndex = 0;
        }

        private void LoadMembers()
        {
            try
            {
                string status = cboMembershipStatus.SelectedIndex <= 0 ? "" : cboMembershipStatus.Text;

                DataTable dt = db.ExecuteQuery("sp_GetTrainerMembers",
                    new SqlParameter[]
                    {
                        new SqlParameter("@TrainerId", trainerId),
                        new SqlParameter("@MembershipStatus", status)
                    },
                    CommandType.StoredProcedure);

                dgvMembers.DataSource = dt;

                if (dgvMembers.Columns["MembershipId"] != null)
                    dgvMembers.Columns["MembershipId"].HeaderText = "Mã gói";

                if (dgvMembers.Columns["CustomerId"] != null)
                    dgvMembers.Columns["CustomerId"].HeaderText = "Mã KH";

                if (dgvMembers.Columns["FullName"] != null)
                    dgvMembers.Columns["FullName"].HeaderText = "Tên khách";

                if (dgvMembers.Columns["Phone"] != null)
                    dgvMembers.Columns["Phone"].HeaderText = "Điện thoại";

                if (dgvMembers.Columns["PackageId"] != null)
                    dgvMembers.Columns["PackageId"].Visible = false;

                if (dgvMembers.Columns["PackageName"] != null)
                    dgvMembers.Columns["PackageName"].HeaderText = "Gói tập";

                if (dgvMembers.Columns["StartDate"] != null)
                    dgvMembers.Columns["StartDate"].HeaderText = "Bắt đầu";

                if (dgvMembers.Columns["EndDate"] != null)
                    dgvMembers.Columns["EndDate"].HeaderText = "Kết thúc";

                if (dgvMembers.Columns["Status"] != null)
                    dgvMembers.Columns["Status"].HeaderText = "Trạng thái";

                if (dgvMembers.Columns["Price"] != null)
                {
                    dgvMembers.Columns["Price"].HeaderText = "Giá";
                    dgvMembers.Columns["Price"].DefaultCellStyle.Format = "N0";
                }

                if (dgvMembers.Columns["CreatedAt"] != null)
                    dgvMembers.Columns["CreatedAt"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load học viên của PT: " + ex.Message);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadMembers();
        }
    }
}