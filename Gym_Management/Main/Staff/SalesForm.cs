using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Staff
{
    public partial class SalesForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int staffId;
        private readonly string staffName;

        private int selectedCustomerId = 0;
        private bool isActiveMember = false;
        private decimal discountPercent = 0;

        private DataTable cartTable;

        public SalesForm(int userId, string fullName)
        {
            InitializeComponent();
            staffId = userId;
            staffName = fullName;
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            lblStaff.Text = "Nhân viên: " + staffName;

            cboPaymentMethod.SelectedIndex = 0;

            InitCartTable();
            LoadBrands();
            LoadProducts();
            ResetCustomerInfo();
            UpdateSummary();
        }

        private void InitCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("ProductId", typeof(int));
            cartTable.Columns.Add("Tên sản phẩm", typeof(string));
            cartTable.Columns.Add("Số lượng", typeof(int));
            cartTable.Columns.Add("Đơn giá", typeof(decimal));
            cartTable.Columns.Add("Thành tiền", typeof(decimal));

            dgvCart.DataSource = cartTable;

            dgvCart.RowHeadersVisible = false;
            dgvCart.AllowUserToAddRows = false;
            dgvCart.ReadOnly = true;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.AllowUserToResizeRows = false;
            dgvCart.RowTemplate.Height = 32;
            dgvCart.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            if (dgvCart.Columns["ProductId"] != null)
                dgvCart.Columns["ProductId"].Visible = false;
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
            catch
            {
                // Nếu không có bảng/brand vẫn để dùng được
            }

            cboBrand.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            flowProducts.Controls.Clear();

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
                WHERE p.Quantity > 0
                  AND (@Keyword = '' OR p.Name LIKE N'%' + @Keyword + N'%')
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

        private Panel CreateProductCard(int productId, string productName, string brandName, decimal price, int quantity, string imageFileName)
        {
            Panel panel = new Panel();
            panel.Width = 190;
            panel.Height = 255;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10);
            panel.BackColor = Color.White;

            PictureBox pbImage = new PictureBox();
            pbImage.Location = new Point(14, 10);
            pbImage.Size = new Size(160, 110);
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                string imageFolder = Path.Combine(Application.StartupPath, "images");
                string imagePath = Path.Combine(imageFolder, imageFileName);

                if (!string.IsNullOrWhiteSpace(imageFileName) && File.Exists(imagePath))
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
            lblPrice.Text = "Giá: " + price.ToString("N0");
            lblPrice.ForeColor = Color.FromArgb(192, 57, 43);
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.Location = new Point(10, 188);
            lblPrice.Size = new Size(170, 20);

            Label lblQty = new Label();
            lblQty.Text = "Tồn kho: " + quantity;
            lblQty.Location = new Point(10, 208);
            lblQty.Size = new Size(100, 20);

            Button btnAdd = new Button();
            btnAdd.Text = "Thêm";
            btnAdd.Size = new Size(70, 30);
            btnAdd.Location = new Point(104, 213);
            btnAdd.BackColor = Color.FromArgb(52, 152, 219);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;

            btnAdd.Click += (s, e) =>
            {
                AddToCart(productId, productName, price, quantity);
            };

            panel.Controls.Add(pbImage);
            panel.Controls.Add(lblName);
            panel.Controls.Add(lblBrand);
            panel.Controls.Add(lblPrice);
            panel.Controls.Add(lblQty);
            panel.Controls.Add(btnAdd);

            return panel;
        }

        private void AddToCart(int productId, string productName, decimal price, int stockQty)
        {
            DataRow existingRow = null;

            foreach (DataRow row in cartTable.Rows)
            {
                if (Convert.ToInt32(row["ProductId"]) == productId)
                {
                    existingRow = row;
                    break;
                }
            }

            if (existingRow == null)
            {
                cartTable.Rows.Add(productId, productName, 1, price, price);
            }
            else
            {
                int currentQty = Convert.ToInt32(existingRow["Số lượng"]);
                if (currentQty + 1 > stockQty)
                {
                    MessageBox.Show("Số lượng vượt quá tồn kho.");
                    return;
                }

                currentQty++;
                existingRow["Số lượng"] = currentQty;
                existingRow["Thành tiền"] = currentQty * price;
            }

            UpdateSummary();
        }

        private void UpdateSummary()
        {
            decimal subTotal = 0;

            foreach (DataRow row in cartTable.Rows)
            {
                subTotal += Convert.ToDecimal(row["Thành tiền"]);
            }

            decimal discountAmount = subTotal * discountPercent / 100M;
            decimal finalTotal = subTotal - discountAmount;

            lblSubTotal.Text = subTotal.ToString("N0");
            lblDiscount.Text = discountAmount.ToString("N0") + " (" + discountPercent.ToString("N0") + "%)";
            lblFinalTotal.Text = finalTotal.ToString("N0");

            CalcChange();
        }

        private void CalcChange()
        {
            if (cboPaymentMethod.Text != "Cash")
            {
                txtCashReceived.Enabled = false;
                txtChange.Text = "0";
                return;
            }

            txtCashReceived.Enabled = true;

            decimal finalTotal = 0;
            decimal cash = 0;

            decimal.TryParse(lblFinalTotal.Text.Replace(",", ""), out finalTotal);
            decimal.TryParse(txtCashReceived.Text.Trim().Replace(",", ""), out cash);

            decimal change = cash - finalTotal;
            txtChange.Text = change < 0 ? "0" : change.ToString("N0");
        }

        private void ResetCustomerInfo()
        {
            selectedCustomerId = 0;
            isActiveMember = false;
            discountPercent = 0;

            lblCustomerName.Text = "Khách: Khách lẻ";
            lblCustomerType.Text = "Loại khách: Khách thường";
        }

        private void SetCustomerInfo(int customerId, string fullName, bool activeMember)
        {
            selectedCustomerId = customerId;
            isActiveMember = activeMember;
            discountPercent = isActiveMember ? 5 : 0;

            lblCustomerName.Text = "Khách: " + fullName;
            lblCustomerType.Text = isActiveMember
                ? "Loại khách: Hội viên active"
                : "Loại khách: Khách thường";

            UpdateSummary();
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void btnChooseCustomer_Click(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void SearchCustomer()
        {
            string keyword = txtCustomerKeyword.Text.Trim();

            if (keyword == "")
            {
                MessageBox.Show("Vui lòng nhập tên hoặc số điện thoại khách hàng.");
                return;
            }

            try
            {
                DataTable dt = db.ExecuteQuery(@"
                    SELECT TOP 20
                        c.CustomerId,
                        c.FullName,
                        c.Phone,
                        CASE
                            WHEN EXISTS (
                                SELECT 1
                                FROM Memberships m
                                WHERE m.CustomerId = c.CustomerId
                                  AND m.Status = 'Active'
                                  AND m.EndDate >= CAST(GETDATE() AS DATE)
                            )
                            THEN CAST(1 AS BIT)
                            ELSE CAST(0 AS BIT)
                        END AS IsActiveMember
                    FROM Customers c
                    WHERE c.FullName LIKE N'%' + @Keyword + N'%'
                       OR ISNULL(c.Phone, '') LIKE N'%' + @Keyword + N'%'
                    ORDER BY c.FullName",
                    new SqlParameter[]
                    {
                        new SqlParameter("@Keyword", keyword)
                    });

                if (dt.Rows.Count == 0)
                {
                    ResetCustomerInfo();
                    UpdateSummary();
                    MessageBox.Show("Không tìm thấy khách hàng.");
                    return;
                }

                DataRow row = dt.Rows[0];
                SetCustomerInfo(
                    Convert.ToInt32(row["CustomerId"]),
                    row["FullName"].ToString(),
                    Convert.ToBoolean(row["IsActiveMember"])
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm khách: " + ex.Message);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            using (AddCustomerForm f = new AddCustomerForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    SetCustomerInfo(f.NewCustomerId, f.NewCustomerDisplayText, false);
                }
            }
        }

        private int GetSelectedCartProductId()
        {
            if (dgvCart.CurrentRow == null) return 0;
            return Convert.ToInt32(dgvCart.CurrentRow.Cells["ProductId"].Value);
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;

            int productId = GetSelectedCartProductId();

            object stockObj = db.ExecuteScalar(@"
                SELECT Quantity
                FROM Products
                WHERE ProductId = @ProductId",
                new SqlParameter[]
                {
                    new SqlParameter("@ProductId", productId)
                });

            int stockQty = Convert.ToInt32(stockObj);

            foreach (DataRow row in cartTable.Rows)
            {
                if (Convert.ToInt32(row["ProductId"]) == productId)
                {
                    int qty = Convert.ToInt32(row["Số lượng"]);
                    decimal price = Convert.ToDecimal(row["Đơn giá"]);

                    if (qty + 1 > stockQty)
                    {
                        MessageBox.Show("Số lượng vượt quá tồn kho.");
                        return;
                    }

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
            if (dgvCart.CurrentRow == null) return;

            int productId = GetSelectedCartProductId();

            for (int i = 0; i < cartTable.Rows.Count; i++)
            {
                DataRow row = cartTable.Rows[i];
                if (Convert.ToInt32(row["ProductId"]) == productId)
                {
                    int qty = Convert.ToInt32(row["Số lượng"]);
                    decimal price = Convert.ToDecimal(row["Đơn giá"]);

                    qty--;
                    if (qty <= 0)
                    {
                        cartTable.Rows.RemoveAt(i);
                    }
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
            if (dgvCart.CurrentRow == null) return;

            int productId = GetSelectedCartProductId();

            for (int i = 0; i < cartTable.Rows.Count; i++)
            {
                if (Convert.ToInt32(cartTable.Rows[i]["ProductId"]) == productId)
                {
                    cartTable.Rows.RemoveAt(i);
                    break;
                }
            }

            UpdateSummary();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            CalcChange();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.");
                return;
            }

            try
            {
                decimal subTotal = 0;
                decimal discountAmount = 0;
                decimal finalTotal = 0;

                decimal.TryParse(lblSubTotal.Text.Replace(",", ""), out subTotal);
                string discountText = lblDiscount.Text.Split('(')[0].Trim().Replace(",", "");
                decimal.TryParse(discountText, out discountAmount);
                decimal.TryParse(lblFinalTotal.Text.Replace(",", ""), out finalTotal);

                string customerType = isActiveMember ? "Hội viên" : "Khách thường";

                object invoiceIdObj = db.ExecuteScalar("sp_CreateSalesInvoice",
                    new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", selectedCustomerId == 0 ? (object)DBNull.Value : selectedCustomerId),
                        new SqlParameter("@SubTotal", subTotal),
                        new SqlParameter("@DiscountPercent", discountPercent),
                        new SqlParameter("@DiscountAmount", discountAmount),
                        new SqlParameter("@FinalTotal", finalTotal),
                        new SqlParameter("@CustomerType", customerType),
                        new SqlParameter("@Note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text.Trim()),
                        new SqlParameter("@CreatedByStaffId", staffId)
                    },
                    CommandType.StoredProcedure);

                int salesInvoiceId = Convert.ToInt32(invoiceIdObj);

                foreach (DataRow row in cartTable.Rows)
                {
                    db.ExecuteNonQuery("sp_AddSalesInvoiceDetail",
                        new SqlParameter[]
                        {
                            new SqlParameter("@SalesInvoiceId", salesInvoiceId),
                            new SqlParameter("@ProductId", Convert.ToInt32(row["ProductId"])),
                            new SqlParameter("@Quantity", Convert.ToInt32(row["Số lượng"])),
                            new SqlParameter("@Price", Convert.ToDecimal(row["Đơn giá"]))
                        },
                        CommandType.StoredProcedure);
                }

                if (cboPaymentMethod.Text == "Online")
                {
                    db.ExecuteNonQuery("sp_PaySalesInvoice",
                        new SqlParameter[]
                        {
                            new SqlParameter("@SalesInvoiceId", salesInvoiceId),
                            new SqlParameter("@Amount", finalTotal),
                            new SqlParameter("@Method", "Online"),
                            new SqlParameter("@CashReceived", DBNull.Value),
                            new SqlParameter("@ReceivedByStaffId", staffId)
                        },
                        CommandType.StoredProcedure);
                }
                else
                {
                    decimal cashReceived = 0;
                    decimal.TryParse(txtCashReceived.Text.Trim().Replace(",", ""), out cashReceived);

                    if (cashReceived < finalTotal)
                    {
                        MessageBox.Show("Tiền khách đưa chưa đủ.");
                        return;
                    }

                    db.ExecuteNonQuery("sp_PaySalesInvoice",
                        new SqlParameter[]
                        {
                            new SqlParameter("@SalesInvoiceId", salesInvoiceId),
                            new SqlParameter("@Amount", finalTotal),
                            new SqlParameter("@Method", "Cash"),
                            new SqlParameter("@CashReceived", cashReceived),
                            new SqlParameter("@ReceivedByStaffId", staffId)
                        },
                        CommandType.StoredProcedure);
                }

                MessageBox.Show("Thanh toán thành công.");
                ResetForm();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message);
            }
        }

        private void ResetForm()
        {
            ResetCustomerInfo();
            txtCustomerKeyword.Text = "";
            txtCashReceived.Text = "";
            txtChange.Text = "0";
            txtNote.Text = "";
            cartTable.Rows.Clear();
            UpdateSummary();
        }
    }
}