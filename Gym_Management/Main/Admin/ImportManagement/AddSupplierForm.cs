using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Gym_Management.Main.Admin
{
    public partial class AddSupplierForm : Form
    {
        private readonly DBHelper db = new DBHelper();

        public int NewSupplierId { get; private set; }

        public AddSupplierForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = db.ExecuteQuery("sp_AddSupplier",
                    new SqlParameter[]
                    {
                        new SqlParameter("@Name", txtName.Text.Trim()),
                        new SqlParameter("@Phone", string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text.Trim()),
                        new SqlParameter("@Email", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim()),
                        new SqlParameter("@Address", string.IsNullOrWhiteSpace(txtAddress.Text) ? (object)DBNull.Value : txtAddress.Text.Trim()),
                        new SqlParameter("@TaxCode", string.IsNullOrWhiteSpace(txtTaxCode.Text) ? (object)DBNull.Value : txtTaxCode.Text.Trim()),
                        new SqlParameter("@Note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text.Trim())
                    },
                    CommandType.StoredProcedure);

                if (dt.Rows.Count > 0)
                {
                    NewSupplierId = Convert.ToInt32(dt.Rows[0]["SupplierId"]);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhà cung cấp: " + ex.Message);
            }
        }
    }
}