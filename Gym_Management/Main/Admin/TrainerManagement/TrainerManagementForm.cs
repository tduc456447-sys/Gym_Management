using Gym_Management.Data;
using Gym_Management.Main.Staff;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin
{
    public partial class TrainerManagementForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int adminId;
        private readonly string adminName;

        private int selectedTrainerId = 0;

        public TrainerManagementForm(int userId, string fullName)
        {
            InitializeComponent();
            adminId = userId;
            adminName = fullName;
        }

        private void TrainerManagementForm_Load(object sender, EventArgs e)
        {
            lblAdmin.Text = "Admin: " + adminName;
            InitGrid();
            LoadTrainerLevels();
            LoadStatusFilter();
            LoadTrainerList();
            ClearTrainerDetail();
        }

        private void InitGrid()
        {
            dgvTrainers.RowHeadersVisible = false;
            dgvTrainers.AllowUserToAddRows = false;
            dgvTrainers.AllowUserToDeleteRows = false;
            dgvTrainers.ReadOnly = true;
            dgvTrainers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrainers.MultiSelect = false;
            dgvTrainers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrainers.AllowUserToResizeRows = false;
            dgvTrainers.RowTemplate.Height = 32;
            dgvTrainers.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvTrainers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void LoadStatusFilter()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Tất cả");
            cboStatus.Items.Add("Active");
            cboStatus.Items.Add("Inactive");
            cboStatus.SelectedIndex = 0;
        }

        private void LoadTrainerLevels()
        {
            try
            {
                DataTable dt = db.ExecuteQuery("sp_GetTrainerLevels", null, CommandType.StoredProcedure);

                DataRow row = dt.NewRow();
                row["LevelId"] = 0;
                row["Name"] = "Tất cả";
                dt.Rows.InsertAt(row, 0);

                cboLevel.DisplayMember = "Name";
                cboLevel.ValueMember = "LevelId";
                cboLevel.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load cấp độ PT: " + ex.Message);
            }
        }

        private void LoadTrainerList()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                string status = cboStatus.SelectedIndex <= 0 ? "" : cboStatus.Text;
                int levelId = 0;

                if (cboLevel.SelectedValue != null)
                    int.TryParse(cboLevel.SelectedValue.ToString(), out levelId);

                DataTable dt = db.ExecuteQuery("sp_GetTrainerList",
                    new SqlParameter[]
                    {
                        new SqlParameter("@Keyword", keyword),
                        new SqlParameter("@Status", status),
                        new SqlParameter("@LevelId", levelId)
                    },
                    CommandType.StoredProcedure);

                dgvTrainers.DataSource = dt;

                if (dgvTrainers.Columns["TrainerId"] != null)
                    dgvTrainers.Columns["TrainerId"].Visible = false;

                if (dgvTrainers.Columns["LevelId"] != null)
                    dgvTrainers.Columns["LevelId"].Visible = false;

                if (dgvTrainers.Columns["Avatar"] != null)
                    dgvTrainers.Columns["Avatar"].Visible = false;

                if (dgvTrainers.Columns["CreatedAt"] != null)
                    dgvTrainers.Columns["CreatedAt"].Visible = false;

                if (dgvTrainers.Columns["UpdatedAt"] != null)
                    dgvTrainers.Columns["UpdatedAt"].Visible = false;

                if (dgvTrainers.Columns["PricePercentIncrease"] != null)
                    dgvTrainers.Columns["PricePercentIncrease"].Visible = false;

                if (dt.Rows.Count > 0)
                {
                    dgvTrainers.ClearSelection();
                    dgvTrainers.Rows[0].Selected = true;
                    dgvTrainers.CurrentCell = dgvTrainers.Rows[0].Cells["Name"];
                    LoadSelectedTrainerDetail();
                }
                else
                {
                    selectedTrainerId = 0;
                    ClearTrainerDetail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách PT: " + ex.Message);
            }
        }

        private void LoadSelectedTrainerDetail()
        {
            if (dgvTrainers.CurrentRow == null)
            {
                ClearTrainerDetail();
                return;
            }

            try
            {
                selectedTrainerId = Convert.ToInt32(dgvTrainers.CurrentRow.Cells["TrainerId"].Value);

                DataTable dt = db.ExecuteQuery("sp_GetTrainerById",
                    new SqlParameter[]
                    {
                        new SqlParameter("@TrainerId", selectedTrainerId)
                    },
                    CommandType.StoredProcedure);

                if (dt.Rows.Count == 0)
                {
                    ClearTrainerDetail();
                    return;
                }

                DataRow row = dt.Rows[0];

                lblNameValue.Text = row["Name"].ToString();
                lblPhoneValue.Text = row["Phone"].ToString();
                lblEmailValue.Text = row["Email"].ToString();
                lblSpecialtyValue.Text = row["Specialty"].ToString();
                lblExperienceValue.Text = row["Experience"].ToString() + " năm";
                lblLevelValue.Text = row["LevelName"].ToString();
                lblSalaryPercentValue.Text = row["SalaryPercent"].ToString() + "%";
                lblStatusValue.Text = row["Status"].ToString();
                lblActiveClientsValue.Text = row["ActiveClients"].ToString();
                lblTotalClientsValue.Text = row["TotalClients"].ToString();
                lblRevenueValue.Text = Convert.ToDecimal(row["TotalRevenue"]).ToString("N0");
                lblCreatedAtValue.Text = row["CreatedAt"] == DBNull.Value ? "" : Convert.ToDateTime(row["CreatedAt"]).ToString("dd/MM/yyyy HH:mm");
                lblUpdatedAtValue.Text = row["UpdatedAt"] == DBNull.Value ? "" : Convert.ToDateTime(row["UpdatedAt"]).ToString("dd/MM/yyyy HH:mm");

                LoadTrainerImage(row["Avatar"].ToString());
                UpdateToggleStatusButton(row["Status"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load chi tiết PT: " + ex.Message);
            }
        }

        private void LoadTrainerImage(string imageFileName)
        {
            picTrainer.Image = null;

            try
            {
                string fileName = (imageFileName ?? "").Trim().TrimStart('/', '\\');
                if (string.IsNullOrWhiteSpace(fileName))
                    return;

                string imageFolder = Path.Combine(Application.StartupPath, "images");
                string imagePath = Path.Combine(imageFolder, fileName);

                if (File.Exists(imagePath))
                    picTrainer.Image = Image.FromFile(imagePath);
            }
            catch
            {
                picTrainer.Image = null;
            }
        }

        private void UpdateToggleStatusButton(string currentStatus)
        {
            if (currentStatus == "Active")
            {
                btnToggleStatus.Text = "Khóa PT";
                btnToggleStatus.BackColor = Color.Firebrick;
                btnToggleStatus.ForeColor = Color.White;
            }
            else
            {
                btnToggleStatus.Text = "Mở PT";
                btnToggleStatus.BackColor = Color.SeaGreen;
                btnToggleStatus.ForeColor = Color.White;
            }
        }

        private void ClearTrainerDetail()
        {
            lblNameValue.Text = "";
            lblPhoneValue.Text = "";
            lblEmailValue.Text = "";
            lblSpecialtyValue.Text = "";
            lblExperienceValue.Text = "";
            lblLevelValue.Text = "";
            lblSalaryPercentValue.Text = "";
            lblStatusValue.Text = "";
            lblActiveClientsValue.Text = "0";
            lblTotalClientsValue.Text = "0";
            lblRevenueValue.Text = "0";
            lblCreatedAtValue.Text = "";
            lblUpdatedAtValue.Text = "";
            picTrainer.Image = null;

            btnToggleStatus.Text = "Khóa/Mở";
            btnToggleStatus.BackColor = SystemColors.Control;
            btnToggleStatus.ForeColor = Color.Black;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTrainerList();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cboStatus.SelectedIndex = 0;
            if (cboLevel.Items.Count > 0)
                cboLevel.SelectedIndex = 0;

            LoadTrainerList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTrainerList();
        }

        private void dgvTrainers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTrainers.Focused || dgvTrainers.ContainsFocus)
                LoadSelectedTrainerDetail();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddEditTrainerForm f = new AddEditTrainerForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadTrainerList();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedTrainerId <= 0)
            {
                MessageBox.Show("Vui lòng chọn huấn luyện viên.");
                return;
            }

            using (AddEditTrainerForm f = new AddEditTrainerForm(selectedTrainerId))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadTrainerList();
                }
            }
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            if (selectedTrainerId <= 0)
            {
                MessageBox.Show("Vui lòng chọn huấn luyện viên.");
                return;
            }

            string currentStatus = lblStatusValue.Text.Trim();
            string newStatus = currentStatus == "Active" ? "Inactive" : "Active";
            string actionText = currentStatus == "Active" ? "khóa" : "mở";

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn " + actionText + " huấn luyện viên này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs != DialogResult.Yes)
                return;

            try
            {
                db.ExecuteQuery("sp_SetTrainerStatus",
                    new SqlParameter[]
                    {
                        new SqlParameter("@TrainerId", selectedTrainerId),
                        new SqlParameter("@Status", newStatus)
                    },
                    CommandType.StoredProcedure);

                MessageBox.Show("Cập nhật trạng thái thành công.");
                LoadTrainerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật trạng thái: " + ex.Message);
            }
        }

        private void btnViewMembers_Click(object sender, EventArgs e)
        {
            if (selectedTrainerId <= 0)
            {
                MessageBox.Show("Vui lòng chọn huấn luyện viên.");
                return;
            }

            using (TrainerMembersForm f = new TrainerMembersForm(selectedTrainerId, lblNameValue.Text))
            {
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (PTScheduleForm f = new PTScheduleForm(selectedTrainerId))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadTrainerList();
                }
            }
        }
    }
}