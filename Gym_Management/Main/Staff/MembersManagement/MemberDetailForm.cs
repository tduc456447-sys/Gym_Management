using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Staff
{
    public partial class MemberDetailForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int customerId;

        public MemberDetailForm(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
        }

        private void MemberDetailForm_Load(object sender, EventArgs e)
        {
            LoadInfo();
            LoadMembershipHistory();
            LoadPaymentHistory();
            StyleGrid(dgvMembershipHistory);
            StyleGrid(dgvPaymentHistory);
        }

        private void LoadInfo()
        {
            string sql = @"
                SELECT 
                    c.CustomerId,
                    c.FullName,
                    c.Phone,
                    c.Address,
                    mp.Avatar,
                    mp.IdentityNumber,
                    mp.CardCode,
                    mp.Status
                FROM Customers c
                LEFT JOIN MemberProfiles mp ON c.CustomerId = mp.CustomerId
                WHERE c.CustomerId = @CustomerId";

            var dt = db.ExecuteQuery(sql, new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@CustomerId", customerId)
            });

            if (dt.Rows.Count == 0) return;

            DataRow r = dt.Rows[0];
            lblName.Text = "Họ tên: " + r["FullName"].ToString();
            lblPhone.Text = "SĐT: " + r["Phone"].ToString();
            lblAddress.Text = "Địa chỉ: " + r["Address"].ToString();
            lblCard.Text = "Mã thẻ: " + r["CardCode"].ToString();
            lblIdentity.Text = "CCCD: " + r["IdentityNumber"].ToString();
            lblStatus.Text = "Trạng thái hồ sơ: " + r["Status"].ToString();

            string avatar = r["Avatar"] == DBNull.Value ? "" : r["Avatar"].ToString();
            try
            {
                if (!string.IsNullOrWhiteSpace(avatar) && File.Exists(avatar))
                    picAvatar.Image = Image.FromFile(avatar);
                else
                    picAvatar.Image = null;
            }
            catch
            {
                picAvatar.Image = null;
            }
        }

        private void LoadMembershipHistory()
        {
            string sql = @"
                SELECT
                    m.MembershipId AS [Mã gói],
                    p.Name AS [Tên gói],
                    ISNULL(t.Name, N'Không có PT') AS [PT],
                    m.StartDate AS [Bắt đầu],
                    m.EndDate AS [Kết thúc],
                    m.Price AS [Giá],
                    m.Status AS [Trạng thái]
                FROM Memberships m
                JOIN Packages p ON m.PackageId = p.PackageId
                LEFT JOIN Trainers t ON m.TrainerId = t.TrainerId
                WHERE m.CustomerId = @CustomerId
                ORDER BY m.MembershipId DESC";

            dgvMembershipHistory.DataSource = db.ExecuteQuery(sql, new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@CustomerId", customerId)
            });
        }

        private void LoadPaymentHistory()
        {
            string sql = @"
                SELECT
                    mp.MembershipPaymentId AS [Mã thanh toán],
                    m.MembershipId AS [Mã gói],
                    p.Name AS [Tên gói],
                    mp.Amount AS [Số tiền],
                    mp.Method AS [Phương thức],
                    mp.CashReceived AS [Khách đưa],
                    mp.ChangeAmount AS [Tiền thừa],
                    mp.PaymentDate AS [Ngày thanh toán],
                    mp.Note AS [Ghi chú]
                FROM MembershipPayments mp
                JOIN Memberships m ON mp.MembershipId = m.MembershipId
                JOIN Packages p ON m.PackageId = p.PackageId
                WHERE m.CustomerId = @CustomerId
                ORDER BY mp.MembershipPaymentId DESC";

            dgvPaymentHistory.DataSource = db.ExecuteQuery(sql, new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@CustomerId", customerId)
            });
        }

        private void StyleGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}