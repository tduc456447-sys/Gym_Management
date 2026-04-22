using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Staff
{
    public partial class MembersForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int staffId;

        public MembersForm(int userId)
        {
            InitializeComponent();
            staffId = userId;
        }

        private void MembersForm_Load(object sender, EventArgs e)
        {
            LoadStatusFilter();
            LoadMembers();
            StyleGrid(dgvMembers);
        }

        private void LoadStatusFilter()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Tất cả");
            cboStatus.Items.Add("Chưa đăng ký");
            cboStatus.Items.Add("Active");
            cboStatus.Items.Add("Pending");
            cboStatus.Items.Add("Expired");
            cboStatus.Items.Add("Cancelled");
            cboStatus.SelectedIndex = 0;
        }

        private void LoadMembers()
        {
            string sql = @"
                SELECT 
                    c.CustomerId AS [Mã KH],
                    c.FullName AS [Họ tên],
                    c.Phone AS [SĐT],
                    ISNULL(mp.CardCode, '') AS [Mã thẻ],
                    ISNULL(p.Name, N'Chưa đăng ký') AS [Gói hiện tại],
                    m.StartDate AS [Bắt đầu],
                    m.EndDate AS [Kết thúc],
                    ISNULL(m.Status, N'Chưa đăng ký') AS [Trạng thái]
                FROM Customers c
                LEFT JOIN MemberProfiles mp ON c.CustomerId = mp.CustomerId
                LEFT JOIN
                (
                    SELECT m1.*
                    FROM Memberships m1
                    INNER JOIN
                    (
                        SELECT CustomerId, MAX(MembershipId) AS MaxMembershipId
                        FROM Memberships
                        GROUP BY CustomerId
                    ) x ON m1.MembershipId = x.MaxMembershipId
                ) m ON c.CustomerId = m.CustomerId
                LEFT JOIN Packages p ON m.PackageId = p.PackageId
                WHERE
                    (@Keyword = '' 
                     OR c.FullName LIKE N'%' + @Keyword + N'%'
                     OR c.Phone LIKE N'%' + @Keyword + N'%'
                     OR ISNULL(mp.CardCode,'') LIKE N'%' + @Keyword + N'%')
                  AND
                    (@Status = N'Tất cả' OR ISNULL(m.Status, N'Chưa đăng ký') = @Status)
                ORDER BY c.CustomerId DESC";

            SqlParameter[] pr =
            {
                new SqlParameter("@Keyword", txtSearch.Text.Trim()),
                new SqlParameter("@Status", cboStatus.Text)
            };

            dgvMembers.DataSource = db.ExecuteQuery(sql, pr);
            FormatGrid();
        }

        private void FormatGrid()
        {
            if (dgvMembers.Columns.Count == 0) return;

            if (dgvMembers.Columns.Contains("Mã KH"))
                dgvMembers.Columns["Mã KH"].Width = 70;

            if (dgvMembers.Columns.Contains("Họ tên"))
                dgvMembers.Columns["Họ tên"].Width = 180;

            if (dgvMembers.Columns.Contains("SĐT"))
                dgvMembers.Columns["SĐT"].Width = 110;

            if (dgvMembers.Columns.Contains("Mã thẻ"))
                dgvMembers.Columns["Mã thẻ"].Width = 110;

            if (dgvMembers.Columns.Contains("Trạng thái"))
                dgvMembers.Columns["Trạng thái"].Width = 100;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private int GetSelectedCustomerId()
        {
            if (dgvMembers.CurrentRow == null) return 0;
            if (dgvMembers.CurrentRow.Cells["Mã KH"].Value == null) return 0;
            return Convert.ToInt32(dgvMembers.CurrentRow.Cells["Mã KH"].Value);
        }

        private string GetSelectedCardCode()
        {
            if (dgvMembers.CurrentRow == null) return string.Empty;
            if (!dgvMembers.Columns.Contains("Mã thẻ")) return string.Empty;

            object value = dgvMembers.CurrentRow.Cells["Mã thẻ"].Value;
            return value == null ? string.Empty : value.ToString().Trim();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboStatus.SelectedIndex = 0;
            LoadMembers();
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId();
            if (customerId == 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên/khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MemberDetailForm f = new MemberDetailForm(customerId))
            {
                f.ShowDialog();
            }

            LoadMembers();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (RegisterMembershipForm f = new RegisterMembershipForm(staffId))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadMembers();
            }
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId();
            if (customerId == 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần gia hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (RenewMembershipForm f = new RenewMembershipForm(staffId, customerId))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadMembers();
            }
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            string cardCode = GetSelectedCardCode();

            using (CheckinForm f = string.IsNullOrWhiteSpace(cardCode)
                ? new CheckinForm()
                : new CheckinForm(cardCode))
            {
                f.ShowDialog();
            }

            LoadMembers();
        }

        private void dgvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnViewDetail.PerformClick();
        }

        private void StyleGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
