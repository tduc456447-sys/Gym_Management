using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class CheckinForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblCardInput;
        private TextBox txtCardCode;
        private Button btnFind;
        private Button btnClear;
        private PictureBox picAvatar;
        private GroupBox grpMemberInfo;
        private Label lblMemberName;
        private Label lblPhone;
        private Label lblCardCode;
        private Label lblPackage;
        private Label lblDateRange;
        private Label lblMembershipStatus;
        private Label lblCheckinNote;
        private Button btnCheckin;
        private GroupBox grpToday;
        private DataGridView dgvTodayCheckins;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblCardInput = new Label();
            this.txtCardCode = new TextBox();
            this.btnFind = new Button();
            this.btnClear = new Button();
            this.picAvatar = new PictureBox();
            this.grpMemberInfo = new GroupBox();
            this.lblMemberName = new Label();
            this.lblPhone = new Label();
            this.lblCardCode = new Label();
            this.lblPackage = new Label();
            this.lblDateRange = new Label();
            this.lblMembershipStatus = new Label();
            this.lblCheckinNote = new Label();
            this.btnCheckin = new Button();
            this.grpToday = new GroupBox();
            this.dgvTodayCheckins = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.grpMemberInfo.SuspendLayout();
            this.grpToday.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayCheckins)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(400, 35);
            this.lblTitle.Text = "Check-in hội viên";

            this.lblCardInput.AutoSize = true;
            this.lblCardInput.Location = new Point(22, 68);
            this.lblCardInput.Name = "lblCardInput";
            this.lblCardInput.Size = new Size(49, 16);
            this.lblCardInput.Text = "Mã thẻ";

            this.txtCardCode.Font = new Font("Segoe UI", 11F);
            this.txtCardCode.Location = new Point(110, 60);
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.Size = new Size(280, 32);
            this.txtCardCode.KeyDown += new KeyEventHandler(this.txtCardCode_KeyDown);

            this.btnFind.Location = new Point(405, 58);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new Size(95, 36);
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);

            this.btnClear.Location = new Point(510, 58);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(95, 36);
            this.btnClear.Text = "Xóa";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.picAvatar.BorderStyle = BorderStyle.FixedSingle;
            this.picAvatar.Location = new Point(18, 32);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new Size(180, 210);
            this.picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;

            this.grpMemberInfo.Controls.Add(this.picAvatar);
            this.grpMemberInfo.Controls.Add(this.lblMemberName);
            this.grpMemberInfo.Controls.Add(this.lblPhone);
            this.grpMemberInfo.Controls.Add(this.lblCardCode);
            this.grpMemberInfo.Controls.Add(this.lblPackage);
            this.grpMemberInfo.Controls.Add(this.lblDateRange);
            this.grpMemberInfo.Controls.Add(this.lblMembershipStatus);
            this.grpMemberInfo.Controls.Add(this.lblCheckinNote);
            this.grpMemberInfo.Controls.Add(this.btnCheckin);
            this.grpMemberInfo.Location = new Point(25, 115);
            this.grpMemberInfo.Name = "grpMemberInfo";
            this.grpMemberInfo.Size = new Size(920, 265);
            this.grpMemberInfo.TabStop = false;
            this.grpMemberInfo.Text = "Thông tin hội viên";

            this.lblMemberName.Location = new Point(220, 35);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new Size(650, 24);
            this.lblMemberName.Text = "Họ tên:";

            this.lblPhone.Location = new Point(220, 67);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new Size(650, 24);
            this.lblPhone.Text = "SĐT:";

            this.lblCardCode.Location = new Point(220, 99);
            this.lblCardCode.Name = "lblCardCode";
            this.lblCardCode.Size = new Size(650, 24);
            this.lblCardCode.Text = "Mã thẻ:";

            this.lblPackage.Location = new Point(220, 131);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new Size(650, 24);
            this.lblPackage.Text = "Gói hiện tại:";

            this.lblDateRange.Location = new Point(220, 163);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new Size(650, 24);
            this.lblDateRange.Text = "Hiệu lực:";

            this.lblMembershipStatus.Location = new Point(220, 195);
            this.lblMembershipStatus.Name = "lblMembershipStatus";
            this.lblMembershipStatus.Size = new Size(650, 24);
            this.lblMembershipStatus.Text = "Trạng thái gói:";

            this.lblCheckinNote.Location = new Point(220, 227);
            this.lblCheckinNote.Name = "lblCheckinNote";
            this.lblCheckinNote.Size = new Size(470, 24);
            this.lblCheckinNote.Text = "Ghi chú:";

            this.btnCheckin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnCheckin.Location = new Point(720, 210);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new Size(170, 40);
            this.btnCheckin.Text = "Check-in";
            this.btnCheckin.UseVisualStyleBackColor = true;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);

            this.grpToday.Controls.Add(this.dgvTodayCheckins);
            this.grpToday.Location = new Point(25, 395);
            this.grpToday.Name = "grpToday";
            this.grpToday.Size = new Size(920, 280);
            this.grpToday.TabStop = false;
            this.grpToday.Text = "Danh sách check-in hôm nay";

            this.dgvTodayCheckins.Location = new Point(18, 28);
            this.dgvTodayCheckins.Name = "dgvTodayCheckins";
            this.dgvTodayCheckins.Size = new Size(872, 230);

            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(972, 695);
            this.Controls.Add(this.grpToday);
            this.Controls.Add(this.grpMemberInfo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtCardCode);
            this.Controls.Add(this.lblCardInput);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CheckinForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Check-in hội viên";
            this.Load += new System.EventHandler(this.CheckinForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.grpMemberInfo.ResumeLayout(false);
            this.grpToday.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayCheckins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
