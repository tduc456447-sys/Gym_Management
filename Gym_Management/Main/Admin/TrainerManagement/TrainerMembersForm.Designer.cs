namespace Gym_Management.Main.Admin
{
    partial class TrainerMembersForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTrainerName = new System.Windows.Forms.Label();
            this.cboMembershipStatus = new System.Windows.Forms.ComboBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTrainerName
            // 
            this.lblTrainerName.AutoSize = true;
            this.lblTrainerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTrainerName.Location = new System.Drawing.Point(21, 16);
            this.lblTrainerName.Name = "lblTrainerName";
            this.lblTrainerName.Size = new System.Drawing.Size(204, 28);
            this.lblTrainerName.TabIndex = 0;
            this.lblTrainerName.Text = "Huấn luyện viên: ...";
            // 
            // cboMembershipStatus
            // 
            this.cboMembershipStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMembershipStatus.FormattingEnabled = true;
            this.cboMembershipStatus.Location = new System.Drawing.Point(691, 19);
            this.cboMembershipStatus.Name = "cboMembershipStatus";
            this.cboMembershipStatus.Size = new System.Drawing.Size(149, 24);
            this.cboMembershipStatus.TabIndex = 1;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(855, 16);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(91, 30);
            this.btnReload.TabIndex = 2;
            this.btnReload.Text = "Lọc";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(599, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trạng thái:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvMembers
            // 
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new System.Drawing.Point(26, 61);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.RowHeadersWidth = 51;
            this.dgvMembers.RowTemplate.Height = 24;
            this.dgvMembers.Size = new System.Drawing.Size(920, 453);
            this.dgvMembers.TabIndex = 4;
            // 
            // TrainerMembersForm
            // 
            this.ClientSize = new System.Drawing.Size(974, 536);
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.cboMembershipStatus);
            this.Controls.Add(this.lblTrainerName);
            this.Name = "TrainerMembersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách học viên của huấn luyện viên";
            this.Load += new System.EventHandler(this.TrainerMembersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTrainerName;
        private System.Windows.Forms.ComboBox cboMembershipStatus;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMembers;
    }
}