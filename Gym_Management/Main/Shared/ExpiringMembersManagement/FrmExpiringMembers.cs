using Gym_Management.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class FrmExpiringMembers : Form
    {
        private readonly DBHelper _db = new DBHelper();

        public FrmExpiringMembers()
        {
            InitializeComponent();
        }

        private void FrmExpiringMembers_Load(object sender, EventArgs e)
        {
            SetupUi();
            numDays.Value = 7;
            LoadExpiringMembers((int)numDays.Value);
        }

        private void SetupUi()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);

            panelHeader.BackColor = Color.White;
            panelFilter.BackColor = Color.White;
            panelGrid.BackColor = Color.White;

            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblSubTitle.ForeColor = Color.DimGray;
            lblTotal.ForeColor = Color.FromArgb(0, 102, 204);

            dgvExpiringMembers.BorderStyle = BorderStyle.None;
            dgvExpiringMembers.BackgroundColor = Color.White;
            dgvExpiringMembers.EnableHeadersVisualStyles = false;
            dgvExpiringMembers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvExpiringMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 40, 49);
            dgvExpiringMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvExpiringMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvExpiringMembers.ColumnHeadersHeight = 38;

            dgvExpiringMembers.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvExpiringMembers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dgvExpiringMembers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvExpiringMembers.RowTemplate.Height = 34;
            dgvExpiringMembers.RowHeadersVisible = false;
            dgvExpiringMembers.GridColor = Color.Gainsboro;

            btnRefresh.BackColor = Color.FromArgb(0, 123, 255);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;

            btnRenew.BackColor = Color.FromArgb(40, 167, 69);
            btnRenew.ForeColor = Color.White;
            btnRenew.FlatStyle = FlatStyle.Flat;
            btnRenew.FlatAppearance.BorderSize = 0;
        }

        private void LoadExpiringMembers(int days)
        {
            try
            {
                string query = @"
SELECT
    c.CustomerId,
    c.FullName,
    c.Phone,
    p.Name AS PackageName,
    m.MembershipId,
    m.StartDate,
    m.EndDate,
    DATEDIFF(DAY, CAST(GETDATE() AS DATE), m.EndDate) AS DaysLeft,
    m.Status
FROM Customers c
INNER JOIN Memberships m ON c.CustomerId = m.CustomerId
INNER JOIN Packages p ON m.PackageId = p.PackageId
WHERE
    m.Status = 'Active'
    AND m.EndDate >= CAST(GETDATE() AS DATE)
    AND DATEDIFF(DAY, CAST(GETDATE() AS DATE), m.EndDate) <= @Days
ORDER BY m.EndDate ASC, c.FullName ASC;";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Days", SqlDbType.Int) { Value = days }
                };

                DataTable dt = _db.ExecuteQuery(query, parameters);

                dgvExpiringMembers.DataSource = dt;

                FormatGrid();
                ColorRows();

                lblTotal.Text = "Tổng: " + dt.Rows.Count + " hội viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void FormatGrid()
        {
            if (dgvExpiringMembers.Columns.Count == 0)
                return;

            dgvExpiringMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpiringMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpiringMembers.MultiSelect = false;
            dgvExpiringMembers.ReadOnly = true;
            dgvExpiringMembers.AllowUserToAddRows = false;
            dgvExpiringMembers.AllowUserToDeleteRows = false;
            dgvExpiringMembers.AllowUserToResizeRows = false;

            dgvExpiringMembers.Columns["CustomerId"].HeaderText = "Mã KH";
            dgvExpiringMembers.Columns["FullName"].HeaderText = "Họ tên";
            dgvExpiringMembers.Columns["Phone"].HeaderText = "Số điện thoại";
            dgvExpiringMembers.Columns["PackageName"].HeaderText = "Gói tập";
            dgvExpiringMembers.Columns["MembershipId"].HeaderText = "Mã gói";
            dgvExpiringMembers.Columns["StartDate"].HeaderText = "Bắt đầu";
            dgvExpiringMembers.Columns["EndDate"].HeaderText = "Hết hạn";
            dgvExpiringMembers.Columns["DaysLeft"].HeaderText = "Còn lại";
            dgvExpiringMembers.Columns["Status"].HeaderText = "Trạng thái";

            dgvExpiringMembers.Columns["CustomerId"].FillWeight = 60;
            dgvExpiringMembers.Columns["FullName"].FillWeight = 150;
            dgvExpiringMembers.Columns["Phone"].FillWeight = 100;
            dgvExpiringMembers.Columns["PackageName"].FillWeight = 120;
            dgvExpiringMembers.Columns["MembershipId"].FillWeight = 70;
            dgvExpiringMembers.Columns["StartDate"].FillWeight = 85;
            dgvExpiringMembers.Columns["EndDate"].FillWeight = 85;
            dgvExpiringMembers.Columns["DaysLeft"].FillWeight = 65;
            dgvExpiringMembers.Columns["Status"].FillWeight = 80;

            dgvExpiringMembers.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvExpiringMembers.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvExpiringMembers.Columns["CustomerId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExpiringMembers.Columns["MembershipId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExpiringMembers.Columns["DaysLeft"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExpiringMembers.Columns["StartDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExpiringMembers.Columns["EndDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExpiringMembers.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ColorRows()
        {
            foreach (DataGridViewRow row in dgvExpiringMembers.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["DaysLeft"].Value == null) continue;

                int daysLeft;
                if (!int.TryParse(row.Cells["DaysLeft"].Value.ToString(), out daysLeft))
                    continue;

                if (daysLeft <= 3)
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                    row.DefaultCellStyle.SelectionBackColor = Color.IndianRed;
                }
                else if (daysLeft <= 7)
                {
                    row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                    row.DefaultCellStyle.SelectionBackColor = Color.Goldenrod;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadExpiringMembers((int)numDays.Value);
        }

        private void numDays_ValueChanged(object sender, EventArgs e)
        {
            LoadExpiringMembers((int)numDays.Value);
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (dgvExpiringMembers.CurrentRow == null || dgvExpiringMembers.CurrentRow.IsNewRow)
            {
                MessageBox.Show(
                    "Vui lòng chọn hội viên cần gia hạn.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            int customerId = Convert.ToInt32(dgvExpiringMembers.CurrentRow.Cells["CustomerId"].Value);
            int membershipId = Convert.ToInt32(dgvExpiringMembers.CurrentRow.Cells["MembershipId"].Value);
            string fullName = dgvExpiringMembers.CurrentRow.Cells["FullName"].Value.ToString();

            MessageBox.Show(
                "Bạn đã chọn gia hạn cho:\n" +
                "- Họ tên: " + fullName + "\n" +
                "- CustomerId: " + customerId + "\n" +
                "- MembershipId: " + membershipId,
                "Gia hạn",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void dgvExpiringMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnRenew_Click(sender, e);
            }
        }
    }
}