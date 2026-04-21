namespace Gym_Management.Main.Admin
{
    partial class ImportForm
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
            this.lblAdmin = new System.Windows.Forms.Label();
            this.groupBoxTop = new System.Windows.Forms.GroupBox();
            this.btnAddSupplierContact = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.cboSupplierContact = new System.Windows.Forms.ComboBox();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxProduct = new System.Windows.Forms.GroupBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxCart = new System.Windows.Forms.GroupBox();
            this.btnEditPrice = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDebt = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.dgvImport = new System.Windows.Forms.DataGridView();
            this.groupBoxTop.SuspendLayout();
            this.groupBoxProduct.SuspendLayout();
            this.groupBoxCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAdmin.Location = new System.Drawing.Point(18, 14);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(124, 28);
            this.lblAdmin.TabIndex = 0;
            this.lblAdmin.Text = "Admin: ...";
            // 
            // groupBoxTop
            // 
            this.groupBoxTop.Controls.Add(this.btnAddSupplierContact);
            this.groupBoxTop.Controls.Add(this.btnAddSupplier);
            this.groupBoxTop.Controls.Add(this.cboSupplierContact);
            this.groupBoxTop.Controls.Add(this.cboSupplier);
            this.groupBoxTop.Controls.Add(this.txtNote);
            this.groupBoxTop.Controls.Add(this.txtPaidAmount);
            this.groupBoxTop.Controls.Add(this.label6);
            this.groupBoxTop.Controls.Add(this.label5);
            this.groupBoxTop.Controls.Add(this.label2);
            this.groupBoxTop.Controls.Add(this.label1);
            this.groupBoxTop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxTop.Location = new System.Drawing.Point(23, 54);
            this.groupBoxTop.Name = "groupBoxTop";
            this.groupBoxTop.Size = new System.Drawing.Size(1245, 136);
            this.groupBoxTop.TabIndex = 1;
            this.groupBoxTop.TabStop = false;
            this.groupBoxTop.Text = "Thông tin phiếu nhập";
            // 
            // btnAddSupplierContact
            // 
            this.btnAddSupplierContact.Location = new System.Drawing.Point(1143, 32);
            this.btnAddSupplierContact.Name = "btnAddSupplierContact";
            this.btnAddSupplierContact.Size = new System.Drawing.Size(82, 32);
            this.btnAddSupplierContact.TabIndex = 9;
            this.btnAddSupplierContact.Text = "+ Liên hệ";
            this.btnAddSupplierContact.UseVisualStyleBackColor = true;
            this.btnAddSupplierContact.Click += new System.EventHandler(this.btnAddSupplierContact_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(518, 31);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(75, 32);
            this.btnAddSupplier.TabIndex = 8;
            this.btnAddSupplier.Text = "+ NCC";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // cboSupplierContact
            // 
            this.cboSupplierContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplierContact.FormattingEnabled = true;
            this.cboSupplierContact.Location = new System.Drawing.Point(819, 32);
            this.cboSupplierContact.Name = "cboSupplierContact";
            this.cboSupplierContact.Size = new System.Drawing.Size(318, 31);
            this.cboSupplierContact.TabIndex = 7;
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(140, 31);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(372, 31);
            this.cboSupplier.TabIndex = 6;
            this.cboSupplier.SelectedIndexChanged += new System.EventHandler(this.cboSupplier_SelectedIndexChanged);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(140, 81);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(997, 30);
            this.txtNote.TabIndex = 5;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Location = new System.Drawing.Point(819, 81);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(181, 30);
            this.txtPaidAmount.TabIndex = 4;
            this.txtPaidAmount.Text = "0";
            this.txtPaidAmount.TextChanged += new System.EventHandler(this.txtPaidAmount_TextChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(669, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 28);
            this.label6.TabIndex = 3;
            this.label6.Text = "Đã trả:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(669, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 28);
            this.label5.TabIndex = 2;
            this.label5.Text = "Người liên hệ:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ghi chú:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhà cung cấp:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxProduct
            // 
            this.groupBoxProduct.Controls.Add(this.btnAddProduct);
            this.groupBoxProduct.Controls.Add(this.cboBrand);
            this.groupBoxProduct.Controls.Add(this.txtSearchProduct);
            this.groupBoxProduct.Controls.Add(this.label4);
            this.groupBoxProduct.Controls.Add(this.label3);
            this.groupBoxProduct.Controls.Add(this.flowProducts);
            this.groupBoxProduct.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxProduct.Location = new System.Drawing.Point(23, 206);
            this.groupBoxProduct.Name = "groupBoxProduct";
            this.groupBoxProduct.Size = new System.Drawing.Size(711, 554);
            this.groupBoxProduct.TabIndex = 2;
            this.groupBoxProduct.TabStop = false;
            this.groupBoxProduct.Text = "Danh sách sản phẩm";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(588, 30);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(107, 32);
            this.btnAddProduct.TabIndex = 5;
            this.btnAddProduct.Text = "+ Sản phẩm";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(360, 31);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(210, 31);
            this.cboBrand.TabIndex = 4;
            this.cboBrand.SelectedIndexChanged += new System.EventHandler(this.cboBrand_SelectedIndexChanged);
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Location = new System.Drawing.Point(67, 31);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(204, 30);
            this.txtSearchProduct.TabIndex = 3;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(287, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hãng:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tìm:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowProducts
            // 
            this.flowProducts.AutoScroll = true;
            this.flowProducts.BackColor = System.Drawing.Color.Gainsboro;
            this.flowProducts.Location = new System.Drawing.Point(11, 79);
            this.flowProducts.Name = "flowProducts";
            this.flowProducts.Size = new System.Drawing.Size(684, 459);
            this.flowProducts.TabIndex = 0;
            // 
            // groupBoxCart
            // 
            this.groupBoxCart.Controls.Add(this.btnEditPrice);
            this.groupBoxCart.Controls.Add(this.btnSave);
            this.groupBoxCart.Controls.Add(this.lblDebt);
            this.groupBoxCart.Controls.Add(this.lblTotal);
            this.groupBoxCart.Controls.Add(this.label8);
            this.groupBoxCart.Controls.Add(this.label7);
            this.groupBoxCart.Controls.Add(this.btnRemove);
            this.groupBoxCart.Controls.Add(this.btnDecrease);
            this.groupBoxCart.Controls.Add(this.btnIncrease);
            this.groupBoxCart.Controls.Add(this.dgvImport);
            this.groupBoxCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxCart.Location = new System.Drawing.Point(752, 206);
            this.groupBoxCart.Name = "groupBoxCart";
            this.groupBoxCart.Size = new System.Drawing.Size(516, 554);
            this.groupBoxCart.TabIndex = 3;
            this.groupBoxCart.TabStop = false;
            this.groupBoxCart.Text = "Chi tiết nhập hàng";
            // 
            // btnEditPrice
            // 
            this.btnEditPrice.Location = new System.Drawing.Point(270, 441);
            this.btnEditPrice.Name = "btnEditPrice";
            this.btnEditPrice.Size = new System.Drawing.Size(110, 36);
            this.btnEditPrice.TabIndex = 9;
            this.btnEditPrice.Text = "Sửa giá";
            this.btnEditPrice.UseVisualStyleBackColor = true;
            this.btnEditPrice.Click += new System.EventHandler(this.btnEditPrice_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(345, 500);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(147, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu phiếu nhập";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDebt
            // 
            this.lblDebt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDebt.ForeColor = System.Drawing.Color.Firebrick;
            this.lblDebt.Location = new System.Drawing.Point(169, 512);
            this.lblDebt.Name = "lblDebt";
            this.lblDebt.Size = new System.Drawing.Size(150, 24);
            this.lblDebt.TabIndex = 7;
            this.lblDebt.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotal.Location = new System.Drawing.Point(169, 484);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(150, 24);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "0";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(17, 512);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 24);
            this.label8.TabIndex = 5;
            this.label8.Text = "Còn nợ:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(17, 484);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 24);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tổng tiền:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(386, 441);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(106, 36);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnDecrease
            // 
            this.btnDecrease.Location = new System.Drawing.Point(142, 441);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(110, 36);
            this.btnDecrease.TabIndex = 2;
            this.btnDecrease.Text = "- SL";
            this.btnDecrease.UseVisualStyleBackColor = true;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // btnIncrease
            // 
            this.btnIncrease.Location = new System.Drawing.Point(20, 441);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(110, 36);
            this.btnIncrease.TabIndex = 1;
            this.btnIncrease.Text = "+ SL";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // dgvImport
            // 
            this.dgvImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImport.Location = new System.Drawing.Point(20, 31);
            this.dgvImport.Name = "dgvImport";
            this.dgvImport.RowHeadersWidth = 51;
            this.dgvImport.RowTemplate.Height = 24;
            this.dgvImport.Size = new System.Drawing.Size(472, 393);
            this.dgvImport.TabIndex = 0;
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 780);
            this.Controls.Add(this.groupBoxCart);
            this.Controls.Add(this.groupBoxProduct);
            this.Controls.Add(this.groupBoxTop);
            this.Controls.Add(this.lblAdmin);
            this.Name = "ImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập hàng";
            this.Load += new System.EventHandler(this.ImportForm_Load);
            this.groupBoxTop.ResumeLayout(false);
            this.groupBoxTop.PerformLayout();
            this.groupBoxProduct.ResumeLayout(false);
            this.groupBoxProduct.PerformLayout();
            this.groupBoxCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.GroupBox groupBoxTop;
        private System.Windows.Forms.Button btnAddSupplierContact;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.ComboBox cboSupplierContact;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowProducts;
        private System.Windows.Forms.GroupBox groupBoxCart;
        private System.Windows.Forms.Button btnEditPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDebt;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.DataGridView dgvImport;
    }
}