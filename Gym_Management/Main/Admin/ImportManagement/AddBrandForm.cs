using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Gym_Management.Main.Admin
{
    public partial class AddBrandForm : Form
    {
        private readonly DBHelper db = new DBHelper();

        public int NewBrandId { get; private set; }

        public AddBrandForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = db.ExecuteQuery("sp_AddBrand",
                    new SqlParameter[]
                    {
                        new SqlParameter("@Name", txtName.Text.Trim())
                    },
                    CommandType.StoredProcedure);

                if (dt.Rows.Count > 0)
                {
                    NewBrandId = Convert.ToInt32(dt.Rows[0]["BrandId"]);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm hãng: " + ex.Message);
            }
        }
    }
}