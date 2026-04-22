using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class RegisterMembershipForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cboCustomer;
        private Button btnAddCustomer;
        private ComboBox cboPackage;
        private ComboBox cboTrainer;
        private DateTimePicker dtpStartDate;
        private TextBox txtAvatar;
        private Button btnChooseAvatar;
        private Button btnClearAvatar;
        private PictureBox pbAvatar;
        private TextBox txtIdentity;
        private TextBox txtCardCode;
        private TextBox txtTotal;
        private ComboBox cboPaymentMethod;
        private TextBox txtCashReceived;
        private TextBox txtChange;
        private Button btnRegister;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.cboPackage = new System.Windows.Forms.ComboBox();
            this.cboTrainer = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtAvatar = new System.Windows.Forms.TextBox();
            this.btnChooseAvatar = new System.Windows.Forms.Button();
            this.btnClearAvatar = new System.Windows.Forms.Button();
            this.txtIdentity = new System.Windows.Forms.TextBox();
            this.txtCardCode = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(160, 20);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(320, 24);
            this.cboCustomer.TabIndex = 1;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(492, 18);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(110, 30);
            this.btnAddCustomer.TabIndex = 2;
            this.btnAddCustomer.Text = "Khách mới";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // cboPackage
            // 
            this.cboPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPackage.FormattingEnabled = true;
            this.cboPackage.Location = new System.Drawing.Point(160, 62);
            this.cboPackage.Name = "cboPackage";
            this.cboPackage.Size = new System.Drawing.Size(442, 24);
            this.cboPackage.TabIndex = 4;
            this.cboPackage.SelectedIndexChanged += new System.EventHandler(this.cboPackage_SelectedIndexChanged);
            // 
            // cboTrainer
            // 
            this.cboTrainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrainer.FormattingEnabled = true;
            this.cboTrainer.Location = new System.Drawing.Point(160, 104);
            this.cboTrainer.Name = "cboTrainer";
            this.cboTrainer.Size = new System.Drawing.Size(442, 24);
            this.cboTrainer.TabIndex = 6;
            this.cboTrainer.SelectedIndexChanged += new System.EventHandler(this.cboTrainer_SelectedIndexChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(160, 146);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(180, 22);
            this.dtpStartDate.TabIndex = 8;
            // 
            // txtAvatar
            // 
            this.txtAvatar.Location = new System.Drawing.Point(160, 190);
            this.txtAvatar.Name = "txtAvatar";
            this.txtAvatar.Size = new System.Drawing.Size(320, 22);
            this.txtAvatar.TabIndex = 10;
            // 
            // btnChooseAvatar
            // 
            this.btnChooseAvatar.Location = new System.Drawing.Point(492, 186);
            this.btnChooseAvatar.Name = "btnChooseAvatar";
            this.btnChooseAvatar.Size = new System.Drawing.Size(110, 30);
            this.btnChooseAvatar.TabIndex = 11;
            this.btnChooseAvatar.Text = "Chọn ảnh";
            this.btnChooseAvatar.UseVisualStyleBackColor = true;
            this.btnChooseAvatar.Click += new System.EventHandler(this.btnChooseAvatar_Click);
            // 
            // btnClearAvatar
            // 
            this.btnClearAvatar.Location = new System.Drawing.Point(492, 222);
            this.btnClearAvatar.Name = "btnClearAvatar";
            this.btnClearAvatar.Size = new System.Drawing.Size(110, 30);
            this.btnClearAvatar.TabIndex = 12;
            this.btnClearAvatar.Text = "Xóa ảnh";
            this.btnClearAvatar.UseVisualStyleBackColor = true;
            this.btnClearAvatar.Click += new System.EventHandler(this.btnClearAvatar_Click);
            // 
            // txtIdentity
            // 
            this.txtIdentity.Location = new System.Drawing.Point(378, 222);
            this.txtIdentity.Name = "txtIdentity";
            this.txtIdentity.Size = new System.Drawing.Size(102, 22);
            this.txtIdentity.TabIndex = 15;
            this.txtIdentity.TextChanged += new System.EventHandler(this.txtIdentity_TextChanged);
            // 
            // txtCardCode
            // 
            this.txtCardCode.Enabled = false;
            this.txtCardCode.Location = new System.Drawing.Point(378, 264);
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.ReadOnly = true;
            this.txtCardCode.Size = new System.Drawing.Size(102, 22);
            this.txtCardCode.TabIndex = 17;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(395, 306);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(85, 22);
            this.txtTotal.TabIndex = 19;
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Online"});
            this.cboPaymentMethod.Location = new System.Drawing.Point(160, 388);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(180, 24);
            this.cboPaymentMethod.TabIndex = 21;
            this.cboPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cboPaymentMethod_SelectedIndexChanged);
            // 
            // txtCashReceived
            // 
            this.txtCashReceived.Location = new System.Drawing.Point(160, 430);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Size = new System.Drawing.Size(180, 22);
            this.txtCashReceived.TabIndex = 23;
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);
            // 
            // txtChange
            // 
            this.txtChange.Location = new System.Drawing.Point(160, 472);
            this.txtChange.Name = "txtChange";
            this.txtChange.Size = new System.Drawing.Size(180, 22);
            this.txtChange.TabIndex = 25;
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(160, 520);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(220, 42);
            this.btnRegister.TabIndex = 26;
            this.btnRegister.Text = "Xác nhận đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gói tập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "PT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ngày bắt đầu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ảnh thẻ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "CCCD";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Mã thẻ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(330, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Tổng tiền";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 392);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Thanh toán";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 434);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Khách đưa";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 476);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "Tiền thừa";
            // 
            // pbAvatar
            // 
            this.pbAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAvatar.Location = new System.Drawing.Point(160, 222);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(150, 150);
            this.pbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAvatar.TabIndex = 13;
            this.pbAvatar.TabStop = false;
            // 
            // RegisterMembershipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 590);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCashReceived);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboPaymentMethod);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCardCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIdentity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pbAvatar);
            this.Controls.Add(this.btnClearAvatar);
            this.Controls.Add(this.btnChooseAvatar);
            this.Controls.Add(this.txtAvatar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboTrainer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboPackage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterMembershipForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký hội viên";
            this.Load += new System.EventHandler(this.RegisterMembershipForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
