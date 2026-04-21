using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Admin
{
    public partial class AddSupplierContactForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int supplierId;

        public int NewContactId { get; private set; }

        public AddSupplierContactForm(int supplierId, string supplierName)
        {
            InitializeComponent();
            this.supplierId = supplierId;
            lblSupplier.Text = "Nhà cung cấp: " + supplierName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = db.ExecuteQuery("sp_AddSupplierContact",
                    new SqlParameter[]
                    {
                        new SqlParameter("@SupplierId", supplierId),
                        new SqlParameter("@FullName", txtFullName.Text.Trim()),
                        new SqlParameter("@Phone", string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text.Trim()),
                        new SqlParameter("@Email", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim()),
                        new SqlParameter("@Position", string.IsNullOrWhiteSpace(txtPosition.Text) ? (object)DBNull.Value : txtPosition.Text.Trim()),
                        new SqlParameter("@IsPrimary", chkPrimary.Checked),
                        new SqlParameter("@Note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text.Trim())
                    },
                    CommandType.StoredProcedure);

                if (dt.Rows.Count > 0)
                {
                    NewContactId = Convert.ToInt32(dt.Rows[0]["ContactId"]);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm người liên hệ: " + ex.Message);
            }
        }
    }
}