using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class MemberDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picAvatar;
        private Label lblName;
        private Label lblPhone;
        private Label lblAddress;
        private Label lblCard;
        private Label lblIdentity;
        private Label lblStatus;
        private DataGridView dgvMembershipHistory;
        private DataGridView dgvPaymentHistory;
        private Label lblHistory1;
        private Label lblHistory2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picAvatar = new PictureBox();
            this.lblName = new Label();
            this.lblPhone = new Label();
            this.lblAddress = new Label();
            this.lblCard = new Label();
            this.lblIdentity = new Label();
            this.lblStatus = new Label();
            this.dgvMembershipHistory = new DataGridView();
            this.dgvPaymentHistory = new DataGridView();
            this.lblHistory1 = new Label();
            this.lblHistory2 = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembershipHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).BeginInit();
            this.SuspendLayout();

            this.picAvatar.BorderStyle = BorderStyle.FixedSingle;
            this.picAvatar.Location = new Point(20, 20);
            this.picAvatar.Size = new Size(140, 160);
            this.picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;

            this.lblName.Location = new Point(180, 20);
            this.lblName.Size = new Size(450, 24);
            this.lblName.Text = "Họ tên:";

            this.lblPhone.Location = new Point(180, 50);
            this.lblPhone.Size = new Size(450, 24);
            this.lblPhone.Text = "SĐT:";

            this.lblAddress.Location = new Point(180, 80);
            this.lblAddress.Size = new Size(500, 24);
            this.lblAddress.Text = "Địa chỉ:";

            this.lblCard.Location = new Point(180, 110);
            this.lblCard.Size = new Size(450, 24);
            this.lblCard.Text = "Mã thẻ:";

            this.lblIdentity.Location = new Point(180, 140);
            this.lblIdentity.Size = new Size(450, 24);
            this.lblIdentity.Text = "CCCD:";

            this.lblStatus.Location = new Point(180, 170);
            this.lblStatus.Size = new Size(450, 24);
            this.lblStatus.Text = "Trạng thái hồ sơ:";

            this.lblHistory1.Location = new Point(20, 210);
            this.lblHistory1.Size = new Size(250, 24);
            this.lblHistory1.Text = "Lịch sử gói tập";

            this.dgvMembershipHistory.Location = new Point(20, 240);
            this.dgvMembershipHistory.Size = new Size(920, 180);

            this.lblHistory2.Location = new Point(20, 435);
            this.lblHistory2.Size = new Size(250, 24);
            this.lblHistory2.Text = "Lịch sử thanh toán";

            this.dgvPaymentHistory.Location = new Point(20, 465);
            this.dgvPaymentHistory.Size = new Size(920, 190);

            this.ClientSize = new Size(960, 680);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.lblIdentity);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblHistory1);
            this.Controls.Add(this.dgvMembershipHistory);
            this.Controls.Add(this.lblHistory2);
            this.Controls.Add(this.dgvPaymentHistory);
            this.Name = "MemberDetailForm";
            this.Text = "Chi tiết hội viên";
            this.Load += new System.EventHandler(this.MemberDetailForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembershipHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).EndInit();
            this.ResumeLayout(false);
        }
    }
}