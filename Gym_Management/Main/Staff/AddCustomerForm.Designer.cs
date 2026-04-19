using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class AddCustomerForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblFullName;
        private Label lblPhone;
        private Label lblAddress;
        private TextBox txtFullName;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private Button btnSave;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFullName = new Label();
            this.lblPhone = new Label();
            this.lblAddress = new Label();
            this.txtFullName = new TextBox();
            this.txtPhone = new TextBox();
            this.txtAddress = new TextBox();
            this.btnSave = new Button();
            this.btnClose = new Button();
            this.SuspendLayout();

            this.lblFullName.Location = new Point(20, 20);
            this.lblFullName.Size = new Size(100, 23);
            this.lblFullName.Text = "Họ tên";

            this.txtFullName.Location = new Point(130, 20);
            this.txtFullName.Size = new Size(280, 22);

            this.lblPhone.Location = new Point(20, 60);
            this.lblPhone.Size = new Size(100, 23);
            this.lblPhone.Text = "Số điện thoại";

            this.txtPhone.Location = new Point(130, 60);
            this.txtPhone.Size = new Size(280, 22);

            this.lblAddress.Location = new Point(20, 100);
            this.lblAddress.Size = new Size(100, 23);
            this.lblAddress.Text = "Địa chỉ";

            this.txtAddress.Location = new Point(130, 100);
            this.txtAddress.Size = new Size(280, 22);

            this.btnSave.Location = new Point(130, 150);
            this.btnSave.Size = new Size(110, 35);
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnClose.Location = new Point(260, 150);
            this.btnClose.Size = new Size(110, 35);
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.ClientSize = new Size(440, 210);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Name = "AddCustomerForm";
            this.Text = "Thêm khách hàng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}