using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Admin
{
    public partial class ImportForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int adminId;
        private readonly string adminName;

        private DataTable importTable;

        public ImportForm(int userId, string fullName)
        {
            InitializeComponent();
            adminId = userId;
            adminName = fullName;
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            lblAdmin.Text = "Admin: " + adminName;

            InitImportTable();
            LoadBrands();
            LoadSuppliers();
            LoadProducts();
            UpdateSummary();
        }

        private void InitImportTable()
        {
            importTable = new DataTable();
            importTable.Columns.Add("ProductId", typeof(int));
            importTable.Columns.Add("Tên sản phẩm", typeof(string));
            importTable.Columns.Add("Số lượng", typeof(int));
            importTable.Columns.Add("Giá nhập", typeof(decimal));
            importTable.Columns.Add("Thành tiền", typeof(decimal));

            dgvImport.DataSource = importTable;

            dgvImport.RowHeadersVisible = false;
            dgvImport.AllowUserToAddRows = false;
            dgvImport.ReadOnly = true;
            dgvImport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvImport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvImport.AllowUserToResizeRows = false;
            dgvImport.RowTemplate.Height = 32;
            dgvImport.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvImport.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            if (dgvImport.Columns["ProductId"] != null)
                dgvImport.Columns["ProductId"].Visible = false;
        }

        private void LoadBrands()
        {
            cboBrand.Items.Clear();
            cboBrand.Items.Add("Tất cả");

            try
            {
                DataTable dt = db.ExecuteQuery("SELECT Name FROM Brands ORDER BY Name");
                foreach (DataRow row in dt.Rows)
                {
                    cboBrand.Items.Add(row["Name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load hãng: " + ex.Message);
            }

            cboBrand.SelectedIndex = 0;
        }

        private void LoadSuppliers()
        {
            cboSupplier.DataSource = null;

            try
            {
                DataTable dt = db.ExecuteQuery(@"
                    SELECT SupplierId, Name
                    FROM Suppliers
                    WHERE Status = 'Active'
                    ORDER BY Name");

                DataRow defaultRow = dt.NewRow();
                defaultRow["SupplierId"] = DBNull.Value;
                defaultRow["Name"] = "-- Chọn nhà cung cấp --";
                dt.Rows.InsertAt(defaultRow, 0);

                cboSupplier.DisplayMember = "Name";
                cboSupplier.ValueMember = "SupplierId";
                cboSupplier.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhà cung cấp: " + ex.Message);
            }
        }

        private void LoadSupplierContacts()
        {
            cboSupplierContact.DataSource = null;

            try
            {
                if (cboSupplier.SelectedValue == null || cboSupplier.SelectedValue == DBNull.Value)
                {
                    DataTable empty = new DataTable();
                    empty.Columns.Add("ContactId", typeof(int));
                    empty.Columns.Add("FullName", typeof(string));

                    DataRow row = empty.NewRow();
                    row["ContactId"] = DBNull.Value;
                    row["FullName"] = "-- Chọn người liên hệ --";
                    empty.Rows.Add(row);

                    cboSupplierContact.DisplayMember = "FullName";
                    cboSupplierContact.ValueMember = "ContactId";
                    cboSupplierContact.DataSource = empty;
                    return;
                }

                int supplierId = Convert.ToInt32(cboSupplier.SelectedValue);

                DataTable dt = db.ExecuteQuery(@"
                    SELECT ContactId, FullName
                    FROM SupplierContacts
                    WHERE SupplierId = @SupplierId
                      AND Status = 'Active'
                    ORDER BY IsPrimary DESC, FullName",
                    new SqlParameter[]
                    {
                        new SqlParameter("@SupplierId", supplierId)
                    });

                DataRow defaultRow = dt.NewRow();
                defaultRow["ContactId"] = DBNull.Value;
                defaultRow["FullName"] = "-- Chọn người liên hệ --";
                dt.Rows.InsertAt(defaultRow, 0);

                cboSupplierContact.DisplayMember = "FullName";
                cboSupplierContact.ValueMember = "ContactId";
                cboSupplierContact.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load người liên hệ: " + ex.Message);
            }
        }

        private void LoadProducts()
        {
            flowProducts.Controls.Clear();

            try
            {
                string brandFilter = cboBrand.SelectedIndex <= 0 ? "" : cboBrand.Text.Trim();

                string sql = @"
                    SELECT 
                        p.ProductId,
                        p.Name,
                        p.Price,
                        p.Quantity,
                        ISNULL(p.Image, '') AS ImageFile,
                        ISNULL(b.Name, '') AS BrandName
                    FROM Products p
                    LEFT JOIN Brands b ON p.BrandId = b.BrandId
                    WHERE (@Keyword = '' OR p.Name LIKE N'%' + @Keyword + N'%')
                      AND (@Brand = '' OR b.Name = @Brand)
                    ORDER BY p.Name";

                DataTable dt = db.ExecuteQuery(sql, new SqlParameter[]
                {
                    new SqlParameter("@Keyword", txtSearchProduct.Text.Trim()),
                    new SqlParameter("@Brand", brandFilter)
                });

                foreach (DataRow row in dt.Rows)
                {
                    Panel card = CreateProductCard(
                        Convert.ToInt32(row["ProductId"]),
                        row["Name"].ToString(),
                        row["BrandName"].ToString(),
                        Convert.ToDecimal(row["Price"]),
                        Convert.ToInt32(row["Quantity"]),
                        row["ImageFile"].ToString()
                    );

                    flowProducts.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load sản phẩm: " + ex.Message);
            }
        }

        private Panel CreateProductCard(int productId, string productName, string brandName, decimal price, int stockQty, string imageFileName)
        {
            Panel panel = new Panel();
            panel.Width = 190;
            panel.Height = 265;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10);
            panel.BackColor = Color.White;

            PictureBox pbImage = new PictureBox();
            pbImage.Location = new Point(14, 10);
            pbImage.Size = new Size(160, 110);
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                string fileName = (imageFileName ?? "").Trim().TrimStart('/', '\\');
                string imageFolder = Path.Combine(Application.StartupPath, "images");
                string imagePath = Path.Combine(imageFolder, fileName);

                if (!string.IsNullOrWhiteSpace(fileName) && File.Exists(imagePath))
                    pbImage.Image = Image.FromFile(imagePath);
                else
                    pbImage.Image = null;
            }
            catch
            {
                pbImage.Image = null;
            }

            Label lblName = new Label();
            lblName.Text = productName;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.Location = new Point(10, 128);
            lblName.Size = new Size(170, 38);

            Label lblBrand = new Label();
            lblBrand.Text = "Hãng: " + (string.IsNullOrWhiteSpace(brandName) ? "-" : brandName);
            lblBrand.Location = new Point(10, 168);
            lblBrand.Size = new Size(170, 20);

            Label lblPrice = new Label();
            lblPrice.Text = "Giá bán: " + price.ToString("N0");
            lblPrice.ForeColor = Color.FromArgb(192, 57, 43);
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.Location = new Point(10, 188);
            lblPrice.Size = new Size(170, 20);

            Label lblQty = new Label();
            lblQty.Text = "Tồn hiện tại: " + stockQty;
            lblQty.Location = new Point(10, 208);
            lblQty.Size = new Size(110, 20);

            Button btnAdd = new Button();
            btnAdd.Text = "Nhập";
            btnAdd.Size = new Size(70, 30);
            btnAdd.Location = new Point(104, 220);
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;

            btnAdd.Click += (s, e) =>
            {
                AddToImportCart(productId, productName, price);
            };

            panel.Controls.Add(pbImage);
            panel.Controls.Add(lblName);
            panel.Controls.Add(lblBrand);
            panel.Controls.Add(lblPrice);
            panel.Controls.Add(lblQty);
            panel.Controls.Add(btnAdd);

            return panel;
        }

        private void AddToImportCart(int productId, string productName, decimal suggestedPrice)
        {
            DataRow existingRow = null;

            foreach (DataRow row in importTable.Rows)
            {
                if (Convert.ToInt32(row["ProductId"]) == productId)
                {
                    existingRow = row;
                    break;
                }
            }

            if (existingRow == null)
            {
                string inputQty = Prompt.ShowDialog("Nhập số lượng:", "Số lượng nhập", "1");
                if (string.IsNullOrWhiteSpace(inputQty)) return;

                int qty;
                if (!int.TryParse(inputQty, out qty) || qty <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ.");
                    return;
                }

                string inputPrice = Prompt.ShowDialog("Nhập giá nhập:", "Giá nhập", suggestedPrice.ToString("0"));
                if (string.IsNullOrWhiteSpace(inputPrice)) return;

                decimal importPrice;
                if (!decimal.TryParse(inputPrice.Replace(",", ""), out importPrice) || importPrice < 0)
                {
                    MessageBox.Show("Giá nhập không hợp lệ.");
                    return;
                }

                importTable.Rows.Add(productId, productName, qty, importPrice, qty * importPrice);
            }
            else
            {
                int currentQty = Convert.ToInt32(existingRow["Số lượng"]);
                decimal currentPrice = Convert.ToDecimal(existingRow["Giá nhập"]);

                string inputQty = Prompt.ShowDialog("Nhập số lượng cộng thêm:", "Cập nhật số lượng", "1");
                if (string.IsNullOrWhiteSpace(inputQty)) return;

                int addQty;
                if (!int.TryParse(inputQty, out addQty) || addQty <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ.");
                    return;
                }

                currentQty += addQty;
                existingRow["Số lượng"] = currentQty;
                existingRow["Thành tiền"] = currentQty * currentPrice;
            }

            UpdateSummary();
        }

        private int GetSelectedImportProductId()
        {
            if (dgvImport.CurrentRow == null) return 0;
            return Convert.ToInt32(dgvImport.CurrentRow.Cells["ProductId"].Value);
        }

        private void UpdateSummary()
        {
            decimal total = 0;

            foreach (DataRow row in importTable.Rows)
            {
                total += Convert.ToDecimal(row["Thành tiền"]);
            }

            lblTotal.Text = total.ToString("N0");

            decimal paidAmount = 0;
            decimal.TryParse(txtPaidAmount.Text.Trim().Replace(",", ""), out paidAmount);

            decimal debt = total - paidAmount;
            if (debt < 0) debt = 0;

            lblDebt.Text = debt.ToString("N0");
        }

        private void ResetForm()
        {
            txtSearchProduct.Text = "";
            txtNote.Text = "";
            txtPaidAmount.Text = "0";
            importTable.Rows.Clear();
            UpdateSummary();
            LoadProducts();
            LoadSuppliers();
            LoadSupplierContacts();
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if (dgvImport.CurrentRow == null) return;

            int productId = GetSelectedImportProductId();

            foreach (DataRow row in importTable.Rows)
            {
                if (Convert.ToInt32(row["ProductId"]) == productId)
                {
                    int qty = Convert.ToInt32(row["Số lượng"]);
                    decimal price = Convert.ToDecimal(row["Giá nhập"]);
                    qty++;
                    row["Số lượng"] = qty;
                    row["Thành tiền"] = qty * price;
                    break;
                }
            }

            UpdateSummary();
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (dgvImport.CurrentRow == null) return;

            int productId = GetSelectedImportProductId();

            for (int i = 0; i < importTable.Rows.Count; i++)
            {
                DataRow row = importTable.Rows[i];
                if (Convert.ToInt32(row["ProductId"]) == productId)
                {
                    int qty = Convert.ToInt32(row["Số lượng"]);
                    decimal price = Convert.ToDecimal(row["Giá nhập"]);

                    qty--;
                    if (qty <= 0)
                        importTable.Rows.RemoveAt(i);
                    else
                    {
                        row["Số lượng"] = qty;
                        row["Thành tiền"] = qty * price;
                    }
                    break;
                }
            }

            UpdateSummary();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvImport.CurrentRow == null) return;

            int productId = GetSelectedImportProductId();

            for (int i = 0; i < importTable.Rows.Count; i++)
            {
                if (Convert.ToInt32(importTable.Rows[i]["ProductId"]) == productId)
                {
                    importTable.Rows.RemoveAt(i);
                    break;
                }
            }

            UpdateSummary();
        }

        private void btnEditPrice_Click(object sender, EventArgs e)
        {
            if (dgvImport.CurrentRow == null) return;

            int productId = GetSelectedImportProductId();

            foreach (DataRow row in importTable.Rows)
            {
                if (Convert.ToInt32(row["ProductId"]) == productId)
                {
                    decimal oldPrice = Convert.ToDecimal(row["Giá nhập"]);
                    int qty = Convert.ToInt32(row["Số lượng"]);

                    string input = Prompt.ShowDialog("Nhập giá nhập mới:", "Cập nhật giá", oldPrice.ToString("0"));
                    if (string.IsNullOrWhiteSpace(input)) return;

                    decimal newPrice;
                    if (!decimal.TryParse(input.Replace(",", ""), out newPrice) || newPrice < 0)
                    {
                        MessageBox.Show("Giá nhập không hợp lệ.");
                        return;
                    }

                    row["Giá nhập"] = newPrice;
                    row["Thành tiền"] = qty * newPrice;
                    break;
                }
            }

            UpdateSummary();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using (AddSupplierForm f = new AddSupplierForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadSuppliers();

                    if (f.NewSupplierId > 0)
                        cboSupplier.SelectedValue = f.NewSupplierId;
                }
            }
        }

        private void btnAddSupplierContact_Click(object sender, EventArgs e)
        {
            if (cboSupplier.SelectedValue == null || cboSupplier.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp trước.");
                return;
            }

            int supplierId = Convert.ToInt32(cboSupplier.SelectedValue);
            string supplierName = cboSupplier.Text;

            using (AddSupplierContactForm f = new AddSupplierContactForm(supplierId, supplierName))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadSupplierContacts();

                    if (f.NewContactId > 0)
                        cboSupplierContact.SelectedValue = f.NewContactId;
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using (AddProductForm f = new AddProductForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadBrands();
                    LoadProducts();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (importTable.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách nhập đang trống.");
                return;
            }

            try
            {
                decimal total = 0;
                decimal paidAmount = 0;

                decimal.TryParse(lblTotal.Text.Replace(",", ""), out total);
                decimal.TryParse(txtPaidAmount.Text.Trim().Replace(",", ""), out paidAmount);

                if (paidAmount < 0 || paidAmount > total)
                {
                    MessageBox.Show("Số tiền đã trả không hợp lệ.");
                    return;
                }

                object supplierIdObj = DBNull.Value;
                object contactIdObj = DBNull.Value;

                if (cboSupplier.SelectedValue != null && cboSupplier.SelectedValue != DBNull.Value)
                    supplierIdObj = cboSupplier.SelectedValue;

                if (cboSupplierContact.SelectedValue != null && cboSupplierContact.SelectedValue != DBNull.Value)
                    contactIdObj = cboSupplierContact.SelectedValue;

                DataTable receiptDt = db.ExecuteQuery("sp_CreateImportReceipt",
                    new SqlParameter[]
                    {
                        new SqlParameter("@SupplierId", supplierIdObj),
                        new SqlParameter("@SupplierContactId", contactIdObj),
                        new SqlParameter("@Total", total),
                        new SqlParameter("@PaidAmount", paidAmount),
                        new SqlParameter("@Note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text.Trim()),
                        new SqlParameter("@CreatedByAdminId", adminId)
                    },
                    CommandType.StoredProcedure);

                if (receiptDt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tạo được phiếu nhập.");
                    return;
                }

                int importId = Convert.ToInt32(receiptDt.Rows[0]["ImportId"]);

                foreach (DataRow row in importTable.Rows)
                {
                    db.ExecuteNonQuery("sp_AddImportDetail",
                        new SqlParameter[]
                        {
                            new SqlParameter("@ImportId", importId),
                            new SqlParameter("@ProductId", Convert.ToInt32(row["ProductId"])),
                            new SqlParameter("@Quantity", Convert.ToInt32(row["Số lượng"])),
                            new SqlParameter("@Price", Convert.ToDecimal(row["Giá nhập"]))
                        },
                        CommandType.StoredProcedure);
                }

                db.ExecuteQuery("sp_RecalculateImportReceipt",
                    new SqlParameter[]
                    {
                        new SqlParameter("@ImportId", importId),
                        new SqlParameter("@PaidAmount", paidAmount)
                    },
                    CommandType.StoredProcedure);

                MessageBox.Show("Lưu phiếu nhập thành công.");
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu phiếu nhập: " + ex.Message);
            }
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSupplierContacts();
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 380,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 320 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 320, Text = defaultValue };
            Button confirmation = new Button() { Text = "OK", Left = 180, Width = 75, Top = 85, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Hủy", Left = 265, Width = 75, Top = 85, DialogResult = DialogResult.Cancel };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);

            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}