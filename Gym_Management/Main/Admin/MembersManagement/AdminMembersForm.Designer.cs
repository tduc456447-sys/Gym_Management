namespace Gym_Management.Main.Admin
{
    partial class AdminMembersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlStat1;
        private System.Windows.Forms.Panel pnlStat2;
        private System.Windows.Forms.Panel pnlStat3;
        private System.Windows.Forms.Panel pnlStat4;
        private System.Windows.Forms.Label lblTotalMembersTitle;
        private System.Windows.Forms.Label lblProfilesTitle;
        private System.Windows.Forms.Label lblActiveMembershipsTitle;
        private System.Windows.Forms.Label lblExpiredMembershipsTitle;
        private System.Windows.Forms.Label lblTotalMembersValue;
        private System.Windows.Forms.Label lblProfilesValue;
        private System.Windows.Forms.Label lblActiveMembershipsValue;
        private System.Windows.Forms.Label lblExpiredMembershipsValue;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label lblKeyword;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblProfileStatus;
        private System.Windows.Forms.ComboBox cboProfileStatus;
        private System.Windows.Forms.Label lblMembershipStatus;
        private System.Windows.Forms.ComboBox cboMembershipStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnToggleStatus;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnCheckin;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.GroupBox groupBoxDetail;
        private System.Windows.Forms.Label labelCustomerId;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelCardCode;
        private System.Windows.Forms.Label labelIdentity;
        private System.Windows.Forms.Label labelJoinDate;
        private System.Windows.Forms.Label labelProfileStatusText;
        private System.Windows.Forms.Label labelCurrentPackage;
        private System.Windows.Forms.Label labelMembershipStatusText;
        private System.Windows.Forms.Label labelTrainer;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelTotalMembershipCount;
        private System.Windows.Forms.Label labelTotalCheckinCount;
        private System.Windows.Forms.Label labelLastCheckin;
        private System.Windows.Forms.Label labelCreatedAt;
        private System.Windows.Forms.Label lblCustomerIdValue;
        private System.Windows.Forms.Label lblFullNameValue;
        private System.Windows.Forms.Label lblPhoneValue;
        private System.Windows.Forms.Label lblAddressValue;
        private System.Windows.Forms.Label lblCardCodeValue;
        private System.Windows.Forms.Label lblIdentityValue;
        private System.Windows.Forms.Label lblJoinDateValue;
        private System.Windows.Forms.Label lblProfileStatusValue;
        private System.Windows.Forms.Label lblCurrentPackageValue;
        private System.Windows.Forms.Label lblMembershipStatusValue;
        private System.Windows.Forms.Label lblTrainerValue;
        private System.Windows.Forms.Label lblStartDateValue;
        private System.Windows.Forms.Label lblEndDateValue;
        private System.Windows.Forms.Label lblPriceValue;
        private System.Windows.Forms.Label lblTotalMembershipCountValue;
        private System.Windows.Forms.Label lblTotalCheckinCountValue;
        private System.Windows.Forms.Label lblLastCheckinValue;
        private System.Windows.Forms.Label lblCreatedAtValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlStat4 = new System.Windows.Forms.Panel();
            this.lblExpiredMembershipsValue = new System.Windows.Forms.Label();
            this.lblExpiredMembershipsTitle = new System.Windows.Forms.Label();
            this.pnlStat3 = new System.Windows.Forms.Panel();
            this.lblActiveMembershipsValue = new System.Windows.Forms.Label();
            this.lblActiveMembershipsTitle = new System.Windows.Forms.Label();
            this.pnlStat2 = new System.Windows.Forms.Panel();
            this.lblProfilesValue = new System.Windows.Forms.Label();
            this.lblProfilesTitle = new System.Windows.Forms.Label();
            this.pnlStat1 = new System.Windows.Forms.Panel();
            this.lblTotalMembersValue = new System.Windows.Forms.Label();
            this.lblTotalMembersTitle = new System.Windows.Forms.Label();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboMembershipStatus = new System.Windows.Forms.ComboBox();
            this.lblMembershipStatus = new System.Windows.Forms.Label();
            this.cboProfileStatus = new System.Windows.Forms.ComboBox();
            this.lblProfileStatus = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.btnCheckin = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.btnToggleStatus = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.groupBoxDetail = new System.Windows.Forms.GroupBox();
            this.lblCreatedAtValue = new System.Windows.Forms.Label();
            this.lblLastCheckinValue = new System.Windows.Forms.Label();
            this.lblTotalCheckinCountValue = new System.Windows.Forms.Label();
            this.lblTotalMembershipCountValue = new System.Windows.Forms.Label();
            this.lblPriceValue = new System.Windows.Forms.Label();
            this.lblEndDateValue = new System.Windows.Forms.Label();
            this.lblStartDateValue = new System.Windows.Forms.Label();
            this.lblTrainerValue = new System.Windows.Forms.Label();
            this.lblMembershipStatusValue = new System.Windows.Forms.Label();
            this.lblCurrentPackageValue = new System.Windows.Forms.Label();
            this.lblProfileStatusValue = new System.Windows.Forms.Label();
            this.lblJoinDateValue = new System.Windows.Forms.Label();
            this.lblIdentityValue = new System.Windows.Forms.Label();
            this.lblCardCodeValue = new System.Windows.Forms.Label();
            this.lblAddressValue = new System.Windows.Forms.Label();
            this.lblPhoneValue = new System.Windows.Forms.Label();
            this.lblFullNameValue = new System.Windows.Forms.Label();
            this.lblCustomerIdValue = new System.Windows.Forms.Label();
            this.labelCreatedAt = new System.Windows.Forms.Label();
            this.labelLastCheckin = new System.Windows.Forms.Label();
            this.labelTotalCheckinCount = new System.Windows.Forms.Label();
            this.labelTotalMembershipCount = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelTrainer = new System.Windows.Forms.Label();
            this.labelMembershipStatusText = new System.Windows.Forms.Label();
            this.labelCurrentPackage = new System.Windows.Forms.Label();
            this.labelProfileStatusText = new System.Windows.Forms.Label();
            this.labelJoinDate = new System.Windows.Forms.Label();
            this.labelIdentity = new System.Windows.Forms.Label();
            this.labelCardCode = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.labelCustomerId = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlStat4.SuspendLayout();
            this.pnlStat3.SuspendLayout();
            this.pnlStat2.SuspendLayout();
            this.pnlStat1.SuspendLayout();
            this.groupBoxFilter.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.groupBoxDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblAdmin);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Location = new System.Drawing.Point(12, 10);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1175, 50);
            this.pnlHeader.TabIndex = 5;
            // 
            // lblAdmin
            // 
            this.lblAdmin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAdmin.Location = new System.Drawing.Point(832, 15);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(326, 20);
            this.lblAdmin.TabIndex = 0;
            this.lblAdmin.Text = "Admin: ...";
            this.lblAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(2, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(205, 35);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Quản lý hội viên";
            // 
            // pnlStats
            // 
            this.pnlStats.Controls.Add(this.pnlStat4);
            this.pnlStats.Controls.Add(this.pnlStat3);
            this.pnlStats.Controls.Add(this.pnlStat2);
            this.pnlStats.Controls.Add(this.pnlStat1);
            this.pnlStats.Location = new System.Drawing.Point(12, 68);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(1175, 72);
            this.pnlStats.TabIndex = 4;
            // 
            // pnlStat4
            // 
            this.pnlStat4.BackColor = System.Drawing.Color.White;
            this.pnlStat4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStat4.Controls.Add(this.lblExpiredMembershipsValue);
            this.pnlStat4.Controls.Add(this.lblExpiredMembershipsTitle);
            this.pnlStat4.Location = new System.Drawing.Point(888, 0);
            this.pnlStat4.Name = "pnlStat4";
            this.pnlStat4.Size = new System.Drawing.Size(286, 70);
            this.pnlStat4.TabIndex = 0;
            // 
            // lblExpiredMembershipsValue
            // 
            this.lblExpiredMembershipsValue.AutoSize = true;
            this.lblExpiredMembershipsValue.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblExpiredMembershipsValue.Location = new System.Drawing.Point(17, 29);
            this.lblExpiredMembershipsValue.Name = "lblExpiredMembershipsValue";
            this.lblExpiredMembershipsValue.Size = new System.Drawing.Size(29, 35);
            this.lblExpiredMembershipsValue.TabIndex = 0;
            this.lblExpiredMembershipsValue.Text = "0";
            // 
            // lblExpiredMembershipsTitle
            // 
            this.lblExpiredMembershipsTitle.AutoSize = true;
            this.lblExpiredMembershipsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblExpiredMembershipsTitle.Location = new System.Drawing.Point(17, 9);
            this.lblExpiredMembershipsTitle.Name = "lblExpiredMembershipsTitle";
            this.lblExpiredMembershipsTitle.Size = new System.Drawing.Size(98, 21);
            this.lblExpiredMembershipsTitle.TabIndex = 1;
            this.lblExpiredMembershipsTitle.Text = "Gói hết hạn";
            // 
            // pnlStat3
            // 
            this.pnlStat3.BackColor = System.Drawing.Color.White;
            this.pnlStat3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStat3.Controls.Add(this.lblActiveMembershipsValue);
            this.pnlStat3.Controls.Add(this.lblActiveMembershipsTitle);
            this.pnlStat3.Location = new System.Drawing.Point(592, 0);
            this.pnlStat3.Name = "pnlStat3";
            this.pnlStat3.Size = new System.Drawing.Size(286, 70);
            this.pnlStat3.TabIndex = 1;
            // 
            // lblActiveMembershipsValue
            // 
            this.lblActiveMembershipsValue.AutoSize = true;
            this.lblActiveMembershipsValue.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblActiveMembershipsValue.Location = new System.Drawing.Point(17, 29);
            this.lblActiveMembershipsValue.Name = "lblActiveMembershipsValue";
            this.lblActiveMembershipsValue.Size = new System.Drawing.Size(29, 35);
            this.lblActiveMembershipsValue.TabIndex = 0;
            this.lblActiveMembershipsValue.Text = "0";
            // 
            // lblActiveMembershipsTitle
            // 
            this.lblActiveMembershipsTitle.AutoSize = true;
            this.lblActiveMembershipsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblActiveMembershipsTitle.Location = new System.Drawing.Point(17, 9);
            this.lblActiveMembershipsTitle.Name = "lblActiveMembershipsTitle";
            this.lblActiveMembershipsTitle.Size = new System.Drawing.Size(134, 21);
            this.lblActiveMembershipsTitle.TabIndex = 1;
            this.lblActiveMembershipsTitle.Text = "Gói còn hiệu lực";
            // 
            // pnlStat2
            // 
            this.pnlStat2.BackColor = System.Drawing.Color.White;
            this.pnlStat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStat2.Controls.Add(this.lblProfilesValue);
            this.pnlStat2.Controls.Add(this.lblProfilesTitle);
            this.pnlStat2.Location = new System.Drawing.Point(296, 0);
            this.pnlStat2.Name = "pnlStat2";
            this.pnlStat2.Size = new System.Drawing.Size(286, 70);
            this.pnlStat2.TabIndex = 2;
            // 
            // lblProfilesValue
            // 
            this.lblProfilesValue.AutoSize = true;
            this.lblProfilesValue.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblProfilesValue.Location = new System.Drawing.Point(17, 29);
            this.lblProfilesValue.Name = "lblProfilesValue";
            this.lblProfilesValue.Size = new System.Drawing.Size(29, 35);
            this.lblProfilesValue.TabIndex = 0;
            this.lblProfilesValue.Text = "0";
            // 
            // lblProfilesTitle
            // 
            this.lblProfilesTitle.AutoSize = true;
            this.lblProfilesTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProfilesTitle.Location = new System.Drawing.Point(17, 9);
            this.lblProfilesTitle.Name = "lblProfilesTitle";
            this.lblProfilesTitle.Size = new System.Drawing.Size(127, 21);
            this.lblProfilesTitle.TabIndex = 1;
            this.lblProfilesTitle.Text = "Đã có hồ sơ thẻ";
            // 
            // pnlStat1
            // 
            this.pnlStat1.BackColor = System.Drawing.Color.White;
            this.pnlStat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStat1.Controls.Add(this.lblTotalMembersValue);
            this.pnlStat1.Controls.Add(this.lblTotalMembersTitle);
            this.pnlStat1.Location = new System.Drawing.Point(0, 0);
            this.pnlStat1.Name = "pnlStat1";
            this.pnlStat1.Size = new System.Drawing.Size(286, 70);
            this.pnlStat1.TabIndex = 3;
            // 
            // lblTotalMembersValue
            // 
            this.lblTotalMembersValue.AutoSize = true;
            this.lblTotalMembersValue.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalMembersValue.Location = new System.Drawing.Point(17, 29);
            this.lblTotalMembersValue.Name = "lblTotalMembersValue";
            this.lblTotalMembersValue.Size = new System.Drawing.Size(29, 35);
            this.lblTotalMembersValue.TabIndex = 0;
            this.lblTotalMembersValue.Text = "0";
            // 
            // lblTotalMembersTitle
            // 
            this.lblTotalMembersTitle.AutoSize = true;
            this.lblTotalMembersTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalMembersTitle.Location = new System.Drawing.Point(17, 9);
            this.lblTotalMembersTitle.Name = "lblTotalMembersTitle";
            this.lblTotalMembersTitle.Size = new System.Drawing.Size(115, 21);
            this.lblTotalMembersTitle.TabIndex = 1;
            this.lblTotalMembersTitle.Text = "Tổng hội viên";
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.BackColor = System.Drawing.Color.White;
            this.groupBoxFilter.Controls.Add(this.btnRefresh);
            this.groupBoxFilter.Controls.Add(this.btnClearFilter);
            this.groupBoxFilter.Controls.Add(this.btnSearch);
            this.groupBoxFilter.Controls.Add(this.cboMembershipStatus);
            this.groupBoxFilter.Controls.Add(this.lblMembershipStatus);
            this.groupBoxFilter.Controls.Add(this.cboProfileStatus);
            this.groupBoxFilter.Controls.Add(this.lblProfileStatus);
            this.groupBoxFilter.Controls.Add(this.txtSearch);
            this.groupBoxFilter.Controls.Add(this.lblKeyword);
            this.groupBoxFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxFilter.Location = new System.Drawing.Point(12, 146);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(1175, 74);
            this.groupBoxFilter.TabIndex = 3;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Bộ lọc";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1063, 29);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 30);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(962, 29);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(95, 30);
            this.btnClearFilter.TabIndex = 1;
            this.btnClearFilter.Text = "Xóa lọc";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(861, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboMembershipStatus
            // 
            this.cboMembershipStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMembershipStatus.Location = new System.Drawing.Point(620, 30);
            this.cboMembershipStatus.Name = "cboMembershipStatus";
            this.cboMembershipStatus.Size = new System.Drawing.Size(225, 29);
            this.cboMembershipStatus.TabIndex = 3;
            // 
            // lblMembershipStatus
            // 
            this.lblMembershipStatus.AutoSize = true;
            this.lblMembershipStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMembershipStatus.Location = new System.Drawing.Point(515, 34);
            this.lblMembershipStatus.Name = "lblMembershipStatus";
            this.lblMembershipStatus.Size = new System.Drawing.Size(104, 20);
            this.lblMembershipStatus.TabIndex = 4;
            this.lblMembershipStatus.Text = "Trạng thái gói:";
            // 
            // cboProfileStatus
            // 
            this.cboProfileStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfileStatus.Location = new System.Drawing.Point(332, 30);
            this.cboProfileStatus.Name = "cboProfileStatus";
            this.cboProfileStatus.Size = new System.Drawing.Size(166, 29);
            this.cboProfileStatus.TabIndex = 5;
            // 
            // lblProfileStatus
            // 
            this.lblProfileStatus.AutoSize = true;
            this.lblProfileStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProfileStatus.Location = new System.Drawing.Point(242, 34);
            this.lblProfileStatus.Name = "lblProfileStatus";
            this.lblProfileStatus.Size = new System.Drawing.Size(103, 20);
            this.lblProfileStatus.TabIndex = 6;
            this.lblProfileStatus.Text = "Trạng thái thẻ:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(74, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(154, 29);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKeyword.Location = new System.Drawing.Point(17, 34);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(65, 20);
            this.lblKeyword.TabIndex = 8;
            this.lblKeyword.Text = "Từ khóa:";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.BackColor = System.Drawing.Color.White;
            this.groupBoxActions.Controls.Add(this.btnCheckin);
            this.groupBoxActions.Controls.Add(this.btnRenew);
            this.groupBoxActions.Controls.Add(this.btnRegister);
            this.groupBoxActions.Controls.Add(this.btnViewDetail);
            this.groupBoxActions.Controls.Add(this.btnToggleStatus);
            this.groupBoxActions.Controls.Add(this.btnDelete);
            this.groupBoxActions.Controls.Add(this.btnEdit);
            this.groupBoxActions.Controls.Add(this.btnAdd);
            this.groupBoxActions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxActions.Location = new System.Drawing.Point(12, 226);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(1175, 68);
            this.groupBoxActions.TabIndex = 2;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Thao tác nhanh";
            // 
            // btnCheckin
            // 
            this.btnCheckin.Location = new System.Drawing.Point(1034, 25);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new System.Drawing.Size(124, 30);
            this.btnCheckin.TabIndex = 0;
            this.btnCheckin.Text = "Check-in";
            this.btnCheckin.UseVisualStyleBackColor = true;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.Location = new System.Drawing.Point(889, 25);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(139, 30);
            this.btnRenew.TabIndex = 1;
            this.btnRenew.Text = "Gia hạn";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(744, 25);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(139, 30);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "Đăng ký gói";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(599, 25);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(139, 30);
            this.btnViewDetail.TabIndex = 3;
            this.btnViewDetail.Text = "Xem chi tiết";
            this.btnViewDetail.UseVisualStyleBackColor = true;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // btnToggleStatus
            // 
            this.btnToggleStatus.Location = new System.Drawing.Point(454, 25);
            this.btnToggleStatus.Name = "btnToggleStatus";
            this.btnToggleStatus.Size = new System.Drawing.Size(139, 30);
            this.btnToggleStatus.TabIndex = 4;
            this.btnToggleStatus.Text = "Khóa / Mở";
            this.btnToggleStatus.UseVisualStyleBackColor = true;
            this.btnToggleStatus.Click += new System.EventHandler(this.btnToggleStatus_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(309, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(139, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(164, 25);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(139, 30);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Sửa hồ sơ";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(19, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(139, 30);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm hội viên";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBoxList
            // 
            this.groupBoxList.BackColor = System.Drawing.Color.White;
            this.groupBoxList.Controls.Add(this.dgvMembers);
            this.groupBoxList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxList.Location = new System.Drawing.Point(12, 300);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(700, 406);
            this.groupBoxList.TabIndex = 1;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "Danh sách hội viên";
            // 
            // dgvMembers
            // 
            this.dgvMembers.ColumnHeadersHeight = 29;
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMembers.Location = new System.Drawing.Point(14, 25);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.RowHeadersWidth = 51;
            this.dgvMembers.Size = new System.Drawing.Size(670, 365);
            this.dgvMembers.TabIndex = 0;
            this.dgvMembers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembers_CellDoubleClick);
            this.dgvMembers.SelectionChanged += new System.EventHandler(this.dgvMembers_SelectionChanged);
            // 
            // groupBoxDetail
            // 
            this.groupBoxDetail.BackColor = System.Drawing.Color.White;
            this.groupBoxDetail.Controls.Add(this.lblCreatedAtValue);
            this.groupBoxDetail.Controls.Add(this.lblLastCheckinValue);
            this.groupBoxDetail.Controls.Add(this.lblTotalCheckinCountValue);
            this.groupBoxDetail.Controls.Add(this.lblTotalMembershipCountValue);
            this.groupBoxDetail.Controls.Add(this.lblPriceValue);
            this.groupBoxDetail.Controls.Add(this.lblEndDateValue);
            this.groupBoxDetail.Controls.Add(this.lblStartDateValue);
            this.groupBoxDetail.Controls.Add(this.lblTrainerValue);
            this.groupBoxDetail.Controls.Add(this.lblMembershipStatusValue);
            this.groupBoxDetail.Controls.Add(this.lblCurrentPackageValue);
            this.groupBoxDetail.Controls.Add(this.lblProfileStatusValue);
            this.groupBoxDetail.Controls.Add(this.lblJoinDateValue);
            this.groupBoxDetail.Controls.Add(this.lblIdentityValue);
            this.groupBoxDetail.Controls.Add(this.lblCardCodeValue);
            this.groupBoxDetail.Controls.Add(this.lblAddressValue);
            this.groupBoxDetail.Controls.Add(this.lblPhoneValue);
            this.groupBoxDetail.Controls.Add(this.lblFullNameValue);
            this.groupBoxDetail.Controls.Add(this.lblCustomerIdValue);
            this.groupBoxDetail.Controls.Add(this.labelCreatedAt);
            this.groupBoxDetail.Controls.Add(this.labelLastCheckin);
            this.groupBoxDetail.Controls.Add(this.labelTotalCheckinCount);
            this.groupBoxDetail.Controls.Add(this.labelTotalMembershipCount);
            this.groupBoxDetail.Controls.Add(this.labelPrice);
            this.groupBoxDetail.Controls.Add(this.labelEndDate);
            this.groupBoxDetail.Controls.Add(this.labelStartDate);
            this.groupBoxDetail.Controls.Add(this.labelTrainer);
            this.groupBoxDetail.Controls.Add(this.labelMembershipStatusText);
            this.groupBoxDetail.Controls.Add(this.labelCurrentPackage);
            this.groupBoxDetail.Controls.Add(this.labelProfileStatusText);
            this.groupBoxDetail.Controls.Add(this.labelJoinDate);
            this.groupBoxDetail.Controls.Add(this.labelIdentity);
            this.groupBoxDetail.Controls.Add(this.labelCardCode);
            this.groupBoxDetail.Controls.Add(this.labelAddress);
            this.groupBoxDetail.Controls.Add(this.labelPhone);
            this.groupBoxDetail.Controls.Add(this.labelFullName);
            this.groupBoxDetail.Controls.Add(this.labelCustomerId);
            this.groupBoxDetail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxDetail.Location = new System.Drawing.Point(718, 300);
            this.groupBoxDetail.Name = "groupBoxDetail";
            this.groupBoxDetail.Size = new System.Drawing.Size(469, 406);
            this.groupBoxDetail.TabIndex = 0;
            this.groupBoxDetail.TabStop = false;
            this.groupBoxDetail.Text = "Thông tin chi tiết";
            // 
            // lblCreatedAtValue
            // 
            this.lblCreatedAtValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreatedAtValue.Location = new System.Drawing.Point(158, 390);
            this.lblCreatedAtValue.Name = "lblCreatedAtValue";
            this.lblCreatedAtValue.Size = new System.Drawing.Size(290, 17);
            this.lblCreatedAtValue.TabIndex = 0;
            this.lblCreatedAtValue.Text = "-";
            // 
            // lblLastCheckinValue
            // 
            this.lblLastCheckinValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLastCheckinValue.Location = new System.Drawing.Point(158, 370);
            this.lblLastCheckinValue.Name = "lblLastCheckinValue";
            this.lblLastCheckinValue.Size = new System.Drawing.Size(290, 17);
            this.lblLastCheckinValue.TabIndex = 1;
            this.lblLastCheckinValue.Text = "-";
            // 
            // lblTotalCheckinCountValue
            // 
            this.lblTotalCheckinCountValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalCheckinCountValue.Location = new System.Drawing.Point(158, 350);
            this.lblTotalCheckinCountValue.Name = "lblTotalCheckinCountValue";
            this.lblTotalCheckinCountValue.Size = new System.Drawing.Size(290, 17);
            this.lblTotalCheckinCountValue.TabIndex = 2;
            this.lblTotalCheckinCountValue.Text = "0";
            // 
            // lblTotalMembershipCountValue
            // 
            this.lblTotalMembershipCountValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalMembershipCountValue.Location = new System.Drawing.Point(158, 330);
            this.lblTotalMembershipCountValue.Name = "lblTotalMembershipCountValue";
            this.lblTotalMembershipCountValue.Size = new System.Drawing.Size(290, 17);
            this.lblTotalMembershipCountValue.TabIndex = 3;
            this.lblTotalMembershipCountValue.Text = "0";
            // 
            // lblPriceValue
            // 
            this.lblPriceValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPriceValue.Location = new System.Drawing.Point(158, 310);
            this.lblPriceValue.Name = "lblPriceValue";
            this.lblPriceValue.Size = new System.Drawing.Size(290, 17);
            this.lblPriceValue.TabIndex = 4;
            this.lblPriceValue.Text = "-";
            // 
            // lblEndDateValue
            // 
            this.lblEndDateValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEndDateValue.Location = new System.Drawing.Point(158, 290);
            this.lblEndDateValue.Name = "lblEndDateValue";
            this.lblEndDateValue.Size = new System.Drawing.Size(290, 17);
            this.lblEndDateValue.TabIndex = 5;
            this.lblEndDateValue.Text = "-";
            // 
            // lblStartDateValue
            // 
            this.lblStartDateValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStartDateValue.Location = new System.Drawing.Point(158, 270);
            this.lblStartDateValue.Name = "lblStartDateValue";
            this.lblStartDateValue.Size = new System.Drawing.Size(290, 17);
            this.lblStartDateValue.TabIndex = 6;
            this.lblStartDateValue.Text = "-";
            // 
            // lblTrainerValue
            // 
            this.lblTrainerValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrainerValue.Location = new System.Drawing.Point(158, 250);
            this.lblTrainerValue.Name = "lblTrainerValue";
            this.lblTrainerValue.Size = new System.Drawing.Size(290, 17);
            this.lblTrainerValue.TabIndex = 7;
            this.lblTrainerValue.Text = "-";
            // 
            // lblMembershipStatusValue
            // 
            this.lblMembershipStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMembershipStatusValue.Location = new System.Drawing.Point(158, 230);
            this.lblMembershipStatusValue.Name = "lblMembershipStatusValue";
            this.lblMembershipStatusValue.Size = new System.Drawing.Size(290, 17);
            this.lblMembershipStatusValue.TabIndex = 8;
            this.lblMembershipStatusValue.Text = "-";
            // 
            // lblCurrentPackageValue
            // 
            this.lblCurrentPackageValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPackageValue.Location = new System.Drawing.Point(158, 210);
            this.lblCurrentPackageValue.Name = "lblCurrentPackageValue";
            this.lblCurrentPackageValue.Size = new System.Drawing.Size(290, 17);
            this.lblCurrentPackageValue.TabIndex = 9;
            this.lblCurrentPackageValue.Text = "-";
            // 
            // lblProfileStatusValue
            // 
            this.lblProfileStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProfileStatusValue.Location = new System.Drawing.Point(158, 190);
            this.lblProfileStatusValue.Name = "lblProfileStatusValue";
            this.lblProfileStatusValue.Size = new System.Drawing.Size(290, 17);
            this.lblProfileStatusValue.TabIndex = 10;
            this.lblProfileStatusValue.Text = "-";
            // 
            // lblJoinDateValue
            // 
            this.lblJoinDateValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblJoinDateValue.Location = new System.Drawing.Point(158, 170);
            this.lblJoinDateValue.Name = "lblJoinDateValue";
            this.lblJoinDateValue.Size = new System.Drawing.Size(290, 17);
            this.lblJoinDateValue.TabIndex = 11;
            this.lblJoinDateValue.Text = "-";
            // 
            // lblIdentityValue
            // 
            this.lblIdentityValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIdentityValue.Location = new System.Drawing.Point(158, 150);
            this.lblIdentityValue.Name = "lblIdentityValue";
            this.lblIdentityValue.Size = new System.Drawing.Size(290, 17);
            this.lblIdentityValue.TabIndex = 12;
            this.lblIdentityValue.Text = "-";
            // 
            // lblCardCodeValue
            // 
            this.lblCardCodeValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardCodeValue.Location = new System.Drawing.Point(158, 130);
            this.lblCardCodeValue.Name = "lblCardCodeValue";
            this.lblCardCodeValue.Size = new System.Drawing.Size(290, 17);
            this.lblCardCodeValue.TabIndex = 13;
            this.lblCardCodeValue.Text = "-";
            // 
            // lblAddressValue
            // 
            this.lblAddressValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAddressValue.Location = new System.Drawing.Point(158, 94);
            this.lblAddressValue.Name = "lblAddressValue";
            this.lblAddressValue.Size = new System.Drawing.Size(290, 32);
            this.lblAddressValue.TabIndex = 14;
            this.lblAddressValue.Text = "-";
            // 
            // lblPhoneValue
            // 
            this.lblPhoneValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhoneValue.Location = new System.Drawing.Point(158, 74);
            this.lblPhoneValue.Name = "lblPhoneValue";
            this.lblPhoneValue.Size = new System.Drawing.Size(290, 17);
            this.lblPhoneValue.TabIndex = 15;
            this.lblPhoneValue.Text = "-";
            // 
            // lblFullNameValue
            // 
            this.lblFullNameValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFullNameValue.Location = new System.Drawing.Point(158, 54);
            this.lblFullNameValue.Name = "lblFullNameValue";
            this.lblFullNameValue.Size = new System.Drawing.Size(290, 17);
            this.lblFullNameValue.TabIndex = 16;
            this.lblFullNameValue.Text = "-";
            // 
            // lblCustomerIdValue
            // 
            this.lblCustomerIdValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCustomerIdValue.Location = new System.Drawing.Point(158, 34);
            this.lblCustomerIdValue.Name = "lblCustomerIdValue";
            this.lblCustomerIdValue.Size = new System.Drawing.Size(290, 17);
            this.lblCustomerIdValue.TabIndex = 17;
            this.lblCustomerIdValue.Text = "-";
            // 
            // labelCreatedAt
            // 
            this.labelCreatedAt.AutoSize = true;
            this.labelCreatedAt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelCreatedAt.Location = new System.Drawing.Point(16, 390);
            this.labelCreatedAt.Name = "labelCreatedAt";
            this.labelCreatedAt.Size = new System.Drawing.Size(113, 20);
            this.labelCreatedAt.TabIndex = 18;
            this.labelCreatedAt.Text = "Ngày tạo hồ sơ:";
            // 
            // labelLastCheckin
            // 
            this.labelLastCheckin.AutoSize = true;
            this.labelLastCheckin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelLastCheckin.Location = new System.Drawing.Point(16, 370);
            this.labelLastCheckin.Name = "labelLastCheckin";
            this.labelLastCheckin.Size = new System.Drawing.Size(131, 20);
            this.labelLastCheckin.TabIndex = 19;
            this.labelLastCheckin.Text = "Check-in gần nhất:";
            // 
            // labelTotalCheckinCount
            // 
            this.labelTotalCheckinCount.AutoSize = true;
            this.labelTotalCheckinCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelTotalCheckinCount.Location = new System.Drawing.Point(16, 350);
            this.labelTotalCheckinCount.Name = "labelTotalCheckinCount";
            this.labelTotalCheckinCount.Size = new System.Drawing.Size(148, 20);
            this.labelTotalCheckinCount.TabIndex = 20;
            this.labelTotalCheckinCount.Text = "Tổng số lần check-in:";
            // 
            // labelTotalMembershipCount
            // 
            this.labelTotalMembershipCount.AutoSize = true;
            this.labelTotalMembershipCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelTotalMembershipCount.Location = new System.Drawing.Point(16, 330);
            this.labelTotalMembershipCount.Name = "labelTotalMembershipCount";
            this.labelTotalMembershipCount.Size = new System.Drawing.Size(145, 20);
            this.labelTotalMembershipCount.TabIndex = 21;
            this.labelTotalMembershipCount.Text = "Tổng số lần đăng ký:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelPrice.Location = new System.Drawing.Point(16, 310);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(122, 20);
            this.labelPrice.TabIndex = 22;
            this.labelPrice.Text = "Giá gói gần nhất:";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelEndDate.Location = new System.Drawing.Point(16, 290);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(92, 20);
            this.labelEndDate.TabIndex = 23;
            this.labelEndDate.Text = "Kết thúc gói:";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelStartDate.Location = new System.Drawing.Point(16, 270);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(89, 20);
            this.labelStartDate.TabIndex = 24;
            this.labelStartDate.Text = "Bắt đầu gói:";
            // 
            // labelTrainer
            // 
            this.labelTrainer.AutoSize = true;
            this.labelTrainer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelTrainer.Location = new System.Drawing.Point(16, 250);
            this.labelTrainer.Name = "labelTrainer";
            this.labelTrainer.Size = new System.Drawing.Size(94, 20);
            this.labelTrainer.TabIndex = 25;
            this.labelTrainer.Text = "PT phụ trách:";
            // 
            // labelMembershipStatusText
            // 
            this.labelMembershipStatusText.AutoSize = true;
            this.labelMembershipStatusText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelMembershipStatusText.Location = new System.Drawing.Point(16, 230);
            this.labelMembershipStatusText.Name = "labelMembershipStatusText";
            this.labelMembershipStatusText.Size = new System.Drawing.Size(104, 20);
            this.labelMembershipStatusText.TabIndex = 26;
            this.labelMembershipStatusText.Text = "Trạng thái gói:";
            // 
            // labelCurrentPackage
            // 
            this.labelCurrentPackage.AutoSize = true;
            this.labelCurrentPackage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelCurrentPackage.Location = new System.Drawing.Point(16, 210);
            this.labelCurrentPackage.Name = "labelCurrentPackage";
            this.labelCurrentPackage.Size = new System.Drawing.Size(88, 20);
            this.labelCurrentPackage.TabIndex = 27;
            this.labelCurrentPackage.Text = "Gói hiện tại:";
            // 
            // labelProfileStatusText
            // 
            this.labelProfileStatusText.AutoSize = true;
            this.labelProfileStatusText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelProfileStatusText.Location = new System.Drawing.Point(16, 190);
            this.labelProfileStatusText.Name = "labelProfileStatusText";
            this.labelProfileStatusText.Size = new System.Drawing.Size(118, 20);
            this.labelProfileStatusText.TabIndex = 28;
            this.labelProfileStatusText.Text = "Trạng thái hồ sơ:";
            // 
            // labelJoinDate
            // 
            this.labelJoinDate.AutoSize = true;
            this.labelJoinDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelJoinDate.Location = new System.Drawing.Point(16, 170);
            this.labelJoinDate.Name = "labelJoinDate";
            this.labelJoinDate.Size = new System.Drawing.Size(110, 20);
            this.labelJoinDate.TabIndex = 29;
            this.labelJoinDate.Text = "Ngày tham gia:";
            // 
            // labelIdentity
            // 
            this.labelIdentity.AutoSize = true;
            this.labelIdentity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelIdentity.Location = new System.Drawing.Point(16, 150);
            this.labelIdentity.Name = "labelIdentity";
            this.labelIdentity.Size = new System.Drawing.Size(100, 20);
            this.labelIdentity.TabIndex = 30;
            this.labelIdentity.Text = "CCCD/CMND:";
            // 
            // labelCardCode
            // 
            this.labelCardCode.AutoSize = true;
            this.labelCardCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelCardCode.Location = new System.Drawing.Point(16, 130);
            this.labelCardCode.Name = "labelCardCode";
            this.labelCardCode.Size = new System.Drawing.Size(58, 20);
            this.labelCardCode.TabIndex = 31;
            this.labelCardCode.Text = "Mã thẻ:";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelAddress.Location = new System.Drawing.Point(16, 94);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(58, 20);
            this.labelAddress.TabIndex = 32;
            this.labelAddress.Text = "Địa chỉ:";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelPhone.Location = new System.Drawing.Point(16, 74);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(100, 20);
            this.labelPhone.TabIndex = 33;
            this.labelPhone.Text = "Số điện thoại:";
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelFullName.Location = new System.Drawing.Point(16, 54);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(57, 20);
            this.labelFullName.TabIndex = 34;
            this.labelFullName.Text = "Họ tên:";
            // 
            // labelCustomerId
            // 
            this.labelCustomerId.AutoSize = true;
            this.labelCustomerId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelCustomerId.Location = new System.Drawing.Point(16, 34);
            this.labelCustomerId.Name = "labelCustomerId";
            this.labelCustomerId.Size = new System.Drawing.Size(89, 20);
            this.labelCustomerId.TabIndex = 35;
            this.labelCustomerId.Text = "Mã hội viên:";
            // 
            // AdminMembersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1199, 813);
            this.Controls.Add(this.groupBoxDetail);
            this.Controls.Add(this.groupBoxList);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminMembersForm";
            this.Text = "Quản lý hội viên";
            this.Load += new System.EventHandler(this.AdminMembersForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStat4.ResumeLayout(false);
            this.pnlStat4.PerformLayout();
            this.pnlStat3.ResumeLayout(false);
            this.pnlStat3.PerformLayout();
            this.pnlStat2.ResumeLayout(false);
            this.pnlStat2.PerformLayout();
            this.pnlStat1.ResumeLayout(false);
            this.pnlStat1.PerformLayout();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.groupBoxDetail.ResumeLayout(false);
            this.groupBoxDetail.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
