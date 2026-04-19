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
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.SuspendLayout();

            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new Point(20, 20);
            this.lblSearch.Text = "Tìm kiếm";

            this.txtSearch.Location = new Point(90, 16);
            this.txtSearch.Size = new Size(260, 22);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new Point(380, 20);
            this.lblStatus.Text = "Trạng thái";

            this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboStatus.Location = new Point(450, 16);
            this.cboStatus.Size = new Size(160, 24);
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);

            this.btnRefresh.Location = new Point(640, 12);
            this.btnRefresh.Size = new Size(90, 30);
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.btnViewDetail.Location = new Point(750, 12);
            this.btnViewDetail.Size = new Size(100, 30);
            this.btnViewDetail.Text = "Chi tiết";
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);

            this.btnRegister.Location = new Point(870, 12);
            this.btnRegister.Size = new Size(120, 30);
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.btnRenew.Location = new Point(1010, 12);
            this.btnRenew.Size = new Size(120, 30);
            this.btnRenew.Text = "Gia hạn";
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);

            this.dgvMembers.Location = new Point(20, 60);
            this.dgvMembers.Size = new Size(1110, 560);
            this.dgvMembers.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvMembers_CellDoubleClick);

            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1150, 640);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.btnViewDetail);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnRefresh);
            this.Name = "MembersForm";
            this.Text = "Quản lý hội viên";
            this.Load += new System.EventHandler(this.MembersForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}