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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cboCustomer = new ComboBox();
            this.btnAddCustomer = new Button();
            this.cboPackage = new ComboBox();
            this.cboTrainer = new ComboBox();
            this.dtpStartDate = new DateTimePicker();
            this.txtAvatar = new TextBox();
            this.txtIdentity = new TextBox();
            this.txtCardCode = new TextBox();
            this.txtTotal = new TextBox();
            this.cboPaymentMethod = new ComboBox();
            this.txtCashReceived = new TextBox();
            this.txtChange = new TextBox();
            this.btnRegister = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label10 = new Label();
            this.SuspendLayout();

            this.label1.Location = new Point(20, 20);
            this.label1.Size = new Size(120, 23);
            this.label1.Text = "Khách hàng";

            this.cboCustomer.Location = new Point(160, 20);
            this.cboCustomer.Size = new Size(250, 24);

            this.btnAddCustomer.Location = new Point(420, 18);
            this.btnAddCustomer.Size = new Size(90, 28);
            this.btnAddCustomer.Text = "Khách mới";
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);

            this.label2.Location = new Point(20, 60);
            this.label2.Size = new Size(120, 23);
            this.label2.Text = "Gói tập";

            this.cboPackage.Location = new Point(160, 60);
            this.cboPackage.Size = new Size(350, 24);
            this.cboPackage.SelectedIndexChanged += new System.EventHandler(this.cboPackage_SelectedIndexChanged);

            this.label3.Location = new Point(20, 100);
            this.label3.Size = new Size(120, 23);
            this.label3.Text = "PT";

            this.cboTrainer.Location = new Point(160, 100);
            this.cboTrainer.Size = new Size(350, 24);
            this.cboTrainer.SelectedIndexChanged += new System.EventHandler(this.cboTrainer_SelectedIndexChanged);

            this.label4.Location = new Point(20, 140);
            this.label4.Size = new Size(120, 23);
            this.label4.Text = "Ngày bắt đầu";

            this.dtpStartDate.Location = new Point(160, 140);
            this.dtpStartDate.Size = new Size(350, 22);

            this.label5.Location = new Point(20, 180);
            this.label5.Size = new Size(120, 23);
            this.label5.Text = "Avatar";

            this.txtAvatar.Location = new Point(160, 180);
            this.txtAvatar.Size = new Size(350, 22);

            this.label6.Location = new Point(20, 220);
            this.label6.Size = new Size(120, 23);
            this.label6.Text = "CCCD";

            this.txtIdentity.Location = new Point(160, 220);
            this.txtIdentity.Size = new Size(350, 22);

            this.label7.Location = new Point(20, 260);
            this.label7.Size = new Size(120, 23);
            this.label7.Text = "Mã thẻ";

            this.txtCardCode.Location = new Point(160, 260);
            this.txtCardCode.Size = new Size(350, 22);

            this.label8.Location = new Point(20, 300);
            this.label8.Size = new Size(120, 23);
            this.label8.Text = "Tổng tiền";

            this.txtTotal.Location = new Point(160, 300);
            this.txtTotal.Size = new Size(350, 22);
            this.txtTotal.ReadOnly = true;

            this.label9.Location = new Point(20, 340);
            this.label9.Size = new Size(120, 23);
            this.label9.Text = "Thanh toán";

            this.cboPaymentMethod.Location = new Point(160, 340);
            this.cboPaymentMethod.Size = new Size(350, 24);
            this.cboPaymentMethod.Items.AddRange(new object[] { "Cash", "Online" });
            this.cboPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cboPaymentMethod_SelectedIndexChanged);

            this.label10.Location = new Point(20, 380);
            this.label10.Size = new Size(120, 23);
            this.label10.Text = "Khách đưa";

            this.txtCashReceived.Location = new Point(160, 380);
            this.txtCashReceived.Size = new Size(350, 22);
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);

            Label lbl11 = new Label();
            lbl11.Location = new Point(20, 420);
            lbl11.Size = new Size(120, 23);
            lbl11.Text = "Tiền thừa";
            this.Controls.Add(lbl11);

            this.txtChange.Location = new Point(160, 420);
            this.txtChange.Size = new Size(350, 22);
            this.txtChange.ReadOnly = true;

            this.btnRegister.Location = new Point(160, 465);
            this.btnRegister.Size = new Size(160, 36);
            this.btnRegister.Text = "Xác nhận đăng ký";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.ClientSize = new Size(540, 530);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboPackage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTrainer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAvatar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIdentity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCardCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboPaymentMethod);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCashReceived);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.btnRegister);
            this.Name = "RegisterMembershipForm";
            this.Text = "Đăng ký hội viên";
            this.Load += new System.EventHandler(this.RegisterMembershipForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}