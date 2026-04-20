using Gym_Management.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    public partial class frmManagingPT : Form
    {
        private static readonly Color CGreen = Color.FromArgb(34, 197, 94);
        private static readonly Color CAmber = Color.FromArgb(245, 158, 11);
        private static readonly Color CRed = Color.FromArgb(239, 68, 68);
        private static readonly Color CPurple = Color.FromArgb(139, 92, 246);
        private static readonly Color CBlue = Color.FromArgb(59, 130, 246);
        private static readonly Color CDark = Color.FromArgb(15, 23, 42);

        private readonly DBHelper _db = new DBHelper();

        public frmManagingPT()
        {
            InitializeComponent();
            AttachEvents();
            LoadData();
        }

        private void AttachEvents()
        {
            btnSearch.Click += delegate { LoadData(txtSearch.Text); };
            txtSearch.KeyDown += TxtSearch_KeyDown;
            btnRefresh.Click += delegate { txtSearch.Clear(); LoadData(); };
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnToggleStatus.Click += BtnToggle_Click;
            dgvPT.CellFormatting += DgvPT_CellFormatting;
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData(txtSearch.Text);
            }
        }

        private void DgvPT_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPT.Columns[e.ColumnIndex].HeaderText == "Trạng thái" && e.Value != null)
            {
                if (e.Value.ToString() == "Active")
                {
                    e.CellStyle.ForeColor = CGreen;
                    e.CellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = CRed;
                }
            }

            if (dgvPT.Columns[e.ColumnIndex].HeaderText == "Level" && e.Value != null)
            {
                switch (e.Value.ToString())
                {
                    case "Elite":
                        e.CellStyle.ForeColor = CPurple;
                        e.CellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        break;
                    case "Pro":
                        e.CellStyle.ForeColor = CBlue;
                        break;
                    case "Basic":
                        e.CellStyle.ForeColor = CAmber;
                        break;
                }
            }
        }

        private void LoadData()
        {
            LoadData(string.Empty);
        }

        private void LoadData(string search)
        {
            try
            {
                string sql = @"
                    SELECT t.TrainerId     AS [ID],
                           t.Name          AS [Họ và tên],
                           t.Phone         AS [Số ĐT],
                           t.Email         AS [Email],
                           t.Specialty     AS [Chuyên môn],
                           t.Experience    AS [KN (năm)],
                           tl.Name         AS [Level],
                           t.SalaryPercent AS [Hoa hồng %],
                           t.Status        AS [Trạng thái],
                           (SELECT COUNT(*) FROM Memberships m
                            WHERE m.TrainerId = t.TrainerId
                              AND m.Status='Active' AND m.EndDate > GETDATE()) AS [HV hiện tại]
                    FROM Trainers t
                    LEFT JOIN TrainerLevels tl ON t.LevelId = tl.LevelId";

                SqlParameter[] parameters = null;
                if (!string.IsNullOrWhiteSpace(search))
                {
                    sql += " WHERE t.Name LIKE @s OR t.Specialty LIKE @s OR t.Email LIKE @s OR t.Phone LIKE @s";
                    parameters = new SqlParameter[] { new SqlParameter("@s", "%" + search + "%") };
                }
                sql += " ORDER BY t.TrainerId DESC";

                dgvPT.DataSource = _db.ExecuteQuery(sql, parameters);
                SetStatus("Hiển thị " + dgvPT.Rows.Count + " huấn luyện viên.");
                UpdateStats();
            }
            catch (Exception ex)
            {
                SetStatus("Lỗi: " + ex.Message);
            }
        }

        private void UpdateStats()
        {
            try
            {
                object total = _db.ExecuteScalar("SELECT COUNT(*) FROM Trainers");
                object active = _db.ExecuteScalar("SELECT COUNT(*) FROM Trainers WHERE Status='Active'");
                object elite = _db.ExecuteScalar("SELECT COUNT(*) FROM Trainers t JOIN TrainerLevels tl ON t.LevelId=tl.LevelId WHERE tl.Name='Elite'");
                object clients = _db.ExecuteScalar("SELECT COUNT(*) FROM Memberships WHERE TrainerId IS NOT NULL AND Status='Active' AND EndDate>GETDATE()");

                lblStatTotalVal.Text = total == null ? "0" : total.ToString();
                lblStatActiveVal.Text = active == null ? "0" : active.ToString();
                lblStatEliteVal.Text = elite == null ? "0" : elite.ToString();
                lblStatClientsVal.Text = clients == null ? "0" : clients.ToString();
            }
            catch
            {
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (PTEditDialog dialog = new PTEditDialog("Thêm huấn luyện viên", null, _db))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    SetStatus("Đã thêm PT mới.");
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id < 0)
            {
                return;
            }

            DataTable dt = _db.ExecuteQuery("SELECT * FROM Trainers WHERE TrainerId=@id", new SqlParameter[] { new SqlParameter("@id", id) });
            if (dt.Rows.Count == 0)
            {
                return;
            }

            using (PTEditDialog dialog = new PTEditDialog("Sửa huấn luyện viên", dt.Rows[0], _db))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    SetStatus("Đã cập nhật.");
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id < 0)
            {
                return;
            }

            int active = Convert.ToInt32(_db.ExecuteScalar(
                "SELECT COUNT(*) FROM Memberships WHERE TrainerId=@id AND Status='Active' AND EndDate>GETDATE()",
                new SqlParameter[] { new SqlParameter("@id", id) }));

            if (active > 0)
            {
                MessageBox.Show("PT đang có " + active + " học viên hoạt động. Hãy đổi trạng thái thay vì xóa.", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xác nhận xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _db.ExecuteNonQuery("DELETE FROM Trainers WHERE TrainerId=@id", new SqlParameter[] { new SqlParameter("@id", id) });
                LoadData();
                SetStatus("Đã xóa.");
            }
            catch (Exception ex)
            {
                SetStatus("Lỗi: " + ex.Message);
            }
        }

        private void BtnToggle_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id < 0)
            {
                return;
            }

            DataTable dt = _db.ExecuteQuery("SELECT Status,Name FROM Trainers WHERE TrainerId=@id", new SqlParameter[] { new SqlParameter("@id", id) });
            if (dt.Rows.Count == 0)
            {
                return;
            }

            string currentStatus = dt.Rows[0]["Status"].ToString();
            string nextStatus = currentStatus == "Active" ? "Inactive" : "Active";
            string trainerName = dt.Rows[0]["Name"].ToString();

            if (MessageBox.Show("Đổi \"" + trainerName + "\" -> " + nextStatus + "?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _db.ExecuteNonQuery(
                    "UPDATE Trainers SET Status=@s WHERE TrainerId=@id",
                    new SqlParameter[]
                    {
                        new SqlParameter("@s", nextStatus),
                        new SqlParameter("@id", id)
                    });
                LoadData();
                SetStatus("Đã đổi trạng thái.");
            }
            catch (Exception ex)
            {
                SetStatus("Lỗi: " + ex.Message);
            }
        }

        private int GetSelectedId()
        {
            if (dgvPT.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một PT.", "Chưa chọn");
                return -1;
            }

            return Convert.ToInt32(dgvPT.SelectedRows[0].Cells["ID"].Value);
        }

        private void SetStatus(string message)
        {
            lblStatus.Text = "  " + DateTime.Now.ToString("HH:mm:ss") + "  —  " + message;
        }
    }

    internal class PTEditDialog : Form
    {
        private readonly DBHelper _db;
        private readonly DataRow _row;
        private int _ptId = -1;

        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtSpecialty;
        private NumericUpDown nudExp;
        private NumericUpDown nudSal;
        private ComboBox cboLevel;
        private ComboBox cboStatus;
        private Label lblError;

        private static readonly Color CBlue = Color.FromArgb(59, 130, 246);
        private static readonly Color CRed = Color.FromArgb(239, 68, 68);
        private static readonly Color CDark = Color.FromArgb(15, 23, 42);
        private static readonly Color CLightBg = Color.FromArgb(248, 250, 252);

        public PTEditDialog(string title, DataRow row, DBHelper db)
        {
            _db = db;
            _row = row;
            BuildUI(title);
            if (row != null)
            {
                PopulateFields();
            }
        }

        private void BuildUI(string title)
        {
            Font inputFont = new Font("Segoe UI", 10.5F);
            Font labelFont = new Font("Segoe UI", 8.5F, FontStyle.Bold);

            Text = title;
            Size = new Size(530, 560);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = CLightBg;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            Panel topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 56;
            topPanel.BackColor = CDark;
            topPanel.Padding = new Padding(20, 10, 10, 10);
            topPanel.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill
            });

            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Padding = new Padding(25, 12, 25, 8);
            contentPanel.BackColor = CLightBg;
            contentPanel.AutoScroll = true;

            int y = 8;
            AddField(contentPanel, labelFont, inputFont, "HỌ VÀ TÊN *", ref y, out txtName);
            AddField(contentPanel, labelFont, inputFont, "SỐ ĐIỆN THOẠI", ref y, out txtPhone);
            AddField(contentPanel, labelFont, inputFont, "EMAIL", ref y, out txtEmail);
            AddField(contentPanel, labelFont, inputFont, "CHUYÊN MÔN (VD: Giảm cân)", ref y, out txtSpecialty);

            contentPanel.Controls.Add(MakeLabel("KINH NGHIỆM (NĂM)", labelFont, y));
            nudExp = new NumericUpDown();
            nudExp.Font = inputFont;
            nudExp.Minimum = 0;
            nudExp.Maximum = 50;
            nudExp.Location = new Point(0, y + 22);
            nudExp.Size = new Size(480, 34);
            contentPanel.Controls.Add(nudExp);
            y += 62;

            contentPanel.Controls.Add(MakeLabel("HOA HỒNG (%)", labelFont, y));
            nudSal = new NumericUpDown();
            nudSal.Font = inputFont;
            nudSal.Minimum = 0;
            nudSal.Maximum = 100;
            nudSal.Location = new Point(0, y + 22);
            nudSal.Size = new Size(480, 34);
            contentPanel.Controls.Add(nudSal);
            y += 62;

            contentPanel.Controls.Add(MakeLabel("TRẠNG THÁI", labelFont, y));
            cboStatus = new ComboBox();
            cboStatus.Font = inputFont;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Location = new Point(0, y + 22);
            cboStatus.Size = new Size(480, 34);
            cboStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            cboStatus.SelectedIndex = 0;
            contentPanel.Controls.Add(cboStatus);
            y += 62;

            contentPanel.Controls.Add(MakeLabel("CẤP ĐỘ (Level)", labelFont, y));
            cboLevel = new ComboBox();
            cboLevel.Font = inputFont;
            cboLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLevel.Location = new Point(0, y + 22);
            cboLevel.Size = new Size(480, 34);
            try
            {
                DataTable dt = _db.ExecuteQuery("SELECT LevelId, Name FROM TrainerLevels ORDER BY LevelId");
                cboLevel.DataSource = dt;
                cboLevel.DisplayMember = "Name";
                cboLevel.ValueMember = "LevelId";
            }
            catch
            {
                cboLevel.Items.Add("(lỗi)");
            }
            contentPanel.Controls.Add(cboLevel);
            y += 62;

            lblError = new Label();
            lblError.Location = new Point(0, y);
            lblError.Size = new Size(480, 20);
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = CRed;
            contentPanel.Controls.Add(lblError);

            Panel bottomPanel = new Panel();
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Height = 60;
            bottomPanel.BackColor = Color.White;
            bottomPanel.Padding = new Padding(20, 12, 20, 12);

            Button btnCancel = new Button();
            btnCancel.Text = "Hủy";
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.BackColor = CRed;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Dock = DockStyle.Right;
            btnCancel.Width = 100;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += delegate { DialogResult = DialogResult.Cancel; Close(); };

            Button btnSave = new Button();
            btnSave.Text = "💾  Lưu";
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.BackColor = CBlue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Dock = DockStyle.Right;
            btnSave.Width = 120;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            bottomPanel.Controls.Add(btnCancel);
            bottomPanel.Controls.Add(btnSave);

            Controls.Add(contentPanel);
            Controls.Add(bottomPanel);
            Controls.Add(topPanel);
        }

        private void AddField(Panel parent, Font labelFont, Font inputFont, string labelText, ref int y, out TextBox textBox)
        {
            parent.Controls.Add(MakeLabel(labelText, labelFont, y));
            textBox = new TextBox();
            textBox.Font = inputFont;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Location = new Point(0, y + 22);
            textBox.Size = new Size(480, 34);
            parent.Controls.Add(textBox);
            y += 62;
        }

        private static Label MakeLabel(string text, Font font, int y)
        {
            return new Label
            {
                Text = text,
                Font = font,
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(0, y),
                Size = new Size(480, 20)
            };
        }

        private void PopulateFields()
        {
            _ptId = Convert.ToInt32(_row["TrainerId"]);
            txtName.Text = Convert.ToString(_row["Name"]);
            txtPhone.Text = _row["Phone"] == DBNull.Value ? string.Empty : Convert.ToString(_row["Phone"]);
            txtEmail.Text = _row["Email"] == DBNull.Value ? string.Empty : Convert.ToString(_row["Email"]);
            txtSpecialty.Text = _row["Specialty"] == DBNull.Value ? string.Empty : Convert.ToString(_row["Specialty"]);
            nudExp.Value = _row["Experience"] == DBNull.Value ? 0 : Convert.ToDecimal(_row["Experience"]);
            nudSal.Value = _row["SalaryPercent"] == DBNull.Value ? 0 : Convert.ToDecimal(_row["SalaryPercent"]);
            cboStatus.SelectedItem = _row["Status"] == DBNull.Value ? "Active" : Convert.ToString(_row["Status"]);

            if (_row["LevelId"] != DBNull.Value && cboLevel.DataSource is DataTable)
            {
                int levelId = Convert.ToInt32(_row["LevelId"]);
                DataTable dt = (DataTable)cboLevel.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["LevelId"]) == levelId)
                    {
                        cboLevel.SelectedValue = levelId;
                        break;
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblError.Text = "⚠  Nhập tên huấn luyện viên!";
                return;
            }

            try
            {
                object levelId = GetNullableSelectedValue(cboLevel);
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@n", txtName.Text.Trim()),
                    new SqlParameter("@ph", DBNullIfWhiteSpace(txtPhone.Text)),
                    new SqlParameter("@em", DBNullIfWhiteSpace(txtEmail.Text)),
                    new SqlParameter("@sp", DBNullIfWhiteSpace(txtSpecialty.Text)),
                    new SqlParameter("@ex", Convert.ToInt32(nudExp.Value)),
                    new SqlParameter("@sl", Convert.ToInt32(nudSal.Value)),
                    new SqlParameter("@st", cboStatus.SelectedItem == null ? "Active" : cboStatus.SelectedItem.ToString()),
                    new SqlParameter("@lv", levelId)
                };

                if (_row == null)
                {
                    _db.ExecuteNonQuery(
                        "INSERT INTO Trainers (Name,Phone,Email,Specialty,Experience,SalaryPercent,Status,LevelId) VALUES (@n,@ph,@em,@sp,@ex,@sl,@st,@lv)",
                        parameters);
                }
                else
                {
                    List<SqlParameter> list = new List<SqlParameter>(parameters);
                    list.Add(new SqlParameter("@id", _ptId));
                    _db.ExecuteNonQuery(
                        "UPDATE Trainers SET Name=@n,Phone=@ph,Email=@em,Specialty=@sp,Experience=@ex,SalaryPercent=@sl,Status=@st,LevelId=@lv WHERE TrainerId=@id",
                        list.ToArray());
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblError.Text = "⚠  " + ex.Message;
            }
        }

        private static object DBNullIfWhiteSpace(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value.Trim();
        }

        private static object GetNullableSelectedValue(ComboBox comboBox)
        {
            if (comboBox.SelectedValue == null || comboBox.SelectedValue == DBNull.Value)
            {
                return DBNull.Value;
            }

            int parsed;
            if (int.TryParse(comboBox.SelectedValue.ToString(), out parsed))
            {
                return parsed;
            }

            return DBNull.Value;
        }
    }
}
