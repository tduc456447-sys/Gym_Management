using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Staff
{
    public partial class AddCustomerForm : Form
    {
        private readonly DBHelper db = new DBHelper();

        public int NewCustomerId { get; private set; } = 0;
        public string NewCustomerDisplayText { get; private set; } = "";

        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (fullName == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên.");
                return;
            }

            try
            {
                if (phone != "")
                {
                    object existed = db.ExecuteScalar(@"
                        SELECT COUNT(*)
                        FROM Customers
                        WHERE Phone = @Phone",
                        new SqlParameter[]
                        {
                            new SqlParameter("@Phone", phone)
                        });

                    if (Convert.ToInt32(existed) > 0)
                    {
                        MessageBox.Show("Số điện thoại này đã tồn tại.");
                        return;
                    }
                }

                object idObj = db.ExecuteScalar(@"
                    INSERT INTO Customers (FullName, Phone, Address, CreatedAt)
                    VALUES (@FullName, @Phone, @Address, GETDATE());

                    SELECT SCOPE_IDENTITY();",
                    new SqlParameter[]
                    {
                        new SqlParameter("@FullName", fullName),
                        new SqlParameter("@Phone", phone == "" ? (object)DBNull.Value : phone),
                        new SqlParameter("@Address", address == "" ? (object)DBNull.Value : address)
                    });

                NewCustomerId = Convert.ToInt32(idObj);
                NewCustomerDisplayText = fullName + " - " + phone;

                MessageBox.Show("Thêm khách hàng thành công.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khách hàng: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}