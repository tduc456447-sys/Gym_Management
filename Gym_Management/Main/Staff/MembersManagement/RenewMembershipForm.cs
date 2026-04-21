using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Staff
{
    public partial class RenewMembershipForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int staffId;
        private readonly int customerId;
        private decimal currentPrice = 0;
        private string customerName = "";

        public RenewMembershipForm(int staffId, int customerId)
        {
            InitializeComponent();
            this.staffId = staffId;
            this.customerId = customerId;
        }

        private void RenewMembershipForm_Load(object sender, EventArgs e)
        {
            LoadCustomer();
            LoadPackages();
            LoadTrainers();
            cboPaymentMethod.SelectedIndex = 0;
            UpdatePrice();
        }

        private void LoadCustomer()
        {
            object name = db.ExecuteScalar("SELECT FullName FROM Customers WHERE CustomerId=@CustomerId",
                new SqlParameter[] { new SqlParameter("@CustomerId", customerId) });

            customerName = name == null ? "" : name.ToString();
            txtCustomer.Text = customerName;
        }

        private void LoadPackages()
        {
            DataTable dt = db.ExecuteQuery("SELECT PackageId, Name FROM Packages ORDER BY Name");
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

            int trainerId = 0;
            int.TryParse(cboTrainer.SelectedValue == null ? "0" : cboTrainer.SelectedValue.ToString(), out trainerId);

            object result = db.ExecuteScalar(@"
                SELECT 
                    p.Price * (1 + ISNULL(tl.PricePercentIncrease, 0) / 100.0)
                FROM Packages p
                LEFT JOIN Trainers t ON t.TrainerId = @TrainerId
                LEFT JOIN TrainerLevels tl ON t.LevelId = tl.LevelId
                WHERE p.PackageId = @PackageId", new SqlParameter[]
            {
                new SqlParameter("@PackageId", packageId),
                new SqlParameter("@TrainerId", trainerId == 0 ? (object)DBNull.Value : trainerId)
            });

            currentPrice = Convert.ToDecimal(result == null || result == DBNull.Value ? 0 : result);
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

        private void btnRenew_Click(object sender, EventArgs e)
        {
            try
            {
                int packageId = Convert.ToInt32(cboPackage.SelectedValue);
                int trainerId = Convert.ToInt32(cboTrainer.SelectedValue);
                DateTime startDate = dtpStartDate.Value.Date;

                db.ExecuteNonQuery("sp_RenewMembership", new SqlParameter[]
                {
                    new SqlParameter("@CustomerId", customerId),
                    new SqlParameter("@PackageId", packageId),
                    new SqlParameter("@TrainerId", trainerId == 0 ? (object)DBNull.Value : trainerId),
                    new SqlParameter("@StartDate", startDate),
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

                int newMembershipId = Convert.ToInt32(membershipId);

                if (cboPaymentMethod.Text == "Online")
                {
                    db.ExecuteNonQuery("sp_PayMembership", new SqlParameter[]
                    {
                        new SqlParameter("@MembershipId", newMembershipId),
                        new SqlParameter("@Amount", currentPrice),
                        new SqlParameter("@Method", "Online"),
                        new SqlParameter("@CashReceived", DBNull.Value),
                        new SqlParameter("@Note", "Gia hạn - thanh toán online"),
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
                        new SqlParameter("@MembershipId", newMembershipId),
                        new SqlParameter("@Amount", currentPrice),
                        new SqlParameter("@Method", "Cash"),
                        new SqlParameter("@CashReceived", cash),
                        new SqlParameter("@Note", "Gia hạn - thanh toán tiền mặt"),
                        new SqlParameter("@ReceivedByStaffId", staffId)
                    }, CommandType.StoredProcedure);
                }

                MessageBox.Show("Gia hạn hội viên thành công.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gia hạn: " + ex.Message);
            }
        }
    }
}