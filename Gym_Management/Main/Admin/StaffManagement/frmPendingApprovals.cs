using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.StaffManagement
{
    public partial class frmPendingApprovals : Form
    {
        public frmPendingApprovals()
        {
            InitializeComponent();
        }

        private void frmPendingApprovals_Load(object sender, EventArgs e)
        {
            SetupStatusComboBox();
            LoadPendingUsers();
        }

        private void SetupStatusComboBox()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Tất cả");
            cboStatus.Items.Add("Pending");
            cboStatus.Items.Add("Approved");
            cboStatus.Items.Add("Rejected");
            cboStatus.SelectedIndex = 0;
        }

        private void LoadPendingUsers()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                string status = cboStatus.SelectedItem != null ? cboStatus.SelectedItem.ToString() : "Tất cả";

                string sql = @"
                    SELECT 
                        Id,
                        Username,
                        FullName,
                        Status
                    FROM PendingUsers
                    WHERE
                        (@Keyword = '' 
                            OR Username LIKE @KeywordLike 
                            OR FullName LIKE @KeywordLike)
                        AND
                        (@Status = '' OR Status = @Status)
                    ORDER BY Id DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Keyword", keyword),
                    new SqlParameter("@KeywordLike", "%" + keyword + "%"),
                    new SqlParameter("@Status", status == "Tất cả" ? "" : status)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);
                dgvPendingUsers.DataSource = dt;

                if (dgvPendingUsers.Columns.Contains("Id"))
                    dgvPendingUsers.Columns["Id"].HeaderText = "ID";

                if (dgvPendingUsers.Columns.Contains("Username"))
                    dgvPendingUsers.Columns["Username"].HeaderText = "Tên đăng nhập";

                if (dgvPendingUsers.Columns.Contains("FullName"))
                    dgvPendingUsers.Columns["FullName"].HeaderText = "Họ tên";

                if (dgvPendingUsers.Columns.Contains("Status"))
                    dgvPendingUsers.Columns["Status"].HeaderText = "Trạng thái";

                dgvPendingUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPendingUsers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chờ duyệt:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSelectedPendingUserId()
        {
            if (dgvPendingUsers.CurrentRow == null)
                return -1;

            if (dgvPendingUsers.CurrentRow.Cells["Id"] == null)
                return -1;

            return Convert.ToInt32(dgvPendingUsers.CurrentRow.Cells["Id"].Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPendingUsers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPendingUsers();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPendingUsers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboStatus.SelectedIndex = 0;
            LoadPendingUsers();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = GetSelectedPendingUserId();
                if (id == -1)
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần duyệt.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string getPendingUserSql = @"
                    SELECT Id, Username, Password, FullName, Status
                    FROM PendingUsers
                    WHERE Id = @Id";

                DataTable dt = DBHelper.ExecuteQuery(getPendingUserSql, new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                });

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy tài khoản chờ duyệt.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow row = dt.Rows[0];
                string username = row["Username"].ToString();
                string password = row["Password"].ToString();
                string fullName = row["FullName"].ToString();
                string status = row["Status"].ToString();

                if (!status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Tài khoản này không còn ở trạng thái chờ duyệt.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadPendingUsers();
                    return;
                }

                object existingUserCount = DBHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM Users WHERE Username = @Username",
                    new SqlParameter[]
                    {
                        new SqlParameter("@Username", username)
                    });

                if (Convert.ToInt32(existingUserCount) > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại trong bảng Users.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    $"Bạn có chắc muốn duyệt tài khoản \"{username}\" không?",
                    "Xác nhận duyệt",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                using (SqlConnection conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();

                    try
                    {
                        string insertUserSql = @"
                            INSERT INTO Users
                            (
                                Username,
                                Password,
                                FullName,
                                Role,
                                Status,
                                Experience,
                                CreatedAt
                            )
                            VALUES
                            (
                                @Username,
                                @Password,
                                @FullName,
                                'Staff',
                                'Active',
                                0,
                                GETDATE()
                            )";

                        using (SqlCommand cmdInsert = new SqlCommand(insertUserSql, conn, trans))
                        {
                            cmdInsert.Parameters.AddWithValue("@Username", username);
                            cmdInsert.Parameters.AddWithValue("@Password", password);
                            cmdInsert.Parameters.AddWithValue("@FullName", fullName);
                            cmdInsert.ExecuteNonQuery();
                        }

                        string updatePendingSql = @"
                            UPDATE PendingUsers
                            SET Status = 'Approved'
                            WHERE Id = @Id AND Status = 'Pending'";

                        using (SqlCommand cmdUpdate = new SqlCommand(updatePendingSql, conn, trans))
                        {
                            cmdUpdate.Parameters.AddWithValue("@Id", id);
                            int rows = cmdUpdate.ExecuteNonQuery();

                            if (rows == 0)
                                throw new Exception("Không thể cập nhật trạng thái tài khoản chờ duyệt.");
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }

                MessageBox.Show("Duyệt tài khoản thành công.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadPendingUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi duyệt tài khoản:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                int id = GetSelectedPendingUserId();
                if (id == -1)
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần từ chối.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc muốn từ chối tài khoản này không?",
                    "Xác nhận từ chối",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                string sql = @"
                    UPDATE PendingUsers
                    SET Status = 'Rejected'
                    WHERE Id = @Id AND Status = 'Pending'";

                int rows = DBHelper.ExecuteNonQuery(sql, new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                });

                if (rows > 0)
                {
                    MessageBox.Show("Đã từ chối tài khoản.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể từ chối. Tài khoản có thể đã được xử lý trước đó.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                LoadPendingUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi từ chối tài khoản:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPendingUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
        }
    }
}