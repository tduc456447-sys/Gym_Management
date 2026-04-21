namespace Gym_Management.Main.Admin.StaffManagement
{
    partial class frmNextWeekSchedule
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.FlowLayoutPanel flowDays;

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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.lblWeek = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.flowDays = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTop.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnReload);
            this.panelTop.Controls.Add(this.lblWeek);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1234, 90);
            this.panelTop.TabIndex = 0;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(810, 30);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(120, 35);
            this.btnReload.TabIndex = 2;
            this.btnReload.Text = "Tải lại";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWeek.Location = new System.Drawing.Point(22, 52);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(48, 23);
            this.lblWeek.TabIndex = 1;
            this.lblWeek.Text = "Tuần";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(172, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LỊCH TUẦN TỚI";
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelBody.Controls.Add(this.flowDays);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 90);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(10);
            this.panelBody.Size = new System.Drawing.Size(1234, 670);
            this.panelBody.TabIndex = 1;
            // 
            // flowDays
            // 
            this.flowDays.AutoScroll = true;
            this.flowDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowDays.Location = new System.Drawing.Point(10, 10);
            this.flowDays.Name = "flowDays";
            this.flowDays.Size = new System.Drawing.Size(1214, 650);
            this.flowDays.TabIndex = 0;
            this.flowDays.WrapContents = false;
            // 
            // frmNextWeekSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 760);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNextWeekSchedule";
            this.Text = "frmNextWeekSchedule";
            this.Load += new System.EventHandler(this.frmNextWeekSchedule_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}