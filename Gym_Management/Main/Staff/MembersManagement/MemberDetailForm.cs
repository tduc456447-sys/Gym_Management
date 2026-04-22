using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
            SetupUi();
            LoadOverview();
            LoadMembershipHistory();
            LoadPaymentHistory();
            LoadCheckinHistory();
            LoadPurchaseHistory();
        }

        private void SetupUi()
        {
            BackColor = Color.FromArgb(245, 247, 250);

            pnlHeader.BackColor = Color.White;
            pnlSummary.BackColor = Color.White;
            pnlProfile.BackColor = Color.White;

            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblSubTitle.ForeColor = Color.DimGray;

            StyleStatPanel(pnlStatMembership, lblStatMembershipTitle, lblStatMembershipValue);
            StyleStatPanel(pnlStatCheckin, lblStatCheckinTitle, lblStatCheckinValue);
            StyleStatPanel(pnlStatSpent, lblStatSpentTitle, lblStatSpentValue);
            StyleStatPanel(pnlStatSales, lblStatSalesTitle, lblStatSalesValue);

            picAvatar.BackColor = Color.WhiteSmoke;

            StyleGrid(dgvMembershipHistory);
            StyleGrid(dgvPaymentHistory);
            StyleGrid(dgvCheckinHistory);
            StyleGrid(dgvPurchaseHistory);
        }

        private void StyleStatPanel(Panel panel, Label title, Label value)
        {
            panel.BackColor = Color.FromArgb(248, 249, 250);
            panel.BorderStyle = BorderStyle.FixedSingle;
            title.ForeColor = Color.DimGray;
            value.ForeColor = Color.FromArgb(0, 102, 204);
        }

        private void StyleGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.Gainsboro;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 40, 49);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 36;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.Height = 32;
        }

        private void LoadOverview()
        {
            string sql = @"
SELECT TOP 1
    c.CustomerId,
    c.FullName,
    c.Phone,
    c.Address,
    c.CreatedAt,
    mp.Avatar,
    mp.IdentityNumber,
    mp.CardCode,
    mp.Status AS ProfileStatus,
    cur.MembershipId,
    cur.PackageName,
    cur.TrainerName,
    cur.StartDate,
    cur.EndDate,
    cur.MembershipStatus,
    cur.Price,
    ISNULL(stats.TotalMembershipCount, 0) AS TotalMembershipCount,
    ISNULL(stats.TotalCheckinCount, 0) AS TotalCheckinCount,
    ISNULL(stats.TotalMembershipSpent, 0) AS TotalMembershipSpent,
    ISNULL(stats.TotalSalesSpent, 0) AS TotalSalesSpent
FROM Customers c
LEFT JOIN MemberProfiles mp ON c.CustomerId = mp.CustomerId
OUTER APPLY
(
    SELECT TOP 1
        m.MembershipId,
        p.Name AS PackageName,
        ISNULL(t.Name, N'Không có PT') AS TrainerName,
        m.StartDate,
        m.EndDate,
        m.Status AS MembershipStatus,
        m.Price
    FROM Memberships m
    JOIN Packages p ON m.PackageId = p.PackageId
    LEFT JOIN Trainers t ON m.TrainerId = t.TrainerId
    WHERE m.CustomerId = c.CustomerId
    ORDER BY
        CASE WHEN m.Status = 'Active' THEN 0 WHEN m.Status = 'Pending' THEN 1 ELSE 2 END,
        m.MembershipId DESC
) cur
OUTER APPLY
(
    SELECT
        (SELECT COUNT(*) FROM Memberships m WHERE m.CustomerId = c.CustomerId) AS TotalMembershipCount,
        (SELECT COUNT(*) FROM Checkins ck WHERE ck.CustomerId = c.CustomerId) AS TotalCheckinCount,
        (SELECT ISNULL(SUM(mp2.Amount), 0)
         FROM MembershipPayments mp2
         JOIN Memberships m2 ON mp2.MembershipId = m2.MembershipId
         WHERE m2.CustomerId = c.CustomerId) AS TotalMembershipSpent,
        (SELECT ISNULL(SUM(sp.Amount), 0)
         FROM SalesPayments sp
         JOIN SalesInvoices si ON sp.SalesInvoiceId = si.SalesInvoiceId
         WHERE si.CustomerId = c.CustomerId) AS TotalSalesSpent
) stats
WHERE c.CustomerId = @CustomerId";

            DataTable dt = db.ExecuteQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@CustomerId", SqlDbType.Int) { Value = customerId }
            });

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            DataRow r = dt.Rows[0];

            lblTitle.Text = "Hồ sơ khách hàng";
            lblSubTitle.Text = "Mã khách hàng: " + r["CustomerId"];

            lblName.Text = r["FullName"].ToString();
            lblPhone.Text = "SĐT: " + SafeText(r["Phone"]);
            lblAddress.Text = "Địa chỉ: " + SafeText(r["Address"]);
            lblIdentity.Text = "CCCD: " + SafeText(r["IdentityNumber"]);
            lblCardCode.Text = "Mã thẻ: " + SafeText(r["CardCode"]);
            lblProfileStatus.Text = "Trạng thái hồ sơ: " + SafeText(r["ProfileStatus"]);
            lblCreatedAt.Text = "Ngày tạo KH: " + SafeDateTime(r["CreatedAt"]);

            string membershipStatus = SafeText(r["MembershipStatus"]);
            string packageName = SafeText(r["PackageName"]);
            string trainerName = SafeText(r["TrainerName"]);
            string startDate = SafeDate(r["StartDate"]);
            string endDate = SafeDate(r["EndDate"]);

            if (string.IsNullOrWhiteSpace(packageName))
            {
                lblCurrentPackage.Text = "Gói hiện tại: Chưa đăng ký";
                lblTrainer.Text = "PT hiện tại: Chưa có";
                lblMembershipPeriod.Text = "Thời hạn: -";
            }
            else
            {
                lblCurrentPackage.Text = "Gói hiện tại: " + packageName + " (" + membershipStatus + ")";
                lblTrainer.Text = "PT hiện tại: " + trainerName;
                lblMembershipPeriod.Text = "Thời hạn: " + startDate + " - " + endDate;
            }

            lblStatMembershipValue.Text = dt.Rows[0]["TotalMembershipCount"].ToString();
            lblStatCheckinValue.Text = dt.Rows[0]["TotalCheckinCount"].ToString();
            lblStatSpentValue.Text = FormatCurrency(r["TotalMembershipSpent"]);
            lblStatSalesValue.Text = FormatCurrency(r["TotalSalesSpent"]);

            if (!string.IsNullOrWhiteSpace(endDate) && DateTime.TryParse(r["EndDate"].ToString(), out DateTime parsedEnd))
            {
                int daysLeft = (parsedEnd.Date - DateTime.Today).Days;
                if (membershipStatus == "Active")
                {
                    lblDaysLeft.Text = daysLeft >= 0
                        ? "Còn lại: " + daysLeft + " ngày"
                        : "Đã hết hạn";
                }
                else
                {
                    lblDaysLeft.Text = "Trạng thái gói: " + membershipStatus;
                }
            }
            else
            {
                lblDaysLeft.Text = "Còn lại: -";
            }

            LoadAvatar(SafeText(r["Avatar"]));
        }

        private void LoadAvatar(string avatarPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(avatarPath))
                {
                    picAvatar.Image = null;
                    return;
                }

                string normalizedPath = avatarPath.Replace("/", "\\").TrimStart('\\');
                string fullPath;

                if (Path.IsPathRooted(normalizedPath))
                {
                    fullPath = normalizedPath;
                }
                else
                {
                    fullPath = Path.Combine(Application.StartupPath, "images", normalizedPath);
                    if (!File.Exists(fullPath))
                        fullPath = Path.Combine(Application.StartupPath, normalizedPath);
                }

                if (!File.Exists(fullPath))
                {
                    picAvatar.Image = null;
                    return;
                }

                if (picAvatar.Image != null)
                {
                    Image old = picAvatar.Image;
                    picAvatar.Image = null;
                    old.Dispose();
                }

                using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                using (Image img = Image.FromStream(fs))
                {
                    picAvatar.Image = new Bitmap(img);
                }
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
    m.Status AS [Trạng thái],
    u.FullName AS [Nhân viên tạo]
FROM Memberships m
JOIN Packages p ON m.PackageId = p.PackageId
LEFT JOIN Trainers t ON m.TrainerId = t.TrainerId
LEFT JOIN Users u ON m.CreatedByStaffId = u.UserId
WHERE m.CustomerId = @CustomerId
ORDER BY m.MembershipId DESC";

            dgvMembershipHistory.DataSource = db.ExecuteQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@CustomerId", SqlDbType.Int) { Value = customerId }
            });

            FormatHistoryGrid(dgvMembershipHistory, true);
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
    ISNULL(u.FullName, N'') AS [Người thu],
    mp.Note AS [Ghi chú]
FROM MembershipPayments mp
JOIN Memberships m ON mp.MembershipId = m.MembershipId
JOIN Packages p ON m.PackageId = p.PackageId
LEFT JOIN Users u ON mp.ReceivedByStaffId = u.UserId
WHERE m.CustomerId = @CustomerId
ORDER BY mp.MembershipPaymentId DESC";

            dgvPaymentHistory.DataSource = db.ExecuteQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@CustomerId", SqlDbType.Int) { Value = customerId }
            });

            FormatHistoryGrid(dgvPaymentHistory, true);
        }

        private void LoadCheckinHistory()
        {
            string sql = @"
SELECT
    ck.CheckinId AS [Mã check-in],
    ck.MembershipId AS [Mã gói],
    p.Name AS [Tên gói],
    ck.CheckinTime AS [Thời gian],
    m.EndDate AS [Hạn gói lúc check-in]
FROM Checkins ck
JOIN Memberships m ON ck.MembershipId = m.MembershipId
JOIN Packages p ON m.PackageId = p.PackageId
WHERE ck.CustomerId = @CustomerId
ORDER BY ck.CheckinId DESC";

            dgvCheckinHistory.DataSource = db.ExecuteQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@CustomerId", SqlDbType.Int) { Value = customerId }
            });

            FormatHistoryGrid(dgvCheckinHistory, false);
        }

        private void LoadPurchaseHistory()
        {
            string sql = @"
SELECT
    si.SalesInvoiceId AS [Mã hóa đơn],
    si.InvoiceDate AS [Ngày hóa đơn],
    SUM(sid.Quantity) AS [SL sản phẩm],
    si.Total AS [Tổng tiền hóa đơn],
    ISNULL(pay.TotalPaid, 0) AS [Đã thanh toán],
    si.Note AS [Ghi chú],
    ISNULL(u.FullName, N'') AS [Nhân viên bán]
FROM SalesInvoices si
LEFT JOIN SalesInvoiceDetails sid ON si.SalesInvoiceId = sid.SalesInvoiceId
LEFT JOIN
(
    SELECT SalesInvoiceId, SUM(Amount) AS TotalPaid
    FROM SalesPayments
    GROUP BY SalesInvoiceId
) pay ON si.SalesInvoiceId = pay.SalesInvoiceId
LEFT JOIN Users u ON si.CreatedByStaffId = u.UserId
WHERE si.CustomerId = @CustomerId
GROUP BY si.SalesInvoiceId, si.InvoiceDate, si.Total, pay.TotalPaid, si.Note, u.FullName
ORDER BY si.SalesInvoiceId DESC";

            dgvPurchaseHistory.DataSource = db.ExecuteQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@CustomerId", SqlDbType.Int) { Value = customerId }
            });

            FormatHistoryGrid(dgvPurchaseHistory, false);
        }

        private void FormatHistoryGrid(DataGridView dgv, bool formatCurrencyColumns)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Name.Contains("Ngày") || col.Name.Contains("Bắt đầu") || col.Name.Contains("Kết thúc") || col.Name.Contains("Thời gian"))
                {
                    col.DefaultCellStyle.Format = col.Name == "Thời gian" || col.Name == "Ngày hóa đơn" || col.Name == "Ngày thanh toán"
                        ? "dd/MM/yyyy HH:mm"
                        : "dd/MM/yyyy";
                }

                if (formatCurrencyColumns && (col.Name == "Giá" || col.Name == "Số tiền" || col.Name == "Khách đưa" || col.Name == "Tiền thừa"))
                {
                    col.DefaultCellStyle.Format = "N0";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (!formatCurrencyColumns && (col.Name == "Tổng tiền hóa đơn" || col.Name == "Đã thanh toán"))
                {
                    col.DefaultCellStyle.Format = "N0";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private string SafeText(object value)
        {
            return value == DBNull.Value ? "" : Convert.ToString(value);
        }

        private string SafeDate(object value)
        {
            if (value == DBNull.Value) return "";
            if (DateTime.TryParse(value.ToString(), out DateTime dt))
                return dt.ToString("dd/MM/yyyy");
            return value.ToString();
        }

        private string SafeDateTime(object value)
        {
            if (value == DBNull.Value) return "";
            if (DateTime.TryParse(value.ToString(), out DateTime dt))
                return dt.ToString("dd/MM/yyyy HH:mm");
            return value.ToString();
        }

        private string FormatCurrency(object value)
        {
            decimal amount = 0;
            if (value != DBNull.Value)
                decimal.TryParse(value.ToString(), out amount);
            return amount.ToString("N0") + " đ";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
