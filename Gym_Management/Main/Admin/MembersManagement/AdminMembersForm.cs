using Gym_Management.Data;
using Gym_Management.Main.Staff;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin
{
    public partial class AdminMembersForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int _userId;
        private readonly string _fullName;

        public AdminMembersForm(int userId, string fullName)
        {
            InitializeComponent();
            _userId = userId;
            _fullName = fullName;
        }

        private void AdminMembersForm_Load(object sender, EventArgs e)
        {
            lblAdmin.Text = "Admin: " + _fullName;
            LoadFilters();
            SetupGrid();
            LoadMembers();
        }

        private void LoadFilters()
        {
            cboProfileStatus.Items.Clear();
            cboProfileStatus.Items.Add("Tất cả");
            cboProfileStatus.Items.Add("Chưa có hồ sơ");
            cboProfileStatus.Items.Add("Active");
            cboProfileStatus.Items.Add("Inactive");
            cboProfileStatus.Items.Add("Blocked");
            cboProfileStatus.SelectedIndex = 0;

            cboMembershipStatus.Items.Clear();
            cboMembershipStatus.Items.Add("Tất cả");
            cboMembershipStatus.Items.Add("Chưa đăng ký");
            cboMembershipStatus.Items.Add("Pending");
            cboMembershipStatus.Items.Add("Active");
            cboMembershipStatus.Items.Add("Expired");
            cboMembershipStatus.Items.Add("Cancelled");
            cboMembershipStatus.SelectedIndex = 0;
        }

        private void SetupGrid()
        {
            dgvMembers.ReadOnly = true;
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.AllowUserToDeleteRows = false;
            dgvMembers.AllowUserToResizeRows = false;
            dgvMembers.MultiSelect = false;
            dgvMembers.RowHeadersVisible = false;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.AutoGenerateColumns = false;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvMembers.BackgroundColor = Color.White;
            dgvMembers.BorderStyle = BorderStyle.None;
            dgvMembers.GridColor = Color.FromArgb(230, 230, 230);
            dgvMembers.EnableHeadersVisualStyles = false;
            dgvMembers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 47, 62);
            dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvMembers.ColumnHeadersHeight = 36;
            dgvMembers.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvMembers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(223, 236, 255);
            dgvMembers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvMembers.DefaultCellStyle.BackColor = Color.White;
            dgvMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvMembers.RowTemplate.Height = 34;
            dgvMembers.Columns.Clear();

            AddTextColumn("CustomerId", "Mã HV", "CustomerId", 75);
            AddTextColumn("FullName", "Họ tên", "FullName", 180);
            AddTextColumn("Phone", "SĐT", "Phone", 110);
            AddTextColumn("PackageName", "Gói hiện tại", "PackageName", 180);
            AddTextColumn("EndDateText", "Hết hạn", "EndDateText", 95);
            AddTextColumn("MembershipStatus", "Trạng thái gói", "MembershipStatus", 110);
            AddTextColumn("ProfileStatus", "Hồ sơ", "ProfileStatus", 90);
        }

        private void AddTextColumn(string name, string headerText, string dataPropertyName, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.HeaderText = headerText;
            col.DataPropertyName = dataPropertyName;
            col.Width = width;
            col.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvMembers.Columns.Add(col);
        }

        private void LoadMembers()
        {
            try
            {
                string sql = @"
SELECT
    c.CustomerId,
    c.FullName,
    ISNULL(c.Phone, '') AS Phone,
    ISNULL(c.Address, '') AS Address,
    ISNULL(mp.CardCode, '') AS CardCode,
    ISNULL(mp.IdentityNumber, '') AS IdentityNumber,
    ISNULL(mp.Status, N'Chưa có hồ sơ') AS ProfileStatus,
    ISNULL(cur.PackageName, N'Chưa đăng ký') AS PackageName,
    cur.StartDate,
    cur.EndDate,
    CONVERT(NVARCHAR(10), cur.EndDate, 103) AS EndDateText,
    ISNULL(cur.MembershipStatus, N'Chưa đăng ký') AS MembershipStatus,
    ISNULL(cur.TrainerName, '') AS TrainerName,
    lastCheckin.LastCheckinTime
FROM Customers c
LEFT JOIN MemberProfiles mp ON c.CustomerId = mp.CustomerId
OUTER APPLY
(
    SELECT TOP 1
        p.Name AS PackageName,
        m.StartDate,
        m.EndDate,
        m.Status AS MembershipStatus,
        t.Name AS TrainerName
    FROM Memberships m
    INNER JOIN Packages p ON m.PackageId = p.PackageId
    LEFT JOIN Trainers t ON m.TrainerId = t.TrainerId
    WHERE m.CustomerId = c.CustomerId
    ORDER BY m.MembershipId DESC
) cur
OUTER APPLY
(
    SELECT MAX(CheckinTime) AS LastCheckinTime
    FROM Checkins ck
    WHERE ck.CustomerId = c.CustomerId
) lastCheckin
WHERE
    (@Keyword = ''
     OR c.FullName LIKE N'%' + @Keyword + N'%'
     OR ISNULL(c.Phone,'') LIKE N'%' + @Keyword + N'%'
     OR ISNULL(mp.CardCode,'') LIKE N'%' + @Keyword + N'%'
     OR ISNULL(mp.IdentityNumber,'') LIKE N'%' + @Keyword + N'%')
AND
    (
        @ProfileStatus = N'Tất cả'
        OR (@ProfileStatus = N'Chưa có hồ sơ' AND mp.CustomerId IS NULL)
        OR ISNULL(mp.Status, N'') = @ProfileStatus
    )
AND
    (
        @MembershipStatus = N'Tất cả'
        OR (@MembershipStatus = N'Chưa đăng ký' AND cur.MembershipStatus IS NULL)
        OR ISNULL(cur.MembershipStatus, N'') = @MembershipStatus
    )
ORDER BY c.CustomerId DESC";

                SqlParameter[] pr =
                {
                    new SqlParameter("@Keyword", txtSearch.Text.Trim()),
                    new SqlParameter("@ProfileStatus", cboProfileStatus.Text),
                    new SqlParameter("@MembershipStatus", cboMembershipStatus.Text)
                };

                DataTable dt = db.ExecuteQuery(sql, pr);
                dgvMembers.DataSource = dt;
                UpdateSummary();
                LoadSelectedMemberDetails();
                ApplyGridStyling();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hội viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyGridStyling()
        {
            foreach (DataGridViewRow row in dgvMembers.Rows)
            {
                string membershipStatus = Convert.ToString(row.Cells["MembershipStatus"].Value);
                string profileStatus = Convert.ToString(row.Cells["ProfileStatus"].Value);

                if (membershipStatus == "Expired")
                    row.Cells["MembershipStatus"].Style.ForeColor = Color.Firebrick;
                else if (membershipStatus == "Active")
                    row.Cells["MembershipStatus"].Style.ForeColor = Color.SeaGreen;
                else if (membershipStatus == "Pending")
                    row.Cells["MembershipStatus"].Style.ForeColor = Color.DarkOrange;

                if (profileStatus == "Blocked")
                    row.Cells["ProfileStatus"].Style.ForeColor = Color.Firebrick;
                else if (profileStatus == "Active")
                    row.Cells["ProfileStatus"].Style.ForeColor = Color.SeaGreen;
            }
        }

        private void UpdateSummary()
        {
            try
            {
                object totalObj = db.ExecuteScalar("SELECT COUNT(*) FROM Customers");
                object profileObj = db.ExecuteScalar("SELECT COUNT(*) FROM MemberProfiles");
                object activeObj = db.ExecuteScalar("SELECT COUNT(*) FROM Memberships WHERE Status = 'Active' AND EndDate >= CAST(GETDATE() AS DATE)");
                object expiredObj = db.ExecuteScalar("SELECT COUNT(*) FROM Memberships WHERE EndDate < CAST(GETDATE() AS DATE) OR Status = 'Expired'");

                lblTotalMembersValue.Text = Convert.ToInt32(totalObj).ToString();
                lblProfilesValue.Text = Convert.ToInt32(profileObj).ToString();
                lblActiveMembershipsValue.Text = Convert.ToInt32(activeObj).ToString();
                lblExpiredMembershipsValue.Text = Convert.ToInt32(expiredObj).ToString();
            }
            catch
            {
                lblTotalMembersValue.Text = "0";
                lblProfilesValue.Text = "0";
                lblActiveMembershipsValue.Text = "0";
                lblExpiredMembershipsValue.Text = "0";
            }
        }

        private int GetSelectedCustomerId()
        {
            if (dgvMembers.CurrentRow == null) return 0;
            object value = dgvMembers.CurrentRow.Cells["CustomerId"].Value;
            if (value == null || value == DBNull.Value) return 0;
            return Convert.ToInt32(value);
        }

        private string GetSelectedCardCode()
        {
            if (dgvMembers.CurrentRow == null) return string.Empty;
            DataRowView row = dgvMembers.CurrentRow.DataBoundItem as DataRowView;
            if (row == null || !row.Row.Table.Columns.Contains("CardCode")) return string.Empty;
            return row["CardCode"] == DBNull.Value ? string.Empty : row["CardCode"].ToString().Trim();
        }

        private void LoadSelectedMemberDetails()
        {
            int customerId = GetSelectedCustomerId();
            if (customerId == 0)
            {
                ClearDetails();
                return;
            }

            try
            {
                string sql = @"
SELECT TOP 1
    c.CustomerId,
    c.FullName,
    c.Phone,
    c.Address,
    c.CreatedAt,
    mp.IdentityNumber,
    mp.CardCode,
    mp.JoinDate,
    mp.Status AS ProfileStatus,
    cur.PackageName,
    cur.StartDate,
    cur.EndDate,
    cur.MembershipStatus,
    cur.TrainerName,
    cur.Price,
    stats.TotalCheckins,
    stats.TotalMemberships,
    stats.LastCheckinTime
FROM Customers c
LEFT JOIN MemberProfiles mp ON c.CustomerId = mp.CustomerId
OUTER APPLY
(
    SELECT TOP 1
        p.Name AS PackageName,
        m.StartDate,
        m.EndDate,
        m.Status AS MembershipStatus,
        t.Name AS TrainerName,
        m.Price
    FROM Memberships m
    INNER JOIN Packages p ON m.PackageId = p.PackageId
    LEFT JOIN Trainers t ON m.TrainerId = t.TrainerId
    WHERE m.CustomerId = c.CustomerId
    ORDER BY m.MembershipId DESC
) cur
OUTER APPLY
(
    SELECT
        (SELECT COUNT(*) FROM Memberships WHERE CustomerId = c.CustomerId) AS TotalMemberships,
        (SELECT COUNT(*) FROM Checkins WHERE CustomerId = c.CustomerId) AS TotalCheckins,
        (SELECT MAX(CheckinTime) FROM Checkins WHERE CustomerId = c.CustomerId) AS LastCheckinTime
) stats
WHERE c.CustomerId = @CustomerId";

                DataTable dt = db.ExecuteQuery(sql, new SqlParameter[] { new SqlParameter("@CustomerId", customerId) });
                if (dt.Rows.Count == 0)
                {
                    ClearDetails();
                    return;
                }

                DataRow r = dt.Rows[0];
                lblCustomerIdValue.Text = customerId.ToString();
                lblFullNameValue.Text = GetRowString(r, "FullName");
                lblPhoneValue.Text = GetRowString(r, "Phone");
                lblAddressValue.Text = GetRowString(r, "Address");
                lblCardCodeValue.Text = GetRowString(r, "CardCode");
                lblIdentityValue.Text = GetRowString(r, "IdentityNumber");
                lblJoinDateValue.Text = FormatDate(r["JoinDate"]);
                lblProfileStatusValue.Text = GetRowString(r, "ProfileStatus", "Chưa có hồ sơ");
                lblCurrentPackageValue.Text = GetRowString(r, "PackageName", "Chưa đăng ký");
                lblMembershipStatusValue.Text = GetRowString(r, "MembershipStatus", "Chưa đăng ký");
                lblTrainerValue.Text = GetRowString(r, "TrainerName");
                lblStartDateValue.Text = FormatDate(r["StartDate"]);
                lblEndDateValue.Text = FormatDate(r["EndDate"]);
                lblPriceValue.Text = FormatMoney(r["Price"]);
                lblTotalMembershipCountValue.Text = GetRowInt(r, "TotalMemberships").ToString();
                lblTotalCheckinCountValue.Text = GetRowInt(r, "TotalCheckins").ToString();
                lblLastCheckinValue.Text = FormatDateTime(r["LastCheckinTime"]);
                lblCreatedAtValue.Text = FormatDateTime(r["CreatedAt"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết hội viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetRowString(DataRow row, string column, string defaultValue = "")
        {
            if (!row.Table.Columns.Contains(column)) return defaultValue;
            object value = row[column];
            return value == null || value == DBNull.Value ? defaultValue : value.ToString();
        }

        private int GetRowInt(DataRow row, string column)
        {
            if (!row.Table.Columns.Contains(column)) return 0;
            object value = row[column];
            if (value == null || value == DBNull.Value) return 0;
            int result;
            return int.TryParse(value.ToString(), out result) ? result : 0;
        }

        private string FormatDate(object value)
        {
            if (value == null || value == DBNull.Value) return "-";
            DateTime dt;
            return DateTime.TryParse(value.ToString(), out dt) ? dt.ToString("dd/MM/yyyy") : "-";
        }

        private string FormatDateTime(object value)
        {
            if (value == null || value == DBNull.Value) return "-";
            DateTime dt;
            return DateTime.TryParse(value.ToString(), out dt) ? dt.ToString("dd/MM/yyyy HH:mm") : "-";
        }

        private string FormatMoney(object value)
        {
            if (value == null || value == DBNull.Value) return "0 đ";
            decimal amount;
            return decimal.TryParse(value.ToString(), out amount) ? amount.ToString("N0") + " đ" : "0 đ";
        }

        private void ClearDetails()
        {
            lblCustomerIdValue.Text = "-";
            lblFullNameValue.Text = "-";
            lblPhoneValue.Text = "-";
            lblAddressValue.Text = "-";
            lblCardCodeValue.Text = "-";
            lblIdentityValue.Text = "-";
            lblJoinDateValue.Text = "-";
            lblProfileStatusValue.Text = "-";
            lblCurrentPackageValue.Text = "-";
            lblMembershipStatusValue.Text = "-";
            lblTrainerValue.Text = "-";
            lblStartDateValue.Text = "-";
            lblEndDateValue.Text = "-";
            lblPriceValue.Text = "-";
            lblTotalMembershipCountValue.Text = "0";
            lblTotalCheckinCountValue.Text = "0";
            lblLastCheckinValue.Text = "-";
            lblCreatedAtValue.Text = "-";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboProfileStatus.SelectedIndex = 0;
            cboMembershipStatus.SelectedIndex = 0;
            LoadMembers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadMembers();
            }
        }

        private void dgvMembers_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedMemberDetails();
        }

        private void dgvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnViewDetail.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AdminMemberEditForm f = new AdminMemberEditForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadMembers();
                    SelectCustomer(f.SavedCustomerId);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId();
            if (customerId == 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (AdminMemberEditForm f = new AdminMemberEditForm(customerId))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadMembers();
                    SelectCustomer(customerId);
                }
            }
        }

        private void SelectCustomer(int customerId)
        {
            foreach (DataGridViewRow row in dgvMembers.Rows)
            {
                if (row.Cells["CustomerId"].Value != null && Convert.ToInt32(row.Cells["CustomerId"].Value) == customerId)
                {
                    row.Selected = true;
                    dgvMembers.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId();
            if (customerId == 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Chỉ xóa được hội viên chưa phát sinh membership/check-in. Bạn có chắc muốn xóa không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                int membershipCount = Convert.ToInt32(db.ExecuteScalar(
                    "SELECT COUNT(*) FROM Memberships WHERE CustomerId = @CustomerId",
                    new SqlParameter[] { new SqlParameter("@CustomerId", customerId) }));

                int checkinCount = Convert.ToInt32(db.ExecuteScalar(
                    "SELECT COUNT(*) FROM Checkins WHERE CustomerId = @CustomerId",
                    new SqlParameter[] { new SqlParameter("@CustomerId", customerId) }));

                if (membershipCount > 0 || checkinCount > 0)
                {
                    MessageBox.Show("Hội viên đã phát sinh dữ liệu membership/check-in nên không thể xóa cứng.", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.ExecuteNonQuery("DELETE FROM MemberProfiles WHERE CustomerId = @CustomerId", new SqlParameter[] { new SqlParameter("@CustomerId", customerId) });
                db.ExecuteNonQuery("DELETE FROM Customers WHERE CustomerId = @CustomerId", new SqlParameter[] { new SqlParameter("@CustomerId", customerId) });

                MessageBox.Show("Xóa hội viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa hội viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId();
            if (customerId == 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                object currentObj = db.ExecuteScalar(
                    "SELECT Status FROM MemberProfiles WHERE CustomerId = @CustomerId",
                    new SqlParameter[] { new SqlParameter("@CustomerId", customerId) });

                if (currentObj == null || currentObj == DBNull.Value)
                {
                    MessageBox.Show("Hội viên này chưa có hồ sơ MemberProfiles. Hãy vào Sửa để tạo hồ sơ trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string currentStatus = currentObj.ToString();
                string nextStatus = currentStatus == "Blocked" ? "Active" : "Blocked";

                db.ExecuteNonQuery(
                    "UPDATE MemberProfiles SET Status = @Status WHERE CustomerId = @CustomerId",
                    new SqlParameter[]
                    {
                        new SqlParameter("@Status", nextStatus),
                        new SqlParameter("@CustomerId", customerId)
                    });

                MessageBox.Show("Đã cập nhật trạng thái hồ sơ sang: " + nextStatus, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembers();
                SelectCustomer(customerId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật trạng thái: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId();
            if (customerId == 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MemberDetailForm f = new MemberDetailForm(customerId))
            {
                f.ShowDialog();
            }

            LoadMembers();
            SelectCustomer(customerId);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (RegisterMembershipForm f = new RegisterMembershipForm(_userId))
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

            using (RenewMembershipForm f = new RenewMembershipForm(_userId, customerId))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadMembers();
            }

            SelectCustomer(customerId);
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            string cardCode = GetSelectedCardCode();
            using (CheckinForm f = string.IsNullOrWhiteSpace(cardCode) ? new CheckinForm() : new CheckinForm(cardCode))
            {
                f.ShowDialog();
            }

            LoadMembers();
        }
    }
}
