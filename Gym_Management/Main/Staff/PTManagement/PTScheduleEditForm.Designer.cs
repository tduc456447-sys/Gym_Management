using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class PTScheduleEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMembership;
        private ComboBox cboMembership;
        private GroupBox grpInfo;
        private Label lblMember;
        private Label lblPhone;
        private Label lblTrainer;
        private Label lblPackage;
        private Label lblExpire;
        private Label lblMemberValue;
        private Label lblPhoneValue;
        private Label lblTrainerValue;
        private Label lblPackageValue;
        private Label lblExpireValue;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Label lblStart;
        private DateTimePicker dtpStart;
        private Label lblEnd;
        private DateTimePicker dtpEnd;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Label lblNote;
        private TextBox txtNote;
        private Button btnSave;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMembership = new Label();
            this.cboMembership = new ComboBox();
            this.grpInfo = new GroupBox();
            this.lblMember = new Label();
            this.lblPhone = new Label();
            this.lblTrainer = new Label();
            this.lblPackage = new Label();
            this.lblExpire = new Label();
            this.lblMemberValue = new Label();
            this.lblPhoneValue = new Label();
            this.lblTrainerValue = new Label();
            this.lblPackageValue = new Label();
            this.lblExpireValue = new Label();
            this.lblDate = new Label();
            this.dtpDate = new DateTimePicker();
            this.lblStart = new Label();
            this.dtpStart = new DateTimePicker();
            this.lblEnd = new Label();
            this.dtpEnd = new DateTimePicker();
            this.lblStatus = new Label();
            this.cboStatus = new ComboBox();
            this.lblNote = new Label();
            this.txtNote = new TextBox();
            this.btnSave = new Button();
            this.btnClose = new Button();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMembership
            // 
            this.lblMembership.AutoSize = true;
            this.lblMembership.Location = new Point(24, 24);
            this.lblMembership.Name = "lblMembership";
            this.lblMembership.Size = new Size(143, 16);
            this.lblMembership.TabIndex = 0;
            this.lblMembership.Text = "Hội viên đang có PT:";
            // 
            // cboMembership
            // 
            this.cboMembership.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboMembership.FormattingEnabled = true;
            this.cboMembership.Location = new Point(173, 20);
            this.cboMembership.Name = "cboMembership";
            this.cboMembership.Size = new Size(464, 24);
            this.cboMembership.TabIndex = 1;
            this.cboMembership.SelectedIndexChanged += new System.EventHandler(this.cboMembership_SelectedIndexChanged);
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblMember);
            this.grpInfo.Controls.Add(this.lblPhone);
            this.grpInfo.Controls.Add(this.lblTrainer);
            this.grpInfo.Controls.Add(this.lblPackage);
            this.grpInfo.Controls.Add(this.lblExpire);
            this.grpInfo.Controls.Add(this.lblMemberValue);
            this.grpInfo.Controls.Add(this.lblPhoneValue);
            this.grpInfo.Controls.Add(this.lblTrainerValue);
            this.grpInfo.Controls.Add(this.lblPackageValue);
            this.grpInfo.Controls.Add(this.lblExpireValue);
            this.grpInfo.Location = new Point(27, 61);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new Size(610, 129);
            this.grpInfo.TabIndex = 2;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Thông tin membership";
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Location = new Point(18, 28);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new Size(63, 16);
            this.lblMember.TabIndex = 0;
            this.lblMember.Text = "Hội viên:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new Point(18, 57);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new Size(41, 16);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "SĐT:";
            // 
            // lblTrainer
            // 
            this.lblTrainer.AutoSize = true;
            this.lblTrainer.Location = new Point(18, 86);
            this.lblTrainer.Name = "lblTrainer";
            this.lblTrainer.Size = new Size(28, 16);
            this.lblTrainer.TabIndex = 2;
            this.lblTrainer.Text = "PT:";
            // 
            // lblPackage
            // 
            this.lblPackage.AutoSize = true;
            this.lblPackage.Location = new Point(316, 28);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new Size(53, 16);
            this.lblPackage.TabIndex = 3;
            this.lblPackage.Text = "Gói tập:";
            // 
            // lblExpire
            // 
            this.lblExpire.AutoSize = true;
            this.lblExpire.Location = new Point(316, 57);
            this.lblExpire.Name = "lblExpire";
            this.lblExpire.Size = new Size(78, 16);
            this.lblExpire.TabIndex = 4;
            this.lblExpire.Text = "Hạn gói tập:";
            // 
            // lblMemberValue
            // 
            this.lblMemberValue.Location = new Point(98, 28);
            this.lblMemberValue.Name = "lblMemberValue";
            this.lblMemberValue.Size = new Size(195, 18);
            this.lblMemberValue.TabIndex = 5;
            // 
            // lblPhoneValue
            // 
            this.lblPhoneValue.Location = new Point(98, 57);
            this.lblPhoneValue.Name = "lblPhoneValue";
            this.lblPhoneValue.Size = new Size(195, 18);
            this.lblPhoneValue.TabIndex = 6;
            // 
            // lblTrainerValue
            // 
            this.lblTrainerValue.Location = new Point(98, 86);
            this.lblTrainerValue.Name = "lblTrainerValue";
            this.lblTrainerValue.Size = new Size(195, 18);
            this.lblTrainerValue.TabIndex = 7;
            // 
            // lblPackageValue
            // 
            this.lblPackageValue.Location = new Point(401, 28);
            this.lblPackageValue.Name = "lblPackageValue";
            this.lblPackageValue.Size = new Size(188, 18);
            this.lblPackageValue.TabIndex = 8;
            // 
            // lblExpireValue
            // 
            this.lblExpireValue.Location = new Point(401, 57);
            this.lblExpireValue.Name = "lblExpireValue";
            this.lblExpireValue.Size = new Size(188, 18);
            this.lblExpireValue.TabIndex = 9;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new Point(24, 213);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new Size(62, 16);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Ngày tập:";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = DateTimePickerFormat.Short;
            this.dtpDate.Location = new Point(173, 208);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new Size(170, 22);
            this.dtpDate.TabIndex = 4;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new Point(24, 247);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new Size(82, 16);
            this.lblStart.TabIndex = 5;
            this.lblStart.Text = "Giờ bắt đầu:";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = DateTimePickerFormat.Time;
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Location = new Point(173, 242);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new Size(170, 22);
            this.dtpStart.TabIndex = 6;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new Point(24, 281);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new Size(86, 16);
            this.lblEnd.TabIndex = 7;
            this.lblEnd.Text = "Giờ kết thúc:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = DateTimePickerFormat.Time;
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Location = new Point(173, 276);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new Size(170, 22);
            this.dtpEnd.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new Point(24, 315);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(71, 16);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new Point(173, 310);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new Size(170, 24);
            this.cboStatus.TabIndex = 10;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new Point(24, 350);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new Size(56, 16);
            this.lblNote.TabIndex = 11;
            this.lblNote.Text = "Ghi chú:";
            // 
            // txtNote
            // 
            this.txtNote.Location = new Point(173, 346);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new Size(464, 71);
            this.txtNote.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new Point(446, 433);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(94, 34);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Lưu lịch";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new Point(546, 433);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(91, 34);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PTScheduleEditForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(666, 489);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.cboMembership);
            this.Controls.Add(this.lblMembership);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PTScheduleEditForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Lịch PT";
            this.Load += new System.EventHandler(this.PTScheduleEditForm_Load);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
