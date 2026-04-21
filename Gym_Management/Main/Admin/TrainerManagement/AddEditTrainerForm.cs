using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Gym_Management.Main.Admin
{
    public partial class AddEditTrainerForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int trainerId;
        private readonly bool isEditMode;

        public AddEditTrainerForm()
        {
            InitializeComponent();
            trainerId = 0;
            isEditMode = false;
        }

        public AddEditTrainerForm(int trainerId)
        {
            InitializeComponent();
            this.trainerId = trainerId;
            isEditMode = true;
        }

        private void AddEditTrainerForm_Load(object sender, EventArgs e)
        {
            LoadTrainerLevels();
            LoadStatus();

            if (isEditMode)
            {
                this.Text = "Cập nhật huấn luyện viên";
                LoadTrainerData();
            }
            else
            {
                this.Text = "Thêm huấn luyện viên";
                txtExperience.Text = "0";
                txtSalaryPercent.Text = "0";
                cboStatus.SelectedItem = "Active";
            }
        }

        private void LoadTrainerLevels()
        {
            try
            {
                DataTable dt = db.ExecuteQuery("sp_GetTrainerLevels", null, CommandType.StoredProcedure);

                DataRow row = dt.NewRow();
                row["LevelId"] = DBNull.Value;
                row["Name"] = "-- Chọn cấp độ --";
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

        private void LoadStatus()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Active");
            cboStatus.Items.Add("Inactive");
        }

        private void LoadTrainerData()
        {
            try
            {
                DataTable dt = db.ExecuteQuery("sp_GetTrainerById",
                    new SqlParameter[]
                    {
                        new SqlParameter("@TrainerId", trainerId)
                    },
                    CommandType.StoredProcedure);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy huấn luyện viên.");
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                DataRow row = dt.Rows[0];

                txtName.Text = row["Name"].ToString();
                txtPhone.Text = row["Phone"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtSpecialty.Text = row["Specialty"].ToString();
                txtExperience.Text = row["Experience"].ToString();
                txtSalaryPercent.Text = row["SalaryPercent"].ToString();
                txtAvatar.Text = row["Avatar"].ToString();
                cboStatus.SelectedItem = row["Status"].ToString();

                if (row["LevelId"] != DBNull.Value)
                    cboLevel.SelectedValue = row["LevelId"];
                else
                    cboLevel.SelectedIndex = 0;

                LoadAvatarPreview(txtAvatar.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu PT: " + ex.Message);
            }
        }

        private void LoadAvatarPreview(string imageFileName)
        {
            picAvatarPreview.Image = null;

            try
            {
                string fileName = (imageFileName ?? "").Trim().TrimStart('/', '\\');
                if (string.IsNullOrWhiteSpace(fileName))
                    return;

                string imageFolder = Path.Combine(Application.StartupPath, "images");
                string imagePath = Path.Combine(imageFolder, fileName);

                if (File.Exists(imagePath))
                    picAvatarPreview.Image = Image.FromFile(imagePath);
            }
            catch
            {
                picAvatarPreview.Image = null;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên huấn luyện viên.");
                txtName.Focus();
                return false;
            }

            int exp;
            if (!int.TryParse(txtExperience.Text.Trim(), out exp) || exp < 0)
            {
                MessageBox.Show("Kinh nghiệm không hợp lệ.");
                txtExperience.Focus();
                return false;
            }

            int salaryPercent;
            if (!int.TryParse(txtSalaryPercent.Text.Trim(), out salaryPercent) || salaryPercent < 0 || salaryPercent > 100)
            {
                MessageBox.Show("Phần trăm lương phải từ 0 đến 100.");
                txtSalaryPercent.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboStatus.Text))
            {
                MessageBox.Show("Vui lòng chọn trạng thái.");
                cboStatus.Focus();
                return false;
            }

            return true;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.webp|All files|*.*";
                dlg.Multiselect = false;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(dlg.FileName);
                    txtAvatar.Text = fileName;
                    LoadAvatarPreview(fileName);
                }
            }
        }

        private void txtAvatar_TextChanged(object sender, EventArgs e)
        {
            LoadAvatarPreview(txtAvatar.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", txtName.Text.Trim()),
                    new SqlParameter("@Phone", string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text.Trim()),
                    new SqlParameter("@Email", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim()),
                    new SqlParameter("@Experience", int.Parse(txtExperience.Text.Trim())),
                    new SqlParameter("@SalaryPercent", int.Parse(txtSalaryPercent.Text.Trim())),
                    new SqlParameter("@Status", cboStatus.Text),
                    new SqlParameter("@Avatar", string.IsNullOrWhiteSpace(txtAvatar.Text) ? (object)DBNull.Value : txtAvatar.Text.Trim()),
                    new SqlParameter("@Specialty", string.IsNullOrWhiteSpace(txtSpecialty.Text) ? (object)DBNull.Value : txtSpecialty.Text.Trim()),
                    new SqlParameter("@LevelId", cboLevel.SelectedValue == null || cboLevel.SelectedValue == DBNull.Value ? (object)DBNull.Value : cboLevel.SelectedValue)
                };

                if (isEditMode)
                {
                    SqlParameter[] fullParams = new SqlParameter[parameters.Length + 1];
                    fullParams[0] = new SqlParameter("@TrainerId", trainerId);
                    Array.Copy(parameters, 0, fullParams, 1, parameters.Length);

                    db.ExecuteQuery("sp_UpdateTrainer", fullParams, CommandType.StoredProcedure);
                    MessageBox.Show("Cập nhật huấn luyện viên thành công.");
                }
                else
                {
                    db.ExecuteQuery("sp_AddTrainer", parameters, CommandType.StoredProcedure);
                    MessageBox.Show("Thêm huấn luyện viên thành công.");
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu huấn luyện viên: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}