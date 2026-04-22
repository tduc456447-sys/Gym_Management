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
        private bool isSubmitting = false;

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
            txtChange.Text = "0";
            UpdatePrice();
        }

        private void LoadCustomer()
        {
            object name = db.ExecuteScalar(
                "SELECT FullName FROM Customers WHERE CustomerId = @CustomerId",
                new SqlParameter[] { new SqlParameter("@CustomerId", customerId) });

            txtCustomer.Text = name == null || name == DBNull.Value ? string.Empty : name.ToString();
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
                SELECT TrainerId, Name
                FROM Trainers
                WHERE Status = 'Active'");

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

        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCashReceived.Enabled = cboPaymentMethod.Text == "Cash";
            if (!txtCashReceived.Enabled)
            {
                txtCashReceived.Text = string.Empty;
            }
            CalcChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            CalcChange();
        }

        private void UpdatePrice()
        {
            if (cboPackage.SelectedValue == null)
            {
                currentPrice = 0;
                txtTotal.Text = "0";
                CalcChange();
                return;
            }

            int packageId;
            if (!int.TryParse(cboPackage.SelectedValue.ToString(), out packageId))
            {
                currentPrice = 0;
                txtTotal.Text = "0";
                CalcChange();
                return;
            }

            int trainerId = GetSelectedTrainerId();
            object result = db.ExecuteScalar(@"
                SELECT p.Price * (1 + ISNULL(tl.PricePercentIncrease, 0) / 100.0)
                FROM Packages p
                LEFT JOIN Trainers t ON t.TrainerId = @TrainerId
                LEFT JOIN TrainerLevels tl ON t.LevelId = tl.LevelId
                WHERE p.PackageId = @PackageId",
                new SqlParameter[]
                {
                    new SqlParameter("@PackageId", packageId),
                    new SqlParameter("@TrainerId", trainerId == 0 ? (object)DBNull.Value : trainerId)
                });

            currentPrice = SafeToDecimal(result);
            txtTotal.Text = currentPrice.ToString("N0");
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
            txtChange.Text = change < 0 ? "0" : change.ToString("N0");
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (isSubmitting)
            {
                return;
            }

            if (cboPackage.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn gói tập.");
                return;
            }

            if (currentPrice <= 0)
            {
                MessageBox.Show("Không xác định được giá gói tập.");
                return;
            }

            try
            {
                isSubmitting = true;
                btnRenew.Enabled = false;

                int packageId = Convert.ToInt32(cboPackage.SelectedValue);
                int trainerId = GetSelectedTrainerId();
                DateTime startDate = dtpStartDate.Value.Date;

                int membershipId = CreateRenewMembership(packageId, trainerId, startDate);
                if (membershipId <= 0)
                {
                    MessageBox.Show("Không lấy được mã gia hạn vừa tạo.");
                    return;
                }

                if (!PayMembership(membershipId))
                {
                    return;
                }

                MessageBox.Show("Gia hạn hội viên thành công.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gia hạn: " + ex.Message);
            }
            finally
            {
                isSubmitting = false;
                btnRenew.Enabled = true;
            }
        }

        private int CreateRenewMembership(int packageId, int trainerId, DateTime startDate)
        {
            object result = db.ExecuteScalar("sp_RenewMembership", new SqlParameter[]
            {
                new SqlParameter("@CustomerId", customerId),
                new SqlParameter("@PackageId", packageId),
                new SqlParameter("@TrainerId", trainerId == 0 ? (object)DBNull.Value : trainerId),
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@CreatedByStaffId", staffId)
            }, CommandType.StoredProcedure);

            int membershipId;
            if (TryConvertToInt(result, out membershipId) && membershipId > 0)
            {
                return membershipId;
            }

            return FindLatestCreatedMembershipId(packageId, trainerId, startDate);
        }

        private bool PayMembership(int membershipId)
        {
            string paymentMethod = cboPaymentMethod.Text;
            if (paymentMethod != "Cash" && paymentMethod != "Online")
            {
                MessageBox.Show("Phương thức thanh toán không hợp lệ.");
                return false;
            }

            if (paymentMethod == "Cash")
            {
                decimal cash = ParseMoney(txtCashReceived.Text);
                if (cash < currentPrice)
                {
                    MessageBox.Show("Tiền khách đưa chưa đủ.");
                    return false;
                }

                db.ExecuteNonQuery("sp_PayMembership", new SqlParameter[]
                {
                    new SqlParameter("@MembershipId", membershipId),
                    new SqlParameter("@Amount", currentPrice),
                    new SqlParameter("@Method", "Cash"),
                    new SqlParameter("@CashReceived", cash),
                    new SqlParameter("@Note", "Gia hạn - thanh toán tiền mặt"),
                    new SqlParameter("@ReceivedByStaffId", staffId)
                }, CommandType.StoredProcedure);

                return true;
            }

            db.ExecuteNonQuery("sp_PayMembership", new SqlParameter[]
            {
                new SqlParameter("@MembershipId", membershipId),
                new SqlParameter("@Amount", currentPrice),
                new SqlParameter("@Method", "Online"),
                new SqlParameter("@CashReceived", DBNull.Value),
                new SqlParameter("@Note", "Gia hạn - thanh toán online"),
                new SqlParameter("@ReceivedByStaffId", staffId)
            }, CommandType.StoredProcedure);

            return true;
        }

        private int FindLatestCreatedMembershipId(int packageId, int trainerId, DateTime startDate)
        {
            object result = db.ExecuteScalar(@"
                SELECT TOP 1 MembershipId
                FROM Memberships
                WHERE CustomerId = @CustomerId
                  AND PackageId = @PackageId
                  AND StartDate = @StartDate
                  AND ISNULL(TrainerId, 0) = @TrainerId
                  AND ISNULL(CreatedByStaffId, 0) = @CreatedByStaffId
                ORDER BY MembershipId DESC",
                new SqlParameter[]
                {
                    new SqlParameter("@CustomerId", customerId),
                    new SqlParameter("@PackageId", packageId),
                    new SqlParameter("@StartDate", startDate),
                    new SqlParameter("@TrainerId", trainerId),
                    new SqlParameter("@CreatedByStaffId", staffId)
                });

            int membershipId;
            return TryConvertToInt(result, out membershipId) ? membershipId : 0;
        }

        private int GetSelectedTrainerId()
        {
            int trainerId;
            return int.TryParse(cboTrainer.SelectedValue == null ? "0" : cboTrainer.SelectedValue.ToString(), out trainerId)
                ? trainerId
                : 0;
        }

        private static decimal ParseMoney(string value)
        {
            decimal money;
            return decimal.TryParse((value ?? string.Empty).Trim().Replace(",", string.Empty), out money) ? money : 0;
        }

        private static decimal SafeToDecimal(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return 0;
            }

            decimal result;
            return decimal.TryParse(value.ToString(), out result) ? result : 0;
        }

        private static bool TryConvertToInt(object value, out int result)
        {
            result = 0;
            if (value == null || value == DBNull.Value)
            {
                return false;
            }

            return int.TryParse(value.ToString(), out result);
        }
    }
}
