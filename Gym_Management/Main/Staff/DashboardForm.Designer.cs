using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gym_Management.Main.Staff
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;

        private Label lblMembers;
        private Label lblRevenue;
        private Label lblInvoices;
        private Label lblCustomers;

        private Chart chartRevenue;
        private DataGridView dgvTopCustomers;
        private DataGridView dgvTopProducts;

        private Label lblChartTitle;
        private Label lblTopCustomersTitle;
        private Label lblTopProductsTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            ChartArea chartArea1 = new ChartArea();
            Series series1 = new Series();

            this.panel1 = new Panel();
            this.label1 = new Label();
            this.lblMembers = new Label();

            this.panel2 = new Panel();
            this.label2 = new Label();
            this.lblRevenue = new Label();

            this.panel3 = new Panel();
            this.label3 = new Label();
            this.lblInvoices = new Label();

            this.panel4 = new Panel();
            this.label4 = new Label();
            this.lblCustomers = new Label();

            this.chartRevenue = new Chart();
            this.dgvTopCustomers = new DataGridView();
            this.dgvTopProducts = new DataGridView();

            this.lblChartTitle = new Label();
            this.lblTopCustomersTitle = new Label();
            this.lblTopProductsTitle = new Label();

            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.SuspendLayout();

            // 
            // panel1
            // 
            this.panel1.BackColor = Color.FromArgb(52, 152, 219);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblMembers);
            this.panel1.Location = new Point(25, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(220, 110);
            this.panel1.TabIndex = 0;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(135, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Membership tạo";

            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblMembers.ForeColor = Color.White;
            this.lblMembers.Location = new Point(14, 45);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new Size(43, 50);
            this.lblMembers.TabIndex = 1;
            this.lblMembers.Text = "0";

            // 
            // panel2
            // 
            this.panel2.BackColor = Color.FromArgb(46, 204, 113);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblRevenue);
            this.panel2.Location = new Point(265, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(220, 110);
            this.panel2.TabIndex = 1;

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.label2.ForeColor = Color.White;
            this.label2.Location = new Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new Size(101, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Doanh thu";

            // 
            // lblRevenue
            // 
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblRevenue.ForeColor = Color.White;
            this.lblRevenue.Location = new Point(14, 52);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new Size(31, 37);
            this.lblRevenue.TabIndex = 1;
            this.lblRevenue.Text = "0";

            // 
            // panel3
            // 
            this.panel3.BackColor = Color.FromArgb(241, 196, 15);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblInvoices);
            this.panel3.Location = new Point(505, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(220, 110);
            this.panel3.TabIndex = 2;

            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.label3.ForeColor = Color.White;
            this.label3.Location = new Point(15, 15);
            this.label3.Name = "label3";
            this.label3.Size = new Size(84, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hóa đơn";

            // 
            // lblInvoices
            // 
            this.lblInvoices.AutoSize = true;
            this.lblInvoices.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblInvoices.ForeColor = Color.White;
            this.lblInvoices.Location = new Point(14, 45);
            this.lblInvoices.Name = "lblInvoices";
            this.lblInvoices.Size = new Size(43, 50);
            this.lblInvoices.TabIndex = 1;
            this.lblInvoices.Text = "0";

            // 
            // panel4
            // 
            this.panel4.BackColor = Color.FromArgb(231, 76, 60);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lblCustomers);
            this.panel4.Location = new Point(745, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(220, 110);
            this.panel4.TabIndex = 3;

            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.label4.ForeColor = Color.White;
            this.label4.Location = new Point(15, 15);
            this.label4.Name = "label4";
            this.label4.Size = new Size(134, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Khách phục vụ";

            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblCustomers.ForeColor = Color.White;
            this.lblCustomers.Location = new Point(14, 45);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new Size(43, 50);
            this.lblCustomers.TabIndex = 1;
            this.lblCustomers.Text = "0";

            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblChartTitle.Location = new Point(25, 150);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new Size(250, 28);
            this.lblChartTitle.TabIndex = 4;
            this.lblChartTitle.Text = "📈 Doanh thu 7 ngày gần nhất";

            // 
            // chartRevenue
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea1);
            this.chartRevenue.Location = new Point(25, 185);
            this.chartRevenue.Name = "chartRevenue";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Revenue";
            this.chartRevenue.Series.Add(series1);
            this.chartRevenue.Size = new Size(940, 260);
            this.chartRevenue.TabIndex = 5;
            this.chartRevenue.Text = "chartRevenue";

            // 
            // lblTopCustomersTitle
            // 
            this.lblTopCustomersTitle.AutoSize = true;
            this.lblTopCustomersTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTopCustomersTitle.Location = new Point(25, 465);
            this.lblTopCustomersTitle.Name = "lblTopCustomersTitle";
            this.lblTopCustomersTitle.Size = new Size(178, 28);
            this.lblTopCustomersTitle.TabIndex = 6;
            this.lblTopCustomersTitle.Text = "🏆 Top khách hàng";

            // 
            // dgvTopCustomers
            // 
            this.dgvTopCustomers.BackgroundColor = Color.White;
            this.dgvTopCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopCustomers.Location = new Point(25, 500);
            this.dgvTopCustomers.Name = "dgvTopCustomers";
            this.dgvTopCustomers.RowHeadersWidth = 51;
            this.dgvTopCustomers.RowTemplate.Height = 24;
            this.dgvTopCustomers.Size = new Size(460, 190);
            this.dgvTopCustomers.TabIndex = 7;

            // 
            // lblTopProductsTitle
            // 
            this.lblTopProductsTitle.AutoSize = true;
            this.lblTopProductsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTopProductsTitle.Location = new Point(505, 465);
            this.lblTopProductsTitle.Name = "lblTopProductsTitle";
            this.lblTopProductsTitle.Size = new Size(171, 28);
            this.lblTopProductsTitle.TabIndex = 8;
            this.lblTopProductsTitle.Text = "🔥 Top sản phẩm";

            // 
            // dgvTopProducts
            // 
            this.dgvTopProducts.BackgroundColor = Color.White;
            this.dgvTopProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopProducts.Location = new Point(505, 500);
            this.dgvTopProducts.Name = "dgvTopProducts";
            this.dgvTopProducts.RowHeadersWidth = 51;
            this.dgvTopProducts.RowTemplate.Height = 24;
            this.dgvTopProducts.Size = new Size(460, 190);
            this.dgvTopProducts.TabIndex = 9;

            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.ClientSize = new Size(1000, 720);
            this.Controls.Add(this.dgvTopProducts);
            this.Controls.Add(this.lblTopProductsTitle);
            this.Controls.Add(this.dgvTopCustomers);
            this.Controls.Add(this.lblTopCustomersTitle);
            this.Controls.Add(this.chartRevenue);
            this.Controls.Add(this.lblChartTitle);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);

            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}