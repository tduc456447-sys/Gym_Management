using System;
using System.Data;
using System.Data.SqlClient;
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
            UpdatePrice();
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

        private void UpdatePrice()
        {
            if (cboPackage.SelectedValue == null) return;

            int packageId;
            if (!int.TryParse(cboPackage.SelectedValue.ToString(), out packageId)) return;

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
            txtTotal.Text = currentPrice.ToString("N0");
            CalcChange();
        }

        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCashReceived.Enabled = cboPaymentMethod.Text == "Cash";
            CalcChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            CalcChange();
        }

        private void CalcChange()
        {
            if (cboPaymentMethod.Text != "Cash")
            {
                txtChange.Text = "0";
                return;
            }

            decimal cash = 0;
            decimal.TryParse(txtCashReceived.Text.Trim(), out cash);
            decimal change = cash - currentPrice;
            txtChange.Text = change < 0 ? "0" : change.ToString("N0");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedValue == null || cboPackage.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng và gói tập.");
                return;
            }

            try
            {
                int customerId = Convert.ToInt32(cboCustomer.SelectedValue);
                int packageId = Convert.ToInt32(cboPackage.SelectedValue);
                int trainerId = Convert.ToInt32(cboTrainer.SelectedValue);
                DateTime startDate = dtpStartDate.Value.Date;

                db.ExecuteNonQuery("sp_RegisterMembership", new SqlParameter[]
                {
                    new SqlParameter("@CustomerId", customerId),
                    new SqlParameter("@PackageId", packageId),
                    new SqlParameter("@TrainerId", trainerId == 0 ? (object)DBNull.Value : trainerId),
                    new SqlParameter("@StartDate", startDate),
                    new SqlParameter("@Avatar", string.IsNullOrWhiteSpace(txtAvatar.Text) ? (object)DBNull.Value : txtAvatar.Text.Trim()),
                    new SqlParameter("@IdentityNumber", string.IsNullOrWhiteSpace(txtIdentity.Text) ? (object)DBNull.Value : txtIdentity.Text.Trim()),
                    new SqlParameter("@CardCode", string.IsNullOrWhiteSpace(txtCardCode.Text) ? (object)DBNull.Value : txtCardCode.Text.Trim()),
                    new SqlParameter("@CreatedByStaffId", staffId)
                }, CommandType.StoredProcedure);

                object membershipId = db.ExecuteScalar(@"
                    SELECT TOP 1 MembershipId
                    FROM Memberships
                    WHERE CustomerId = @CustomerId
                    ORDER BY MembershipId DESC", new SqlParameter[]
                {
                    new SqlParameter("@CustomerId", customerId)
                });

                createdMembershipId = Convert.ToInt32(membershipId);

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
                    decimal cash = 0;
                    decimal.TryParse(txtCashReceived.Text.Trim(), out cash);

                    if (cash < currentPrice)
                    {
                        MessageBox.Show("Tiền khách đưa chưa đủ.");
                        return;
                    }

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

                MessageBox.Show("Đăng ký hội viên thành công.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký: " + ex.Message);
            }
        }
    }
}