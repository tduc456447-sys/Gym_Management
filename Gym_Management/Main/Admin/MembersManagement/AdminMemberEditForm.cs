using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Admin
{
    public partial class AdminMemberEditForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int _customerId;
        private readonly bool _isEdit;

        public int SavedCustomerId { get; private set; }

        public AdminMemberEditForm()
        {
            InitializeComponent();
            _customerId = 0;
            _isEdit = false;
        }

        public AdminMemberEditForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            _isEdit = true;
        }

        private void AdminMemberEditForm_Load(object sender, EventArgs e)
        {
            LoadStatusOptions();
            if (_isEdit)
            {
                lblTitle.Text = "Sửa hồ sơ hội viên";
                LoadData();
            }
            else
            {
                lblTitle.Text = "Thêm hội viên";
                dtpJoinDate.Value = DateTime.Today;
                txtCardCode.Text = GenerateNextCardCode();
                cboStatus.SelectedIndex = 0;
            }
        }

        private void LoadStatusOptions()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Active");
            cboStatus.Items.Add("Inactive");
            cboStatus.Items.Add("Blocked");
        }

        private void LoadData()
        {
            string sql = @"
SELECT TOP 1
    c.CustomerId,
    c.FullName,
    c.Phone,
    c.Address,
    mp.IdentityNumber,
    mp.CardCode,
    mp.JoinDate,
    mp.Status
FROM Customers c
LEFT JOIN MemberProfiles mp ON c.CustomerId = mp.CustomerId
WHERE c.CustomerId = @CustomerId";

            DataTable dt = db.ExecuteQuery(sql, new SqlParameter[] { new SqlParameter("@CustomerId", _customerId) });
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hội viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            DataRow r = dt.Rows[0];
            txtFullName.Text = GetString(r, "FullName");
            txtPhone.Text = GetString(r, "Phone");
            txtAddress.Text = GetString(r, "Address");
            txtIdentityNumber.Text = GetString(r, "IdentityNumber");
            txtCardCode.Text = GetString(r, "CardCode");
            if (string.IsNullOrWhiteSpace(txtCardCode.Text))
                txtCardCode.Text = GenerateNextCardCode();

            if (r["JoinDate"] != DBNull.Value)
            {
                DateTime joinDate;
                if (DateTime.TryParse(r["JoinDate"].ToString(), out joinDate))
                    dtpJoinDate.Value = joinDate;
            }
            else
            {
                dtpJoinDate.Value = DateTime.Today;
            }

            string status = GetString(r, "Status");
            if (string.IsNullOrWhiteSpace(status)) status = "Active";
            cboStatus.SelectedItem = status;
        }

        private string GetString(DataRow row, string column)
        {
            if (!row.Table.Columns.Contains(column)) return string.Empty;
            object value = row[column];
            return value == null || value == DBNull.Value ? string.Empty : value.ToString();
        }

        private string GenerateNextCardCode()
        {
            try
            {
                object result = db.ExecuteScalar("sp_GenerateNextCardCode", null, CommandType.StoredProcedure);
                if (result != null && result != DBNull.Value)
                    return result.ToString();
            }
            catch
            {
            }

            try
            {
                object result = db.ExecuteScalar(@"
SELECT 'CARD' + RIGHT('0000' + CAST(ISNULL(MAX(TRY_CAST(SUBSTRING(CardCode, 5, LEN(CardCode)) AS INT)), 0) + 1 AS VARCHAR(10)), 4)
FROM MemberProfiles
WHERE CardCode LIKE 'CARD%'");

                return result == null || result == DBNull.Value ? "CARD0001" : result.ToString();
            }
            catch
            {
                return "CARD0001";
            }
        }

        private void btnGenerateCard_Click(object sender, EventArgs e)
        {
            txtCardCode.Text = GenerateNextCardCode();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string identity = txtIdentityNumber.Text.Trim();
            string cardCode = txtCardCode.Text.Trim();
            string status = cboStatus.Text.Trim();
            DateTime joinDate = dtpJoinDate.Value.Date;

            if (fullName == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (status == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn trạng thái hồ sơ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboStatus.Focus();
                return;
            }

            try
            {
                if (phone != string.Empty)
                {
                    string phoneSql = _isEdit
                        ? "SELECT COUNT(*) FROM Customers WHERE Phone = @Phone AND CustomerId <> @CustomerId"
                        : "SELECT COUNT(*) FROM Customers WHERE Phone = @Phone";

                    SqlParameter[] phoneParams = _isEdit
                        ? new SqlParameter[]
                        {
                            new SqlParameter("@Phone", phone),
                            new SqlParameter("@CustomerId", _customerId)
                        }
                        : new SqlParameter[]
                        {
                            new SqlParameter("@Phone", phone)
                        };

                    int phoneCount = Convert.ToInt32(db.ExecuteScalar(phoneSql, phoneParams));
                    if (phoneCount > 0)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPhone.Focus();
                        return;
                    }
                }

                if (cardCode != string.Empty)
                {
                    string cardSql = _isEdit
                        ? "SELECT COUNT(*) FROM MemberProfiles WHERE CardCode = @CardCode AND CustomerId <> @CustomerId"
                        : "SELECT COUNT(*) FROM MemberProfiles WHERE CardCode = @CardCode";

                    SqlParameter[] cardParams = _isEdit
                        ? new SqlParameter[]
                        {
                            new SqlParameter("@CardCode", cardCode),
                            new SqlParameter("@CustomerId", _customerId)
                        }
                        : new SqlParameter[]
                        {
                            new SqlParameter("@CardCode", cardCode)
                        };

                    int cardCount = Convert.ToInt32(db.ExecuteScalar(cardSql, cardParams));
                    if (cardCount > 0)
                    {
                        MessageBox.Show("Mã thẻ đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCardCode.Focus();
                        return;
                    }
                }

                if (_isEdit)
                {
                    db.ExecuteNonQuery(@"
UPDATE Customers
SET FullName = @FullName,
    Phone = @Phone,
    Address = @Address
WHERE CustomerId = @CustomerId",
                        new SqlParameter[]
                        {
                            new SqlParameter("@FullName", fullName),
                            new SqlParameter("@Phone", phone == string.Empty ? (object)DBNull.Value : phone),
                            new SqlParameter("@Address", address == string.Empty ? (object)DBNull.Value : address),
                            new SqlParameter("@CustomerId", _customerId)
                        });

                    int profileCount = Convert.ToInt32(db.ExecuteScalar(
                        "SELECT COUNT(*) FROM MemberProfiles WHERE CustomerId = @CustomerId",
                        new SqlParameter[] { new SqlParameter("@CustomerId", _customerId) }));

                    if (profileCount == 0)
                    {
                        db.ExecuteNonQuery(@"
INSERT INTO MemberProfiles(CustomerId, Avatar, IdentityNumber, CardCode, JoinDate, Status)
VALUES(@CustomerId, NULL, @IdentityNumber, @CardCode, @JoinDate, @Status)",
                            new SqlParameter[]
                            {
                                new SqlParameter("@CustomerId", _customerId),
                                new SqlParameter("@IdentityNumber", identity == string.Empty ? (object)DBNull.Value : identity),
                                new SqlParameter("@CardCode", cardCode == string.Empty ? (object)DBNull.Value : cardCode),
                                new SqlParameter("@JoinDate", joinDate),
                                new SqlParameter("@Status", status)
                            });
                    }
                    else
                    {
                        db.ExecuteNonQuery(@"
UPDATE MemberProfiles
SET IdentityNumber = @IdentityNumber,
    CardCode = @CardCode,
    JoinDate = @JoinDate,
    Status = @Status
WHERE CustomerId = @CustomerId",
                            new SqlParameter[]
                            {
                                new SqlParameter("@IdentityNumber", identity == string.Empty ? (object)DBNull.Value : identity),
                                new SqlParameter("@CardCode", cardCode == string.Empty ? (object)DBNull.Value : cardCode),
                                new SqlParameter("@JoinDate", joinDate),
                                new SqlParameter("@Status", status),
                                new SqlParameter("@CustomerId", _customerId)
                            });
                    }

                    SavedCustomerId = _customerId;
                    MessageBox.Show("Cập nhật hội viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    object newIdObj = db.ExecuteScalar(@"
INSERT INTO Customers(FullName, Phone, Address, CreatedAt)
VALUES(@FullName, @Phone, @Address, GETDATE());
SELECT SCOPE_IDENTITY();",
                        new SqlParameter[]
                        {
                            new SqlParameter("@FullName", fullName),
                            new SqlParameter("@Phone", phone == string.Empty ? (object)DBNull.Value : phone),
                            new SqlParameter("@Address", address == string.Empty ? (object)DBNull.Value : address)
                        });

                    int newCustomerId = Convert.ToInt32(newIdObj);

                    db.ExecuteNonQuery(@"
INSERT INTO MemberProfiles(CustomerId, Avatar, IdentityNumber, CardCode, JoinDate, Status)
VALUES(@CustomerId, NULL, @IdentityNumber, @CardCode, @JoinDate, @Status)",
                        new SqlParameter[]
                        {
                            new SqlParameter("@CustomerId", newCustomerId),
                            new SqlParameter("@IdentityNumber", identity == string.Empty ? (object)DBNull.Value : identity),
                            new SqlParameter("@CardCode", cardCode == string.Empty ? (object)DBNull.Value : cardCode),
                            new SqlParameter("@JoinDate", joinDate),
                            new SqlParameter("@Status", status)
                        });

                    SavedCustomerId = newCustomerId;
                    MessageBox.Show("Thêm hội viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu hội viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
