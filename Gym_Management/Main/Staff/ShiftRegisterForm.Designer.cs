using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class ShiftRegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblDate;
        private Label lblShift;
        private TextBox txtDate;
        private ComboBox cboShift;
        private Button btnRegister;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblDate = new Label();
            this.lblShift = new Label();
            this.txtDate = new TextBox();
            this.cboShift = new ComboBox();
            this.btnRegister = new Button();
            this.btnClose = new Button();
            this.SuspendLayout();

            this.lblDate.Location = new Point(20, 25);
            this.lblDate.Size = new Size(100, 23);
            this.lblDate.Text = "Ngày";

            this.txtDate.Location = new Point(130, 25);
            this.txtDate.Size = new Size(220, 22);
            this.txtDate.ReadOnly = true;

            this.lblShift.Location = new Point(20, 70);
            this.lblShift.Size = new Size(100, 23);
            this.lblShift.Text = "Ca làm";

            this.cboShift.Location = new Point(130, 70);
            this.cboShift.Size = new Size(320, 24);
            this.cboShift.DropDownStyle = ComboBoxStyle.DropDownList;

            this.btnRegister.Location = new Point(130, 125);
            this.btnRegister.Size = new Size(120, 35);
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.btnClose.Location = new Point(270, 125);
            this.btnClose.Size = new Size(120, 35);
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.ClientSize = new Size(490, 185);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.cboShift);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnClose);
            this.Name = "ShiftRegisterForm";
            this.Text = "Đăng ký ca";
            this.Load += new System.EventHandler(this.ShiftRegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}