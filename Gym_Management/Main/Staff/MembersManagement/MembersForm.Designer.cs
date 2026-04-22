using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class MembersForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtSearch;
        private ComboBox cboStatus;
        private Label lblSearch;
        private Label lblStatus;
        private DataGridView dgvMembers;
        private Button btnViewDetail;
        private Button btnRegister;
        private Button btnRenew;
        private Button btnRefresh;
        private Button btnCheckin;
        private Panel pnlTop;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSearch = new TextBox();
            this.cboStatus = new ComboBox();
            this.lblSearch = new Label();
            this.lblStatus = new Label();
            this.dgvMembers = new DataGridView();
            this.btnViewDetail = new Button();
            this.btnRegister = new Button();
            this.btnRenew = new Button();
            this.btnRefresh = new Button();
            this.btnCheckin = new Button();
            this.pnlTop = new Panel();
            this.lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = Color.WhiteSmoke;
            this.pnlTop.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblStatus);
            this.pnlTop.Controls.Add(this.cboStatus);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnViewDetail);
            this.pnlTop.Controls.Add(this.btnRegister);
            this.pnlTop.Controls.Add(this.btnRenew);
            this.pnlTop.Controls.Add(this.btnCheckin);
            this.pnlTop.Location = new Point(12, 12);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(1186, 92);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(14, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(157, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý hội viên";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new Point(16, 55);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new Size(64, 16);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new Point(86, 51);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new Size(280, 22);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new Point(390, 55);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(67, 16);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Trạng thái";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new Point(463, 50);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new Size(150, 24);
            this.cboStatus.TabIndex = 4;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = Color.White;
            this.btnRefresh.Location = new Point(637, 46);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(96, 32);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.BackColor = Color.White;
            this.btnViewDetail.Location = new Point(748, 46);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new Size(96, 32);
            this.btnViewDetail.TabIndex = 6;
            this.btnViewDetail.Text = "Chi tiết";
            this.btnViewDetail.UseVisualStyleBackColor = false;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = Color.White;
            this.btnRegister.Location = new Point(859, 46);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new Size(96, 32);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.BackColor = Color.White;
            this.btnRenew.Location = new Point(970, 46);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new Size(96, 32);
            this.btnRenew.TabIndex = 8;
            this.btnRenew.Text = "Gia hạn";
            this.btnRenew.UseVisualStyleBackColor = false;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // btnCheckin
            // 
            this.btnCheckin.BackColor = Color.White;
            this.btnCheckin.Location = new Point(1081, 46);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new Size(90, 32);
            this.btnCheckin.TabIndex = 9;
            this.btnCheckin.Text = "Check-in";
            this.btnCheckin.UseVisualStyleBackColor = false;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // dgvMembers
            // 
            this.dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new Point(12, 118);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.RowHeadersWidth = 51;
            this.dgvMembers.RowTemplate.Height = 24;
            this.dgvMembers.Size = new Size(1186, 550);
            this.dgvMembers.TabIndex = 1;
            this.dgvMembers.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvMembers_CellDoubleClick);
            // 
            // MembersForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1210, 680);
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.pnlTop);
            this.Name = "MembersForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý hội viên";
            this.Load += new System.EventHandler(this.MembersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
