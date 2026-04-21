using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Gym_Management.Main.Admin
{
    public partial class AddProductForm : Form
    {
        private readonly DBHelper db = new DBHelper();

        public int NewProductId { get; private set; }

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            LoadBrands();
            LoadUnits();
        }

        private void LoadBrands()
        {
            DataTable dt = db.ExecuteQuery("SELECT BrandId, Name FROM Brands ORDER BY Name");
            DataRow row = dt.NewRow();
            row["BrandId"] = DBNull.Value;
            row["Name"] = "-- Chọn hãng --";
            dt.Rows.InsertAt(row, 0);

            cboBrand.DisplayMember = "Name";
            cboBrand.ValueMember = "BrandId";
            cboBrand.DataSource = dt;
        }

        private void LoadUnits()
        {
            DataTable dt = db.ExecuteQuery("SELECT UnitId, Name FROM Units ORDER BY Name");
            DataRow row = dt.NewRow();
            row["UnitId"] = DBNull.Value;
            row["Name"] = "-- Chọn đơn vị --";
            dt.Rows.InsertAt(row, 0);

            cboUnit.DisplayMember = "Name";
            cboUnit.ValueMember = "UnitId";
            cboUnit.DataSource = dt;
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            using (AddBrandForm f = new AddBrandForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadBrands();
                    if (f.NewBrandId > 0)
                        cboBrand.SelectedValue = f.NewBrandId;
                }
            }
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            using (AddUnitForm f = new AddUnitForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadUnits();
                    if (f.NewUnitId > 0)
                        cboUnit.SelectedValue = f.NewUnitId;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal price;
                if (!decimal.TryParse(txtPrice.Text.Trim().Replace(",", ""), out price) || price < 0)
                {
                    MessageBox.Show("Giá bán không hợp lệ.");
                    return;
                }

                DataTable dt = db.ExecuteQuery("sp_AddProduct",
                    new SqlParameter[]
                    {
                        new SqlParameter("@Name", txtName.Text.Trim()),
                        new SqlParameter("@BrandId", cboBrand.SelectedValue == null || cboBrand.SelectedValue == DBNull.Value ? (object)DBNull.Value : cboBrand.SelectedValue),
                        new SqlParameter("@UnitId", cboUnit.SelectedValue == null || cboUnit.SelectedValue == DBNull.Value ? (object)DBNull.Value : cboUnit.SelectedValue),
                        new SqlParameter("@Price", price),
                        new SqlParameter("@Barcode", string.IsNullOrWhiteSpace(txtBarcode.Text) ? (object)DBNull.Value : txtBarcode.Text.Trim()),
                        new SqlParameter("@Image", string.IsNullOrWhiteSpace(txtImage.Text) ? (object)DBNull.Value : txtImage.Text.Trim()),
                        new SqlParameter("@Description", string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text.Trim())
                    },
                    CommandType.StoredProcedure);

                if (dt.Rows.Count > 0)
                {
                    NewProductId = Convert.ToInt32(dt.Rows[0]["ProductId"]);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sản phẩm: " + ex.Message);
            }
        }
    }
}