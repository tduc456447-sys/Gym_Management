using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Gym_Management.Data;

namespace Gym_Management.Main.Staff
{
    public partial class DashboardForm : Form
    {
        private int staffId;
        private DBHelper db = new DBHelper();

        public DashboardForm(int userId)
        {
            InitializeComponent();
            this.staffId = userId;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            InitChart();
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                LoadKpi();
                LoadChart();
                LoadTopCustomers();
                LoadTopProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi dashboard: " + ex.Message);
            }
        }

        private void LoadKpi()
        {
            object m = db.ExecuteScalar(@"
        SELECT COUNT(*)
        FROM Memberships
        WHERE CreatedByStaffId = @StaffId",
                new SqlParameter[]
                {
            new SqlParameter("@StaffId", staffId)
                });
            lblMembers.Text = m?.ToString() ?? "0";

            object rev1 = db.ExecuteScalar(@"
        SELECT ISNULL(SUM(Amount),0)
        FROM MembershipPayments
        WHERE ReceivedByStaffId = @StaffId",
                new SqlParameter[]
                {
            new SqlParameter("@StaffId", staffId)
                });

            object rev2 = db.ExecuteScalar(@"
        SELECT ISNULL(SUM(Amount),0)
        FROM SalesPayments
        WHERE ReceivedByStaffId = @StaffId",
                new SqlParameter[]
                {
            new SqlParameter("@StaffId", staffId)
                });

            decimal totalRevenue = Convert.ToDecimal(rev1) + Convert.ToDecimal(rev2);
            lblRevenue.Text = totalRevenue.ToString("N0") + " VND";

            object inv = db.ExecuteScalar(@"
        SELECT COUNT(*)
        FROM SalesInvoices
        WHERE CreatedByStaffId = @StaffId",
                new SqlParameter[]
                {
            new SqlParameter("@StaffId", staffId)
                });
            lblInvoices.Text = inv?.ToString() ?? "0";

            object cus = db.ExecuteScalar(@"
        SELECT COUNT(DISTINCT CustomerId)
        FROM Memberships
        WHERE CreatedByStaffId = @StaffId",
                new SqlParameter[]
                {
            new SqlParameter("@StaffId", staffId)
                });
            lblCustomers.Text = cus?.ToString() ?? "0";
        }

        private void InitChart()
        {
            chartRevenue.Series.Clear();
            chartRevenue.ChartAreas.Clear();

            ChartArea area = new ChartArea();
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartRevenue.ChartAreas.Add(area);

            Series s = new Series();
            s.Name = "Revenue";
            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;
            chartRevenue.Series.Add(s);
        }

        private void LoadChart()
        {
            DataTable dt = db.ExecuteQuery(@"
        SELECT RevenueDate, SUM(Amount) Revenue
        FROM
        (
            SELECT CAST(PaymentDate AS DATE) RevenueDate, Amount
            FROM MembershipPayments
            WHERE ReceivedByStaffId = @StaffId

            UNION ALL

            SELECT CAST(PaymentDate AS DATE), Amount
            FROM SalesPayments
            WHERE ReceivedByStaffId = @StaffId
        ) t
        WHERE RevenueDate >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))
        GROUP BY RevenueDate
        ORDER BY RevenueDate",
                new SqlParameter[]
                {
            new SqlParameter("@StaffId", staffId)
                });

            chartRevenue.Series[0].Points.Clear();

            foreach (DataRow row in dt.Rows)
            {
                chartRevenue.Series[0].Points.AddXY(
                    Convert.ToDateTime(row["RevenueDate"]).ToString("dd/MM"),
                    Convert.ToDecimal(row["Revenue"])
                );
            }
        }

        private void LoadTopCustomers()
        {
            dgvTopCustomers.DataSource = db.ExecuteQuery(@"
        SELECT TOP 5
            c.FullName AS [Khách hàng],
            SUM(p.Amount) AS [Tổng chi]
        FROM MembershipPayments p
        JOIN Memberships m ON p.MembershipId = m.MembershipId
        JOIN Customers c ON m.CustomerId = c.CustomerId
        WHERE p.ReceivedByStaffId = @StaffId
        GROUP BY c.FullName
        ORDER BY [Tổng chi] DESC",
                new SqlParameter[]
                {
            new SqlParameter("@StaffId", staffId)
                });
        }

        private void LoadTopProducts()
        {
            dgvTopProducts.DataSource = db.ExecuteQuery(@"
        SELECT TOP 5
            p.Name AS [Sản phẩm],
            SUM(d.Quantity) AS [Đã bán]
        FROM SalesInvoiceDetails d
        JOIN SalesInvoices s ON d.SalesInvoiceId = s.SalesInvoiceId
        JOIN Products p ON d.ProductId = p.ProductId
        WHERE s.CreatedByStaffId = @StaffId
        GROUP BY p.Name
        ORDER BY [Đã bán] DESC",
                new SqlParameter[]
                {
            new SqlParameter("@StaffId", staffId)
                });
        }
    }
}