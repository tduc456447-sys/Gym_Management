using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.ImportManagement
{
    public partial class frmImportReceipt : Form
    {
        private readonly DBHelper db = new DBHelper();
        private DataTable importItems;

        public frmImportReceipt()
        {
            InitializeComponent();
        }

        private void frmImportReceipt_Load(object sender, EventArgs e)
        {
            InitImportTable();
            LoadProducts();
            UpdateTotal();
        }

        #region Khởi tạo dữ liệu tạm

        private void InitImportTable()
        {
            importItems = new DataTable();
            importItems.Columns.Add("ProductId", typeof(int));
            importItems.Columns.Add("ProductName", typeof(string));
            importItems.Columns.Add("Quantity", typeof(int));
            importItems.Columns.Add("Price", typeof(decimal));
            importItems.Columns.Add("Amount", typeof(decimal), "Quantity * Price");
        }

        private void LoadProducts()
        {
            try
            {
                DataTable dt = db.ExecuteQuery(@"
                    SELECT ProductId, Name, Price, Stock
                    FROM Products
                    ORDER BY Name
                ");

                cboProduct.DataSource = dt;
                cboProduct.DisplayMember = "Name";
                cboProduct.ValueMember = "ProductId";
                cboProduct.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
            }
        }

        #endregion

        #region Thêm item vào phiếu

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboProduct.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm.");
                    cboProduct.Focus();
                    return;
                }

                int quantity;
                if (!int.TryParse(txtQuantity.Text.Trim(), out quantity) || quantity <= 0)
                {
                    MessageBox.Show("Số lượng nhập không hợp lệ.");
                    txtQuantity.Focus();
                    return;
                }

                decimal price;
                if (!decimal.TryParse(txtImportPrice.Text.Trim(), out price) || price < 0)
                {
                    MessageBox.Show("Giá nhập không hợp lệ.");
                    txtImportPrice.Focus();
                    return;
                }

                int productId = Convert.ToInt32(cboProduct.SelectedValue);
                string productName = cboProduct.Text.Trim();

                DataRow existingRow = null;
                foreach (DataRow row in importItems.Rows)
                {
                    if (Convert.ToInt32(row["ProductId"]) == productId)
                    {
                        existingRow = row;
                        break;
                    }
                }

                if (existingRow != null)
                {
                    existingRow["Quantity"] = Convert.ToInt32(existingRow["Quantity"]) + quantity;
                    existingRow["Price"] = price;
                }
                else
                {
                    DataRow newRow = importItems.NewRow();
                    newRow["ProductId"] = productId;
                    newRow["ProductName"] = productName;
                    newRow["Quantity"] = quantity;
                    newRow["Price"] = price;
                    importItems.Rows.Add(newRow);
                }

                RenderImportItems();
                UpdateTotal();
                ClearItemInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sản phẩm vào phiếu: " + ex.Message);
            }
        }

        private void ClearItemInput()
        {
            cboProduct.SelectedIndex = -1;
            txtQuantity.Clear();
            txtImportPrice.Clear();
        }

        #endregion

        #region Render item card

        private void RenderImportItems()
        {
            flpItems.Controls.Clear();

            foreach (DataRow row in importItems.Rows)
            {
                flpItems.Controls.Add(CreateItemCard(row));
            }
        }

        private Panel CreateItemCard(DataRow row)
        {
            Panel card = new Panel
            {
                Width = 730,
                Height = 95,
                BackColor = Color.FromArgb(248, 250, 252),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Tag = row
            };

            Label lblName = new Label
            {
                Parent = card,
                Text = row["ProductName"].ToString(),
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(15, 12),
                Size = new Size(260, 24)
            };

            Label lblQty = new Label
            {
                Parent = card,
                Text = "SL: " + Convert.ToInt32(row["Quantity"]).ToString(),
                Location = new Point(15, 45),
                Size = new Size(90, 22),
                ForeColor = Color.FromArgb(71, 85, 105)
            };

            Label lblPrice = new Label
            {
                Parent = card,
                Text = "Giá nhập: " + Convert.ToDecimal(row["Price"]).ToString("N0") + " VNĐ",
                Location = new Point(120, 45),
                Size = new Size(180, 22),
                ForeColor = Color.FromArgb(71, 85, 105)
            };

            Label lblAmount = new Label
            {
                Parent = card,
                Text = "Thành tiền: " + Convert.ToDecimal(row["Amount"]).ToString("N0") + " VNĐ",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Location = new Point(320, 45),
                Size = new Size(220, 22),
                ForeColor = Color.FromArgb(22, 163, 74)
            };

            Button btnRemove = new Button
            {
                Parent = card,
                Text = "Xóa",
                Width = 70,
                Height = 30,
                Location = new Point(630, 30),
                BackColor = Color.FromArgb(220, 38, 38),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = row
            };
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.Click += btnRemoveItem_Click;

            return card;
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if (btn == null || btn.Tag == null) return;

                DataRow row = btn.Tag as DataRow;
                if (row == null) return;

                DialogResult rs = MessageBox.Show(
                    "Xóa sản phẩm này khỏi phiếu nhập?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (rs == DialogResult.Yes)
                {
                    importItems.Rows.Remove(row);
                    RenderImportItems();
                    UpdateTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dòng nhập: " + ex.Message);
            }
        }

        #endregion

        #region Tổng tiền

        private void UpdateTotal()
        {
            decimal total = 0;

            foreach (DataRow row in importItems.Rows)
            {
                total += Convert.ToDecimal(row["Amount"]);
            }

            lblTotal.Text = "Tổng: " + total.ToString("N0") + " VNĐ";
        }

        #endregion

        #region Lưu phiếu

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (importItems.Rows.Count == 0)
                {
                    MessageBox.Show("Phiếu nhập chưa có sản phẩm nào.");
                    return;
                }

                decimal total = 0;
                foreach (DataRow row in importItems.Rows)
                {
                    total += Convert.ToDecimal(row["Amount"]);
                }

                SqlParameter[] receiptParams = new SqlParameter[]
                {
                    new SqlParameter("@Date", dtpDate.Value),
                    new SqlParameter("@Total", total)
                };

                object importIdObj = db.ExecuteScalar(
                    @"INSERT INTO ImportReceipts ([Date], Total)
                      VALUES (@Date, @Total);
                      SELECT SCOPE_IDENTITY();",
                    receiptParams
                );

                int importId = Convert.ToInt32(importIdObj);

                foreach (DataRow row in importItems.Rows)
                {
                    SqlParameter[] detailParams = new SqlParameter[]
                    {
                        new SqlParameter("@ImportId", importId),
                        new SqlParameter("@ProductId", row["ProductId"]),
                        new SqlParameter("@Quantity", row["Quantity"]),
                        new SqlParameter("@Price", row["Price"])
                    };

                    db.ExecuteNonQuery(
                        @"INSERT INTO ImportDetails (ImportId, ProductId, Quantity, Price)
                          VALUES (@ImportId, @ProductId, @Quantity, @Price)",
                        detailParams
                    );
                }

                MessageBox.Show(
                    "Lưu phiếu nhập thành công.\nMã phiếu: " + importId,
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu phiếu nhập: " + ex.Message);
            }
        }

        private void ResetForm()
        {
            dtpDate.Value = DateTime.Now;
            txtSupplier.Clear();
            txtNote.Clear();
            ClearItemInput();

            importItems.Clear();
            RenderImportItems();
            UpdateTotal();
        }

        #endregion
    }
}