using Gym_Management.Data;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gym_Management.Main.Admin
{
    public partial class ucAdminDashboard : UserControl
    {
        DBHelper db = new DBHelper();

        private Chart chartRevenue;
        private DataGridView dgvTopProducts;
        private DataGridView dgvTopCustomers;

        public ucAdminDashboard()
        {
            InitializeComponent();
        }

        private void ucAdminDashboard_Load(object sender, EventArgs e)
        {
            InitUI();
            LoadDashboard();
        }

        private void InitUI()
        {
            this.BackColor = Color.FromArgb(245, 246, 250);

            StyleCard(panel1, Color.FromArgb(52, 152, 219));
            StyleCard(panel2, Color.FromArgb(46, 204, 113));
            StyleCard(panel3, Color.FromArgb(241, 196, 15));
            StyleCard(panel4, Color.FromArgb(231, 76, 60));

            label1.Text = "👥 Khách hàng";
            label2.Text = "🏋 Hội viên active";
            label3.Text = "💰 Doanh thu hôm nay";
            label4.Text = "📦 Sản phẩm còn hàng";

            lblCustomers.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblMembers.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblRevenue.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblProducts.Font = new Font("Segoe UI", 18, FontStyle.Bold);

            chartRevenue = new Chart();
            chartRevenue.Location = new Point(30, 180);
            chartRevenue.Size = new Size(650, 250);

            ChartArea area = new ChartArea();
            area.BackColor = Color.White;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);

            chartRevenue.ChartAreas.Add(area);

            Series series = new Series();
            series.Name = "Revenue";
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            chartRevenue.Series.Add(series);
            this.Controls.Add(chartRevenue);

            dgvTopProducts = new DataGridView();
            dgvTopProducts.Location = new Point(30, 460);
            dgvTopProducts.Size = new Size(450, 180);
            StyleGrid(dgvTopProducts);
            this.Controls.Add(dgvTopProducts);

            dgvTopCustomers = new DataGridView();
            dgvTopCustomers.Location = new Point(500, 460);
            dgvTopCustomers.Size = new Size(450, 180);
            StyleGrid(dgvTopCustomers);
            this.Controls.Add(dgvTopCustomers);

            AddTitle("📈 Doanh thu 7 ngày gần nhất", 30, 145);
            AddTitle("🔥 Top sản phẩm", 30, 430);
            AddTitle("🏆 Top khách hàng", 500, 430);
        }

        private void LoadDashboard()
        {
            try
            {
                LoadKpi();
                LoadChart();
                LoadTopProducts();
                LoadTopCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi dashboard admin: " + ex.Message);
            }
        }

        private void LoadKpi()
        {
            object customerObj = db.ExecuteScalar(@"
                SELECT COUNT(*) 
                FROM Customers
            ");
            lblCustomers.Text = customerObj?.ToString() ?? "0";

            object memberObj = db.ExecuteScalar(@"
                SELECT COUNT(*)
                FROM Memberships
                WHERE Status = 'Active'
                  AND EndDate >= CAST(GETDATE() AS DATE)
            ");
            lblMembers.Text = memberObj?.ToString() ?? "0";

            object revenueObj = db.ExecuteScalar(@"
                SELECT ISNULL(SUM(Amount), 0)
                FROM
                (
                    SELECT Amount, PaymentDate FROM MembershipPayments
                    UNION ALL
                    SELECT Amount, PaymentDate FROM SalesPayments
                ) x
                WHERE CAST(x.PaymentDate AS DATE) = CAST(GETDATE() AS DATE)
            ");
            decimal todayRevenue = Convert.ToDecimal(revenueObj);
            lblRevenue.Text = todayRevenue.ToString("N0") + " VND";

            object productObj = db.ExecuteScalar(@"
                SELECT COUNT(*)
                FROM Products
                WHERE Quantity > 0
            ");
            lblProducts.Text = productObj?.ToString() ?? "0";
        }

        private void LoadChart()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT
                    RevenueDate,
                    SUM(Amount) AS TotalRevenue
                FROM
                (
                    SELECT CAST(PaymentDate AS DATE) AS RevenueDate, Amount
                    FROM MembershipPayments
                    WHERE PaymentDate >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))

                    UNION ALL

                    SELECT CAST(PaymentDate AS DATE) AS RevenueDate, Amount
                    FROM SalesPayments
                    WHERE PaymentDate >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))
                ) x
                GROUP BY RevenueDate
                ORDER BY RevenueDate
            ");

            chartRevenue.Series[0].Points.Clear();

            foreach (DataRow row in dt.Rows)
            {
                chartRevenue.Series[0].Points.AddXY(
                    Convert.ToDateTime(row["RevenueDate"]).ToString("dd/MM"),
                    Convert.ToDecimal(row["TotalRevenue"])
                );
            }
        }

        private void LoadTopProducts()
        {
            dgvTopProducts.DataSource = db.ExecuteQuery(@"
                SELECT TOP 5
                    p.Name AS [Sản phẩm],
                    SUM(d.Quantity) AS [Đã bán],
                    SUM(d.Quantity * d.Price) AS [Doanh thu]
                FROM SalesInvoiceDetails d
                JOIN Products p ON p.ProductId = d.ProductId
                GROUP BY p.Name
                ORDER BY [Đã bán] DESC
            ");
        }

        private void LoadTopCustomers()
        {
            dgvTopCustomers.DataSource = db.ExecuteQuery(@"
                SELECT TOP 5
                    c.FullName AS [Khách hàng],
                    ISNULL(mp.TotalMembership, 0) + ISNULL(sp.TotalSales, 0) AS [Tổng chi]
                FROM Customers c
                LEFT JOIN
                (
                    SELECT m.CustomerId, SUM(p.Amount) AS TotalMembership
                    FROM MembershipPayments p
                    JOIN Memberships m ON p.MembershipId = m.MembershipId
                    GROUP BY m.CustomerId
                ) mp ON c.CustomerId = mp.CustomerId
                LEFT JOIN
                (
                    SELECT s.CustomerId, SUM(p.Amount) AS TotalSales
                    FROM SalesPayments p
                    JOIN SalesInvoices s ON p.SalesInvoiceId = s.SalesInvoiceId
                    GROUP BY s.CustomerId
                ) sp ON c.CustomerId = sp.CustomerId
                ORDER BY [Tổng chi] DESC
            ");
        }

        private void StyleCard(Panel p, Color color)
        {
            p.BackColor = color;
            SetRounded(p, 20);

            foreach (Control c in p.Controls)
                c.ForeColor = Color.White;
        }

        private void StyleGrid(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 30;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        }

        private void AddTitle(string text, int left, int top)
        {
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            lbl.Text = text;
            lbl.Location = new Point(left, top);
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(44, 62, 80);
            this.Controls.Add(lbl);
        }

        private void SetRounded(Control control, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }
    }
}