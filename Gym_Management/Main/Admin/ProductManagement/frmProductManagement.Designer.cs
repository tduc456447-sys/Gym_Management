namespace Gym_Management.Main.Admin.ProductManagement
{
    partial class frmProductManagement
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlFormHeader;
        private System.Windows.Forms.Panel pnlGridHeader;
        private System.Windows.Forms.Panel pnlActions;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPreviewTitle;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblFilterBrand;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboFilterBrand;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.PictureBox picProduct;

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

        private System.Windows.Forms.DataGridView dgvProducts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterBrand = new System.Windows.Forms.Label();
            this.cboFilterBrand = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlFormHeader = new System.Windows.Forms.Panel();
            this.pnlActions = new System.Windows.Forms.Panel();

            this.lblProductId = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPreviewTitle = new System.Windows.Forms.Label();

            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.btnChooseImage = new System.Windows.Forms.Button();
            this.picProduct = new System.Windows.Forms.PictureBox();

            this.btnNew = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlGridHeader = new System.Windows.Forms.Panel();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFormHeader.SuspendLayout();
            this.pnlGridHeader.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            this.ClientSize = new System.Drawing.Size(1380, 820);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProductManagement";
            this.Text = "Quản lý hàng hóa";
            this.Load += new System.EventHandler(this.frmProductManagement_Load);

            // ================= TOP =================
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1340, 95);
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new System.Drawing.Point(18, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Quản lý hàng hóa";

            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(21, 52);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Text = "Thêm, cập nhật, tìm kiếm và quản lý sản phẩm";

            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblSearch.Location = new System.Drawing.Point(535, 18);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Từ khóa";

            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(538, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(240, 30);
            this.txtSearch.TabIndex = 0;

            this.lblFilterBrand.AutoSize = true;
            this.lblFilterBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFilterBrand.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblFilterBrand.Location = new System.Drawing.Point(792, 18);
            this.lblFilterBrand.Name = "lblFilterBrand";
            this.lblFilterBrand.Text = "Hãng";

            this.cboFilterBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFilterBrand.Location = new System.Drawing.Point(795, 42);
            this.cboFilterBrand.Name = "cboFilterBrand";
            this.cboFilterBrand.Size = new System.Drawing.Size(180, 31);
            this.cboFilterBrand.TabIndex = 1;

            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(995, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 36);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.btnRefresh.Location = new System.Drawing.Point(1125, 40);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 36);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblSubTitle);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblFilterBrand);
            this.pnlTop.Controls.Add(this.cboFilterBrand);
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Controls.Add(this.btnRefresh);

            // ================= LEFT =================
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Location = new System.Drawing.Point(20, 125);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(430, 675);
            this.pnlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));

            this.pnlFormHeader.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlFormHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlFormHeader.Name = "pnlFormHeader";
            this.pnlFormHeader.Size = new System.Drawing.Size(430, 55);

            System.Windows.Forms.Label lblHeaderLeft = new System.Windows.Forms.Label();
            lblHeaderLeft.AutoSize = true;
            lblHeaderLeft.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            lblHeaderLeft.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            lblHeaderLeft.Location = new System.Drawing.Point(16, 14);
            lblHeaderLeft.Text = "Thông tin hàng hóa";
            this.pnlFormHeader.Controls.Add(lblHeaderLeft);

            int leftX = 22;
            int rightX = 225;
            int inputW = 180;
            int fullW = 385;

            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(leftX, 72);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Text = "Mã sản phẩm";

            this.txtProductId.Location = new System.Drawing.Point(leftX, 95);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.ReadOnly = true;
            this.txtProductId.Size = new System.Drawing.Size(fullW, 30);
            this.txtProductId.TabIndex = 4;

            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(leftX, 136);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Text = "Tên hàng hóa";

            this.txtProductName.Location = new System.Drawing.Point(leftX, 159);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(fullW, 30);
            this.txtProductName.TabIndex = 5;

            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(leftX, 202);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Text = "Hãng";

            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBrand.Location = new System.Drawing.Point(leftX, 225);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(inputW, 31);
            this.cboBrand.TabIndex = 6;

            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(rightX, 202);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Text = "Đơn vị";

            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboUnit.Location = new System.Drawing.Point(rightX, 225);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(inputW, 31);
            this.cboUnit.TabIndex = 7;

            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(leftX, 269);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "Giá bán";

            this.txtPrice.Location = new System.Drawing.Point(leftX, 292);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(inputW, 30);
            this.txtPrice.TabIndex = 8;

            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(rightX, 269);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Text = "Số lượng";

            this.txtQuantity.Location = new System.Drawing.Point(rightX, 292);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(inputW, 30);
            this.txtQuantity.TabIndex = 9;

            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(leftX, 336);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Text = "Mã vạch";

            this.txtBarcode.Location = new System.Drawing.Point(leftX, 359);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(fullW, 30);
            this.txtBarcode.TabIndex = 10;

            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(leftX, 401);
            this.lblImage.Name = "lblImage";
            this.lblImage.Text = "Tên file ảnh";

            this.txtImage.Location = new System.Drawing.Point(leftX, 424);
            this.txtImage.Name = "txtImage";
            this.txtImage.ReadOnly = true;
            this.txtImage.Size = new System.Drawing.Size(265, 30);
            this.txtImage.TabIndex = 11;

            this.btnChooseImage.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnChooseImage.FlatAppearance.BorderSize = 0;
            this.btnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseImage.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnChooseImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseImage.Location = new System.Drawing.Point(294, 423);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(113, 32);
            this.btnChooseImage.TabIndex = 12;
            this.btnChooseImage.Text = "Chọn ảnh";
            this.btnChooseImage.UseVisualStyleBackColor = false;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);

            this.lblPreviewTitle.AutoSize = true;
            this.lblPreviewTitle.Location = new System.Drawing.Point(leftX, 465);
            this.lblPreviewTitle.Name = "lblPreviewTitle";
            this.lblPreviewTitle.Text = "Xem trước ảnh";

            this.picProduct.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProduct.Location = new System.Drawing.Point(leftX, 488);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(150, 120);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabStop = false;

            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(187, 465);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Text = "Mô tả";

            this.txtDescription.Location = new System.Drawing.Point(190, 488);
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(217, 120);
            this.txtDescription.TabIndex = 13;

            this.pnlActions.Location = new System.Drawing.Point(20, 624);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(390, 40);

            this.btnNew.BackColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNew.Location = new System.Drawing.Point(0, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(90, 36);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "Mới";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(100, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 36);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(200, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 36);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(300, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 36);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.pnlActions.Controls.Add(this.btnNew);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Controls.Add(this.btnUpdate);
            this.pnlActions.Controls.Add(this.btnDelete);

            this.pnlLeft.Controls.Add(this.pnlFormHeader);
            this.pnlLeft.Controls.Add(this.lblProductId);
            this.pnlLeft.Controls.Add(this.txtProductId);
            this.pnlLeft.Controls.Add(this.lblProductName);
            this.pnlLeft.Controls.Add(this.txtProductName);
            this.pnlLeft.Controls.Add(this.lblBrand);
            this.pnlLeft.Controls.Add(this.cboBrand);
            this.pnlLeft.Controls.Add(this.lblUnit);
            this.pnlLeft.Controls.Add(this.cboUnit);
            this.pnlLeft.Controls.Add(this.lblPrice);
            this.pnlLeft.Controls.Add(this.txtPrice);
            this.pnlLeft.Controls.Add(this.lblQuantity);
            this.pnlLeft.Controls.Add(this.txtQuantity);
            this.pnlLeft.Controls.Add(this.lblBarcode);
            this.pnlLeft.Controls.Add(this.txtBarcode);
            this.pnlLeft.Controls.Add(this.lblImage);
            this.pnlLeft.Controls.Add(this.txtImage);
            this.pnlLeft.Controls.Add(this.btnChooseImage);
            this.pnlLeft.Controls.Add(this.lblPreviewTitle);
            this.pnlLeft.Controls.Add(this.picProduct);
            this.pnlLeft.Controls.Add(this.lblDescription);
            this.pnlLeft.Controls.Add(this.txtDescription);
            this.pnlLeft.Controls.Add(this.pnlActions);

            // ================= RIGHT =================
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Location = new System.Drawing.Point(465, 125);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(895, 675);
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

            this.pnlGridHeader.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlGridHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlGridHeader.Name = "pnlGridHeader";
            this.pnlGridHeader.Size = new System.Drawing.Size(895, 55);
            this.pnlGridHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblListTitle.Location = new System.Drawing.Point(18, 14);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Text = "Danh sách hàng hóa";

            this.pnlGridHeader.Controls.Add(this.lblListTitle);

            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.ColumnHeadersHeight = 42;
            this.dgvProducts.Location = new System.Drawing.Point(18, 70);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowTemplate.Height = 36;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(860, 585);
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            this.dgvProducts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvProducts_DataBindingComplete);

            this.pnlRight.Controls.Add(this.pnlGridHeader);
            this.pnlRight.Controls.Add(this.dgvProducts);

            // Add form controls
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFormHeader.ResumeLayout(false);
            this.pnlGridHeader.ResumeLayout(false);
            this.pnlGridHeader.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
        }
    }
}