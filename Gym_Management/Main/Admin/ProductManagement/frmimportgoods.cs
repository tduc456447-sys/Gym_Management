using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.ProductManagement
{
    public partial class frmimportgoods : Form
    {
        private readonly DBHelper db = new DBHelper();

        public frmimportgoods()
        {
            InitializeComponent();

            this.Load += frmimportgoods_Load;
            dgvReceipts.SelectionChanged += dgvReceipts_SelectionChanged;
            btnRefresh.Click += btnRefresh_Click;
            btnSearch.Click += btnSearch_Click;
        }

        private void frmimportgoods_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            LoadReceipts();
        }

        private void LoadReceipts()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FromDate", dtpFrom.Value.Date),
                    new SqlParameter("@ToDate", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))
                };

                DataTable dt = db.ExecuteQuery(@"
                    SELECT 
                        ir.ImportId AS [Mã phiếu],
                        ir.[Date] AS [Ngày nhập],
                        ISNULL(ir.SupplierName, N'') AS [Nhà cung cấp],
                        ISNULL(ir.Note, N'') AS [Ghi chú],
                        ir.Total AS [Tổng tiền],
                        COUNT(d.Id) AS [Số dòng]
                    FROM ImportReceipts ir
                    LEFT JOIN ImportDetails d ON ir.ImportId = d.ImportId
                    WHERE ir.[Date] BETWEEN @FromDate AND @ToDate
                    GROUP BY ir.ImportId, ir.[Date], ir.SupplierName, ir.Note, ir.Total
                    ORDER BY ir.ImportId DESC
                ", parameters);

                dgvReceipts.DataSource = dt;

                if (dgvReceipts.Columns.Count > 0)
                {
                    dgvReceipts.Columns["Mã phiếu"].Width = 90;
                    dgvReceipts.Columns["Ngày nhập"].Width = 170;
                    dgvReceipts.Columns["Nhà cung cấp"].Width = 170;
                    dgvReceipts.Columns["Ghi chú"].Width = 200;
                    dgvReceipts.Columns["Tổng tiền"].DefaultCellStyle.Format = "N0";
                    dgvReceipts.Columns["Số dòng"].Width = 80;
                }

                lblCount.Text = "Tổng phiếu: " + dt.Rows.Count;

                if (dt.Rows.Count > 0)
                {
                    dgvReceipts.Rows[0].Selected = true;
                    LoadReceiptDetails(Convert.ToInt32(dt.Rows[0]["Mã phiếu"]));
                }
                else
                {
                    dgvDetails.DataSource = null;
                    lblReceiptInfo.Text = "Chưa có phiếu nhập nào trong khoảng thời gian này.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReceiptDetails(int importId)
        {
            try
            {
                DataTable dt = db.ExecuteQuery(@"
            SELECT 
                d.Id AS [ID],
                p.Name AS [Tên sản phẩm],
                d.Quantity AS [Số lượng],
                d.Price AS [Giá nhập],
                (d.Quantity * d.Price) AS [Thành tiền]
            FROM ImportDetails d
            INNER JOIN Products p ON d.ProductId = p.ProductId
            WHERE d.ImportId = @ImportId
            ORDER BY d.Id ASC
        ", new SqlParameter[]
                {
            new SqlParameter("@ImportId", importId)
                });

                dgvDetails.DataSource = dt;

                if (dgvDetails.Columns.Count > 0)
                {
                    dgvDetails.Columns["ID"].Width = 60;
                    dgvDetails.Columns["Tên sản phẩm"].Width = 260;
                    dgvDetails.Columns["Giá nhập"].DefaultCellStyle.Format = "N0";
                    dgvDetails.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
                }

                DataTable info = db.ExecuteQuery(@"
            SELECT 
                ImportId,
                [Date],
                ISNULL(SupplierName, N'Không xác định') AS SupplierName,
                ISNULL(Note, N'') AS Note,
                Total
            FROM ImportReceipts
            WHERE ImportId = @ImportId
        ", new SqlParameter[]
                {
            new SqlParameter("@ImportId", importId)
                });

                if (info.Rows.Count > 0)
                {
                    DataRow row = info.Rows[0];
                    lblReceiptInfo.Text =
                        "Phiếu #" + row["ImportId"].ToString()
                        + " | Ngày: " + Convert.ToDateTime(row["Date"]).ToString("dd/MM/yyyy HH:mm")
                        + " | NCC: " + row["SupplierName"].ToString()
                        + " | Ghi chú: " + row["Note"].ToString()
                        + " | Tổng: " + Convert.ToDecimal(row["Total"]).ToString("N0") + " VNĐ";
                }
                else
                {
                    lblReceiptInfo.Text = "Thông tin phiếu nhập";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvReceipts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvReceipts.SelectedRows.Count == 0)
                    return;

                int importId = Convert.ToInt32(dgvReceipts.SelectedRows[0].Cells["Mã phiếu"].Value);
                LoadReceiptDetails(importId);
            }
            catch
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            LoadReceipts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadReceipts();
        }
    }
}