namespace Gym_Management.Main.Admin
{
    partial class ucAdminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Label lblMembers;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblProducts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomers = new System.Windows.Forms.Label();

            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMembers = new System.Windows.Forms.Label();

            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();

            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();

            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();

            // panel1
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblCustomers);
            this.panel1.Location = new System.Drawing.Point(30, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 90);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);

            // lblCustomers
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Location = new System.Drawing.Point(20, 45);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(14, 16);
            this.lblCustomers.Text = "0";

            // panel2
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblMembers);
            this.panel2.Location = new System.Drawing.Point(270, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 90);

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);

            // lblMembers
            this.lblMembers.AutoSize = true;
            this.lblMembers.Location = new System.Drawing.Point(20, 45);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(14, 16);
            this.lblMembers.Text = "0";

            // panel3
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblRevenue);
            this.panel3.Location = new System.Drawing.Point(510, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 90);

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);

            // lblRevenue
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Location = new System.Drawing.Point(20, 45);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(14, 16);
            this.lblRevenue.Text = "0";

            // panel4
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lblProducts);
            this.panel4.Location = new System.Drawing.Point(750, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(220, 90);

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);

            // lblProducts
            this.lblProducts.AutoSize = true;
            this.lblProducts.Location = new System.Drawing.Point(20, 45);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(14, 16);
            this.lblProducts.Text = "0";

            // ucAdminDashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Name = "ucAdminDashboard";
            this.Size = new System.Drawing.Size(1000, 680);
            this.Load += new System.EventHandler(this.ucAdminDashboard_Load);

            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}