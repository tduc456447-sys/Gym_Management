namespace Gym_Management.Main.Admin
{
    partial class TrainerManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboLevel = new System.Windows.Forms.ComboBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.dgvTrainers = new System.Windows.Forms.DataGridView();
            this.groupBoxDetail = new System.Windows.Forms.GroupBox();
            this.lblUpdatedAtValue = new System.Windows.Forms.Label();
            this.lblCreatedAtValue = new System.Windows.Forms.Label();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.lblTotalClientsValue = new System.Windows.Forms.Label();
            this.lblActiveClientsValue = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblSalaryPercentValue = new System.Windows.Forms.Label();
            this.lblLevelValue = new System.Windows.Forms.Label();
            this.lblExperienceValue = new System.Windows.Forms.Label();
            this.lblSpecialtyValue = new System.Windows.Forms.Label();
            this.lblEmailValue = new System.Windows.Forms.Label();
            this.lblPhoneValue = new System.Windows.Forms.Label();
            this.lblNameValue = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picTrainer = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnToggleStatus = new System.Windows.Forms.Button();
            this.btnViewMembers = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxFilter.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).BeginInit();
            this.groupBoxDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTrainer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(19, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(291, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý huấn luyện viên";
            // 
            // lblAdmin
            // 
            this.lblAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdmin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAdmin.Location = new System.Drawing.Point(903, 18);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(327, 23);
            this.lblAdmin.TabIndex = 1;
            this.lblAdmin.Text = "Admin: ...";
            this.lblAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.btnRefresh);
            this.groupBoxFilter.Controls.Add(this.btnClearFilter);
            this.groupBoxFilter.Controls.Add(this.btnSearch);
            this.groupBoxFilter.Controls.Add(this.cboLevel);
            this.groupBoxFilter.Controls.Add(this.cboStatus);
            this.groupBoxFilter.Controls.Add(this.txtSearch);
            this.groupBoxFilter.Controls.Add(this.label3);
            this.groupBoxFilter.Controls.Add(this.label2);
            this.groupBoxFilter.Controls.Add(this.label1);
            this.groupBoxFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxFilter.Location = new System.Drawing.Point(25, 58);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(1205, 93);
            this.groupBoxFilter.TabIndex = 2;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Bộ lọc";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1087, 35);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 32);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(972, 35);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(101, 32);
            this.btnClearFilter.TabIndex = 7;
            this.btnClearFilter.Text = "Xóa lọc";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(857, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(101, 32);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboLevel
            // 
            this.cboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevel.FormattingEnabled = true;
            this.cboLevel.Location = new System.Drawing.Point(672, 36);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Size = new System.Drawing.Size(164, 31);
            this.cboLevel.TabIndex = 5;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(433, 36);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(143, 31);
            this.cboStatus.TabIndex = 4;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(93, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(249, 30);
            this.txtSearch.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(596, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Level:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(348, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trạng thái:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.dgvTrainers);
            this.groupBoxList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxList.Location = new System.Drawing.Point(25, 167);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(756, 531);
            this.groupBoxList.TabIndex = 3;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "Danh sách huấn luyện viên";
            // 
            // dgvTrainers
            // 
            this.dgvTrainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainers.Location = new System.Drawing.Point(16, 31);
            this.dgvTrainers.Name = "dgvTrainers";
            this.dgvTrainers.RowHeadersWidth = 51;
            this.dgvTrainers.RowTemplate.Height = 24;
            this.dgvTrainers.Size = new System.Drawing.Size(724, 484);
            this.dgvTrainers.TabIndex = 0;
            this.dgvTrainers.SelectionChanged += new System.EventHandler(this.dgvTrainers_SelectionChanged);
            // 
            // groupBoxDetail
            // 
            this.groupBoxDetail.Controls.Add(this.lblUpdatedAtValue);
            this.groupBoxDetail.Controls.Add(this.lblCreatedAtValue);
            this.groupBoxDetail.Controls.Add(this.lblRevenueValue);
            this.groupBoxDetail.Controls.Add(this.lblTotalClientsValue);
            this.groupBoxDetail.Controls.Add(this.lblActiveClientsValue);
            this.groupBoxDetail.Controls.Add(this.lblStatusValue);
            this.groupBoxDetail.Controls.Add(this.lblSalaryPercentValue);
            this.groupBoxDetail.Controls.Add(this.lblLevelValue);
            this.groupBoxDetail.Controls.Add(this.lblExperienceValue);
            this.groupBoxDetail.Controls.Add(this.lblSpecialtyValue);
            this.groupBoxDetail.Controls.Add(this.lblEmailValue);
            this.groupBoxDetail.Controls.Add(this.lblPhoneValue);
            this.groupBoxDetail.Controls.Add(this.lblNameValue);
            this.groupBoxDetail.Controls.Add(this.label16);
            this.groupBoxDetail.Controls.Add(this.label15);
            this.groupBoxDetail.Controls.Add(this.label14);
            this.groupBoxDetail.Controls.Add(this.label13);
            this.groupBoxDetail.Controls.Add(this.label12);
            this.groupBoxDetail.Controls.Add(this.label11);
            this.groupBoxDetail.Controls.Add(this.label10);
            this.groupBoxDetail.Controls.Add(this.label9);
            this.groupBoxDetail.Controls.Add(this.label8);
            this.groupBoxDetail.Controls.Add(this.label7);
            this.groupBoxDetail.Controls.Add(this.label6);
            this.groupBoxDetail.Controls.Add(this.label5);
            this.groupBoxDetail.Controls.Add(this.label4);
            this.groupBoxDetail.Controls.Add(this.picTrainer);
            this.groupBoxDetail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxDetail.Location = new System.Drawing.Point(797, 167);
            this.groupBoxDetail.Name = "groupBoxDetail";
            this.groupBoxDetail.Size = new System.Drawing.Size(433, 531);
            this.groupBoxDetail.TabIndex = 4;
            this.groupBoxDetail.TabStop = false;
            this.groupBoxDetail.Text = "Thông tin chi tiết";
            // 
            // lblUpdatedAtValue
            // 
            this.lblUpdatedAtValue.Location = new System.Drawing.Point(147, 480);
            this.lblUpdatedAtValue.Name = "lblUpdatedAtValue";
            this.lblUpdatedAtValue.Size = new System.Drawing.Size(264, 23);
            this.lblUpdatedAtValue.TabIndex = 26;
            // 
            // lblCreatedAtValue
            // 
            this.lblCreatedAtValue.Location = new System.Drawing.Point(147, 450);
            this.lblCreatedAtValue.Name = "lblCreatedAtValue";
            this.lblCreatedAtValue.Size = new System.Drawing.Size(264, 23);
            this.lblCreatedAtValue.TabIndex = 25;
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.Location = new System.Drawing.Point(147, 420);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(264, 23);
            this.lblRevenueValue.TabIndex = 24;
            // 
            // lblTotalClientsValue
            // 
            this.lblTotalClientsValue.Location = new System.Drawing.Point(147, 390);
            this.lblTotalClientsValue.Name = "lblTotalClientsValue";
            this.lblTotalClientsValue.Size = new System.Drawing.Size(264, 23);
            this.lblTotalClientsValue.TabIndex = 23;
            // 
            // lblActiveClientsValue
            // 
            this.lblActiveClientsValue.Location = new System.Drawing.Point(147, 360);
            this.lblActiveClientsValue.Name = "lblActiveClientsValue";
            this.lblActiveClientsValue.Size = new System.Drawing.Size(264, 23);
            this.lblActiveClientsValue.TabIndex = 22;
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.Location = new System.Drawing.Point(147, 330);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(264, 23);
            this.lblStatusValue.TabIndex = 21;
            // 
            // lblSalaryPercentValue
            // 
            this.lblSalaryPercentValue.Location = new System.Drawing.Point(147, 300);
            this.lblSalaryPercentValue.Name = "lblSalaryPercentValue";
            this.lblSalaryPercentValue.Size = new System.Drawing.Size(264, 23);
            this.lblSalaryPercentValue.TabIndex = 20;
            // 
            // lblLevelValue
            // 
            this.lblLevelValue.Location = new System.Drawing.Point(147, 270);
            this.lblLevelValue.Name = "lblLevelValue";
            this.lblLevelValue.Size = new System.Drawing.Size(264, 23);
            this.lblLevelValue.TabIndex = 19;
            // 
            // lblExperienceValue
            // 
            this.lblExperienceValue.Location = new System.Drawing.Point(147, 240);
            this.lblExperienceValue.Name = "lblExperienceValue";
            this.lblExperienceValue.Size = new System.Drawing.Size(264, 23);
            this.lblExperienceValue.TabIndex = 18;
            // 
            // lblSpecialtyValue
            // 
            this.lblSpecialtyValue.Location = new System.Drawing.Point(147, 210);
            this.lblSpecialtyValue.Name = "lblSpecialtyValue";
            this.lblSpecialtyValue.Size = new System.Drawing.Size(264, 23);
            this.lblSpecialtyValue.TabIndex = 17;
            // 
            // lblEmailValue
            // 
            this.lblEmailValue.Location = new System.Drawing.Point(147, 180);
            this.lblEmailValue.Name = "lblEmailValue";
            this.lblEmailValue.Size = new System.Drawing.Size(264, 23);
            this.lblEmailValue.TabIndex = 16;
            // 
            // lblPhoneValue
            // 
            this.lblPhoneValue.Location = new System.Drawing.Point(147, 150);
            this.lblPhoneValue.Name = "lblPhoneValue";
            this.lblPhoneValue.Size = new System.Drawing.Size(264, 23);
            this.lblPhoneValue.TabIndex = 15;
            // 
            // lblNameValue
            // 
            this.lblNameValue.Location = new System.Drawing.Point(147, 120);
            this.lblNameValue.Name = "lblNameValue";
            this.lblNameValue.Size = new System.Drawing.Size(264, 23);
            this.lblNameValue.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(18, 480);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(123, 23);
            this.label16.TabIndex = 13;
            this.label16.Text = "Cập nhật:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(18, 450);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(123, 23);
            this.label15.TabIndex = 12;
            this.label15.Text = "Tạo lúc:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(18, 420);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 23);
            this.label14.TabIndex = 11;
            this.label14.Text = "Doanh thu:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(18, 390);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 23);
            this.label13.TabIndex = 10;
            this.label13.Text = "Tổng học viên:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(18, 360);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 23);
            this.label12.TabIndex = 9;
            this.label12.Text = "HV active:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(18, 330);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 23);
            this.label11.TabIndex = 8;
            this.label11.Text = "Trạng thái:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(18, 300);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 23);
            this.label10.TabIndex = 7;
            this.label10.Text = "% Lương:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(18, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 23);
            this.label9.TabIndex = 6;
            this.label9.Text = "Level:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(18, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 23);
            this.label8.TabIndex = 5;
            this.label8.Text = "Kinh nghiệm:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(18, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 23);
            this.label7.TabIndex = 4;
            this.label7.Text = "Chuyên môn:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(18, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "Email:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(18, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Điện thoại:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Họ tên:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picTrainer
            // 
            this.picTrainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTrainer.Location = new System.Drawing.Point(151, 29);
            this.picTrainer.Name = "picTrainer";
            this.picTrainer.Size = new System.Drawing.Size(120, 80);
            this.picTrainer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTrainer.TabIndex = 0;
            this.picTrainer.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(25, 714);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(128, 40);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Thêm PT";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(170, 714);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(128, 40);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Sửa PT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnToggleStatus
            // 
            this.btnToggleStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleStatus.Location = new System.Drawing.Point(315, 714);
            this.btnToggleStatus.Name = "btnToggleStatus";
            this.btnToggleStatus.Size = new System.Drawing.Size(128, 40);
            this.btnToggleStatus.TabIndex = 7;
            this.btnToggleStatus.Text = "Khóa/Mở";
            this.btnToggleStatus.UseVisualStyleBackColor = true;
            this.btnToggleStatus.Click += new System.EventHandler(this.btnToggleStatus_Click);
            // 
            // btnViewMembers
            // 
            this.btnViewMembers.BackColor = System.Drawing.Color.SteelBlue;
            this.btnViewMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewMembers.ForeColor = System.Drawing.Color.White;
            this.btnViewMembers.Location = new System.Drawing.Point(460, 714);
            this.btnViewMembers.Name = "btnViewMembers";
            this.btnViewMembers.Size = new System.Drawing.Size(164, 40);
            this.btnViewMembers.TabIndex = 8;
            this.btnViewMembers.Text = "Xem học viên";
            this.btnViewMembers.UseVisualStyleBackColor = false;
            this.btnViewMembers.Click += new System.EventHandler(this.btnViewMembers_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(637, 714);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "Xem lịch pt";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TrainerManagementForm
            // 
            this.ClientSize = new System.Drawing.Size(1255, 772);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnViewMembers);
            this.Controls.Add(this.btnToggleStatus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBoxDetail);
            this.Controls.Add(this.groupBoxList);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.lblTitle);
            this.Name = "TrainerManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý huấn luyện viên";
            this.Load += new System.EventHandler(this.TrainerManagementForm_Load);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).EndInit();
            this.groupBoxDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTrainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboLevel;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dgvTrainers;
        private System.Windows.Forms.GroupBox groupBoxDetail;
        private System.Windows.Forms.PictureBox picTrainer;
        private System.Windows.Forms.Label lblUpdatedAtValue;
        private System.Windows.Forms.Label lblCreatedAtValue;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Label lblTotalClientsValue;
        private System.Windows.Forms.Label lblActiveClientsValue;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblSalaryPercentValue;
        private System.Windows.Forms.Label lblLevelValue;
        private System.Windows.Forms.Label lblExperienceValue;
        private System.Windows.Forms.Label lblSpecialtyValue;
        private System.Windows.Forms.Label lblEmailValue;
        private System.Windows.Forms.Label lblPhoneValue;
        private System.Windows.Forms.Label lblNameValue;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnToggleStatus;
        private System.Windows.Forms.Button btnViewMembers;
        private System.Windows.Forms.Button button1;
    }
}