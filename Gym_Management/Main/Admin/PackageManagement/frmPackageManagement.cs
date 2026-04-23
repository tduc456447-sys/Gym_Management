using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.PackageManagement
{
    public partial class frmPackageManagement : Form
    {
        private readonly DBHelper db = new DBHelper();
        private int selectedPackageId = 0;
        private bool isBindingData = false;

        public frmPackageManagement()
        {
            InitializeComponent();
            ApplyModernStyle();
        }

        private void frmPackageManagement_Load(object sender, EventArgs e)
        {
            LoadFilterType();
            LoadFilterStatus();
            LoadDurationTypes();
            LoadStatusOptions();
            LoadTrainers();
            LoadPackages();
            SetDefaultForm();
        }

        #region Load dữ liệu

        private void LoadFilterType()
        {
            cboFilterType.Items.Clear();
            cboFilterType.Items.Add("Tất cả");
            cboFilterType.Items.Add("NORMAL");
            cboFilterType.Items.Add("PT");
            cboFilterType.SelectedIndex = 0;
        }

        private void LoadFilterStatus()
        {
            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.Add("Tất cả");
            cboFilterStatus.Items.Add("Active");
            cboFilterStatus.Items.Add("Inactive");
            cboFilterStatus.SelectedIndex = 0;
        }

        private void LoadDurationTypes()
        {
            object[] items = { "Day", "Week", "Month", "Year" };
            cboDurationType.Items.Clear();
            cboDurationType.Items.AddRange(items);
            cboDurationType.SelectedIndex = 2;
        }

        private void LoadStatusOptions()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Active");
            cboStatus.Items.Add("Inactive");
            cboStatus.SelectedIndex = 0;
        }

        private void LoadTrainers()
        {
            try
            {
                DataTable dt = db.ExecuteQuery(@"
                    SELECT TrainerId,
                           Name + N' - ' + ISNULL(Phone, '') AS DisplayName
                    FROM Trainers
                    WHERE Status = 'Active'
                    ORDER BY Name");

                cboTrainer.DataSource = dt;
                cboTrainer.DisplayMember = "DisplayName";
                cboTrainer.ValueMember = "TrainerId";
                cboTrainer.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách PT: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPackages()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                string packageType = cboFilterType.SelectedIndex <= 0 ? string.Empty : cboFilterType.Text;
                string status = cboFilterStatus.SelectedIndex <= 0 ? string.Empty : cboFilterStatus.Text;

                string sql = @"
                    SELECT
                        p.PackageId,
                        p.Name AS [Tên gói],
                        p.PackageType AS [Loại gói],
                        p.DurationValue AS [Thời lượng],
                        p.DurationType AS [Đơn vị],
                        p.Price AS [Giá],
                        ISNULL(p.PTSessionCount, 0) AS [Số buổi PT],
                        ISNULL(t.Name, N'') AS [PT phụ trách],
                        p.Status AS [Trạng thái],
                        ISNULL(p.Description, N'') AS [Mô tả],
                        p.TrainerId
                    FROM Packages p
                    LEFT JOIN Trainers t ON p.TrainerId = t.TrainerId
                    WHERE (@Keyword = '' OR p.Name LIKE N'%' + @Keyword + '%' OR ISNULL(p.Description, N'') LIKE N'%' + @Keyword + '%')
                      AND (@PackageType = '' OR p.PackageType = @PackageType)
                      AND (@Status = '' OR p.Status = @Status)
                    ORDER BY p.PackageId DESC";

                DataTable dt = db.ExecuteQuery(sql, new SqlParameter[]
                {
                    new SqlParameter("@Keyword", keyword),
                    new SqlParameter("@PackageType", packageType),
                    new SqlParameter("@Status", status)
                });

                dgvPackages.DataSource = dt;
                FormatGrid();

                if (dt.Rows.Count > 0)
                {
                    dgvPackages.ClearSelection();
                    dgvPackages.Rows[0].Selected = true;
                    dgvPackages.CurrentCell = dgvPackages.Rows[0].Cells["Tên gói"];
                    LoadCurrentRowToForm();
                }
                else
                {
                    SetDefaultForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách gói tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrainerInfoBySelectedTrainer()
        {
            try
            {
                if (cboTrainer.SelectedValue == null)
                {
                    ClearTrainerInfo();
                    return;
                }

                int trainerId;
                if (!int.TryParse(cboTrainer.SelectedValue.ToString(), out trainerId) || trainerId <= 0)
                {
                    ClearTrainerInfo();
                    return;
                }

                DataTable dt = db.ExecuteQuery(@"
                    SELECT TOP 1
                        t.Name,
                        ISNULL(t.Phone, '') AS Phone,
                        ISNULL(t.Specialty, '') AS Specialty,
                        ISNULL(t.Experience, 0) AS Experience,
                        ISNULL(l.Name, '') AS LevelName
                    FROM Trainers t
                    LEFT JOIN TrainerLevels l ON t.LevelId = l.LevelId
                    WHERE t.TrainerId = @TrainerId",
                    new SqlParameter[] { new SqlParameter("@TrainerId", trainerId) });

                if (dt.Rows.Count == 0)
                {
                    ClearTrainerInfo();
                    return;
                }

                DataRow row = dt.Rows[0];
                lblTrainerNameValue.Text = row["Name"].ToString();
                lblTrainerPhoneValue.Text = row["Phone"].ToString();
                lblTrainerSpecialtyValue.Text = row["Specialty"].ToString();
                lblTrainerExperienceValue.Text = row["Experience"].ToString() + " năm";
                lblTrainerLevelValue.Text = row["LevelName"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin PT: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Style

        private void ApplyModernStyle()
        {
            Font commonFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.Font = commonFont;
            this.BackColor = Color.White;

            foreach (Control ctl in Controls.OfType<Control>())
            {
                ApplyStyleRecursive(ctl);
            }
        }

        private void ApplyStyleRecursive(Control parent)
        {
            if (parent is TextBox)
            {
                TextBox txt = (TextBox)parent;
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 10F);
                txt.BackColor = Color.White;
            }
            else if (parent is ComboBox)
            {
                ComboBox cbo = (ComboBox)parent;
                cbo.FlatStyle = FlatStyle.Flat;
                cbo.Font = new Font("Segoe UI", 10F);
            }
            else if (parent is NumericUpDown)
            {
                NumericUpDown num = (NumericUpDown)parent;
                num.Font = new Font("Segoe UI", 10F);
            }
            else if (parent is Button)
            {
                Button btn = (Button)parent;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
                btn.Height = 40;
            }
            else if (parent is GroupBox)
            {
                parent.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            }

            foreach (Control child in parent.Controls)
            {
                ApplyStyleRecursive(child);
            }
        }

        private void FormatGrid()
        {
            dgvPackages.EnableHeadersVisualStyles = false;
            dgvPackages.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvPackages.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPackages.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvPackages.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPackages.ColumnHeadersHeight = 42;
            dgvPackages.RowTemplate.Height = 34;
            dgvPackages.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvPackages.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvPackages.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPackages.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvPackages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPackages.RowHeadersVisible = false;
            dgvPackages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPackages.MultiSelect = false;
            dgvPackages.AllowUserToAddRows = false;
            dgvPackages.AllowUserToDeleteRows = false;
            dgvPackages.ReadOnly = true;
            dgvPackages.BorderStyle = BorderStyle.None;
            dgvPackages.GridColor = Color.Gainsboro;

            if (dgvPackages.Columns.Contains("PackageId"))
                dgvPackages.Columns["PackageId"].Visible = false;

            if (dgvPackages.Columns.Contains("TrainerId"))
                dgvPackages.Columns["TrainerId"].Visible = false;

            if (dgvPackages.Columns.Contains("Giá"))
                dgvPackages.Columns["Giá"].DefaultCellStyle.Format = "N0";
        }

        #endregion

        #region Form state

        private void SetDefaultForm()
        {
            isBindingData = true;
            selectedPackageId = 0;
            txtPackageId.Text = string.Empty;
            txtPackageName.Clear();
            rdoNormal.Checked = true;
            numDurationValue.Value = 1;
            cboDurationType.SelectedItem = "Month";
            txtPrice.Text = string.Empty;
            txtDescription.Clear();
            cboStatus.SelectedItem = "Active";
            numPTSessions.Value = 1;
            cboTrainer.SelectedIndex = -1;
            isBindingData = false;

            ClearTrainerInfo();
            TogglePackageTypeUI();
        }

        private void ClearTrainerInfo()
        {
            lblTrainerNameValue.Text = "-";
            lblTrainerPhoneValue.Text = "-";
            lblTrainerSpecialtyValue.Text = "-";
            lblTrainerExperienceValue.Text = "-";
            lblTrainerLevelValue.Text = "-";
        }

        private void TogglePackageTypeUI()
        {
            bool isPT = rdoPT.Checked;
            pnlPTInfo.Visible = isPT;
            cboTrainer.Enabled = isPT;
            numPTSessions.Enabled = isPT;

            if (!isPT)
            {
                isBindingData = true;
                cboTrainer.SelectedIndex = -1;
                numPTSessions.Value = 1;
                isBindingData = false;
                ClearTrainerInfo();
            }
            else if (!isBindingData)
            {
                LoadTrainerInfoBySelectedTrainer();
            }
        }

        private void LoadCurrentRowToForm()
        {
            if (dgvPackages.CurrentRow == null)
            {
                SetDefaultForm();
                return;
            }

            isBindingData = true;
            DataGridViewRow row = dgvPackages.CurrentRow;

            selectedPackageId = Convert.ToInt32(row.Cells["PackageId"].Value);
            txtPackageId.Text = selectedPackageId.ToString();
            txtPackageName.Text = row.Cells["Tên gói"].Value.ToString();

            string type = row.Cells["Loại gói"].Value.ToString();
            rdoPT.Checked = type == "PT";
            rdoNormal.Checked = type != "PT";

            decimal durationValue;
            decimal.TryParse(row.Cells["Thời lượng"].Value.ToString(), out durationValue);
            if (durationValue <= 0) durationValue = 1;
            numDurationValue.Value = durationValue > numDurationValue.Maximum ? numDurationValue.Maximum : durationValue;

            cboDurationType.SelectedItem = row.Cells["Đơn vị"].Value.ToString();
            txtPrice.Text = Convert.ToDecimal(row.Cells["Giá"].Value).ToString("N0");
            txtDescription.Text = row.Cells["Mô tả"].Value.ToString();
            cboStatus.SelectedItem = row.Cells["Trạng thái"].Value.ToString();

            decimal ptSessions;
            decimal.TryParse(row.Cells["Số buổi PT"].Value.ToString(), out ptSessions);
            if (ptSessions <= 0) ptSessions = 1;
            numPTSessions.Value = ptSessions > numPTSessions.Maximum ? numPTSessions.Maximum : ptSessions;

            object trainerIdObj = row.Cells["TrainerId"].Value;
            if (trainerIdObj != DBNull.Value && trainerIdObj != null)
                cboTrainer.SelectedValue = Convert.ToInt32(trainerIdObj);
            else
                cboTrainer.SelectedIndex = -1;

            isBindingData = false;
            TogglePackageTypeUI();
            LoadTrainerInfoBySelectedTrainer();
        }

        #endregion

        #region Validation

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtPackageName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên gói tập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPackageName.Focus();
                return false;
            }

            decimal price = ParseMoney(txtPrice.Text);
            if (price <= 0)
            {
                MessageBox.Show("Giá tiền phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            if (numDurationValue.Value <= 0)
            {
                MessageBox.Show("Thời gian áp dụng phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDurationValue.Focus();
                return false;
            }

            if (cboDurationType.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị thời gian.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDurationType.Focus();
                return false;
            }

            if (rdoPT.Checked)
            {
                if (cboTrainer.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn huấn luyện viên cho gói PT.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboTrainer.Focus();
                    return false;
                }

                int trainerId;
                if (!int.TryParse(cboTrainer.SelectedValue.ToString(), out trainerId) || trainerId <= 0)
                {
                    MessageBox.Show("Huấn luyện viên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboTrainer.Focus();
                    return false;
                }

                if (numPTSessions.Value <= 0)
                {
                    MessageBox.Show("Số buổi PT phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numPTSessions.Focus();
                    return false;
                }
            }

            return true;
        }

        private decimal ParseMoney(string input)
        {
            decimal money;
            return decimal.TryParse((input ?? string.Empty).Trim().Replace(",", string.Empty), NumberStyles.Number, CultureInfo.InvariantCulture, out money)
                ? money
                : 0;
        }

        #endregion

        #region CRUD

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SetDefaultForm();
            txtPackageName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                string packageType = rdoPT.Checked ? "PT" : "NORMAL";
                object trainerId = rdoPT.Checked ? (object)Convert.ToInt32(cboTrainer.SelectedValue) : DBNull.Value;
                object ptSessions = rdoPT.Checked ? (object)Convert.ToInt32(numPTSessions.Value) : DBNull.Value;

                db.ExecuteNonQuery(@"
                    INSERT INTO Packages(Name, PackageType, DurationValue, DurationType, Price, Description, Status, TrainerId, PTSessionCount)
                    VALUES(@Name, @PackageType, @DurationValue, @DurationType, @Price, @Description, @Status, @TrainerId, @PTSessionCount)",
                    new SqlParameter[]
                    {
                        new SqlParameter("@Name", txtPackageName.Text.Trim()),
                        new SqlParameter("@PackageType", packageType),
                        new SqlParameter("@DurationValue", Convert.ToInt32(numDurationValue.Value)),
                        new SqlParameter("@DurationType", cboDurationType.Text),
                        new SqlParameter("@Price", ParseMoney(txtPrice.Text)),
                        new SqlParameter("@Description", string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text.Trim()),
                        new SqlParameter("@Status", cboStatus.Text),
                        new SqlParameter("@TrainerId", trainerId),
                        new SqlParameter("@PTSessionCount", ptSessions)
                    });

                MessageBox.Show("Thêm gói tập thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPackages();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm gói tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPackageId <= 0)
            {
                MessageBox.Show("Vui lòng chọn gói tập cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                string packageType = rdoPT.Checked ? "PT" : "NORMAL";
                object trainerId = rdoPT.Checked ? (object)Convert.ToInt32(cboTrainer.SelectedValue) : DBNull.Value;
                object ptSessions = rdoPT.Checked ? (object)Convert.ToInt32(numPTSessions.Value) : DBNull.Value;

                db.ExecuteNonQuery(@"
                    UPDATE Packages
                    SET Name = @Name,
                        PackageType = @PackageType,
                        DurationValue = @DurationValue,
                        DurationType = @DurationType,
                        Price = @Price,
                        Description = @Description,
                        Status = @Status,
                        TrainerId = @TrainerId,
                        PTSessionCount = @PTSessionCount
                    WHERE PackageId = @PackageId",
                    new SqlParameter[]
                    {
                        new SqlParameter("@PackageId", selectedPackageId),
                        new SqlParameter("@Name", txtPackageName.Text.Trim()),
                        new SqlParameter("@PackageType", packageType),
                        new SqlParameter("@DurationValue", Convert.ToInt32(numDurationValue.Value)),
                        new SqlParameter("@DurationType", cboDurationType.Text),
                        new SqlParameter("@Price", ParseMoney(txtPrice.Text)),
                        new SqlParameter("@Description", string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text.Trim()),
                        new SqlParameter("@Status", cboStatus.Text),
                        new SqlParameter("@TrainerId", trainerId),
                        new SqlParameter("@PTSessionCount", ptSessions)
                    });

                MessageBox.Show("Cập nhật gói tập thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPackages();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật gói tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPackageId <= 0)
            {
                MessageBox.Show("Vui lòng chọn gói tập cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa gói tập này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                object count = db.ExecuteScalar("SELECT COUNT(*) FROM Memberships WHERE PackageId = @PackageId",
                    new SqlParameter[] { new SqlParameter("@PackageId", selectedPackageId) });

                int usedCount = count == null || count == DBNull.Value ? 0 : Convert.ToInt32(count);
                if (usedCount > 0)
                {
                    MessageBox.Show("Gói tập đã phát sinh dữ liệu hội viên, không thể xóa. Hãy chuyển sang trạng thái Inactive.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.ExecuteNonQuery("DELETE FROM Packages WHERE PackageId = @PackageId",
                    new SqlParameter[] { new SqlParameter("@PackageId", selectedPackageId) });

                MessageBox.Show("Xóa gói tập thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPackages();
                SetDefaultForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa gói tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Events

        private void dgvPackages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                LoadCurrentRowToForm();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPackages();
        }

        private void cboFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated) return;
            LoadPackages();
        }

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated) return;
            LoadPackages();
        }

        private void rdoNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNormal.Checked)
                TogglePackageTypeUI();
        }

        private void rdoPT_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPT.Checked)
                TogglePackageTypeUI();
        }

        private void cboTrainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isBindingData) return;
            LoadTrainerInfoBySelectedTrainer();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTrainers();
            LoadPackages();
            SetDefaultForm();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
