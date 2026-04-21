using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class RenewMembershipForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtCustomer;
        private ComboBox cboPackage;
        private ComboBox cboTrainer;
        private DateTimePicker dtpStartDate;
        private TextBox txtTotal;
        private ComboBox cboPaymentMethod;
        private TextBox txtCashReceived;
        private TextBox txtChange;
        private Button btnRenew;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCustomer = new TextBox();
            this.cboPackage = new ComboBox();
            this.cboTrainer = new ComboBox();
            this.dtpStartDate = new DateTimePicker();
            this.txtTotal = new TextBox();
            this.cboPaymentMethod = new ComboBox();
            this.txtCashReceived = new TextBox();
            this.txtChange = new TextBox();
            this.btnRenew = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.SuspendLayout();

            this.label1.Location = new Point(20, 20); this.label1.Size = new Size(120, 23); this.label1.Text = "Khách hàng";
            this.txtCustomer.Location = new Point(160, 20); this.txtCustomer.Size = new Size(340, 22); this.txtCustomer.ReadOnly = true;

            this.label2.Location = new Point(20, 60); this.label2.Size = new Size(120, 23); this.label2.Text = "Gói tập";
            this.cboPackage.Location = new Point(160, 60); this.cboPackage.Size = new Size(340, 24);
            this.cboPackage.SelectedIndexChanged += new System.EventHandler(this.cboPackage_SelectedIndexChanged);

            this.label3.Location = new Point(20, 100); this.label3.Size = new Size(120, 23); this.label3.Text = "PT";
            this.cboTrainer.Location = new Point(160, 100); this.cboTrainer.Size = new Size(340, 24);
            this.cboTrainer.SelectedIndexChanged += new System.EventHandler(this.cboTrainer_SelectedIndexChanged);

            this.label4.Location = new Point(20, 140); this.label4.Size = new Size(120, 23); this.label4.Text = "Ngày bắt đầu";
            this.dtpStartDate.Location = new Point(160, 140); this.dtpStartDate.Size = new Size(340, 22);

            this.label5.Location = new Point(20, 180); this.label5.Size = new Size(120, 23); this.label5.Text = "Tổng tiền";
            this.txtTotal.Location = new Point(160, 180); this.txtTotal.Size = new Size(340, 22); this.txtTotal.ReadOnly = true;

            this.label6.Location = new Point(20, 220); this.label6.Size = new Size(120, 23); this.label6.Text = "Thanh toán";
            this.cboPaymentMethod.Location = new Point(160, 220); this.cboPaymentMethod.Size = new Size(340, 24);
            this.cboPaymentMethod.Items.AddRange(new object[] { "Cash", "Online" });
            this.cboPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cboPaymentMethod_SelectedIndexChanged);

            this.label7.Location = new Point(20, 260); this.label7.Size = new Size(120, 23); this.label7.Text = "Khách đưa";
            this.txtCashReceived.Location = new Point(160, 260); this.txtCashReceived.Size = new Size(340, 22);
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);

            Label lbl8 = new Label();
            lbl8.Location = new Point(20, 300);
            lbl8.Size = new Size(120, 23);
            lbl8.Text = "Tiền thừa";
            this.Controls.Add(lbl8);

            this.txtChange.Location = new Point(160, 300); this.txtChange.Size = new Size(340, 22); this.txtChange.ReadOnly = true;

            this.btnRenew.Location = new Point(160, 350);
            this.btnRenew.Size = new Size(140, 36);
            this.btnRenew.Text = "Xác nhận gia hạn";
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);

            this.ClientSize = new Size(540, 420);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboPackage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTrainer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboPaymentMethod);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCashReceived);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.btnRenew);
            this.Name = "RenewMembershipForm";
            this.Text = "Gia hạn hội viên";
            this.Load += new System.EventHandler(this.RenewMembershipForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}