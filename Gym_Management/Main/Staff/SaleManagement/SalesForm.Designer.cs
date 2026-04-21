using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlTop;
        private Label lblStaff;
        private Label lblCustomerKeyword;
        private TextBox txtCustomerKeyword;
        private Button btnSearchCustomer;
        private Button btnChooseCustomer;
        private Button btnAddCustomer;
        private Label lblCustomerName;
        private Label lblCustomerType;

        private Panel pnlLeft;
        private Label lblProductSearch;
        private TextBox txtSearchProduct;
        private Label lblBrand;
        private ComboBox cboBrand;
        private FlowLayoutPanel flowProducts;

        private Panel pnlRight;
        private DataGridView dgvCart;
        private Button btnIncrease;
        private Button btnDecrease;
        private Button btnRemove;

        private Panel pnlBottom;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblSubTotal;
        private Label lblDiscount;
        private Label lblFinalTotal;
        private Label lblPayment;
        private ComboBox cboPaymentMethod;
        private Label lblCash;
        private TextBox txtCashReceived;
        private Label lblChangeText;
        private TextBox txtChange;
        private Label lblNoteText;
        private TextBox txtNote;
        private Button btnCheckout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblStaff = new System.Windows.Forms.Label();
            this.lblCustomerKeyword = new System.Windows.Forms.Label();
            this.txtCustomerKeyword = new System.Windows.Forms.TextBox();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.btnChooseCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblProductSearch = new System.Windows.Forms.Label();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.flowProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFinalTotal = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblCash = new System.Windows.Forms.Label();
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.lblChangeText = new System.Windows.Forms.Label();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.lblNoteText = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.lblStaff);
            this.pnlTop.Controls.Add(this.lblCustomerKeyword);
            this.pnlTop.Controls.Add(this.txtCustomerKeyword);
            this.pnlTop.Controls.Add(this.btnSearchCustomer);
            this.pnlTop.Controls.Add(this.btnChooseCustomer);
            this.pnlTop.Controls.Add(this.btnAddCustomer);
            this.pnlTop.Controls.Add(this.lblCustomerName);
            this.pnlTop.Controls.Add(this.lblCustomerType);
            this.pnlTop.Location = new System.Drawing.Point(10, 10);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1260, 95);
            this.pnlTop.TabIndex = 0;
            // 
            // lblStaff
            // 
            this.lblStaff.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStaff.Location = new System.Drawing.Point(20, 15);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(260, 23);
            this.lblStaff.TabIndex = 0;
            this.lblStaff.Text = "Nhân viên:";
            // 
            // lblCustomerKeyword
            // 
            this.lblCustomerKeyword.Location = new System.Drawing.Point(20, 55);
            this.lblCustomerKeyword.Name = "lblCustomerKeyword";
            this.lblCustomerKeyword.Size = new System.Drawing.Size(70, 23);
            this.lblCustomerKeyword.TabIndex = 1;
            this.lblCustomerKeyword.Text = "Khách";
            // 
            // txtCustomerKeyword
            // 
            this.txtCustomerKeyword.Location = new System.Drawing.Point(95, 53);
            this.txtCustomerKeyword.Name = "txtCustomerKeyword";
            this.txtCustomerKeyword.Size = new System.Drawing.Size(210, 22);
            this.txtCustomerKeyword.TabIndex = 2;
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Location = new System.Drawing.Point(315, 50);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(75, 28);
            this.btnSearchCustomer.TabIndex = 3;
            this.btnSearchCustomer.Text = "Tìm";
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // btnChooseCustomer
            // 
            this.btnChooseCustomer.Location = new System.Drawing.Point(400, 50);
            this.btnChooseCustomer.Name = "btnChooseCustomer";
            this.btnChooseCustomer.Size = new System.Drawing.Size(90, 28);
            this.btnChooseCustomer.TabIndex = 4;
            this.btnChooseCustomer.Text = "Chọn KH";
            this.btnChooseCustomer.Click += new System.EventHandler(this.btnChooseCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(500, 50);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(100, 28);
            this.btnAddCustomer.TabIndex = 5;
            this.btnAddCustomer.Text = "Khách mới";
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.Location = new System.Drawing.Point(650, 20);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(300, 23);
            this.lblCustomerName.TabIndex = 6;
            this.lblCustomerName.Text = "Khách: Khách lẻ";
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.Location = new System.Drawing.Point(650, 52);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(300, 23);
            this.lblCustomerType.TabIndex = 7;
            this.lblCustomerType.Text = "Loại khách: Khách thường";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.lblProductSearch);
            this.pnlLeft.Controls.Add(this.txtSearchProduct);
            this.pnlLeft.Controls.Add(this.lblBrand);
            this.pnlLeft.Controls.Add(this.cboBrand);
            this.pnlLeft.Controls.Add(this.flowProducts);
            this.pnlLeft.Location = new System.Drawing.Point(10, 115);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(700, 425);
            this.pnlLeft.TabIndex = 1;
            // 
            // lblProductSearch
            // 
            this.lblProductSearch.Location = new System.Drawing.Point(15, 15);
            this.lblProductSearch.Name = "lblProductSearch";
            this.lblProductSearch.Size = new System.Drawing.Size(100, 23);
            this.lblProductSearch.TabIndex = 0;
            this.lblProductSearch.Text = "Tìm sản phẩm";
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Location = new System.Drawing.Point(120, 13);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(200, 22);
            this.txtSearchProduct.TabIndex = 1;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            // 
            // lblBrand
            // 
            this.lblBrand.Location = new System.Drawing.Point(340, 15);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(50, 23);
            this.lblBrand.TabIndex = 2;
            this.lblBrand.Text = "Hãng";
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.Location = new System.Drawing.Point(390, 13);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(160, 24);
            this.cboBrand.TabIndex = 3;
            this.cboBrand.SelectedIndexChanged += new System.EventHandler(this.cboBrand_SelectedIndexChanged);
            // 
            // flowProducts
            // 
            this.flowProducts.AutoScroll = true;
            this.flowProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.flowProducts.Location = new System.Drawing.Point(15, 50);
            this.flowProducts.Name = "flowProducts";
            this.flowProducts.Size = new System.Drawing.Size(665, 355);
            this.flowProducts.TabIndex = 4;
            this.flowProducts.Paint += new System.Windows.Forms.PaintEventHandler(this.flowProducts_Paint);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.dgvCart);
            this.pnlRight.Controls.Add(this.btnIncrease);
            this.pnlRight.Controls.Add(this.btnDecrease);
            this.pnlRight.Controls.Add(this.btnRemove);
            this.pnlRight.Location = new System.Drawing.Point(720, 115);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(550, 425);
            this.pnlRight.TabIndex = 2;
            // 
            // dgvCart
            // 
            this.dgvCart.ColumnHeadersHeight = 29;
            this.dgvCart.Location = new System.Drawing.Point(15, 15);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.Size = new System.Drawing.Size(520, 320);
            this.dgvCart.TabIndex = 0;
            // 
            // btnIncrease
            // 
            this.btnIncrease.Location = new System.Drawing.Point(15, 350);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(90, 32);
            this.btnIncrease.TabIndex = 1;
            this.btnIncrease.Text = "+ SL";
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // btnDecrease
            // 
            this.btnDecrease.Location = new System.Drawing.Point(115, 350);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(90, 32);
            this.btnDecrease.TabIndex = 2;
            this.btnDecrease.Text = "- SL";
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(215, 350);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 32);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.label1);
            this.pnlBottom.Controls.Add(this.lblSubTotal);
            this.pnlBottom.Controls.Add(this.label2);
            this.pnlBottom.Controls.Add(this.lblDiscount);
            this.pnlBottom.Controls.Add(this.label3);
            this.pnlBottom.Controls.Add(this.lblFinalTotal);
            this.pnlBottom.Controls.Add(this.lblPayment);
            this.pnlBottom.Controls.Add(this.cboPaymentMethod);
            this.pnlBottom.Controls.Add(this.lblCash);
            this.pnlBottom.Controls.Add(this.txtCashReceived);
            this.pnlBottom.Controls.Add(this.lblChangeText);
            this.pnlBottom.Controls.Add(this.txtChange);
            this.pnlBottom.Controls.Add(this.lblNoteText);
            this.pnlBottom.Controls.Add(this.txtNote);
            this.pnlBottom.Controls.Add(this.btnCheckout);
            this.pnlBottom.Location = new System.Drawing.Point(10, 550);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1260, 155);
            this.pnlBottom.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tạm tính";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Location = new System.Drawing.Point(130, 20);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(160, 23);
            this.lblSubTotal.TabIndex = 1;
            this.lblSubTotal.Text = "0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Giảm giá";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Location = new System.Drawing.Point(130, 50);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(180, 23);
            this.lblDiscount.TabIndex = 3;
            this.lblDiscount.Text = "0";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tổng tiền";
            // 
            // lblFinalTotal
            // 
            this.lblFinalTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFinalTotal.ForeColor = System.Drawing.Color.Red;
            this.lblFinalTotal.Location = new System.Drawing.Point(130, 82);
            this.lblFinalTotal.Name = "lblFinalTotal";
            this.lblFinalTotal.Size = new System.Drawing.Size(180, 30);
            this.lblFinalTotal.TabIndex = 5;
            this.lblFinalTotal.Text = "0";
            // 
            // lblPayment
            // 
            this.lblPayment.Location = new System.Drawing.Point(360, 20);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(100, 23);
            this.lblPayment.TabIndex = 6;
            this.lblPayment.Text = "Thanh toán";
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Online"});
            this.cboPaymentMethod.Location = new System.Drawing.Point(470, 18);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(180, 24);
            this.cboPaymentMethod.TabIndex = 7;
            this.cboPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cboPaymentMethod_SelectedIndexChanged);
            // 
            // lblCash
            // 
            this.lblCash.Location = new System.Drawing.Point(360, 50);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(100, 23);
            this.lblCash.TabIndex = 8;
            this.lblCash.Text = "Khách đưa";
            // 
            // txtCashReceived
            // 
            this.txtCashReceived.Location = new System.Drawing.Point(470, 48);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Size = new System.Drawing.Size(180, 22);
            this.txtCashReceived.TabIndex = 9;
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);
            // 
            // lblChangeText
            // 
            this.lblChangeText.Location = new System.Drawing.Point(360, 80);
            this.lblChangeText.Name = "lblChangeText";
            this.lblChangeText.Size = new System.Drawing.Size(100, 23);
            this.lblChangeText.TabIndex = 10;
            this.lblChangeText.Text = "Tiền thừa";
            // 
            // txtChange
            // 
            this.txtChange.Location = new System.Drawing.Point(470, 78);
            this.txtChange.Name = "txtChange";
            this.txtChange.ReadOnly = true;
            this.txtChange.Size = new System.Drawing.Size(180, 22);
            this.txtChange.TabIndex = 11;
            // 
            // lblNoteText
            // 
            this.lblNoteText.Location = new System.Drawing.Point(720, 20);
            this.lblNoteText.Name = "lblNoteText";
            this.lblNoteText.Size = new System.Drawing.Size(70, 23);
            this.lblNoteText.TabIndex = 12;
            this.lblNoteText.Text = "Ghi chú";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(790, 18);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(260, 22);
            this.txtNote.TabIndex = 13;
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(1090, 45);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(135, 50);
            this.btnCheckout.TabIndex = 14;
            this.btnCheckout.Text = "Thanh toán";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // SalesForm
            // 
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlBottom);
            this.Name = "SalesForm";
            this.Text = "Bán hàng";
            this.Load += new System.EventHandler(this.SalesForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}