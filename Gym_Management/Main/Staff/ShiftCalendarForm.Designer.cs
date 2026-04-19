using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class ShiftCalendarForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private FlowLayoutPanel flowWeek;
        private ComboBox cboWeek;
        private Button btnPrev;
        private Button btnNext;
        private Button btnAttendance;
        private Button btnRefresh;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new Panel();
            this.cboWeek = new ComboBox();
            this.btnPrev = new Button();
            this.btnNext = new Button();
            this.btnAttendance = new Button();
            this.btnRefresh = new Button();
            this.lblStatus = new Label();
            this.flowWeek = new FlowLayoutPanel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = Color.WhiteSmoke;
            this.panelTop.Controls.Add(this.cboWeek);
            this.panelTop.Controls.Add(this.btnPrev);
            this.panelTop.Controls.Add(this.btnNext);
            this.panelTop.Controls.Add(this.btnAttendance);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.lblStatus);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Height = 55;

            // cboWeek
            this.cboWeek.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboWeek.Items.AddRange(new object[] { "Tuần này", "Tuần sau" });
            this.cboWeek.Location = new Point(20, 15);
            this.cboWeek.Size = new Size(120, 24);
            this.cboWeek.SelectedIndexChanged += new System.EventHandler(this.cboWeek_SelectedIndexChanged);

            // btnPrev
            this.btnPrev.Location = new Point(160, 12);
            this.btnPrev.Size = new Size(45, 30);
            this.btnPrev.Text = "<<";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);

            // btnNext
            this.btnNext.Location = new Point(215, 12);
            this.btnNext.Size = new Size(45, 30);
            this.btnNext.Text = ">>";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            // btnAttendance
            this.btnAttendance.Location = new Point(280, 12);
            this.btnAttendance.Size = new Size(130, 30);
            this.btnAttendance.Text = "Chấm công";
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);

            // btnRefresh
            this.btnRefresh.Location = new Point(425, 12);
            this.btnRefresh.Size = new Size(100, 30);
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = Color.Red;
            this.lblStatus.Location = new Point(550, 18);
            this.lblStatus.Size = new Size(0, 16);

            // flowWeek
            this.flowWeek.AutoScroll = true;
            this.flowWeek.Dock = DockStyle.Fill;
            this.flowWeek.Location = new Point(0, 55);
            this.flowWeek.Name = "flowWeek";
            this.flowWeek.Padding = new Padding(10);
            this.flowWeek.WrapContents = false;

            // ShiftCalendarForm
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1190, 480);
            this.Controls.Add(this.flowWeek);
            this.Controls.Add(this.panelTop);
            this.Name = "ShiftCalendarForm";
            this.Text = "Lịch ca làm";
            this.Load += new System.EventHandler(this.ShiftCalendarForm_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}