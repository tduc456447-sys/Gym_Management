using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Gym_Management.Data;

namespace Gym_Management.Main.Staff
{
    public partial class ShiftCalendarForm : Form
    {
        private readonly DBHelper db = new DBHelper();
        private readonly int userId;
        private DateTime currentWeekStart;

        public ShiftCalendarForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void ShiftCalendarForm_Load(object sender, EventArgs e)
        {
            cboWeek.SelectedIndex = 0;
            currentWeekStart = GetStartOfWeek(DateTime.Today);
            LoadCalendar();
            CheckReminder();
        }

        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-diff).Date;
        }

        private void LoadCalendar()
        {
            flowWeek.Controls.Clear();

            DateTime start = currentWeekStart;

            if (cboWeek.Text == "Tuần sau")
                start = currentWeekStart.AddDays(7);

            for (int i = 0; i < 7; i++)
            {
                DateTime date = start.AddDays(i);

                ucDayShift uc = new ucDayShift();
                uc.Width = 160;
                uc.Height = 360;
                uc.SetDate(date, date.Date == DateTime.Today);
                uc.ShiftClicked += Uc_ShiftClicked;

                LoadShiftsForDay(uc, date);
                flowWeek.Controls.Add(uc);
            }
        }

        private void LoadShiftsForDay(ucDayShift uc, DateTime date)
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT 
                    ws.ShiftId,
                    ws.Name,
                    CONVERT(VARCHAR(5), ws.StartTime, 108) AS StartTime,
                    CONVERT(VARCHAR(5), ws.EndTime, 108) AS EndTime,
                    ws.MaxStaff,
                    COUNT(us.Id) AS CurrentStaff,
                    SUM(CASE WHEN us.UserId = @UserId THEN 1 ELSE 0 END) AS IsMine
                FROM WorkShifts ws
                LEFT JOIN UserShifts us
                    ON ws.ShiftId = us.ShiftId
                   AND us.WorkDate = @WorkDate
                GROUP BY ws.ShiftId, ws.Name, ws.StartTime, ws.EndTime, ws.MaxStaff
                ORDER BY ws.StartTime",
                new SqlParameter[]
                {
                    new SqlParameter("@UserId", userId),
                    new SqlParameter("@WorkDate", date.Date)
                });

            uc.ClearShifts();

            foreach (DataRow row in dt.Rows)
            {
                uc.AddShift(
                    Convert.ToInt32(row["ShiftId"]),
                    row["Name"].ToString(),
                    row["StartTime"].ToString(),
                    row["EndTime"].ToString(),
                    Convert.ToInt32(row["CurrentStaff"]),
                    Convert.ToInt32(row["MaxStaff"]),
                    Convert.ToInt32(row["IsMine"]) > 0
                );
            }
        }

        private void Uc_ShiftClicked(DateTime workDate, int shiftId)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem registerItem = new ToolStripMenuItem("Đăng ký ca");
            registerItem.Click += (s, e) =>
            {
                using (ShiftRegisterForm f = new ShiftRegisterForm(userId, workDate, shiftId))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        LoadCalendar();
                        CheckReminder();
                    }
                }
            };

            ToolStripMenuItem attendanceItem = new ToolStripMenuItem("Chấm công hôm nay");
            attendanceItem.Click += (s, e) =>
            {
                using (ShiftAttendanceForm f = new ShiftAttendanceForm(userId))
                {
                    f.ShowDialog();
                }
            };

            menu.Items.Add(registerItem);

            if (workDate.Date == DateTime.Today)
                menu.Items.Add(attendanceItem);

            menu.Show(Cursor.Position);
        }

        private void CheckReminder()
        {
            DateTime nextWeekStart = GetStartOfWeek(DateTime.Today).AddDays(7);
            DateTime nextWeekEnd = nextWeekStart.AddDays(6);

            object count = db.ExecuteScalar(@"
                SELECT COUNT(*)
                FROM UserShifts
                WHERE UserId = @UserId
                  AND WorkDate BETWEEN @StartDate AND @EndDate",
                new SqlParameter[]
                {
                    new SqlParameter("@UserId", userId),
                    new SqlParameter("@StartDate", nextWeekStart),
                    new SqlParameter("@EndDate", nextWeekEnd)
                });

            lblStatus.Text = Convert.ToInt32(count) == 0
                ? "⚠ Bạn chưa đăng ký ca cho tuần sau"
                : "";
        }

        private void cboWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCalendar();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            currentWeekStart = currentWeekStart.AddDays(-7);
            LoadCalendar();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentWeekStart = currentWeekStart.AddDays(7);
            LoadCalendar();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            using (ShiftAttendanceForm f = new ShiftAttendanceForm(userId))
            {
                f.ShowDialog();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCalendar();
            CheckReminder();
        }
    }
}