using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class ShiftAttendanceForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblDate;
        private Label lblShift;
        private TextBox txtDate;
        private ComboBox cboShift;
        private Button btnCheckIn;
        private Button btnCheckOut;
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
            this.btnCheckIn = new Button();
            this.btnCheckOut = new Button();
            this.btnClose = new Button();
            this.SuspendLayout();

            this.lblDate.Location = new Point(20, 25);
            this.lblDate.Size = new Size(100, 23);
            this.lblDate.Text = "Hôm nay";

            this.txtDate.Location = new Point(130, 25);
            this.txtDate.Size = new Size(220, 22);
            this.txtDate.ReadOnly = true;

            this.lblShift.Location = new Point(20, 70);
            this.lblShift.Size = new Size(100, 23);
            this.lblShift.Text = "Ca hôm nay";

            this.cboShift.Location = new Point(130, 70);
            this.cboShift.Size = new Size(320, 24);
            this.cboShift.DropDownStyle = ComboBoxStyle.DropDownList;

            this.btnCheckIn.Location = new Point(50, 130);
            this.btnCheckIn.Size = new Size(120, 38);
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);

            this.btnCheckOut.Location = new Point(190, 130);
            this.btnCheckOut.Size = new Size(120, 38);
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);

            this.btnClose.Location = new Point(330, 130);
            this.btnClose.Size = new Size(120, 38);
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.ClientSize = new Size(490, 205);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.cboShift);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnClose);
            this.Name = "ShiftAttendanceForm";
            this.Text = "Chấm công theo ca";
            this.Load += new System.EventHandler(this.ShiftAttendanceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}