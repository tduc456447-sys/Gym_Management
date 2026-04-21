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
                    mp.CardCode AS [Mã thẻ],
                    p.Name AS [Gói hiện tại],
                    m.StartDate AS [Bắt đầu],
                    m.EndDate AS [Kết thúc],
                    m.Status AS [Trạng thái]
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
            return Convert.ToInt32(dgvMembers.CurrentRow.Cells["Mã KH"].Value);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId();
            if (customerId == 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên/khách hàng.");
                return;
            }

            using (MemberDetailForm f = new MemberDetailForm(customerId))
            {
                f.ShowDialog();
            }
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
                MessageBox.Show("Vui lòng chọn hội viên cần gia hạn.");
                return;
            }

            using (RenewMembershipForm f = new RenewMembershipForm(staffId, customerId))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadMembers();
            }
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
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}