using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class PTScheduleForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop;
        private Label lblTitle;
        private Label lblKeyword;
        private Label lblStatus;
        private Label lblTrainer;
        private Label lblFrom;
        private Label lblTo;
        private TextBox txtKeyword;
        private ComboBox cboStatus;
        private ComboBox cboTrainer;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Button btnToday;
        private Button btnThisWeek;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnMarkDone;
        private Button btnCancel;
        private Button btnRefresh;
        private DataGridView dgvSchedules;
        private Label lblSummary;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new Panel();
            this.lblTitle = new Label();
            this.lblKeyword = new Label();
            this.lblStatus = new Label();
            this.lblTrainer = new Label();
            this.lblFrom = new Label();
            this.lblTo = new Label();
            this.txtKeyword = new TextBox();
            this.cboStatus = new ComboBox();
            this.cboTrainer = new ComboBox();
            this.dtpFrom = new DateTimePicker();
            this.dtpTo = new DateTimePicker();
            this.btnToday = new Button();
            this.btnThisWeek = new Button();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnMarkDone = new Button();
            this.btnCancel = new Button();
            this.btnRefresh = new Button();
            this.dgvSchedules = new DataGridView();
            this.lblSummary = new Label();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = Color.WhiteSmoke;
            this.pnlTop.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblKeyword);
            this.pnlTop.Controls.Add(this.txtKeyword);
            this.pnlTop.Controls.Add(this.lblStatus);
            this.pnlTop.Controls.Add(this.cboStatus);
            this.pnlTop.Controls.Add(this.lblTrainer);
            this.pnlTop.Controls.Add(this.cboTrainer);
            this.pnlTop.Controls.Add(this.lblFrom);
            this.pnlTop.Controls.Add(this.dtpFrom);
            this.pnlTop.Controls.Add(this.lblTo);
            this.pnlTop.Controls.Add(this.dtpTo);
            this.pnlTop.Controls.Add(this.btnToday);
            this.pnlTop.Controls.Add(this.btnThisWeek);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.btnEdit);
            this.pnlTop.Controls.Add(this.btnMarkDone);
            this.pnlTop.Controls.Add(this.btnCancel);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Location = new Point(12, 12);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(1186, 126);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.Location = new Point(18, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(188, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Lịch tập với PT";
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Location = new Point(20, 61);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new Size(68, 16);
            this.lblKeyword.TabIndex = 1;
            this.lblKeyword.Text = "Từ khóa:";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new Point(94, 58);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new Size(197, 22);
            this.txtKeyword.TabIndex = 2;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new Point(310, 61);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(71, 16);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new Point(387, 57);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new Size(121, 24);
            this.cboStatus.TabIndex = 4;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // lblTrainer
            // 
            this.lblTrainer.AutoSize = true;
            this.lblTrainer.Location = new Point(525, 61);
            this.lblTrainer.Name = "lblTrainer";
            this.lblTrainer.Size = new Size(28, 16);
            this.lblTrainer.TabIndex = 5;
            this.lblTrainer.Text = "PT:";
            // 
            // cboTrainer
            // 
            this.cboTrainer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTrainer.FormattingEnabled = true;
            this.cboTrainer.Location = new Point(559, 57);
            this.cboTrainer.Name = "cboTrainer";
            this.cboTrainer.Size = new Size(163, 24);
            this.cboTrainer.TabIndex = 6;
            this.cboTrainer.SelectedIndexChanged += new System.EventHandler(this.cboTrainer_SelectedIndexChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new Point(20, 95);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new Size(29, 16);
            this.lblFrom.TabIndex = 7;
            this.lblFrom.Text = "Từ:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = DateTimePickerFormat.Short;
            this.dtpFrom.Location = new Point(94, 90);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new Size(120, 22);
            this.dtpFrom.TabIndex = 8;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new Point(235, 95);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new Size(33, 16);
            this.lblTo.TabIndex = 9;
            this.lblTo.Text = "Đến:";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = DateTimePickerFormat.Short;
            this.dtpTo.Location = new Point(274, 90);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new Size(120, 22);
            this.dtpTo.TabIndex = 10;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // btnToday
            // 
            this.btnToday.Location = new Point(414, 88);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new Size(83, 26);
            this.btnToday.TabIndex = 11;
            this.btnToday.Text = "Hôm nay";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // btnThisWeek
            // 
            this.btnThisWeek.Location = new Point(503, 88);
            this.btnThisWeek.Name = "btnThisWeek";
            this.btnThisWeek.Size = new Size(96, 26);
            this.btnThisWeek.TabIndex = 12;
            this.btnThisWeek.Text = "Tuần này";
            this.btnThisWeek.UseVisualStyleBackColor = true;
            this.btnThisWeek.Click += new System.EventHandler(this.btnThisWeek_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new Point(740, 56);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(85, 26);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Thêm lịch";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new Point(831, 56);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(85, 26);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Sửa lịch";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnMarkDone
            // 
            this.btnMarkDone.Location = new Point(922, 56);
            this.btnMarkDone.Name = "btnMarkDone";
            this.btnMarkDone.Size = new Size(103, 26);
            this.btnMarkDone.TabIndex = 15;
            this.btnMarkDone.Text = "Hoàn thành";
            this.btnMarkDone.UseVisualStyleBackColor = true;
            this.btnMarkDone.Click += new System.EventHandler(this.btnMarkDone_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(1031, 56);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(64, 26);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new Point(1101, 56);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(68, 26);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvSchedules
            // 
            this.dgvSchedules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedules.Location = new Point(12, 171);
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.RowHeadersWidth = 51;
            this.dgvSchedules.RowTemplate.Height = 24;
            this.dgvSchedules.Size = new Size(1186, 497);
            this.dgvSchedules.TabIndex = 1;
            this.dgvSchedules.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvSchedules_CellDoubleClick);
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblSummary.Location = new Point(12, 147);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new Size(136, 20);
            this.lblSummary.TabIndex = 2;
            this.lblSummary.Text = "Tổng lịch: 0 | ...";
            // 
            // PTScheduleForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1210, 680);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.dgvSchedules);
            this.Controls.Add(this.pnlTop);
            this.Name = "PTScheduleForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Lịch tập với PT";
            this.Load += new System.EventHandler(this.PTScheduleForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
