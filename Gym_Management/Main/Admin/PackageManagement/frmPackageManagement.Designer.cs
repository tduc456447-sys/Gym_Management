using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.PackageManagement
{
    partial class frmPackageManagement
    {
        private System.ComponentModel.IContainer components = null;
        private SplitContainer splitContainer1;
        private Panel pnlFilter;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblFilterType;
        private ComboBox cboFilterType;
        private Label lblFilterStatus;
        private ComboBox cboFilterStatus;
        private DataGridView dgvPackages;
        private GroupBox grpInfo;
        private Label lblPackageId;
        private TextBox txtPackageId;
        private Label lblPackageName;
        private TextBox txtPackageName;
        private GroupBox grpPackageType;
        private RadioButton rdoNormal;
        private RadioButton rdoPT;
        private Label lblDuration;
        private NumericUpDown numDurationValue;
        private ComboBox cboDurationType;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Panel pnlPTInfo;
        private Label lblTrainer;
        private ComboBox cboTrainer;
        private Label lblPTSessions;
        private NumericUpDown numPTSessions;
        private GroupBox grpTrainerInfo;
        private Label lblTrainerName;
        private Label lblTrainerPhone;
        private Label lblTrainerSpecialty;
        private Label lblTrainerExperience;
        private Label lblTrainerLevel;
        private Label lblTrainerNameValue;
        private Label lblTrainerPhoneValue;
        private Label lblTrainerSpecialtyValue;
        private Label lblTrainerExperienceValue;
        private Label lblTrainerLevelValue;
        private FlowLayoutPanel flowButtons;
        private Button btnAddNew;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvPackages = new System.Windows.Forms.DataGridView();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterType = new System.Windows.Forms.Label();
            this.cboFilterType = new System.Windows.Forms.ComboBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblPackageId = new System.Windows.Forms.Label();
            this.txtPackageId = new System.Windows.Forms.TextBox();
            this.pnlPTInfo = new System.Windows.Forms.Panel();
            this.lblTrainer = new System.Windows.Forms.Label();
            this.cboTrainer = new System.Windows.Forms.ComboBox();
            this.lblPTSessions = new System.Windows.Forms.Label();
            this.numPTSessions = new System.Windows.Forms.NumericUpDown();
            this.grpTrainerInfo = new System.Windows.Forms.GroupBox();
            this.lblTrainerName = new System.Windows.Forms.Label();
            this.lblTrainerPhone = new System.Windows.Forms.Label();
            this.lblTrainerSpecialty = new System.Windows.Forms.Label();
            this.lblTrainerExperience = new System.Windows.Forms.Label();
            this.lblTrainerLevel = new System.Windows.Forms.Label();
            this.lblTrainerNameValue = new System.Windows.Forms.Label();
            this.lblTrainerPhoneValue = new System.Windows.Forms.Label();
            this.lblTrainerSpecialtyValue = new System.Windows.Forms.Label();
            this.lblTrainerExperienceValue = new System.Windows.Forms.Label();
            this.lblTrainerLevelValue = new System.Windows.Forms.Label();
            this.lblPackageName = new System.Windows.Forms.Label();
            this.txtPackageName = new System.Windows.Forms.TextBox();
            this.grpPackageType = new System.Windows.Forms.GroupBox();
            this.rdoNormal = new System.Windows.Forms.RadioButton();
            this.rdoPT = new System.Windows.Forms.RadioButton();
            this.lblDuration = new System.Windows.Forms.Label();
            this.numDurationValue = new System.Windows.Forms.NumericUpDown();
            this.cboDurationType = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackages)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.flowButtons.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.pnlPTInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPTSessions)).BeginInit();
            this.grpTrainerInfo.SuspendLayout();
            this.grpPackageType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationValue)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.dgvPackages);
            this.splitContainer1.Panel1.Controls.Add(this.pnlFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.grpInfo);
            this.splitContainer1.Size = new System.Drawing.Size(1199, 720);
            this.splitContainer1.SplitterDistance = 700;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvPackages
            // 
            this.dgvPackages.BackgroundColor = System.Drawing.Color.White;
            this.dgvPackages.ColumnHeadersHeight = 29;
            this.dgvPackages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPackages.Location = new System.Drawing.Point(0, 96);
            this.dgvPackages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPackages.Name = "dgvPackages";
            this.dgvPackages.RowHeadersWidth = 51;
            this.dgvPackages.Size = new System.Drawing.Size(700, 624);
            this.dgvPackages.TabIndex = 1;
            this.dgvPackages.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPackages_CellClick);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.lblSearch);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.lblFilterType);
            this.pnlFilter.Controls.Add(this.cboFilterType);
            this.pnlFilter.Controls.Add(this.lblFilterStatus);
            this.pnlFilter.Controls.Add(this.cboFilterStatus);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.pnlFilter.Size = new System.Drawing.Size(700, 96);
            this.pnlFilter.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(18, 14);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(62, 16);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(22, 35);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(470, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblFilterType
            // 
            this.lblFilterType.AutoSize = true;
            this.lblFilterType.Location = new System.Drawing.Point(18, 66);
            this.lblFilterType.Name = "lblFilterType";
            this.lblFilterType.Size = new System.Drawing.Size(55, 16);
            this.lblFilterType.TabIndex = 1;
            this.lblFilterType.Text = "Loại gói";
            // 
            // cboFilterType
            // 
            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterType.Location = new System.Drawing.Point(96, 64);
            this.cboFilterType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size(140, 24);
            this.cboFilterType.TabIndex = 1;
            this.cboFilterType.SelectedIndexChanged += new System.EventHandler(this.cboFilterType_SelectedIndexChanged);
            // 
            // lblFilterStatus
            // 
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Location = new System.Drawing.Point(257, 66);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(67, 16);
            this.lblFilterStatus.TabIndex = 2;
            this.lblFilterStatus.Text = "Trạng thái";
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.Location = new System.Drawing.Point(347, 64);
            this.cboFilterStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(145, 24);
            this.cboFilterStatus.TabIndex = 2;
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterStatus_SelectedIndexChanged);
            // 
            // flowButtons
            // 
            this.flowButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowButtons.Controls.Add(this.btnAddNew);
            this.flowButtons.Controls.Add(this.btnSave);
            this.flowButtons.Controls.Add(this.btnUpdate);
            this.flowButtons.Controls.Add(this.btnDelete);
            this.flowButtons.Controls.Add(this.btnRefresh);
            this.flowButtons.Location = new System.Drawing.Point(6, 574);
            this.flowButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Size = new System.Drawing.Size(475, 43);
            this.flowButtons.TabIndex = 1;
            this.flowButtons.WrapContents = false;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(3, 2);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(90, 32);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "Thêm mới";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(99, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(180, 2);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 32);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(281, 2);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 32);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(362, 2);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 32);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpInfo
            // 
            this.grpInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInfo.Controls.Add(this.flowButtons);
            this.grpInfo.Controls.Add(this.lblPackageId);
            this.grpInfo.Controls.Add(this.txtPackageId);
            this.grpInfo.Controls.Add(this.pnlPTInfo);
            this.grpInfo.Controls.Add(this.lblPackageName);
            this.grpInfo.Controls.Add(this.txtPackageName);
            this.grpInfo.Controls.Add(this.grpPackageType);
            this.grpInfo.Controls.Add(this.lblDuration);
            this.grpInfo.Controls.Add(this.numDurationValue);
            this.grpInfo.Controls.Add(this.cboDurationType);
            this.grpInfo.Controls.Add(this.lblPrice);
            this.grpInfo.Controls.Add(this.txtPrice);
            this.grpInfo.Controls.Add(this.lblDescription);
            this.grpInfo.Controls.Add(this.txtDescription);
            this.grpInfo.Controls.Add(this.lblStatus);
            this.grpInfo.Controls.Add(this.cboStatus);
            this.grpInfo.Location = new System.Drawing.Point(6, 2);
            this.grpInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpInfo.Size = new System.Drawing.Size(481, 655);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Thông tin gói tập";
            // 
            // lblPackageId
            // 
            this.lblPackageId.AutoSize = true;
            this.lblPackageId.Location = new System.Drawing.Point(18, 30);
            this.lblPackageId.Name = "lblPackageId";
            this.lblPackageId.Size = new System.Drawing.Size(48, 16);
            this.lblPackageId.TabIndex = 0;
            this.lblPackageId.Text = "Mã gói";
            // 
            // txtPackageId
            // 
            this.txtPackageId.Location = new System.Drawing.Point(146, 27);
            this.txtPackageId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPackageId.Name = "txtPackageId";
            this.txtPackageId.ReadOnly = true;
            this.txtPackageId.Size = new System.Drawing.Size(250, 22);
            this.txtPackageId.TabIndex = 0;
            // 
            // pnlPTInfo
            // 
            this.pnlPTInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPTInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPTInfo.Controls.Add(this.lblTrainer);
            this.pnlPTInfo.Controls.Add(this.cboTrainer);
            this.pnlPTInfo.Controls.Add(this.lblPTSessions);
            this.pnlPTInfo.Controls.Add(this.numPTSessions);
            this.pnlPTInfo.Controls.Add(this.grpTrainerInfo);
            this.pnlPTInfo.Location = new System.Drawing.Point(6, 339);
            this.pnlPTInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPTInfo.Name = "pnlPTInfo";
            this.pnlPTInfo.Size = new System.Drawing.Size(469, 231);
            this.pnlPTInfo.TabIndex = 8;
            // 
            // lblTrainer
            // 
            this.lblTrainer.AutoSize = true;
            this.lblTrainer.Location = new System.Drawing.Point(12, 10);
            this.lblTrainer.Name = "lblTrainer";
            this.lblTrainer.Size = new System.Drawing.Size(59, 16);
            this.lblTrainer.TabIndex = 0;
            this.lblTrainer.Text = "Chọn PT";
            // 
            // cboTrainer
            // 
            this.cboTrainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrainer.Location = new System.Drawing.Point(104, 7);
            this.cboTrainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboTrainer.Name = "cboTrainer";
            this.cboTrainer.Size = new System.Drawing.Size(338, 24);
            this.cboTrainer.TabIndex = 0;
            this.cboTrainer.SelectedIndexChanged += new System.EventHandler(this.cboTrainer_SelectedIndexChanged);
            // 
            // lblPTSessions
            // 
            this.lblPTSessions.AutoSize = true;
            this.lblPTSessions.Location = new System.Drawing.Point(12, 40);
            this.lblPTSessions.Name = "lblPTSessions";
            this.lblPTSessions.Size = new System.Drawing.Size(74, 16);
            this.lblPTSessions.TabIndex = 1;
            this.lblPTSessions.Text = "Số buổi PT";
            // 
            // numPTSessions
            // 
            this.numPTSessions.Location = new System.Drawing.Point(104, 38);
            this.numPTSessions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numPTSessions.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPTSessions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPTSessions.Name = "numPTSessions";
            this.numPTSessions.Size = new System.Drawing.Size(120, 22);
            this.numPTSessions.TabIndex = 1;
            this.numPTSessions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // grpTrainerInfo
            // 
            this.grpTrainerInfo.Controls.Add(this.lblTrainerName);
            this.grpTrainerInfo.Controls.Add(this.lblTrainerPhone);
            this.grpTrainerInfo.Controls.Add(this.lblTrainerSpecialty);
            this.grpTrainerInfo.Controls.Add(this.lblTrainerExperience);
            this.grpTrainerInfo.Controls.Add(this.lblTrainerLevel);
            this.grpTrainerInfo.Controls.Add(this.lblTrainerNameValue);
            this.grpTrainerInfo.Controls.Add(this.lblTrainerPhoneValue);
            this.grpTrainerInfo.Controls.Add(this.lblTrainerSpecialtyValue);
            this.grpTrainerInfo.Controls.Add(this.lblTrainerExperienceValue);
            this.grpTrainerInfo.Controls.Add(this.lblTrainerLevelValue);
            this.grpTrainerInfo.Location = new System.Drawing.Point(12, 66);
            this.grpTrainerInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpTrainerInfo.Name = "grpTrainerInfo";
            this.grpTrainerInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpTrainerInfo.Size = new System.Drawing.Size(430, 125);
            this.grpTrainerInfo.TabIndex = 2;
            this.grpTrainerInfo.TabStop = false;
            this.grpTrainerInfo.Text = "Thông tin huấn luyện viên";
            // 
            // lblTrainerName
            // 
            this.lblTrainerName.AutoSize = true;
            this.lblTrainerName.Location = new System.Drawing.Point(12, 19);
            this.lblTrainerName.Name = "lblTrainerName";
            this.lblTrainerName.Size = new System.Drawing.Size(31, 16);
            this.lblTrainerName.TabIndex = 0;
            this.lblTrainerName.Text = "Tên";
            // 
            // lblTrainerPhone
            // 
            this.lblTrainerPhone.AutoSize = true;
            this.lblTrainerPhone.Location = new System.Drawing.Point(12, 42);
            this.lblTrainerPhone.Name = "lblTrainerPhone";
            this.lblTrainerPhone.Size = new System.Drawing.Size(34, 16);
            this.lblTrainerPhone.TabIndex = 1;
            this.lblTrainerPhone.Text = "SĐT";
            // 
            // lblTrainerSpecialty
            // 
            this.lblTrainerSpecialty.AutoSize = true;
            this.lblTrainerSpecialty.Location = new System.Drawing.Point(12, 65);
            this.lblTrainerSpecialty.Name = "lblTrainerSpecialty";
            this.lblTrainerSpecialty.Size = new System.Drawing.Size(81, 16);
            this.lblTrainerSpecialty.TabIndex = 2;
            this.lblTrainerSpecialty.Text = "Chuyên môn";
            // 
            // lblTrainerExperience
            // 
            this.lblTrainerExperience.AutoSize = true;
            this.lblTrainerExperience.Location = new System.Drawing.Point(12, 88);
            this.lblTrainerExperience.Name = "lblTrainerExperience";
            this.lblTrainerExperience.Size = new System.Drawing.Size(79, 16);
            this.lblTrainerExperience.TabIndex = 3;
            this.lblTrainerExperience.Text = "Kinh nghiệm";
            // 
            // lblTrainerLevel
            // 
            this.lblTrainerLevel.AutoSize = true;
            this.lblTrainerLevel.Location = new System.Drawing.Point(220, 19);
            this.lblTrainerLevel.Name = "lblTrainerLevel";
            this.lblTrainerLevel.Size = new System.Drawing.Size(51, 16);
            this.lblTrainerLevel.TabIndex = 4;
            this.lblTrainerLevel.Text = "Cấp độ";
            // 
            // lblTrainerNameValue
            // 
            this.lblTrainerNameValue.AutoSize = true;
            this.lblTrainerNameValue.Location = new System.Drawing.Point(110, 19);
            this.lblTrainerNameValue.Name = "lblTrainerNameValue";
            this.lblTrainerNameValue.Size = new System.Drawing.Size(11, 16);
            this.lblTrainerNameValue.TabIndex = 5;
            this.lblTrainerNameValue.Text = "-";
            // 
            // lblTrainerPhoneValue
            // 
            this.lblTrainerPhoneValue.AutoSize = true;
            this.lblTrainerPhoneValue.Location = new System.Drawing.Point(110, 42);
            this.lblTrainerPhoneValue.Name = "lblTrainerPhoneValue";
            this.lblTrainerPhoneValue.Size = new System.Drawing.Size(11, 16);
            this.lblTrainerPhoneValue.TabIndex = 6;
            this.lblTrainerPhoneValue.Text = "-";
            // 
            // lblTrainerSpecialtyValue
            // 
            this.lblTrainerSpecialtyValue.AutoSize = true;
            this.lblTrainerSpecialtyValue.Location = new System.Drawing.Point(110, 65);
            this.lblTrainerSpecialtyValue.Name = "lblTrainerSpecialtyValue";
            this.lblTrainerSpecialtyValue.Size = new System.Drawing.Size(11, 16);
            this.lblTrainerSpecialtyValue.TabIndex = 7;
            this.lblTrainerSpecialtyValue.Text = "-";
            // 
            // lblTrainerExperienceValue
            // 
            this.lblTrainerExperienceValue.AutoSize = true;
            this.lblTrainerExperienceValue.Location = new System.Drawing.Point(110, 88);
            this.lblTrainerExperienceValue.Name = "lblTrainerExperienceValue";
            this.lblTrainerExperienceValue.Size = new System.Drawing.Size(11, 16);
            this.lblTrainerExperienceValue.TabIndex = 8;
            this.lblTrainerExperienceValue.Text = "-";
            // 
            // lblTrainerLevelValue
            // 
            this.lblTrainerLevelValue.AutoSize = true;
            this.lblTrainerLevelValue.Location = new System.Drawing.Point(287, 19);
            this.lblTrainerLevelValue.Name = "lblTrainerLevelValue";
            this.lblTrainerLevelValue.Size = new System.Drawing.Size(11, 16);
            this.lblTrainerLevelValue.TabIndex = 9;
            this.lblTrainerLevelValue.Text = "-";
            // 
            // lblPackageName
            // 
            this.lblPackageName.AutoSize = true;
            this.lblPackageName.Location = new System.Drawing.Point(18, 64);
            this.lblPackageName.Name = "lblPackageName";
            this.lblPackageName.Size = new System.Drawing.Size(53, 16);
            this.lblPackageName.TabIndex = 1;
            this.lblPackageName.Text = "Tên gói";
            // 
            // txtPackageName
            // 
            this.txtPackageName.Location = new System.Drawing.Point(146, 62);
            this.txtPackageName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPackageName.Name = "txtPackageName";
            this.txtPackageName.Size = new System.Drawing.Size(250, 22);
            this.txtPackageName.TabIndex = 1;
            // 
            // grpPackageType
            // 
            this.grpPackageType.Controls.Add(this.rdoNormal);
            this.grpPackageType.Controls.Add(this.rdoPT);
            this.grpPackageType.Location = new System.Drawing.Point(22, 98);
            this.grpPackageType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpPackageType.Name = "grpPackageType";
            this.grpPackageType.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpPackageType.Size = new System.Drawing.Size(374, 53);
            this.grpPackageType.TabIndex = 2;
            this.grpPackageType.TabStop = false;
            this.grpPackageType.Text = "Loại gói";
            // 
            // rdoNormal
            // 
            this.rdoNormal.AutoSize = true;
            this.rdoNormal.Location = new System.Drawing.Point(22, 22);
            this.rdoNormal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoNormal.Name = "rdoNormal";
            this.rdoNormal.Size = new System.Drawing.Size(92, 20);
            this.rdoNormal.TabIndex = 0;
            this.rdoNormal.TabStop = true;
            this.rdoNormal.Text = "Gói thường";
            this.rdoNormal.CheckedChanged += new System.EventHandler(this.rdoNormal_CheckedChanged);
            // 
            // rdoPT
            // 
            this.rdoPT.AutoSize = true;
            this.rdoPT.Location = new System.Drawing.Point(174, 22);
            this.rdoPT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoPT.Name = "rdoPT";
            this.rdoPT.Size = new System.Drawing.Size(70, 20);
            this.rdoPT.TabIndex = 1;
            this.rdoPT.TabStop = true;
            this.rdoPT.Text = "Gói PT";
            this.rdoPT.CheckedChanged += new System.EventHandler(this.rdoPT_CheckedChanged);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(18, 165);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(70, 16);
            this.lblDuration.TabIndex = 3;
            this.lblDuration.Text = "Thời lượng";
            // 
            // numDurationValue
            // 
            this.numDurationValue.Location = new System.Drawing.Point(146, 162);
            this.numDurationValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numDurationValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDurationValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDurationValue.Name = "numDurationValue";
            this.numDurationValue.Size = new System.Drawing.Size(90, 22);
            this.numDurationValue.TabIndex = 3;
            this.numDurationValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboDurationType
            // 
            this.cboDurationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDurationType.Location = new System.Drawing.Point(246, 162);
            this.cboDurationType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboDurationType.Name = "cboDurationType";
            this.cboDurationType.Size = new System.Drawing.Size(150, 24);
            this.cboDurationType.TabIndex = 4;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(18, 200);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(52, 16);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Giá tiền";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(146, 198);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(250, 22);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(18, 235);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(40, 16);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Mô tả";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(146, 233);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(250, 58);
            this.txtDescription.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(18, 304);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(67, 16);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Trạng thái";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Location = new System.Drawing.Point(146, 302);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(250, 24);
            this.cboStatus.TabIndex = 7;
            // 
            // frmPackageManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 720);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1217, 767);
            this.Name = "frmPackageManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý gói tập";
            this.Load += new System.EventHandler(this.frmPackageManagement_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackages)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.flowButtons.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.pnlPTInfo.ResumeLayout(false);
            this.pnlPTInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPTSessions)).EndInit();
            this.grpTrainerInfo.ResumeLayout(false);
            this.grpTrainerInfo.PerformLayout();
            this.grpPackageType.ResumeLayout(false);
            this.grpPackageType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationValue)).EndInit();
            this.ResumeLayout(false);

        }
    }
}