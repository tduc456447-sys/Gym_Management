using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Shared.InvoiceManagement
{
    public partial class InvoiceHistoryForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int _userId;
        private readonly string _fullName;
        private readonly bool _isAdmin;

        public InvoiceHistoryForm(int userId, string fullName, bool isAdmin)
        {
            InitializeComponent();
            _userId = userId;
            _fullName = fullName;
            _isAdmin = isAdmin;
        }

        private void InvoiceHistoryForm_Load(object sender, EventArgs e)
        {
            cboType.Items.Clear();
            cboType.Items.Add("Tất cả");
            cboType.Items.Add("Bán hàng");
            cboType.Items.Add("Hội viên");
            cboType.Items.Add("Nhập hàng");
            cboType.SelectedIndex = 0;

            dtFrom.Value = DateTime.Today.AddMonths(-1);
            dtTo.Value = DateTime.Today;

            lblUserScope.Text = _isAdmin
                ? "Phạm vi xem: Admin xem toàn bộ hóa đơn"
                : "Phạm vi xem: Staff chỉ xem hóa đơn mình tạo hoặc mình thu tiền";

            ConfigureMasterGrid();
            ConfigureDetailGrid();
            LoadInvoices();
        }

        private void ConfigureMasterGrid()
        {
            dgvInvoices.AutoGenerateColumns = true;
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.AllowUserToDeleteRows = false;
            dgvInvoices.ReadOnly = true;
            dgvInvoices.MultiSelect = false;
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoices.RowHeadersVisible = false;
            dgvInvoices.AllowUserToResizeRows = false;
            dgvInvoices.RowTemplate.Height = 30;
            dgvInvoices.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvInvoices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void ConfigureDetailGrid()
        {
            dgvDetails.AutoGenerateColumns = true;
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.ReadOnly = true;
            dgvDetails.MultiSelect = false;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.AllowUserToResizeRows = false;
            dgvDetails.RowTemplate.Height = 30;
            dgvDetails.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            cboType.SelectedIndex = 0;
            dtFrom.Value = DateTime.Today.AddMonths(-1);
            dtTo.Value = DateTime.Today;
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            try
            {
                string type = cboType.SelectedItem == null ? "Tất cả" : cboType.SelectedItem.ToString();
                string sql = BuildInvoiceQuery(type);

                DataTable dt = db.ExecuteQuery(sql, new SqlParameter[]
                {
                    new SqlParameter("@UserId", _userId),
                    new SqlParameter("@IsAdmin", _isAdmin ? 1 : 0),
                    new SqlParameter("@DateFrom", dtFrom.Value.Date),
                    new SqlParameter("@DateTo", dtTo.Value.Date.AddDays(1).AddSeconds(-1)),
                    new SqlParameter("@Keyword", txtKeyword.Text.Trim())
                });

                dgvInvoices.DataSource = dt;
                FormatMasterGrid();
                lblCount.Text = "Số hóa đơn: " + dt.Rows.Count;

                if (dt.Rows.Count > 0)
                {
                    dgvInvoices.Rows[0].Selected = true;
                    LoadInvoiceDetails();
                }
                else
                {
                    dgvDetails.DataSource = null;
                    lblDetail.Text = "Chi tiết hóa đơn";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildInvoiceQuery(string type)
        {
            string salesQuery = @"
SELECT
    CAST('SALE' AS NVARCHAR(20)) AS InvoiceTypeCode,
    N'Bán hàng' AS LoaiHoaDon,
    si.SalesInvoiceId AS InvoiceId,
    N'SALE-' + RIGHT('000000' + CAST(si.SalesInvoiceId AS VARCHAR(20)), 6) AS MaHoaDon,
    si.InvoiceDate AS NgayTao,
    ISNULL(c.FullName, N'Khách lẻ') AS DoiTuong,
    CAST(si.Total AS DECIMAL(18,2)) AS TongTien,
    CAST(ISNULL((SELECT SUM(sp.Amount) FROM SalesPayments sp WHERE sp.SalesInvoiceId = si.SalesInvoiceId), 0) AS DECIMAL(18,2)) AS DaThanhToan,
    CAST(si.Total - ISNULL((SELECT SUM(sp.Amount) FROM SalesPayments sp WHERE sp.SalesInvoiceId = si.SalesInvoiceId), 0) AS DECIMAL(18,2)) AS ConLai,
    ISNULL(uCreate.FullName, N'') AS NguoiTao,
    ISNULL(uPay.FullName, N'') AS NguoiThuTien,
    ISNULL(si.Note, N'') AS GhiChu
FROM SalesInvoices si
LEFT JOIN Customers c ON c.CustomerId = si.CustomerId
LEFT JOIN Users uCreate ON uCreate.UserId = si.CreatedByStaffId
OUTER APPLY (
    SELECT TOP 1 u.FullName
    FROM SalesPayments sp2
    LEFT JOIN Users u ON u.UserId = sp2.ReceivedByStaffId
    WHERE sp2.SalesInvoiceId = si.SalesInvoiceId
    ORDER BY sp2.PaymentDate DESC, sp2.SalesPaymentId DESC
) uPay
WHERE si.InvoiceDate >= @DateFrom
  AND si.InvoiceDate <= @DateTo
  AND (
        @Keyword = ''
        OR CAST(si.SalesInvoiceId AS NVARCHAR(20)) LIKE '%' + @Keyword + '%'
        OR ISNULL(c.FullName, N'Khách lẻ') LIKE N'%' + @Keyword + N'%'
        OR ISNULL(uCreate.FullName, N'') LIKE N'%' + @Keyword + N'%'
        OR ISNULL(si.Note, N'') LIKE N'%' + @Keyword + N'%'
      )
  AND (
        @IsAdmin = 1
        OR si.CreatedByStaffId = @UserId
        OR EXISTS (SELECT 1 FROM SalesPayments sp WHERE sp.SalesInvoiceId = si.SalesInvoiceId AND sp.ReceivedByStaffId = @UserId)
      )";

            string membershipQuery = @"
SELECT
    CAST('MEM' AS NVARCHAR(20)) AS InvoiceTypeCode,
    N'Hội viên' AS LoaiHoaDon,
    m.MembershipId AS InvoiceId,
    N'MEM-' + RIGHT('000000' + CAST(m.MembershipId AS VARCHAR(20)), 6) AS MaHoaDon,
    m.CreatedAt AS NgayTao,
    c.FullName AS DoiTuong,
    CAST(m.Price AS DECIMAL(18,2)) AS TongTien,
    CAST(ISNULL((SELECT SUM(mp.Amount) FROM MembershipPayments mp WHERE mp.MembershipId = m.MembershipId), 0) AS DECIMAL(18,2)) AS DaThanhToan,
    CAST(m.Price - ISNULL((SELECT SUM(mp.Amount) FROM MembershipPayments mp WHERE mp.MembershipId = m.MembershipId), 0) AS DECIMAL(18,2)) AS ConLai,
    ISNULL(uCreate.FullName, N'') AS NguoiTao,
    ISNULL(uPay.FullName, N'') AS NguoiThuTien,
    (ISNULL(p.Name, N'') + CASE WHEN t.Name IS NULL THEN N'' ELSE N' | PT: ' + t.Name END) AS GhiChu
FROM Memberships m
JOIN Customers c ON c.CustomerId = m.CustomerId
LEFT JOIN Packages p ON p.PackageId = m.PackageId
LEFT JOIN Trainers t ON t.TrainerId = m.TrainerId
LEFT JOIN Users uCreate ON uCreate.UserId = m.CreatedByStaffId
OUTER APPLY (
    SELECT TOP 1 u.FullName
    FROM MembershipPayments mp2
    LEFT JOIN Users u ON u.UserId = mp2.ReceivedByStaffId
    WHERE mp2.MembershipId = m.MembershipId
    ORDER BY mp2.PaymentDate DESC, mp2.MembershipPaymentId DESC
) uPay
WHERE m.CreatedAt >= @DateFrom
  AND m.CreatedAt <= @DateTo
  AND (
        @Keyword = ''
        OR CAST(m.MembershipId AS NVARCHAR(20)) LIKE '%' + @Keyword + '%'
        OR c.FullName LIKE N'%' + @Keyword + N'%'
        OR ISNULL(uCreate.FullName, N'') LIKE N'%' + @Keyword + N'%'
        OR ISNULL(p.Name, N'') LIKE N'%' + @Keyword + N'%'
      )
  AND (
        @IsAdmin = 1
        OR m.CreatedByStaffId = @UserId
        OR EXISTS (SELECT 1 FROM MembershipPayments mp WHERE mp.MembershipId = m.MembershipId AND mp.ReceivedByStaffId = @UserId)
      )";

            string importQuery = @"
SELECT
    CAST('IMP' AS NVARCHAR(20)) AS InvoiceTypeCode,
    N'Nhập hàng' AS LoaiHoaDon,
    ir.ImportId AS InvoiceId,
    N'IMP-' + RIGHT('000000' + CAST(ir.ImportId AS VARCHAR(20)), 6) AS MaHoaDon,
    ir.Date AS NgayTao,
    ISNULL(s.Name, N'') AS DoiTuong,
    CAST(ir.Total AS DECIMAL(18,2)) AS TongTien,
    CAST(ir.Total AS DECIMAL(18,2)) AS DaThanhToan,
    CAST(0 AS DECIMAL(18,2)) AS ConLai,
    ISNULL(uAdmin.FullName, N'') AS NguoiTao,
    N'' AS NguoiThuTien,
    ISNULL(sc.FullName, N'') AS GhiChu
FROM ImportReceipts ir
LEFT JOIN Suppliers s ON s.SupplierId = ir.SupplierId
LEFT JOIN SupplierContacts sc ON sc.ContactId = ir.ContactId
LEFT JOIN Users uAdmin ON uAdmin.UserId = ir.CreatedByAdminId
WHERE ir.Date >= @DateFrom
  AND ir.Date <= @DateTo
  AND (
        @Keyword = ''
        OR CAST(ir.ImportId AS NVARCHAR(20)) LIKE '%' + @Keyword + '%'
        OR ISNULL(s.Name, N'') LIKE N'%' + @Keyword + N'%'
        OR ISNULL(uAdmin.FullName, N'') LIKE N'%' + @Keyword + N'%'
      )
  AND (
        @IsAdmin = 1
        OR 1 = 0
      )";

            if (type == "Bán hàng") return salesQuery + " ORDER BY NgayTao DESC";
            if (type == "Hội viên") return membershipQuery + " ORDER BY NgayTao DESC";
            if (type == "Nhập hàng") return importQuery + " ORDER BY NgayTao DESC";

            return salesQuery + @"
UNION ALL
" + membershipQuery + @"
UNION ALL
" + importQuery + @"
ORDER BY NgayTao DESC";
        }

        private void FormatMasterGrid()
        {
            if (dgvInvoices.Columns.Count == 0)
                return;

            if (dgvInvoices.Columns["InvoiceTypeCode"] != null)
                dgvInvoices.Columns["InvoiceTypeCode"].Visible = false;

            if (dgvInvoices.Columns["InvoiceId"] != null)
                dgvInvoices.Columns["InvoiceId"].Visible = false;

            string[] moneyColumns = { "TongTien", "DaThanhToan", "ConLai" };
            foreach (string colName in moneyColumns)
            {
                if (dgvInvoices.Columns[colName] != null)
                    dgvInvoices.Columns[colName].DefaultCellStyle.Format = "N0";
            }

            if (dgvInvoices.Columns["NgayTao"] != null)
                dgvInvoices.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private void dgvInvoices_SelectionChanged(object sender, EventArgs e)
        {
            LoadInvoiceDetails();
        }

        private void LoadInvoiceDetails()
        {
            try
            {
                if (dgvInvoices.CurrentRow == null)
                {
                    dgvDetails.DataSource = null;
                    return;
                }

                string typeCode = Convert.ToString(dgvInvoices.CurrentRow.Cells["InvoiceTypeCode"].Value);
                int invoiceId = Convert.ToInt32(dgvInvoices.CurrentRow.Cells["InvoiceId"].Value);
                string displayCode = Convert.ToString(dgvInvoices.CurrentRow.Cells["MaHoaDon"].Value);

                lblDetail.Text = "Chi tiết hóa đơn: " + displayCode;

                if (typeCode == "SALE")
                {
                    DataTable dt = db.ExecuteQuery(@"
SELECT
    p.Name AS TenHangMuc,
    d.Quantity AS SoLuong,
    CAST(d.Price AS DECIMAL(18,2)) AS DonGia,
    CAST(d.Quantity * d.Price AS DECIMAL(18,2)) AS ThanhTien,
    ISNULL(p.Barcode, '') AS MaPhu
FROM SalesInvoiceDetails d
JOIN Products p ON p.ProductId = d.ProductId
WHERE d.SalesInvoiceId = @Id
ORDER BY d.Id", new SqlParameter[]
                    {
                        new SqlParameter("@Id", invoiceId)
                    });

                    dgvDetails.DataSource = dt;
                }
                else if (typeCode == "MEM")
                {
                    DataTable dt = db.ExecuteQuery(@"
SELECT
    N'Gói tập' AS TenHangMuc,
    ISNULL(p.Name, N'') AS NoiDung,
    m.StartDate AS TuNgay,
    m.EndDate AS DenNgay,
    m.Status AS TrangThai,
    CAST(m.Price AS DECIMAL(18,2)) AS GiaTri
FROM Memberships m
LEFT JOIN Packages p ON p.PackageId = m.PackageId
WHERE m.MembershipId = @Id

UNION ALL

SELECT
    N'Thanh toán' AS TenHangMuc,
    N'Phương thức: ' + mp.Method + ISNULL(N' | Ghi chú: ' + mp.Note, N'') AS NoiDung,
    CAST(mp.PaymentDate AS DATETIME) AS TuNgay,
    CAST(NULL AS DATETIME) AS DenNgay,
    N'Đã thu' AS TrangThai,
    CAST(mp.Amount AS DECIMAL(18,2)) AS GiaTri
FROM MembershipPayments mp
WHERE mp.MembershipId = @Id
ORDER BY TuNgay", new SqlParameter[]
                    {
                        new SqlParameter("@Id", invoiceId)
                    });

                    dgvDetails.DataSource = dt;
                }
                else if (typeCode == "IMP")
                {
                    DataTable dt = db.ExecuteQuery(@"
SELECT
    p.Name AS TenHangMuc,
    d.Quantity AS SoLuong,
    CAST(d.Price AS DECIMAL(18,2)) AS DonGia,
    CAST(d.Quantity * d.Price AS DECIMAL(18,2)) AS ThanhTien,
    ISNULL(b.Name, '') AS ThuongHieu
FROM ImportDetails d
JOIN Products p ON p.ProductId = d.ProductId
LEFT JOIN Brands b ON b.BrandId = p.BrandId
WHERE d.ImportId = @Id
ORDER BY d.Id", new SqlParameter[]
                    {
                        new SqlParameter("@Id", invoiceId)
                    });

                    dgvDetails.DataSource = dt;
                }

                FormatDetailGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDetailGrid()
        {
            if (dgvDetails.Columns.Count == 0)
                return;

            string[] moneyColumns = { "DonGia", "ThanhTien", "GiaTri" };
            foreach (string colName in moneyColumns)
            {
                if (dgvDetails.Columns[colName] != null)
                    dgvDetails.Columns[colName].DefaultCellStyle.Format = "N0";
            }

            string[] dateColumns = { "TuNgay", "DenNgay" };
            foreach (string colName in dateColumns)
            {
                if (dgvDetails.Columns[colName] != null)
                    dgvDetails.Columns[colName].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }
    }
}
