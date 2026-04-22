namespace GymManagement
{
    partial class FrmExpiringMembers
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblLegendRed;
        private System.Windows.Forms.Label lblLegendYellow;
        private System.Windows.Forms.DataGridView dgvExpiringMembers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblDays = new System.Windows.Forms.Label();
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblLegendRed = new System.Windows.Forms.Label();
            this.lblLegendYellow = new System.Windows.Forms.Label();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dgvExpiringMembers = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiringMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.panelHeader.Size = new System.Drawing.Size(1180, 85);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(291, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hội viên sắp hết hạn gói tập";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTitle.Location = new System.Drawing.Point(22, 48);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(336, 19);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Theo dõi các hội viên sắp hết hạn để gia hạn kịp thời";
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.lblDays);
            this.panelFilter.Controls.Add(this.numDays);
            this.panelFilter.Controls.Add(this.btnRefresh);
            this.panelFilter.Controls.Add(this.btnRenew);
            this.panelFilter.Controls.Add(this.lblTotal);
            this.panelFilter.Controls.Add(this.lblLegendRed);
            this.panelFilter.Controls.Add(this.lblLegendYellow);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 85);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelFilter.Size = new System.Drawing.Size(1180, 90);
            this.panelFilter.TabIndex = 1;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDays.Location = new System.Drawing.Point(22, 16);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(147, 19);
            this.lblDays.TabIndex = 0;
            this.lblDays.Text = "Cảnh báo trong (ngày):";
            // 
            // numDays
            // 
            this.numDays.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numDays.Location = new System.Drawing.Point(175, 14);
            this.numDays.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDays.Name = "numDays";
            this.numDays.Size = new System.Drawing.Size(75, 25);
            this.numDays.TabIndex = 1;
            this.numDays.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(265, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.Location = new System.Drawing.Point(385, 12);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(125, 30);
            this.btnRenew.TabIndex = 3;
            this.btnRenew.Text = "Gia hạn hội viên";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(915, 16);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(240, 23);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Tổng: 0 hội viên";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLegendRed
            // 
            this.lblLegendRed.AutoSize = true;
            this.lblLegendRed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLegendRed.Location = new System.Drawing.Point(22, 56);
            this.lblLegendRed.Name = "lblLegendRed";
            this.lblLegendRed.Size = new System.Drawing.Size(118, 15);
            this.lblLegendRed.TabIndex = 5;
            this.lblLegendRed.Text = "■ Màu đỏ: còn <= 3 ngày";
            // 
            // lblLegendYellow
            // 
            this.lblLegendYellow.AutoSize = true;
            this.lblLegendYellow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLegendYellow.Location = new System.Drawing.Point(170, 56);
            this.lblLegendYellow.Name = "lblLegendYellow";
            this.lblLegendYellow.Size = new System.Drawing.Size(129, 15);
            this.lblLegendYellow.TabIndex = 6;
            this.lblLegendYellow.Text = "■ Màu vàng: còn <= 7 ngày";
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.dgvExpiringMembers);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 175);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.panelGrid.Size = new System.Drawing.Size(1180, 505);
            this.panelGrid.TabIndex = 2;
            // 
            // dgvExpiringMembers
            // 
            this.dgvExpiringMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpiringMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpiringMembers.Location = new System.Drawing.Point(20, 0);
            this.dgvExpiringMembers.Name = "dgvExpiringMembers";
            this.dgvExpiringMembers.RowHeadersWidth = 51;
            this.dgvExpiringMembers.RowTemplate.Height = 24;
            this.dgvExpiringMembers.Size = new System.Drawing.Size(1140, 485);
            this.dgvExpiringMembers.TabIndex = 0;
            this.dgvExpiringMembers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpiringMembers_CellDoubleClick);
            // 
            // FrmExpiringMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1180, 680);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmExpiringMembers";
            this.Text = "FrmExpiringMembers";
            this.Load += new System.EventHandler(this.FrmExpiringMembers_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiringMembers)).EndInit();
            this.ResumeLayout(false);
        }
    }
}