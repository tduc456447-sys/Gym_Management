using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Staff
{
    public partial class RegisterMembershipForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int staffId;
        private decimal currentPrice = 0;
        private int createdMembershipId = 0;
        private bool isSubmitting = false;
        private string savedAvatarRelativePath = string.Empty;
        private string selectedAvatarSourcePath = string.Empty;

        public RegisterMembershipForm(int staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
        }

        private void RegisterMembershipForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadPackages();
            LoadTrainers();

            cboPaymentMethod.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Today;
            txtAvatar.ReadOnly = true;
            txtTotal.ReadOnly = true;
            txtChange.ReadOnly = true;
            txtCardCode.ReadOnly = true;

            GenerateCardCode();
            UpdateCashState();
            UpdatePrice();
        }

        private void GenerateCardCode()
        {
            try
            {
                object result = db.ExecuteScalar(
                    "sp_GenerateNextCardCode",
                    null,
                    CommandType.StoredProcedure
                );

                txtCardCode.Text = result == null || result == DBNull.Value
                    ? "CARD0001"
                    : result.ToString();
            }
            catch
            {
                txtCardCode.Text = "CARD0001";
            }
        }

        private void LoadCustomers()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT CustomerId, FullName + N' - ' + ISNULL(Phone,'') AS DisplayText
                FROM Customers
                ORDER BY CustomerId DESC");

            cboCustomer.DataSource = dt;
            cboCustomer.DisplayMember = "DisplayText";
            cboCustomer.ValueMember = "CustomerId";
        }

        private void ReloadCustomers(int selectedCustomerId = 0)
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT CustomerId, FullName + N' - ' + ISNULL(Phone,'') AS DisplayText
                FROM Customers
                ORDER BY CustomerId DESC");

            cboCustomer.DataSource = null;
            cboCustomer.DataSource = dt;
            cboCustomer.DisplayMember = "DisplayText";
            cboCustomer.ValueMember = "CustomerId";

            if (selectedCustomerId > 0)
                cboCustomer.SelectedValue = selectedCustomerId;
        }

        private void LoadPackages()
        {
            DataTable dt = db.ExecuteQuery("SELECT PackageId, Name, Price FROM Packages ORDER BY Name");
            cboPackage.DataSource = dt;
            cboPackage.DisplayMember = "Name";
            cboPackage.ValueMember = "PackageId";
        }

        private void LoadTrainers()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT 0 AS TrainerId, N'Không chọn PT' AS Name
                UNION ALL
                SELECT TrainerId, Name FROM Trainers WHERE Status = 'Active'");

            cboTrainer.DataSource = dt;
            cboTrainer.DisplayMember = "Name";
            cboTrainer.ValueMember = "TrainerId";
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            using (AddCustomerForm f = new AddCustomerForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ReloadCustomers(f.NewCustomerId);
                }
            }
        }

        private void cboPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void cboTrainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCashState();
            CalcChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            CalcChange();
        }

        private void btnChooseAvatar_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Chọn ảnh hội viên";
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.webp";
                    ofd.Multiselect = false;

                    if (ofd.ShowDialog() != DialogResult.OK)
                        return;

                    selectedAvatarSourcePath = ofd.FileName;
                    savedAvatarRelativePath = string.Empty;
                    txtAvatar.Text = Path.GetFileName(ofd.FileName);
                    LoadAvatarPreview(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể chọn ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearAvatar_Click(object sender, EventArgs e)
        {
            selectedAvatarSourcePath = string.Empty;
            savedAvatarRelativePath = string.Empty;
            txtAvatar.Clear();

            if (pbAvatar.Image != null)
            {
                var oldImage = pbAvatar.Image;
                pbAvatar.Image = null;
                oldImage.Dispose();
            }
        }

        private void UpdateCashState()
        {
            bool isCash = cboPaymentMethod.Text == "Cash";
            txtCashReceived.Enabled = isCash;

            if (!isCash)
            {
                txtCashReceived.Text = string.Empty;
                txtChange.Text = "0";
            }
        }

        private void UpdatePrice()
        {
            if (cboPackage.SelectedValue == null)
                return;

            int packageId;
            if (!int.TryParse(cboPackage.SelectedValue.ToString(), out packageId))
                return;

            string sql = @"
                SELECT 
                    p.Price * (1 + ISNULL(tl.PricePercentIncrease, 0) / 100.0)
                FROM Packages p
                LEFT JOIN Trainers t ON t.TrainerId = @TrainerId
                LEFT JOIN TrainerLevels tl ON t.LevelId = tl.LevelId
                WHERE p.PackageId = @PackageId";

            int trainerId = 0;
            int.TryParse(cboTrainer.SelectedValue == null ? "0" : cboTrainer.SelectedValue.ToString(), out trainerId);

            object result = db.ExecuteScalar(sql, new SqlParameter[]
            {
                new SqlParameter("@PackageId", packageId),
                new SqlParameter("@TrainerId", trainerId == 0 ? (object)DBNull.Value : trainerId)
            });

            currentPrice = Convert.ToDecimal(result == DBNull.Value || result == null ? 0 : result);
            txtTotal.Text = currentPrice.ToString("N0", CultureInfo.InvariantCulture);
            CalcChange();
        }

        private void CalcChange()
        {
            if (cboPaymentMethod.Text != "Cash")
            {
                txtChange.Text = "0";
                return;
            }

            decimal cash = ParseMoney(txtCashReceived.Text);
            decimal change = cash - currentPrice;
            txtChange.Text = change < 0 ? "0" : change.ToString("N0", CultureInfo.InvariantCulture);
        }

        private decimal ParseMoney(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            input = input.Replace(",", string.Empty).Trim();
            decimal value;
            decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
            return value;
        }

        private void LoadAvatarPreview(string fullPath)
        {
            if (pbAvatar.Image != null)
            {
                var old = pbAvatar.Image;
                pbAvatar.Image = null;
                old.Dispose();
            }

            if (!File.Exists(fullPath))
                return;

            using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            using (var temp = Image.FromStream(fs))
            {
                pbAvatar.Image = new Bitmap(temp);
            }
        }

        private string SaveAvatarIfNeeded(int customerId)
        {
            if (string.IsNullOrWhiteSpace(selectedAvatarSourcePath) || !File.Exists(selectedAvatarSourcePath))
            {
                return string.Empty;
            }

            string membersFolder = Path.Combine(Application.StartupPath, "images", "members");
            if (!Directory.Exists(membersFolder))
            {
                Directory.CreateDirectory(membersFolder);
            }

            string ext = Path.GetExtension(selectedAvatarSourcePath);
            string fileName = string.Format(
                CultureInfo.InvariantCulture,
                "member_{0}_{1:yyyyMMdd_HHmmssfff}{2}",
                customerId,
                DateTime.Now,
                ext);
            string destinationPath = Path.Combine(membersFolder, fileName);
            File.Copy(selectedAvatarSourcePath, destinationPath, true);

            string relativePath = Path.Combine("images", "members", fileName);

            db.ExecuteNonQuery(@"
                UPDATE MemberProfiles
                SET Avatar = @Avatar
                WHERE CustomerId = @CustomerId",
                new SqlParameter[]
                {
                    new SqlParameter("@Avatar", relativePath),
                    new SqlParameter("@CustomerId", customerId)
                });

            savedAvatarRelativePath = relativePath;
            txtAvatar.Text = relativePath;
            LoadAvatarPreview(destinationPath);
            return relativePath;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (isSubmitting)
                return;

            if (cboCustomer.SelectedValue == null || cboPackage.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng và gói tập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal cash = 0;
            if (cboPaymentMethod.Text == "Cash")
            {
                cash = ParseMoney(txtCashReceived.Text);
                if (cash < currentPrice)
                {
                    MessageBox.Show("Tiền khách đưa chưa đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCashReceived.Focus();
                    return;
                }
            }

            try
            {
                isSubmitting = true;
                btnRegister.Enabled = false;

                int customerId = Convert.ToInt32(cboCustomer.SelectedValue);
                int packageId = Convert.ToInt32(cboPackage.SelectedValue);
                int trainerId = Convert.ToInt32(cboTrainer.SelectedValue);
                DateTime startDate = dtpStartDate.Value.Date;

                object membershipId = db.ExecuteScalar("sp_RegisterMembership", new SqlParameter[]
                {
                    new SqlParameter("@CustomerId", customerId),
                    new SqlParameter("@PackageId", packageId),
                    new SqlParameter("@TrainerId", trainerId == 0 ? (object)DBNull.Value : trainerId),
                    new SqlParameter("@StartDate", startDate),
                    new SqlParameter("@Avatar", DBNull.Value),
                    new SqlParameter("@IdentityNumber", string.IsNullOrWhiteSpace(txtIdentity.Text) ? (object)DBNull.Value : txtIdentity.Text.Trim()),
                    new SqlParameter("@CardCode", DBNull.Value),
                    new SqlParameter("@CreatedByStaffId", staffId)
                }, CommandType.StoredProcedure);

                if (membershipId == null || membershipId == DBNull.Value)
                {
                    MessageBox.Show(
                        "Không lấy được mã đăng ký từ database.\nHãy cập nhật đúng bản stored procedure sp_RegisterMembership.",
                        "Lỗi cấu hình DB",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                createdMembershipId = Convert.ToInt32(membershipId);

                if (createdMembershipId <= 0)
                {
                    MessageBox.Show(
                        "Mã đăng ký không hợp lệ.\nHãy kiểm tra lại stored procedure sp_RegisterMembership.",
                        "Lỗi cấu hình DB",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                SaveAvatarIfNeeded(customerId);

                if (cboPaymentMethod.Text == "Online")
                {
                    db.ExecuteNonQuery("sp_PayMembership", new SqlParameter[]
                    {
                        new SqlParameter("@MembershipId", createdMembershipId),
                        new SqlParameter("@Amount", currentPrice),
                        new SqlParameter("@Method", "Online"),
                        new SqlParameter("@CashReceived", DBNull.Value),
                        new SqlParameter("@Note", "Thanh toán online"),
                        new SqlParameter("@ReceivedByStaffId", staffId)
                    }, CommandType.StoredProcedure);
                }
                else
                {
                    db.ExecuteNonQuery("sp_PayMembership", new SqlParameter[]
                    {
                        new SqlParameter("@MembershipId", createdMembershipId),
                        new SqlParameter("@Amount", currentPrice),
                        new SqlParameter("@Method", "Cash"),
                        new SqlParameter("@CashReceived", cash),
                        new SqlParameter("@Note", "Thanh toán tiền mặt"),
                        new SqlParameter("@ReceivedByStaffId", staffId)
                    }, CommandType.StoredProcedure);
                }

                MessageBox.Show("Đăng ký hội viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isSubmitting = false;
                btnRegister.Enabled = true;
            }
        }

        private void txtIdentity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}