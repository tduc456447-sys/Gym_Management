using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class ucDayShift
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblDate;
        private FlowLayoutPanel flowShifts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.flowShifts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(323, 55);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(0, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(323, 55);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Thứ 2\r\n01/01/2026";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowShifts
            // 
            this.flowShifts.AutoScroll = true;
            this.flowShifts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowShifts.Location = new System.Drawing.Point(0, 55);
            this.flowShifts.Name = "flowShifts";
            this.flowShifts.Padding = new System.Windows.Forms.Padding(4);
            this.flowShifts.Size = new System.Drawing.Size(323, 305);
            this.flowShifts.TabIndex = 1;
            // 
            // ucDayShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowShifts);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ucDayShift";
            this.Size = new System.Drawing.Size(323, 360);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}