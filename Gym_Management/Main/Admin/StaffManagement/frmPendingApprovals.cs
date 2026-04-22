using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.StaffManagement
{
    public partial class frmPendingApprovals : Form
    {
        private readonly DBHelper db = new DBHelper();
        private bool isProcessing = false;

        public frmPendingApprovals()
        {
            InitializeComponent();
        }

        private void frmPendingApprovals_Load(object sender, EventArgs e)
        {
            SetupStatusComboBox();
            txtPassword.UseSystemPasswordChar = true;
            LoadPendingUsers();
            ClearDetailFields();
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

                DataTable dt = db.ExecuteQuery(@"
                    SELECT
                        Id,
                        Username,
                        Password,
                        FullName,
                        Phone,
                        Email,
                        Status
                    FROM PendingUsers
                    WHERE
                        (@Keyword = ''
                            OR Username LIKE @KeywordLike
                            OR FullName LIKE @KeywordLike
                            OR ISNULL(Phone, '') LIKE @KeywordLike
                            OR ISNULL(Email, '') LIKE @KeywordLike)
                        AND (@Status = '' OR Status = @Status)
                    ORDER BY Id DESC",
                    new SqlParameter[]
                    {
                        new SqlParameter("@Keyword", keyword),
                        new SqlParameter("@KeywordLike", "%" + keyword + "%"),
                        new SqlParameter("@Status", status == "Tất cả" ? string.Empty : status)
                    });

                dgvPendingUsers.DataSource = dt;

                if (dgvPendingUsers.Columns.Contains("Id")) dgvPendingUsers.Columns["Id"].HeaderText = "Mã chờ";
                if (dgvPendingUsers.Columns.Contains("Username")) dgvPendingUsers.Columns["Username"].HeaderText = "Tên đăng nhập";
                if (dgvPendingUsers.Columns.Contains("Password"))
                {
                    dgvPendingUsers.Columns["Password"].HeaderText = "Mật khẩu";
                    dgvPendingUsers.Columns["Password"].Visible = false;
                }
                if (dgvPendingUsers.Columns.Contains("FullName")) dgvPendingUsers.Columns["FullName"].HeaderText = "Họ tên";
                if (dgvPendingUsers.Columns.Contains("Phone")) dgvPendingUsers.Columns["Phone"].HeaderText = "SĐT";
                if (dgvPendingUsers.Columns.Contains("Email")) dgvPendingUsers.Columns["Email"].HeaderText = "Email";
                if (dgvPendingUsers.Columns.Contains("Status")) dgvPendingUsers.Columns["Status"].HeaderText = "Trạng thái";

                dgvPendingUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPendingUsers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chờ duyệt:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDetailFields()
        {
            txtPendingId.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtStatus.Clear();
        }

        private int GetSelectedPendingUserId()
        {
            if (dgvPendingUsers.CurrentRow == null) return -1;
            if (dgvPendingUsers.CurrentRow.Cells["Id"] == null || dgvPendingUsers.CurrentRow.Cells["Id"].Value == null) return -1;
            return Convert.ToInt32(dgvPendingUsers.CurrentRow.Cells["Id"].Value);
        }

        private void FillDetailFieldsFromGrid()
        {
            if (dgvPendingUsers.CurrentRow == null) return;

            txtPendingId.Text = dgvPendingUsers.CurrentRow.Cells["Id"]?.Value?.ToString() ?? string.Empty;
            txtUsername.Text = dgvPendingUsers.CurrentRow.Cells["Username"]?.Value?.ToString() ?? string.Empty;
            txtPassword.Text = dgvPendingUsers.CurrentRow.Cells["Password"]?.Value?.ToString() ?? string.Empty;
            txtFullName.Text = dgvPendingUsers.CurrentRow.Cells["FullName"]?.Value?.ToString() ?? string.Empty;
            txtPhone.Text = dgvPendingUsers.CurrentRow.Cells["Phone"]?.Value?.ToString() ?? string.Empty;
            txtEmail.Text = dgvPendingUsers.CurrentRow.Cells["Email"]?.Value?.ToString() ?? string.Empty;
            txtStatus.Text = dgvPendingUsers.CurrentRow.Cells["Status"]?.Value?.ToString() ?? string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPendingUsers();
            ClearDetailFields();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboStatus.SelectedIndex = 0;
            LoadPendingUsers();
            ClearDetailFields();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;

            int id = GetSelectedPendingUserId();
            if (id == -1)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text.Trim();
            string currentStatus = txtStatus.Text.Trim();
            if (!currentStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Chỉ có thể duyệt tài khoản đang ở trạng thái Pending.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn duyệt tài khoản \"{username}\" không?",
                "Xác nhận duyệt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                isProcessing = true;
                btnApprove.Enabled = false;
                btnReject.Enabled = false;

                db.ExecuteNonQuery("sp_ApprovePendingUser",
                    new SqlParameter[] { new SqlParameter("@PendingId", id) },
                    CommandType.StoredProcedure);

                MessageBox.Show("Duyệt tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPendingUsers();
                ClearDetailFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi duyệt tài khoản:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isProcessing = false;
                btnApprove.Enabled = true;
                btnReject.Enabled = true;
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;

            int id = GetSelectedPendingUserId();
            if (id == -1)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần từ chối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentStatus = txtStatus.Text.Trim();
            if (!currentStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Chỉ có thể từ chối tài khoản đang ở trạng thái Pending.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn từ chối tài khoản này không?",
                "Xác nhận từ chối",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                isProcessing = true;
                btnApprove.Enabled = false;
                btnReject.Enabled = false;

                db.ExecuteNonQuery("sp_RejectPendingUser",
                    new SqlParameter[] { new SqlParameter("@PendingId", id) },
                    CommandType.StoredProcedure);

                MessageBox.Show("Đã từ chối tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPendingUsers();
                ClearDetailFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi từ chối tài khoản:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isProcessing = false;
                btnApprove.Enabled = true;
                btnReject.Enabled = true;
            }
        }

        private void dgvPendingUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            FillDetailFieldsFromGrid();
        }
    }
}
