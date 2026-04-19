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
            this.pnlTop = new Panel();
            this.lblStaff = new Label();
            this.lblCustomerKeyword = new Label();
            this.txtCustomerKeyword = new TextBox();
            this.btnSearchCustomer = new Button();
            this.btnChooseCustomer = new Button();
            this.btnAddCustomer = new Button();
            this.lblCustomerName = new Label();
            this.lblCustomerType = new Label();

            this.pnlLeft = new Panel();
            this.lblProductSearch = new Label();
            this.txtSearchProduct = new TextBox();
            this.lblBrand = new Label();
            this.cboBrand = new ComboBox();
            this.flowProducts = new FlowLayoutPanel();

            this.pnlRight = new Panel();
            this.dgvCart = new DataGridView();
            this.btnIncrease = new Button();
            this.btnDecrease = new Button();
            this.btnRemove = new Button();

            this.pnlBottom = new Panel();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.lblSubTotal = new Label();
            this.lblDiscount = new Label();
            this.lblFinalTotal = new Label();
            this.lblPayment = new Label();
            this.cboPaymentMethod = new ComboBox();
            this.lblCash = new Label();
            this.txtCashReceived = new TextBox();
            this.lblChangeText = new Label();
            this.txtChange = new TextBox();
            this.lblNoteText = new Label();
            this.txtNote = new TextBox();
            this.btnCheckout = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Location = new Point(10, 10);
            this.pnlTop.Size = new Size(1260, 95);
            this.pnlTop.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTop.BackColor = Color.White;

            this.lblStaff.Location = new Point(20, 15);
            this.lblStaff.Size = new Size(260, 23);
            this.lblStaff.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblStaff.Text = "Nhân viên:";

            this.lblCustomerKeyword.Location = new Point(20, 55);
            this.lblCustomerKeyword.Size = new Size(70, 23);
            this.lblCustomerKeyword.Text = "Khách";

            this.txtCustomerKeyword.Location = new Point(95, 53);
            this.txtCustomerKeyword.Size = new Size(210, 22);

            this.btnSearchCustomer.Location = new Point(315, 50);
            this.btnSearchCustomer.Size = new Size(75, 28);
            this.btnSearchCustomer.Text = "Tìm";
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);

            this.btnChooseCustomer.Location = new Point(400, 50);
            this.btnChooseCustomer.Size = new Size(90, 28);
            this.btnChooseCustomer.Text = "Chọn KH";
            this.btnChooseCustomer.Click += new System.EventHandler(this.btnChooseCustomer_Click);

            this.btnAddCustomer.Location = new Point(500, 50);
            this.btnAddCustomer.Size = new Size(100, 28);
            this.btnAddCustomer.Text = "Khách mới";
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);

            this.lblCustomerName.Location = new Point(650, 20);
            this.lblCustomerName.Size = new Size(300, 23);
            this.lblCustomerName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCustomerName.Text = "Khách: Khách lẻ";

            this.lblCustomerType.Location = new Point(650, 52);
            this.lblCustomerType.Size = new Size(300, 23);
            this.lblCustomerType.Text = "Loại khách: Khách thường";

            this.pnlTop.Controls.Add(this.lblStaff);
            this.pnlTop.Controls.Add(this.lblCustomerKeyword);
            this.pnlTop.Controls.Add(this.txtCustomerKeyword);
            this.pnlTop.Controls.Add(this.btnSearchCustomer);
            this.pnlTop.Controls.Add(this.btnChooseCustomer);
            this.pnlTop.Controls.Add(this.btnAddCustomer);
            this.pnlTop.Controls.Add(this.lblCustomerName);
            this.pnlTop.Controls.Add(this.lblCustomerType);

            // pnlLeft
            this.pnlLeft.Location = new Point(10, 115);
            this.pnlLeft.Size = new Size(700, 425);
            this.pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            this.pnlLeft.BackColor = Color.White;

            this.lblProductSearch.Location = new Point(15, 15);
            this.lblProductSearch.Size = new Size(100, 23);
            this.lblProductSearch.Text = "Tìm sản phẩm";

            this.txtSearchProduct.Location = new Point(120, 13);
            this.txtSearchProduct.Size = new Size(200, 22);
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);

            this.lblBrand.Location = new Point(340, 15);
            this.lblBrand.Size = new Size(50, 23);
            this.lblBrand.Text = "Hãng";

            this.cboBrand.Location = new Point(390, 13);
            this.cboBrand.Size = new Size(160, 24);
            this.cboBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboBrand.SelectedIndexChanged += new System.EventHandler(this.cboBrand_SelectedIndexChanged);

            this.flowProducts.Location = new Point(15, 50);
            this.flowProducts.Size = new Size(665, 355);
            this.flowProducts.AutoScroll = true;
            this.flowProducts.WrapContents = true;
            this.flowProducts.BackColor = Color.FromArgb(248, 249, 250);

            this.pnlLeft.Controls.Add(this.lblProductSearch);
            this.pnlLeft.Controls.Add(this.txtSearchProduct);
            this.pnlLeft.Controls.Add(this.lblBrand);
            this.pnlLeft.Controls.Add(this.cboBrand);
            this.pnlLeft.Controls.Add(this.flowProducts);

            // pnlRight
            this.pnlRight.Location = new Point(720, 115);
            this.pnlRight.Size = new Size(550, 425);
            this.pnlRight.BorderStyle = BorderStyle.FixedSingle;
            this.pnlRight.BackColor = Color.White;

            this.dgvCart.Location = new Point(15, 15);
            this.dgvCart.Size = new Size(520, 320);

            this.btnIncrease.Location = new Point(15, 350);
            this.btnIncrease.Size = new Size(90, 32);
            this.btnIncrease.Text = "+ SL";
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);

            this.btnDecrease.Location = new Point(115, 350);
            this.btnDecrease.Size = new Size(90, 32);
            this.btnDecrease.Text = "- SL";
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);

            this.btnRemove.Location = new Point(215, 350);
            this.btnRemove.Size = new Size(90, 32);
            this.btnRemove.Text = "Xóa";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            this.pnlRight.Controls.Add(this.dgvCart);
            this.pnlRight.Controls.Add(this.btnIncrease);
            this.pnlRight.Controls.Add(this.btnDecrease);
            this.pnlRight.Controls.Add(this.btnRemove);

            // pnlBottom
            this.pnlBottom.Location = new Point(10, 550);
            this.pnlBottom.Size = new Size(1260, 155);
            this.pnlBottom.BorderStyle = BorderStyle.FixedSingle;
            this.pnlBottom.BackColor = Color.White;

            this.label1.Location = new Point(20, 20);
            this.label1.Size = new Size(100, 23);
            this.label1.Text = "Tạm tính";

            this.lblSubTotal.Location = new Point(130, 20);
            this.lblSubTotal.Size = new Size(160, 23);
            this.lblSubTotal.Text = "0";

            this.label2.Location = new Point(20, 50);
            this.label2.Size = new Size(100, 23);
            this.label2.Text = "Giảm giá";

            this.lblDiscount.Location = new Point(130, 50);
            this.lblDiscount.Size = new Size(180, 23);
            this.lblDiscount.Text = "0";

            this.label3.Location = new Point(20, 85);
            this.label3.Size = new Size(100, 23);
            this.label3.Text = "Tổng tiền";

            this.lblFinalTotal.Location = new Point(130, 82);
            this.lblFinalTotal.Size = new Size(180, 30);
            this.lblFinalTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblFinalTotal.ForeColor = Color.Red;
            this.lblFinalTotal.Text = "0";

            this.lblPayment.Location = new Point(360, 20);
            this.lblPayment.Size = new Size(100, 23);
            this.lblPayment.Text = "Thanh toán";

            this.cboPaymentMethod.Location = new Point(470, 18);
            this.cboPaymentMethod.Size = new Size(180, 24);
            this.cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.Items.AddRange(new object[] { "Cash", "Online" });
            this.cboPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cboPaymentMethod_SelectedIndexChanged);

            this.lblCash.Location = new Point(360, 50);
            this.lblCash.Size = new Size(100, 23);
            this.lblCash.Text = "Khách đưa";

            this.txtCashReceived.Location = new Point(470, 48);
            this.txtCashReceived.Size = new Size(180, 22);
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);

            this.lblChangeText.Location = new Point(360, 80);
            this.lblChangeText.Size = new Size(100, 23);
            this.lblChangeText.Text = "Tiền thừa";

            this.txtChange.Location = new Point(470, 78);
            this.txtChange.Size = new Size(180, 22);
            this.txtChange.ReadOnly = true;

            this.lblNoteText.Location = new Point(720, 20);
            this.lblNoteText.Size = new Size(70, 23);
            this.lblNoteText.Text = "Ghi chú";

            this.txtNote.Location = new Point(790, 18);
            this.txtNote.Size = new Size(260, 22);

            this.btnCheckout.Location = new Point(1090, 45);
            this.btnCheckout.Size = new Size(135, 50);
            this.btnCheckout.Text = "Thanh toán";
            this.btnCheckout.BackColor = Color.FromArgb(39, 174, 96);
            this.btnCheckout.ForeColor = Color.White;
            this.btnCheckout.FlatStyle = FlatStyle.Flat;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

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

            // SalesForm
            this.ClientSize = new Size(1280, 720);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlBottom);
            this.Name = "SalesForm";
            this.Text = "Bán hàng";
            this.Load += new System.EventHandler(this.SalesForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
        }
    }
}