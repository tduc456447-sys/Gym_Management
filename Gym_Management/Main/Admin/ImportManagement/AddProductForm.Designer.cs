namespace Gym_Management.Main.Admin
{
    partial class AddProductForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddUnit = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên sản phẩm:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(147, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 22);
            this.txtName.TabIndex = 1;
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(147, 59);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(198, 24);
            this.cboBrand.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hãng:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddBrand
            // 
            this.btnAddBrand.Location = new System.Drawing.Point(351, 56);
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.Size = new System.Drawing.Size(75, 28);
            this.btnAddBrand.TabIndex = 4;
            this.btnAddBrand.Text = "+ Hãng";
            this.btnAddBrand.UseVisualStyleBackColor = true;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(147, 95);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(198, 24);
            this.cboUnit.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đơn vị:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddUnit
            // 
            this.btnAddUnit.Location = new System.Drawing.Point(351, 92);
            this.btnAddUnit.Name = "btnAddUnit";
            this.btnAddUnit.Size = new System.Drawing.Size(75, 28);
            this.btnAddUnit.TabIndex = 7;
            this.btnAddUnit.Text = "+ Đơn vị";
            this.btnAddUnit.UseVisualStyleBackColor = true;
            this.btnAddUnit.Click += new System.EventHandler(this.btnAddUnit_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(147, 132);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(279, 22);
            this.txtPrice.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Giá bán:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(147, 168);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(279, 22);
            this.txtBarcode.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(20, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Barcode:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImage
            // 
            this.txtImage.Location = new System.Drawing.Point(147, 204);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(279, 22);
            this.txtImage.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(20, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tên file ảnh:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(147, 240);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(279, 22);
            this.txtDescription.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(20, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Mô tả:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(319, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 34);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Lưu sản phẩm";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddProductForm
            // 
            this.ClientSize = new System.Drawing.Size(455, 331);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddUnit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboUnit);
            this.Controls.Add(this.btnAddBrand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboBrand);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm sản phẩm";
            this.Load += new System.EventHandler(this.AddProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddBrand;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddUnit;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
    }
}