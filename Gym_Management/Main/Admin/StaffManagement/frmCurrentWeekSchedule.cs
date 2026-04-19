using Gym_Management.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Gym_Management.Main.Admin.StaffManagement
{
    public partial class frmCurrentWeekSchedule : Form
    {
        private DBHelper db = new DBHelper();

        public frmCurrentWeekSchedule()
        {
            InitializeComponent();
        }

        private void frmCurrentWeekSchedule_Load(object sender, EventArgs e)
        {
            LoadCurrentWeekSchedule();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadCurrentWeekSchedule();
        }

        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = date.DayOfWeek - DayOfWeek.Monday;
            if (diff < 0) diff += 7;
            return date.AddDays(-diff).Date;
        }

        private void LoadCurrentWeekSchedule()
        {
            try
            {
                DateTime startWeek = GetStartOfWeek(DateTime.Now);
                DateTime endWeek = startWeek.AddDays(6);

                lblWeek.Text = $"Tuần hiện tại: {startWeek:dd/MM/yyyy} - {endWeek:dd/MM/yyyy}";

                string sql = @"
                    SELECT
                        us.WorkDate,
                        ws.Name AS ShiftName,
                        ws.StartTime,
                        ws.EndTime,
                        u.FullName
                    FROM UserShifts us
                    JOIN Users u ON us.UserId = u.UserId
                    JOIN WorkShifts ws ON us.ShiftId = ws.ShiftId
                    WHERE us.WorkDate BETWEEN @StartWeek AND @EndWeek
                    ORDER BY us.WorkDate, ws.StartTime, u.FullName
                ";

                SqlParameter[] pr =
                {
                    new SqlParameter("@StartWeek", startWeek),
                    new SqlParameter("@EndWeek", endWeek)
                };

                DataTable dt = db.ExecuteQuery(sql, pr);
                RenderWeekBoard(dt, startWeek);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch tuần này: " + ex.Message);
            }
        }

        private void RenderWeekBoard(DataTable dt, DateTime startWeek)
        {
            flowDays.Controls.Clear();

            for (int i = 0; i < 7; i++)
            {
                DateTime day = startWeek.AddDays(i);

                Panel dayPanel = CreateDayPanel(day);
                FlowLayoutPanel shiftContainer = (FlowLayoutPanel)dayPanel.Controls["shiftContainer"];

                var shiftsOfDay = dt.AsEnumerable()
                    .Where(r => Convert.ToDateTime(r["WorkDate"]).Date == day.Date)
                    .GroupBy(r => new
                    {
                        ShiftName = r["ShiftName"].ToString(),
                        StartTime = TimeSpan.Parse(r["StartTime"].ToString()),
                        EndTime = TimeSpan.Parse(r["EndTime"].ToString())
                    })
                    .OrderBy(g => g.Key.StartTime)
                    .ToList();

                if (shiftsOfDay.Count == 0)
                {
                    shiftContainer.Controls.Add(CreateEmptyShiftCard());
                }
                else
                {
                    foreach (var shift in shiftsOfDay)
                    {
                        List<string> employees = shift
                            .Select(x => x["FullName"].ToString())
                            .Distinct()
                            .ToList();

                        shiftContainer.Controls.Add(
                            CreateShiftCard(
                                shift.Key.ShiftName,
                                shift.Key.StartTime,
                                shift.Key.EndTime,
                                employees
                            )
                        );
                    }
                }

                flowDays.Controls.Add(dayPanel);
            }
        }

        private Panel CreateDayPanel(DateTime day)
        {
            Panel panel = new Panel();
            panel.Width = 185;
            panel.Height = 560;
            panel.Margin = new Padding(6);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label lblDay = new Label();
            lblDay.Text = GetVietnameseDayName(day) + Environment.NewLine + day.ToString("dd/MM/yyyy");
            lblDay.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblDay.TextAlign = ContentAlignment.MiddleCenter;
            lblDay.Dock = DockStyle.Top;
            lblDay.Height = 62;
            lblDay.BackColor = day.DayOfWeek == DayOfWeek.Sunday
                ? Color.FromArgb(244, 235, 198)
                : Color.FromArgb(235, 235, 235);

            FlowLayoutPanel shiftContainer = new FlowLayoutPanel();
            shiftContainer.Name = "shiftContainer";
            shiftContainer.Dock = DockStyle.Fill;
            shiftContainer.FlowDirection = FlowDirection.TopDown;
            shiftContainer.WrapContents = false;
            shiftContainer.AutoScroll = true;
            shiftContainer.Padding = new Padding(6);
            shiftContainer.BackColor = Color.WhiteSmoke;

            panel.Controls.Add(shiftContainer);
            panel.Controls.Add(lblDay);

            return panel;
        }

        private Panel CreateShiftCard(string shiftName, TimeSpan startTime, TimeSpan endTime, List<string> employees)
        {
            Panel card = new Panel();
            card.Width = 155;
            card.Height = 135;
            card.Margin = new Padding(4);
            card.BackColor = Color.FromArgb(220, 235, 247);
            card.BorderStyle = BorderStyle.FixedSingle;

            Label lblTitle = new Label();
            lblTitle.Text = shiftName;
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location = new Point(5, 5);
            lblTitle.Size = new Size(143, 22);

            Label lblTime = new Label();
            lblTime.Text = $"{startTime:hh\\:mm} - {endTime:hh\\:mm}";
            lblTime.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            lblTime.Location = new Point(5, 28);
            lblTime.Size = new Size(143, 20);

            Label lblCount = new Label();
            lblCount.Text = $"Số người: {employees.Count}";
            lblCount.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblCount.ForeColor = Color.FromArgb(40, 40, 40);
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            lblCount.Location = new Point(5, 50);
            lblCount.Size = new Size(143, 20);

            Label lblEmployees = new Label();
            lblEmployees.Text = employees.Count > 0
                ? string.Join(Environment.NewLine, employees)
                : "Chưa có nhân viên";
            lblEmployees.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
            lblEmployees.Location = new Point(8, 74);
            lblEmployees.Size = new Size(137, 52);
            lblEmployees.TextAlign = ContentAlignment.TopLeft;

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblTime);
            card.Controls.Add(lblCount);
            card.Controls.Add(lblEmployees);

            return card;
        }

        private Panel CreateEmptyShiftCard()
        {
            Panel card = new Panel();
            card.Width = 155;
            card.Height = 80;
            card.Margin = new Padding(4);
            card.BackColor = Color.FromArgb(245, 245, 245);
            card.BorderStyle = BorderStyle.FixedSingle;

            Label lbl = new Label();
            lbl.Text = "Không có lịch";
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lbl.ForeColor = Color.Gray;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;

            card.Controls.Add(lbl);
            return card;
        }

        private string GetVietnameseDayName(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday: return "Thứ 2";
                case DayOfWeek.Tuesday: return "Thứ 3";
                case DayOfWeek.Wednesday: return "Thứ 4";
                case DayOfWeek.Thursday: return "Thứ 5";
                case DayOfWeek.Friday: return "Thứ 6";
                case DayOfWeek.Saturday: return "Thứ 7";
                case DayOfWeek.Sunday: return "Chủ nhật";
                default: return "";
            }
        }
    }
}