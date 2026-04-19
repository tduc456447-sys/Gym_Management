namespace Gym_Management.Main.Admin.StaffManagement
{
    partial class frmStaffManagement
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelContent;

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Button btnEmployeeAccounts;
        private System.Windows.Forms.Button btnPendingApprovals;
        private System.Windows.Forms.Button btnCurrentWeekSchedule;
        private System.Windows.Forms.Button btnNextWeekSchedule;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnSalary;

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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnSalary = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnNextWeekSchedule = new System.Windows.Forms.Button();
            this.btnCurrentWeekSchedule = new System.Windows.Forms.Button();
            this.btnPendingApprovals = new System.Windows.Forms.Button();
            this.btnEmployeeAccounts = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.panelMenu.Controls.Add(this.btnSalary);
            this.panelMenu.Controls.Add(this.btnAttendance);
            this.panelMenu.Controls.Add(this.btnNextWeekSchedule);
            this.panelMenu.Controls.Add(this.btnCurrentWeekSchedule);
            this.panelMenu.Controls.Add(this.btnPendingApprovals);
            this.panelMenu.Controls.Add(this.btnEmployeeAccounts);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(230, 669);
            this.panelMenu.TabIndex = 0;
            // 
            // btnSalary
            // 
            this.btnSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnSalary.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalary.FlatAppearance.BorderSize = 0;
            this.btnSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalary.ForeColor = System.Drawing.Color.White;
            this.btnSalary.Location = new System.Drawing.Point(0, 275);
            this.btnSalary.Name = "btnSalary";
            this.btnSalary.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSalary.Size = new System.Drawing.Size(230, 55);
            this.btnSalary.TabIndex = 5;
            this.btnSalary.Text = "Tính lương";
            this.btnSalary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalary.UseVisualStyleBackColor = false;
            this.btnSalary.Click += new System.EventHandler(this.btnSalary_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnAttendance.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAttendance.FlatAppearance.BorderSize = 0;
            this.btnAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAttendance.ForeColor = System.Drawing.Color.White;
            this.btnAttendance.Location = new System.Drawing.Point(0, 220);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAttendance.Size = new System.Drawing.Size(230, 55);
            this.btnAttendance.TabIndex = 4;
            this.btnAttendance.Text = "Chuyên cần";
            this.btnAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttendance.UseVisualStyleBackColor = false;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnNextWeekSchedule
            // 
            this.btnNextWeekSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnNextWeekSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNextWeekSchedule.FlatAppearance.BorderSize = 0;
            this.btnNextWeekSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextWeekSchedule.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNextWeekSchedule.ForeColor = System.Drawing.Color.White;
            this.btnNextWeekSchedule.Location = new System.Drawing.Point(0, 165);
            this.btnNextWeekSchedule.Name = "btnNextWeekSchedule";
            this.btnNextWeekSchedule.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNextWeekSchedule.Size = new System.Drawing.Size(230, 55);
            this.btnNextWeekSchedule.TabIndex = 3;
            this.btnNextWeekSchedule.Text = "Lịch tuần sau";
            this.btnNextWeekSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNextWeekSchedule.UseVisualStyleBackColor = false;
            this.btnNextWeekSchedule.Click += new System.EventHandler(this.btnNextWeekSchedule_Click);
            // 
            // btnCurrentWeekSchedule
            // 
            this.btnCurrentWeekSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnCurrentWeekSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCurrentWeekSchedule.FlatAppearance.BorderSize = 0;
            this.btnCurrentWeekSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrentWeekSchedule.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCurrentWeekSchedule.ForeColor = System.Drawing.Color.White;
            this.btnCurrentWeekSchedule.Location = new System.Drawing.Point(0, 110);
            this.btnCurrentWeekSchedule.Name = "btnCurrentWeekSchedule";
            this.btnCurrentWeekSchedule.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCurrentWeekSchedule.Size = new System.Drawing.Size(230, 55);
            this.btnCurrentWeekSchedule.TabIndex = 2;
            this.btnCurrentWeekSchedule.Text = "Lịch tuần này";
            this.btnCurrentWeekSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurrentWeekSchedule.UseVisualStyleBackColor = false;
            this.btnCurrentWeekSchedule.Click += new System.EventHandler(this.btnCurrentWeekSchedule_Click);
            // 
            // btnPendingApprovals
            // 
            this.btnPendingApprovals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnPendingApprovals.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPendingApprovals.FlatAppearance.BorderSize = 0;
            this.btnPendingApprovals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendingApprovals.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPendingApprovals.ForeColor = System.Drawing.Color.White;
            this.btnPendingApprovals.Location = new System.Drawing.Point(0, 55);
            this.btnPendingApprovals.Name = "btnPendingApprovals";
            this.btnPendingApprovals.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPendingApprovals.Size = new System.Drawing.Size(230, 55);
            this.btnPendingApprovals.TabIndex = 1;
            this.btnPendingApprovals.Text = "Duyệt tài khoản";
            this.btnPendingApprovals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPendingApprovals.UseVisualStyleBackColor = false;
            this.btnPendingApprovals.Click += new System.EventHandler(this.btnPendingApprovals_Click);
            // 
            // btnEmployeeAccounts
            // 
            this.btnEmployeeAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnEmployeeAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmployeeAccounts.FlatAppearance.BorderSize = 0;
            this.btnEmployeeAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeAccounts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEmployeeAccounts.ForeColor = System.Drawing.Color.White;
            this.btnEmployeeAccounts.Location = new System.Drawing.Point(0, 0);
            this.btnEmployeeAccounts.Name = "btnEmployeeAccounts";
            this.btnEmployeeAccounts.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnEmployeeAccounts.Size = new System.Drawing.Size(230, 55);
            this.btnEmployeeAccounts.TabIndex = 0;
            this.btnEmployeeAccounts.Text = "Tài khoản nhân viên";
            this.btnEmployeeAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeeAccounts.UseVisualStyleBackColor = false;
            this.btnEmployeeAccounts.Click += new System.EventHandler(this.btnEmployeeAccounts_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(230, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1035, 60);
            this.panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(83, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(230, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1035, 609);
            this.panelContent.TabIndex = 2;
            // 
            // frmStaffManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 669);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStaffManagement";
            this.Text = "frmStaffManagement";
            this.Load += new System.EventHandler(this.frmStaffManagement_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}