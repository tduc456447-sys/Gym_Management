using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.ImportManagement
{
    partial class frmImportReceipt
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;

        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cboSupplier;

        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtImportPrice;
        private System.Windows.Forms.Button btnAddItem;

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.FlowLayoutPanel flpItems;

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSave;

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

            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();

            this.lblSupplier = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();

            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();

            this.pnlLeft = new System.Windows.Forms.Panel();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtImportPrice = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();

            this.pnlRight = new System.Windows.Forms.Panel();
            this.flpItems = new System.Windows.Forms.FlowLayoutPanel();

            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // FORM
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Text = "Nhập hàng";

            // HEADER PANEL
            pnlTop.BackColor = System.Drawing.Color.White;
            pnlTop.Size = new System.Drawing.Size(1160, 80);
            pnlTop.Location = new System.Drawing.Point(20, 15);
            pnlTop.BorderStyle = BorderStyle.None;

            lblTitle.Text = "Phiếu nhập hàng";
            lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.AutoSize = true;

            pnlTop.Controls.Add(lblTitle);

            // FORM CONTENT - LEFT PART (SẢN PHẨM NHẬP)
            lblDate.Text = "Ngày nhập";
            lblDate.Location = new System.Drawing.Point(30, 110);
            lblDate.ForeColor = Color.FromArgb(71, 85, 105);
            dtpDate.Location = new System.Drawing.Point(30, 135);
            dtpDate.Size = new System.Drawing.Size(250, 30);

            lblSupplier.Text = "Nhà cung cấp";
            lblSupplier.Location = new System.Drawing.Point(300, 110);
            lblSupplier.ForeColor = Color.FromArgb(71, 85, 105);
            cboSupplier.Location = new System.Drawing.Point(300, 135);
            cboSupplier.Size = new System.Drawing.Size(250, 30);
            cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList;

            lblNote.Text = "Ghi chú";
            lblNote.Location = new System.Drawing.Point(600, 110);
            lblNote.ForeColor = Color.FromArgb(71, 85, 105);
            txtNote.Location = new System.Drawing.Point(600, 135);
            txtNote.Size = new System.Drawing.Size(250, 30);
            txtNote.Multiline = true;

            // LEFT - ADD ITEM (Chọn sản phẩm và nhập số lượng, giá nhập)
            pnlLeft.BackColor = System.Drawing.Color.White;
            pnlLeft.Location = new System.Drawing.Point(20, 180);
            pnlLeft.Size = new System.Drawing.Size(350, 380);
            pnlLeft.BorderStyle = BorderStyle.None;

            cboProduct.Location = new System.Drawing.Point(20, 30);
            cboProduct.Width = 300;
            cboProduct.Font = new Font("Segoe UI", 10F);

            txtQuantity.Location = new System.Drawing.Point(20, 80);
            txtQuantity.Width = 140;
            txtQuantity.Font = new Font("Segoe UI", 10F);
            txtQuantity.Text = "Số lượng";

            txtImportPrice.Location = new System.Drawing.Point(180, 80);
            txtImportPrice.Width = 140;
            txtImportPrice.Font = new Font("Segoe UI", 10F);
            txtImportPrice.Text = "Giá nhập";

            btnAddItem.Text = "Thêm vào phiếu";
            btnAddItem.Location = new System.Drawing.Point(20, 130);
            btnAddItem.Size = new System.Drawing.Size(300, 35);
            btnAddItem.BackColor = Color.FromArgb(37, 99, 235);
            btnAddItem.ForeColor = Color.White;
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.Font = new Font("Segoe UI Semibold", 10F);
            btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);

            pnlLeft.Controls.Add(cboProduct);
            pnlLeft.Controls.Add(txtQuantity);
            pnlLeft.Controls.Add(txtImportPrice);
            pnlLeft.Controls.Add(btnAddItem);

            // RIGHT - DANH SÁCH SẢN PHẨM ĐÃ NHẬP
            pnlRight.BackColor = System.Drawing.Color.White;
            pnlRight.Location = new System.Drawing.Point(390, 180);
            pnlRight.Size = new System.Drawing.Size(790, 380);
            pnlRight.BorderStyle = BorderStyle.None;

            flpItems.AutoScroll = true;
            flpItems.Dock = DockStyle.Fill;

            pnlRight.Controls.Add(flpItems);

            // TOTAL PANEL (Hiển thị tổng tiền)
            lblTotal.Text = "Tổng: 0 VNĐ";
            lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            lblTotal.ForeColor = Color.FromArgb(71, 85, 105);
            lblTotal.Location = new System.Drawing.Point(800, 580);
            lblTotal.AutoSize = true;

            btnSave.Text = "Lưu phiếu";
            btnSave.Location = new System.Drawing.Point(950, 580);
            btnSave.BackColor = Color.FromArgb(22, 163, 74);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 10F);
            btnSave.Size = new System.Drawing.Size(100, 40);
            btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // ADD TO FORM
            this.Controls.Add(pnlTop);
            this.Controls.Add(lblDate);
            this.Controls.Add(dtpDate);
            this.Controls.Add(lblSupplier);
            this.Controls.Add(cboSupplier);
            this.Controls.Add(lblNote);
            this.Controls.Add(txtNote);
            this.Controls.Add(pnlLeft);
            this.Controls.Add(pnlRight);
            this.Controls.Add(lblTotal);
            this.Controls.Add(btnSave);

            this.ResumeLayout(false);
        }
    }
}