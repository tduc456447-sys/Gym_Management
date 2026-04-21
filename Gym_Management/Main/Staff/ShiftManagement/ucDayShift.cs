using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    public partial class ucDayShift : UserControl
    {
        public DateTime WorkDate { get; private set; }

        public event Action<DateTime, int> ShiftClicked;

        public ucDayShift()
        {
            InitializeComponent();
        }

        public void SetDate(DateTime date, bool isToday = false)
        {
            WorkDate = date;
            lblDate.Text = string.Format("{0}\n{1:dd/MM/yyyy}", GetVietnameseDay(date.DayOfWeek), date);
            pnlHeader.BackColor = isToday
                ? Color.FromArgb(255, 243, 205)
                : Color.FromArgb(240, 240, 240);
        }

        public void ClearShifts()
        {
            flowShifts.Controls.Clear();
        }

        public void AddShift(int shiftId, string shiftName, string startTime, string endTime, int currentStaff, int maxStaff, bool isMine)
        {
            Button btn = new Button();
            btn.Width = 135;
            btn.Height = 70;
            btn.Margin = new Padding(6);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Text = string.Format("{0}\n{1} - {2}\n{3}/{4}", shiftName, startTime, endTime, currentStaff, maxStaff);

            if (isMine)
                btn.BackColor = Color.FromArgb(198, 239, 206);
            else if (currentStaff >= maxStaff)
                btn.BackColor = Color.FromArgb(255, 199, 206);
            else
                btn.BackColor = Color.FromArgb(221, 235, 247);

            btn.Tag = shiftId;
            btn.Click += (s, e) =>
            {
                if (ShiftClicked != null)
                    ShiftClicked(WorkDate, shiftId);
            };

            flowShifts.Controls.Add(btn);
        }

        private string GetVietnameseDay(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return "Thứ 2";
                case DayOfWeek.Tuesday: return "Thứ 3";
                case DayOfWeek.Wednesday: return "Thứ 4";
                case DayOfWeek.Thursday: return "Thứ 5";
                case DayOfWeek.Friday: return "Thứ 6";
                case DayOfWeek.Saturday: return "Thứ 7";
                default: return "Chủ nhật";
            }
        }
    }
}