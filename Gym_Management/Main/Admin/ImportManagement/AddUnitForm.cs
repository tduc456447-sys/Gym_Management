using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Gym_Management.Main.Admin
{
    public partial class AddUnitForm : Form
    {
        private readonly DBHelper db = new DBHelper();

        public int NewUnitId { get; private set; }

        public AddUnitForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = db.ExecuteQuery("sp_AddUnit",
                    new SqlParameter[]
                    {
                        new SqlParameter("@Name", txtName.Text.Trim())
                    },
                    CommandType.StoredProcedure);

                if (dt.Rows.Count > 0)
                {
                    NewUnitId = Convert.ToInt32(dt.Rows[0]["UnitId"]);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm đơn vị: " + ex.Message);
            }
        }
    }
}