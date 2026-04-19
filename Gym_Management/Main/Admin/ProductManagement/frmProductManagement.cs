using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.ProductManagement
{
    public partial class frmProductManagement : Form
    {
        private DBHelper db = new DBHelper();

        public frmProductManagement()
        {
            InitializeComponent();
            ApplyModernStyle();
        }

        private void frmProductManagement_Load(object sender, EventArgs e)
        {
            LoadBrandsFilter();
            LoadBrands();
            LoadUnits();
            LoadProducts();
            ClearInput();
        }

        #region Load dữ liệu

        private void LoadBrandsFilter()
        {
            try
            {
                DataTable dt = db.ExecuteQuery(@"
                    SELECT 0 AS BrandId, N'Tất cả hãng' AS Name
                    UNION ALL
                    SELECT BrandId, Name
                    FROM Brands
                    ORDER BY BrandId
                ");

                cboFilterBrand.DataSource = dt;
                cboFilterBrand.DisplayMember = "Name";
                cboFilterBrand.ValueMember = "BrandId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hãng lọc: " + ex.Message);
            }
        }

        private void LoadBrands()
        {
            try
            {
                DataTable dt = db.ExecuteQuery(@"
                    SELECT BrandId, Name
                    FROM Brands
                    ORDER BY Name
                ");

                cboBrand.DataSource = dt;
                cboBrand.DisplayMember = "Name";
                cboBrand.ValueMember = "BrandId";
                cboBrand.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hãng: " + ex.Message);
            }
        }

        private void LoadUnits()
        {
            try
            {
                DataTable dt = db.ExecuteQuery(@"
                    SELECT UnitId, Name
                    FROM Units
                    ORDER BY Name
                ");

                cboUnit.DataSource = dt;
                cboUnit.DisplayMember = "Name";
                cboUnit.ValueMember = "UnitId";
                cboUnit.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải đơn vị: " + ex.Message);
            }
        }

        private void LoadProducts()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                int brandId = 0;

                if (cboFilterBrand.SelectedValue != null)
                    int.TryParse(cboFilterBrand.SelectedValue.ToString(), out brandId);

                string sql = @"
                    SELECT
                        p.ProductId AS [Mã SP],
                        p.Name AS [Tên hàng],
                        ISNULL(b.Name, N'') AS [Hãng],
                        ISNULL(u.Name, N'') AS [Đơn vị],
                        p.Price AS [Giá bán],
                        p.Quantity AS [Tồn kho],
                        ISNULL(p.Barcode, '') AS [Mã vạch],
                        ISNULL(p.Image, '') AS [Ảnh],
                        ISNULL(p.Description, N'') AS [Mô tả]
                    FROM Products p
                    LEFT JOIN Brands b ON p.BrandId = b.BrandId
                    LEFT JOIN Units u ON p.UnitId = u.UnitId
                    WHERE
                        (@Keyword = '' OR p.Name LIKE N'%' + @Keyword + '%' OR p.Barcode LIKE '%' + @Keyword + '%')
                        AND (@BrandId = 0 OR p.BrandId = @BrandId)
                    ORDER BY p.ProductId DESC
                ";

                SqlParameter[] pr =
                {
                    new SqlParameter("@Keyword", keyword),
                    new SqlParameter("@BrandId", brandId)
                };

                DataTable dt = db.ExecuteQuery(sql, pr);
                dgvProducts.DataSource = dt;

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hàng hóa: " + ex.Message);
            }
        }

        #endregion

        #region Style

        private void ApplyModernStyle()
        {
            StyleTextBox(txtSearch);
            StyleTextBox(txtProductId);
            StyleTextBox(txtProductName);
            StyleTextBox(txtPrice);
            StyleTextBox(txtQuantity);
            StyleTextBox(txtBarcode);
            StyleTextBox(txtImage);
            StyleTextBox(txtDescription);

            StyleComboBox(cboBrand);
            StyleComboBox(cboUnit);
            StyleComboBox(cboFilterBrand);
        }

        private void StyleTextBox(TextBox txt)
        {
            if (txt == null) return;

            txt.BackColor = Color.White;
            txt.ForeColor = Color.FromArgb(33, 37, 41);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        }

        private void StyleComboBox(ComboBox cbo)
        {
            if (cbo == null) return;

            cbo.BackColor = Color.White;
            cbo.ForeColor = Color.FromArgb(33, 37, 41);
            cbo.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cbo.FlatStyle = FlatStyle.Flat;
        }

        private void FormatGrid()
        {
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.DefaultCellStyle.BackColor = Color.White;
            dgvProducts.DefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvProducts.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 10F);

            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.MultiSelect = false;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.GridColor = Color.FromArgb(230, 230, 230);
            dgvProducts.ColumnHeadersHeight = 42;
            dgvProducts.RowTemplate.Height = 36;

            if (dgvProducts.Columns.Contains("Ảnh"))
                dgvProducts.Columns["Ảnh"].Visible = false;

            if (dgvProducts.Columns.Contains("Mô tả"))
                dgvProducts.Columns["Mô tả"].FillWeight = 150;

            if (dgvProducts.Columns.Contains("Giá bán"))
                dgvProducts.Columns["Giá bán"].DefaultCellStyle.Format = "N0";

            if (dgvProducts.Columns.Contains("Tồn kho"))
                dgvProducts.Columns["Tồn kho"].FillWeight = 70;

            if (dgvProducts.Columns.Contains("Mã SP"))
                dgvProducts.Columns["Mã SP"].FillWeight = 70;
        }

        #endregion

        #region Validate + Clear

        private bool ValidateInput(bool isUpdate = false)
        {
            if (isUpdate && string.IsNullOrWhiteSpace(txtProductId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật.");
                return false;
            }

            string name = txtProductName.Text.Trim();
            string priceText = txtPrice.Text.Trim();
            string quantityText = txtQuantity.Text.Trim();
            string barcode = txtBarcode.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên hàng hóa.");
                txtProductName.Focus();
                return false;
            }

            if (cboBrand.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn hãng.");
                cboBrand.Focus();
                return false;
            }

            if (cboUnit.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị.");
                cboUnit.Focus();
                return false;
            }

            if (!decimal.TryParse(priceText, out decimal price) || price < 0)
            {
                MessageBox.Show("Giá bán không hợp lệ.");
                txtPrice.Focus();
                return false;
            }

            if (!int.TryParse(quantityText, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ.");
                txtQuantity.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(barcode))
            {
                if (IsBarcodeExists(barcode, isUpdate ? txtProductId.Text.Trim() : null))
                {
                    MessageBox.Show("Mã vạch đã tồn tại.");
                    txtBarcode.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool IsBarcodeExists(string barcode, string currentProductId = null)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM Products
                WHERE Barcode = @Barcode
            ";

            if (!string.IsNullOrWhiteSpace(currentProductId))
            {
                sql += " AND ProductId <> @ProductId";
            }

            SqlParameter[] pr;
            if (!string.IsNullOrWhiteSpace(currentProductId))
            {
                pr = new SqlParameter[]
                {
                    new SqlParameter("@Barcode", barcode),
                    new SqlParameter("@ProductId", Convert.ToInt32(currentProductId))
                };
            }
            else
            {
                pr = new SqlParameter[]
                {
                    new SqlParameter("@Barcode", barcode)
                };
            }

            object result = db.ExecuteScalar(sql, pr);
            return Convert.ToInt32(result) > 0;
        }

        private void ClearInput()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtBarcode.Clear();
            txtImage.Clear();
            txtDescription.Clear();

            cboBrand.SelectedIndex = -1;
            cboUnit.SelectedIndex = -1;

            picProduct.Image = null;
            txtProductName.Focus();
        }

        #endregion

        #region Ảnh

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh sản phẩm";
                ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.webp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImage.Text = Path.GetFileName(ofd.FileName);

                    try
                    {
                        if (picProduct.Image != null)
                        {
                            picProduct.Image.Dispose();
                            picProduct.Image = null;
                        }

                        using (var bmpTemp = new Bitmap(ofd.FileName))
                        {
                            picProduct.Image = new Bitmap(bmpTemp);
                        }
                    }
                    catch
                    {
                        picProduct.Image = null;
                    }
                }
            }
        }

        private void LoadImagePreview(string fileName)
        {
            try
            {
                if (picProduct.Image != null)
                {
                    picProduct.Image.Dispose();
                    picProduct.Image = null;
                }

                if (string.IsNullOrWhiteSpace(fileName))
                    return;

                string cleanFileName = fileName.Trim().TrimStart('/', '\\');

                string[] possiblePaths =
                {
                    Path.Combine(Application.StartupPath, "Images", cleanFileName),
                    Path.Combine(Application.StartupPath, cleanFileName),
                    Path.Combine(Application.StartupPath, "Resources", cleanFileName)
                };

                foreach (string path in possiblePaths)
                {
                    if (File.Exists(path))
                    {
                        using (var bmpTemp = new Bitmap(path))
                        {
                            picProduct.Image = new Bitmap(bmpTemp);
                        }
                        return;
                    }
                }

                picProduct.Image = null;
            }
            catch
            {
                picProduct.Image = null;
            }
        }

        #endregion

        #region CRUD

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                string name = txtProductName.Text.Trim();
                decimal price = Convert.ToDecimal(txtPrice.Text.Trim());
                int quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                string barcode = txtBarcode.Text.Trim();
                string image = txtImage.Text.Trim();
                string description = txtDescription.Text.Trim();

                string sql = @"
                    INSERT INTO Products
                    (
                        Name, BrandId, UnitId, Price, Quantity, Barcode, Image, Description
                    )
                    VALUES
                    (
                        @Name, @BrandId, @UnitId, @Price, @Quantity, @Barcode, @Image, @Description
                    )
                ";

                SqlParameter[] pr =
                {
                    new SqlParameter("@Name", name),
                    new SqlParameter("@BrandId", Convert.ToInt32(cboBrand.SelectedValue)),
                    new SqlParameter("@UnitId", Convert.ToInt32(cboUnit.SelectedValue)),
                    new SqlParameter("@Price", price),
                    new SqlParameter("@Quantity", quantity),
                    new SqlParameter("@Barcode", string.IsNullOrWhiteSpace(barcode) ? (object)DBNull.Value : barcode),
                    new SqlParameter("@Image", string.IsNullOrWhiteSpace(image) ? (object)DBNull.Value : image),
                    new SqlParameter("@Description", string.IsNullOrWhiteSpace(description) ? (object)DBNull.Value : description)
                };

                db.ExecuteNonQuery(sql, pr);

                MessageBox.Show("Thêm hàng hóa thành công.");
                LoadProducts();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm hàng hóa: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput(true)) return;

                int productId = Convert.ToInt32(txtProductId.Text.Trim());
                string name = txtProductName.Text.Trim();
                decimal price = Convert.ToDecimal(txtPrice.Text.Trim());
                int quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                string barcode = txtBarcode.Text.Trim();
                string image = txtImage.Text.Trim();
                string description = txtDescription.Text.Trim();

                string sql = @"
                    UPDATE Products
                    SET
                        Name = @Name,
                        BrandId = @BrandId,
                        UnitId = @UnitId,
                        Price = @Price,
                        Quantity = @Quantity,
                        Barcode = @Barcode,
                        Image = @Image,
                        Description = @Description
                    WHERE ProductId = @ProductId
                ";

                SqlParameter[] pr =
                {
                    new SqlParameter("@Name", name),
                    new SqlParameter("@BrandId", Convert.ToInt32(cboBrand.SelectedValue)),
                    new SqlParameter("@UnitId", Convert.ToInt32(cboUnit.SelectedValue)),
                    new SqlParameter("@Price", price),
                    new SqlParameter("@Quantity", quantity),
                    new SqlParameter("@Barcode", string.IsNullOrWhiteSpace(barcode) ? (object)DBNull.Value : barcode),
                    new SqlParameter("@Image", string.IsNullOrWhiteSpace(image) ? (object)DBNull.Value : image),
                    new SqlParameter("@Description", string.IsNullOrWhiteSpace(description) ? (object)DBNull.Value : description),
                    new SqlParameter("@ProductId", productId)
                };

                db.ExecuteNonQuery(sql, pr);

                MessageBox.Show("Cập nhật hàng hóa thành công.");
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật hàng hóa: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProductId.Text))
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.");
                    return;
                }

                DialogResult rs = MessageBox.Show(
                    "Bạn có chắc muốn xóa sản phẩm này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (rs != DialogResult.Yes) return;

                int productId = Convert.ToInt32(txtProductId.Text);

                db.ExecuteNonQuery(
                    "DELETE FROM Products WHERE ProductId = @ProductId",
                    new SqlParameter[]
                    {
                        new SqlParameter("@ProductId", productId)
                    });

                MessageBox.Show("Xóa sản phẩm thành công.");
                LoadProducts();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa sản phẩm. Có thể sản phẩm đang được dùng ở phiếu nhập hoặc hóa đơn.\n\n" + ex.Message);
            }
        }

        #endregion

        #region Sự kiện phụ

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

            txtProductId.Text = row.Cells["Mã SP"].Value?.ToString();
            txtProductName.Text = row.Cells["Tên hàng"].Value?.ToString();
            cboBrand.Text = row.Cells["Hãng"].Value?.ToString();
            cboUnit.Text = row.Cells["Đơn vị"].Value?.ToString();
            txtPrice.Text = row.Cells["Giá bán"].Value?.ToString();
            txtQuantity.Text = row.Cells["Tồn kho"].Value?.ToString();
            txtBarcode.Text = row.Cells["Mã vạch"].Value?.ToString();
            txtImage.Text = row.Cells["Ảnh"].Value?.ToString();
            txtDescription.Text = row.Cells["Mô tả"].Value?.ToString();

            LoadImagePreview(txtImage.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            if (cboFilterBrand.DataSource != null)
                cboFilterBrand.SelectedIndex = 0;

            LoadProducts();
            ClearInput();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadProducts();
                e.SuppressKeyPress = true;
            }
        }

        private void cboFilterBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
                LoadProducts();
        }

        private void dgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.Cells["Tồn kho"]?.Value == null) continue;

                if (int.TryParse(row.Cells["Tồn kho"].Value.ToString(), out int qty))
                {
                    if (qty == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                    }
                    else if (qty <= 10)
                    {
                        row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                    }
                }
            }
        }

        #endregion
    }
}