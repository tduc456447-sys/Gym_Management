using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class MemberDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubTitle;
        private Panel pnlSummary;
        private Panel pnlStatMembership;
        private Panel pnlStatCheckin;
        private Panel pnlStatSpent;
        private Panel pnlStatSales;
        private Label lblStatMembershipTitle;
        private Label lblStatMembershipValue;
        private Label lblStatCheckinTitle;
        private Label lblStatCheckinValue;
        private Label lblStatSpentTitle;
        private Label lblStatSpentValue;
        private Label lblStatSalesTitle;
        private Label lblStatSalesValue;
        private Panel pnlProfile;
        private PictureBox picAvatar;
        private Label lblName;
        private Label lblPhone;
        private Label lblAddress;
        private Label lblIdentity;
        private Label lblCardCode;
        private Label lblProfileStatus;
        private Label lblCreatedAt;
        private Label lblCurrentPackage;
        private Label lblTrainer;
        private Label lblMembershipPeriod;
        private Label lblDaysLeft;
        private Button btnClose;
        private TabControl tabMain;
        private TabPage tabMemberships;
        private TabPage tabPayments;
        private TabPage tabCheckins;
        private TabPage tabPurchases;
        private DataGridView dgvMembershipHistory;
        private DataGridView dgvPaymentHistory;
        private DataGridView dgvCheckinHistory;
        private DataGridView dgvPurchaseHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblSubTitle = new Label();
            this.pnlSummary = new Panel();
            this.pnlStatMembership = new Panel();
            this.lblStatMembershipTitle = new Label();
            this.lblStatMembershipValue = new Label();
            this.pnlStatCheckin = new Panel();
            this.lblStatCheckinTitle = new Label();
            this.lblStatCheckinValue = new Label();
            this.pnlStatSpent = new Panel();
            this.lblStatSpentTitle = new Label();
            this.lblStatSpentValue = new Label();
            this.pnlStatSales = new Panel();
            this.lblStatSalesTitle = new Label();
            this.lblStatSalesValue = new Label();
            this.pnlProfile = new Panel();
            this.picAvatar = new PictureBox();
            this.lblName = new Label();
            this.lblPhone = new Label();
            this.lblAddress = new Label();
            this.lblIdentity = new Label();
            this.lblCardCode = new Label();
            this.lblProfileStatus = new Label();
            this.lblCreatedAt = new Label();
            this.lblCurrentPackage = new Label();
            this.lblTrainer = new Label();
            this.lblMembershipPeriod = new Label();
            this.lblDaysLeft = new Label();
            this.btnClose = new Button();
            this.tabMain = new TabControl();
            this.tabMemberships = new TabPage();
            this.dgvMembershipHistory = new DataGridView();
            this.tabPayments = new TabPage();
            this.dgvPaymentHistory = new DataGridView();
            this.tabCheckins = new TabPage();
            this.dgvCheckinHistory = new DataGridView();
            this.tabPurchases = new TabPage();
            this.dgvPurchaseHistory = new DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlStatMembership.SuspendLayout();
            this.pnlStatCheckin.SuspendLayout();
            this.pnlStatSpent.SuspendLayout();
            this.pnlStatSales.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabMemberships.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembershipHistory)).BeginInit();
            this.tabPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).BeginInit();
            this.tabCheckins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckinHistory)).BeginInit();
            this.tabPurchases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseHistory)).BeginInit();
            this.SuspendLayout();
            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new Padding(20, 15, 20, 10);
            this.pnlHeader.Size = new Size(1180, 80);
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(204, 32);
            this.lblTitle.Text = "Hồ sơ khách hàng";
            // lblSubTitle
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new Font("Segoe UI", 10F);
            this.lblSubTitle.Location = new Point(22, 48);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new Size(106, 19);
            this.lblSubTitle.Text = "Mã khách hàng:";
            // pnlSummary
            this.pnlSummary.Controls.Add(this.pnlStatMembership);
            this.pnlSummary.Controls.Add(this.pnlStatCheckin);
            this.pnlSummary.Controls.Add(this.pnlStatSpent);
            this.pnlSummary.Controls.Add(this.pnlStatSales);
            this.pnlSummary.Dock = DockStyle.Top;
            this.pnlSummary.Location = new Point(0, 80);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Padding = new Padding(20, 10, 20, 10);
            this.pnlSummary.Size = new Size(1180, 95);
            // pnlStatMembership
            this.pnlStatMembership.Controls.Add(this.lblStatMembershipTitle);
            this.pnlStatMembership.Controls.Add(this.lblStatMembershipValue);
            this.pnlStatMembership.Location = new Point(20, 10);
            this.pnlStatMembership.Name = "pnlStatMembership";
            this.pnlStatMembership.Size = new Size(265, 72);
            // lblStatMembershipTitle
            this.lblStatMembershipTitle.AutoSize = true;
            this.lblStatMembershipTitle.Font = new Font("Segoe UI", 10F);
            this.lblStatMembershipTitle.Location = new Point(14, 10);
            this.lblStatMembershipTitle.Text = "Tổng số gói tập";
            // lblStatMembershipValue
            this.lblStatMembershipValue.AutoSize = true;
            this.lblStatMembershipValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblStatMembershipValue.Location = new Point(12, 28);
            this.lblStatMembershipValue.Text = "0";
            // pnlStatCheckin
            this.pnlStatCheckin.Controls.Add(this.lblStatCheckinTitle);
            this.pnlStatCheckin.Controls.Add(this.lblStatCheckinValue);
            this.pnlStatCheckin.Location = new Point(305, 10);
            this.pnlStatCheckin.Name = "pnlStatCheckin";
            this.pnlStatCheckin.Size = new Size(265, 72);
            // lblStatCheckinTitle
            this.lblStatCheckinTitle.AutoSize = true;
            this.lblStatCheckinTitle.Font = new Font("Segoe UI", 10F);
            this.lblStatCheckinTitle.Location = new Point(14, 10);
            this.lblStatCheckinTitle.Text = "Tổng lượt check-in";
            // lblStatCheckinValue
            this.lblStatCheckinValue.AutoSize = true;
            this.lblStatCheckinValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblStatCheckinValue.Location = new Point(12, 28);
            this.lblStatCheckinValue.Text = "0";
            // pnlStatSpent
            this.pnlStatSpent.Controls.Add(this.lblStatSpentTitle);
            this.pnlStatSpent.Controls.Add(this.lblStatSpentValue);
            this.pnlStatSpent.Location = new Point(590, 10);
            this.pnlStatSpent.Name = "pnlStatSpent";
            this.pnlStatSpent.Size = new Size(265, 72);
            // lblStatSpentTitle
            this.lblStatSpentTitle.AutoSize = true;
            this.lblStatSpentTitle.Font = new Font("Segoe UI", 10F);
            this.lblStatSpentTitle.Location = new Point(14, 10);
            this.lblStatSpentTitle.Text = "Tổng chi gói tập";
            // lblStatSpentValue
            this.lblStatSpentValue.AutoSize = true;
            this.lblStatSpentValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblStatSpentValue.Location = new Point(12, 30);
            this.lblStatSpentValue.Text = "0 đ";
            // pnlStatSales
            this.pnlStatSales.Controls.Add(this.lblStatSalesTitle);
            this.pnlStatSales.Controls.Add(this.lblStatSalesValue);
            this.pnlStatSales.Location = new Point(875, 10);
            this.pnlStatSales.Name = "pnlStatSales";
            this.pnlStatSales.Size = new Size(285, 72);
            // lblStatSalesTitle
            this.lblStatSalesTitle.AutoSize = true;
            this.lblStatSalesTitle.Font = new Font("Segoe UI", 10F);
            this.lblStatSalesTitle.Location = new Point(14, 10);
            this.lblStatSalesTitle.Text = "Tổng chi mua hàng";
            // lblStatSalesValue
            this.lblStatSalesValue.AutoSize = true;
            this.lblStatSalesValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblStatSalesValue.Location = new Point(12, 30);
            this.lblStatSalesValue.Text = "0 đ";
            // pnlProfile
            this.pnlProfile.Controls.Add(this.picAvatar);
            this.pnlProfile.Controls.Add(this.lblName);
            this.pnlProfile.Controls.Add(this.lblPhone);
            this.pnlProfile.Controls.Add(this.lblAddress);
            this.pnlProfile.Controls.Add(this.lblIdentity);
            this.pnlProfile.Controls.Add(this.lblCardCode);
            this.pnlProfile.Controls.Add(this.lblProfileStatus);
            this.pnlProfile.Controls.Add(this.lblCreatedAt);
            this.pnlProfile.Controls.Add(this.lblCurrentPackage);
            this.pnlProfile.Controls.Add(this.lblTrainer);
            this.pnlProfile.Controls.Add(this.lblMembershipPeriod);
            this.pnlProfile.Controls.Add(this.lblDaysLeft);
            this.pnlProfile.Controls.Add(this.btnClose);
            this.pnlProfile.Dock = DockStyle.Top;
            this.pnlProfile.Location = new Point(0, 175);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Padding = new Padding(20, 10, 20, 10);
            this.pnlProfile.Size = new Size(1180, 210);
            // picAvatar
            this.picAvatar.BorderStyle = BorderStyle.FixedSingle;
            this.picAvatar.Location = new Point(20, 15);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new Size(150, 170);
            this.picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblName.Location = new Point(190, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(115, 30);
            this.lblName.Text = "Họ và tên";
            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new Font("Segoe UI", 10F);
            this.lblPhone.Location = new Point(192, 58);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new Size(41, 19);
            this.lblPhone.Text = "SĐT:";
            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new Font("Segoe UI", 10F);
            this.lblAddress.Location = new Point(192, 84);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new Size(55, 19);
            this.lblAddress.Text = "Địa chỉ:";
            // lblIdentity
            this.lblIdentity.AutoSize = true;
            this.lblIdentity.Font = new Font("Segoe UI", 10F);
            this.lblIdentity.Location = new Point(192, 110);
            this.lblIdentity.Name = "lblIdentity";
            this.lblIdentity.Size = new Size(48, 19);
            this.lblIdentity.Text = "CCCD:";
            // lblCardCode
            this.lblCardCode.AutoSize = true;
            this.lblCardCode.Font = new Font("Segoe UI", 10F);
            this.lblCardCode.Location = new Point(192, 136);
            this.lblCardCode.Name = "lblCardCode";
            this.lblCardCode.Size = new Size(60, 19);
            this.lblCardCode.Text = "Mã thẻ:";
            // lblProfileStatus
            this.lblProfileStatus.AutoSize = true;
            this.lblProfileStatus.Font = new Font("Segoe UI", 10F);
            this.lblProfileStatus.Location = new Point(192, 162);
            this.lblProfileStatus.Name = "lblProfileStatus";
            this.lblProfileStatus.Size = new Size(103, 19);
            this.lblProfileStatus.Text = "Trạng thái hồ sơ:";
            // lblCreatedAt
            this.lblCreatedAt.AutoSize = true;
            this.lblCreatedAt.Font = new Font("Segoe UI", 10F);
            this.lblCreatedAt.Location = new Point(620, 20);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new Size(98, 19);
            this.lblCreatedAt.Text = "Ngày tạo KH:";
            // lblCurrentPackage
            this.lblCurrentPackage.AutoSize = true;
            this.lblCurrentPackage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCurrentPackage.Location = new Point(620, 58);
            this.lblCurrentPackage.Name = "lblCurrentPackage";
            this.lblCurrentPackage.Size = new Size(92, 19);
            this.lblCurrentPackage.Text = "Gói hiện tại:";
            // lblTrainer
            this.lblTrainer.AutoSize = true;
            this.lblTrainer.Font = new Font("Segoe UI", 10F);
            this.lblTrainer.Location = new Point(620, 84);
            this.lblTrainer.Name = "lblTrainer";
            this.lblTrainer.Size = new Size(79, 19);
            this.lblTrainer.Text = "PT hiện tại:";
            // lblMembershipPeriod
            this.lblMembershipPeriod.AutoSize = true;
            this.lblMembershipPeriod.Font = new Font("Segoe UI", 10F);
            this.lblMembershipPeriod.Location = new Point(620, 110);
            this.lblMembershipPeriod.Name = "lblMembershipPeriod";
            this.lblMembershipPeriod.Size = new Size(60, 19);
            this.lblMembershipPeriod.Text = "Thời hạn:";
            // lblDaysLeft
            this.lblDaysLeft.AutoSize = true;
            this.lblDaysLeft.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDaysLeft.ForeColor = Color.Firebrick;
            this.lblDaysLeft.Location = new Point(620, 136);
            this.lblDaysLeft.Name = "lblDaysLeft";
            this.lblDaysLeft.Size = new Size(61, 19);
            this.lblDaysLeft.Text = "Còn lại:";
            // btnClose
            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Location = new Point(1045, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(115, 34);
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // tabMain
            this.tabMain.Controls.Add(this.tabMemberships);
            this.tabMain.Controls.Add(this.tabPayments);
            this.tabMain.Controls.Add(this.tabCheckins);
            this.tabMain.Controls.Add(this.tabPurchases);
            this.tabMain.Dock = DockStyle.Fill;
            this.tabMain.Font = new Font("Segoe UI", 10F);
            this.tabMain.Location = new Point(0, 385);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new Size(1180, 335);
            // tabMemberships
            this.tabMemberships.Controls.Add(this.dgvMembershipHistory);
            this.tabMemberships.Location = new Point(4, 26);
            this.tabMemberships.Name = "tabMemberships";
            this.tabMemberships.Padding = new Padding(10);
            this.tabMemberships.Size = new Size(1172, 305);
            this.tabMemberships.Text = "Lịch sử gói tập";
            this.tabMemberships.UseVisualStyleBackColor = true;
            // dgvMembershipHistory
            this.dgvMembershipHistory.Dock = DockStyle.Fill;
            this.dgvMembershipHistory.Location = new Point(10, 10);
            this.dgvMembershipHistory.Name = "dgvMembershipHistory";
            this.dgvMembershipHistory.Size = new Size(1152, 285);
            // tabPayments
            this.tabPayments.Controls.Add(this.dgvPaymentHistory);
            this.tabPayments.Location = new Point(4, 26);
            this.tabPayments.Name = "tabPayments";
            this.tabPayments.Padding = new Padding(10);
            this.tabPayments.Size = new Size(1172, 305);
            this.tabPayments.Text = "Thanh toán gói tập";
            this.tabPayments.UseVisualStyleBackColor = true;
            // dgvPaymentHistory
            this.dgvPaymentHistory.Dock = DockStyle.Fill;
            this.dgvPaymentHistory.Location = new Point(10, 10);
            this.dgvPaymentHistory.Name = "dgvPaymentHistory";
            this.dgvPaymentHistory.Size = new Size(1152, 285);
            // tabCheckins
            this.tabCheckins.Controls.Add(this.dgvCheckinHistory);
            this.tabCheckins.Location = new Point(4, 26);
            this.tabCheckins.Name = "tabCheckins";
            this.tabCheckins.Padding = new Padding(10);
            this.tabCheckins.Size = new Size(1172, 305);
            this.tabCheckins.Text = "Lịch sử check-in";
            this.tabCheckins.UseVisualStyleBackColor = true;
            // dgvCheckinHistory
            this.dgvCheckinHistory.Dock = DockStyle.Fill;
            this.dgvCheckinHistory.Location = new Point(10, 10);
            this.dgvCheckinHistory.Name = "dgvCheckinHistory";
            this.dgvCheckinHistory.Size = new Size(1152, 285);
            // tabPurchases
            this.tabPurchases.Controls.Add(this.dgvPurchaseHistory);
            this.tabPurchases.Location = new Point(4, 26);
            this.tabPurchases.Name = "tabPurchases";
            this.tabPurchases.Padding = new Padding(10);
            this.tabPurchases.Size = new Size(1172, 305);
            this.tabPurchases.Text = "Mua hàng";
            this.tabPurchases.UseVisualStyleBackColor = true;
            // dgvPurchaseHistory
            this.dgvPurchaseHistory.Dock = DockStyle.Fill;
            this.dgvPurchaseHistory.Location = new Point(10, 10);
            this.dgvPurchaseHistory.Name = "dgvPurchaseHistory";
            this.dgvPurchaseHistory.Size = new Size(1152, 285);
            // MemberDetailForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1180, 720);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlProfile);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlHeader);
            this.Font = new Font("Segoe UI", 9F);
            this.MinimumSize = new Size(1100, 680);
            this.Name = "MemberDetailForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Hồ sơ khách hàng";
            this.Load += new System.EventHandler(this.MemberDetailForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlStatMembership.ResumeLayout(false);
            this.pnlStatMembership.PerformLayout();
            this.pnlStatCheckin.ResumeLayout(false);
            this.pnlStatCheckin.PerformLayout();
            this.pnlStatSpent.ResumeLayout(false);
            this.pnlStatSpent.PerformLayout();
            this.pnlStatSales.ResumeLayout(false);
            this.pnlStatSales.PerformLayout();
            this.pnlProfile.ResumeLayout(false);
            this.pnlProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabMemberships.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembershipHistory)).EndInit();
            this.tabPayments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).EndInit();
            this.tabCheckins.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckinHistory)).EndInit();
            this.tabPurchases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseHistory)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
