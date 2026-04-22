using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Staff
{
    public partial class CheckinForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private int currentCustomerId = 0;
        private int currentMembershipId = 0;

        public CheckinForm() : this("")
        {
        }

        public CheckinForm(string initialCardCode)
        {
            InitializeComponent();
            txtCardCode.Text = initialCardCode ?? "";
        }

        private void CheckinForm_Load(object sender, EventArgs e)
        {
            LoadTodayCheckins();
            ClearMemberInfo(false);

            if (!string.IsNullOrWhiteSpace(txtCardCode.Text))
                LoadMemberByCardCode();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadMemberByCardCode();
        }

        private void txtCardCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnFind.PerformClick();
            }
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCardCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã thẻ hội viên.");
                txtCardCode.Focus();
                return;
            }

            try
            {
                SqlParameter[] pr =
                {
                    new SqlParameter("@CardCode", txtCardCode.Text.Trim())
                };

                object result = db.ExecuteScalar("sp_CheckinMember", pr, CommandType.StoredProcedure);

                int newCheckinId = 0;
                if (result != null && result != DBNull.Value)
                    int.TryParse(result.ToString(), out newCheckinId);

                MessageBox.Show(
                    newCheckinId > 0 ? "Check-in thành công." : "Check-in thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadMemberByCardCode();
                LoadTodayCheckins();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi check-in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCardCode.Clear();
            txtCardCode.Focus();
            ClearMemberInfo(true);
        }

        private void LoadMemberByCardCode()
        {
            string cardCode = txtCardCode.Text.Trim();

            if (string.IsNullOrWhiteSpace(cardCode))
            {
                MessageBox.Show("Vui lòng nhập mã thẻ hội viên.");
                txtCardCode.Focus();
                return;
            }

            string sql = @"
                SELECT TOP 1
                    c.CustomerId,
                    c.FullName,
                    c.Phone,
                    c.Address,
                    mp.Avatar,
                    mp.CardCode,
                    m.MembershipId,
                    p.Name AS PackageName,
                    m.StartDate,
                    m.EndDate,
                    m.Status,
                    CASE 
                        WHEN m.MembershipId IS NULL THEN N'Chưa đăng ký gói'
                        WHEN m.Status <> 'Active' THEN N'Không đủ điều kiện check-in'
                        WHEN CAST(GETDATE() AS DATE) < m.StartDate THEN N'Gói chưa đến ngày hiệu lực'
                        WHEN CAST(GETDATE() AS DATE) > m.EndDate THEN N'Gói đã hết hạn'
                        ELSE N'Có thể check-in'
                    END AS CheckinNote
                FROM MemberProfiles mp
                JOIN Customers c ON c.CustomerId = mp.CustomerId
                OUTER APPLY
                (
                    SELECT TOP 1 m1.*
                    FROM Memberships m1
                    WHERE m1.CustomerId = c.CustomerId
                    ORDER BY
                        CASE
                            WHEN m1.Status = 'Active'
                                 AND CAST(GETDATE() AS DATE) BETWEEN m1.StartDate AND m1.EndDate THEN 0
                            WHEN m1.Status = 'Pending' THEN 1
                            WHEN m1.Status = 'Active' THEN 2
                            ELSE 3
                        END,
                        m1.EndDate DESC,
                        m1.MembershipId DESC
                ) m
                LEFT JOIN Packages p ON p.PackageId = m.PackageId
                WHERE mp.CardCode = @CardCode";

            DataTable dt = db.ExecuteQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@CardCode", cardCode)
            });

            if (dt.Rows.Count == 0)
            {
                ClearMemberInfo(false);
                MessageBox.Show("Không tìm thấy hội viên với mã thẻ này.");
                txtCardCode.Focus();
                txtCardCode.SelectAll();
                return;
            }

            DataRow r = dt.Rows[0];

            currentCustomerId = ToInt(r["CustomerId"]);
            currentMembershipId = ToInt(r["MembershipId"]);

            lblMemberName.Text = "Họ tên: " + SafeText(r["FullName"]);
            lblPhone.Text = "SĐT: " + SafeText(r["Phone"]);
            lblCardCode.Text = "Mã thẻ: " + SafeText(r["CardCode"]);
            lblPackage.Text = "Gói hiện tại: " + SafeText(r["PackageName"]);
            lblDateRange.Text = "Hiệu lực: " + FormatDate(r["StartDate"]) + " - " + FormatDate(r["EndDate"]);
            lblMembershipStatus.Text = "Trạng thái gói: " + SafeText(r["Status"]);
            lblCheckinNote.Text = "Ghi chú: " + SafeText(r["CheckinNote"]);

            bool canCheckin =
                currentMembershipId > 0 &&
                string.Equals(SafeText(r["Status"]), "Active", StringComparison.OrdinalIgnoreCase) &&
                IsCurrentDateInRange(r["StartDate"], r["EndDate"]);

            btnCheckin.Enabled = canCheckin;
            lblCheckinNote.ForeColor = canCheckin ? Color.DarkGreen : Color.Firebrick;

            LoadAvatar(SafeText(r["Avatar"]));
        }

        private void LoadTodayCheckins()
        {
            string sql = @"
                SELECT
                    ci.CheckinId AS [Mã check-in],
                    c.FullName AS [Họ tên],
                    mp.CardCode AS [Mã thẻ],
                    p.Name AS [Gói],
                    ci.CheckinTime AS [Thời gian]
                FROM Checkins ci
                JOIN Customers c ON c.CustomerId = ci.CustomerId
                LEFT JOIN MemberProfiles mp ON mp.CustomerId = c.CustomerId
                LEFT JOIN Memberships m ON m.MembershipId = ci.MembershipId
                LEFT JOIN Packages p ON p.PackageId = m.PackageId
                WHERE CAST(ci.CheckinTime AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY ci.CheckinTime DESC";

            dgvTodayCheckins.DataSource = db.ExecuteQuery(sql);
            StyleGrid(dgvTodayCheckins);
        }

        private void ClearMemberInfo(bool clearCardInput)
        {
            currentCustomerId = 0;
            currentMembershipId = 0;

            if (clearCardInput)
                txtCardCode.Clear();

            lblMemberName.Text = "Họ tên:";
            lblPhone.Text = "SĐT:";
            lblCardCode.Text = "Mã thẻ:";
            lblPackage.Text = "Gói hiện tại:";
            lblDateRange.Text = "Hiệu lực:";
            lblMembershipStatus.Text = "Trạng thái gói:";
            lblCheckinNote.Text = "Ghi chú:";
            lblCheckinNote.ForeColor = Color.Black;
            picAvatar.Image = null;
            btnCheckin.Enabled = false;
        }

        private void LoadAvatar(string avatar)
        {
            picAvatar.Image = null;

            if (string.IsNullOrWhiteSpace(avatar))
                return;

            string[] possiblePaths =
            {
                avatar,
                Path.Combine(Application.StartupPath, avatar),
                Path.Combine(Application.StartupPath, "images", avatar.Replace("/", "\\"))
            };

            foreach (string path in possiblePaths)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                        using (var temp = Image.FromStream(fs))
                        {
                            picAvatar.Image = new Bitmap(temp);
                        }
                        return;
                    }
                }
                catch
                {
                }
            }
        }

        private bool IsCurrentDateInRange(object startDateObj, object endDateObj)
        {
            if (startDateObj == DBNull.Value || endDateObj == DBNull.Value) return false;

            DateTime today = DateTime.Today;
            DateTime startDate = Convert.ToDateTime(startDateObj).Date;
            DateTime endDate = Convert.ToDateTime(endDateObj).Date;

            return today >= startDate && today <= endDate;
        }

        private string SafeText(object value)
        {
            return value == DBNull.Value || value == null ? "" : value.ToString();
        }

        private string FormatDate(object value)
        {
            if (value == DBNull.Value || value == null) return "";
            return Convert.ToDateTime(value).ToString("dd/MM/yyyy");
        }

        private int ToInt(object value)
        {
            if (value == DBNull.Value || value == null) return 0;
            int result;
            return int.TryParse(value.ToString(), out result) ? result : 0;
        }

        private void StyleGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.MultiSelect = false;
        }
    }
}
