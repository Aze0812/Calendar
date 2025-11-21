using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static int _year, _month;
        public static List<Schedule> schedules = new List<Schedule>();

        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showDay(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void NxtPicBox_Click(object sender, EventArgs e)
        {
            //next month
            _month += 1;
            if (_month > 12)
            {
                _month = 1;
                _year += 1;
            }
            showDay(_month, _year);
        }

        private void PrevPicBox_Click(object sender, EventArgs e)
        {
            //previous month
            _month -= 1;
            if (_month < 1)
            {
                _month = 12;
                _year -= 1;
            }
            showDay(_month, _year);
        }

        private void AddSchedBtn_1(object sender, EventArgs e)
        {
            //add Schedule
            AddSchedules AddSched = new AddSchedules();
            AddSched.ShowDialog();
            if (AddSched.IsSaved)
            {
                Schedule newSchedule = new Schedule(
                    AddSched.ScheduleDate,
                    AddSched.ScheduleName,
                    AddSched.ScheduleDescription
                );
                schedules.Add(newSchedule);
                showDay(_month, _year);
            }
        }

        private void BckBtn_Click(object sender, EventArgs e)
        {
            //back to dashboard, main form, or what.
            Form1 mf = new Form1();
            mf.Close();
        }

        private void UpdateBtn_Click_1(object sender, EventArgs e)
        {
            //Update button schedule
            //What the helly (part Vibe code :C)
            //customize message box to select date
            using (Form dateSelector = new Form())
            {
                dateSelector.Text = "Select Date to Update";
                dateSelector.Size = new Size(300, 150);
                dateSelector.StartPosition = FormStartPosition.CenterParent;
                dateSelector.FormBorderStyle = FormBorderStyle.FixedDialog;
                dateSelector.MaximizeBox = false;
                dateSelector.MinimizeBox = false;

                DateTimePicker dtPicker = new DateTimePicker();
                dtPicker.Location = new Point(20, 20);
                dtPicker.Width = 250;
                dtPicker.Value = new DateTime(_year, _month, 1);

                Button okButton = new Button();
                okButton.Text = "OK";
                okButton.Location = new Point(100, 60);
                okButton.DialogResult = DialogResult.OK;

                Button cancelButton = new Button();
                cancelButton.Text = "Cancel";
                cancelButton.Location = new Point(180, 60);
                cancelButton.DialogResult = DialogResult.Cancel;

                dateSelector.Controls.Add(dtPicker);
                dateSelector.Controls.Add(okButton);
                dateSelector.Controls.Add(cancelButton);
                dateSelector.AcceptButton = okButton;
                dateSelector.CancelButton = cancelButton;

                if (dateSelector.ShowDialog() == DialogResult.OK)
                {
                    DateTime selectedDate = dtPicker.Value.Date;
                    UpdateSchedules updateForm = new UpdateSchedules(selectedDate);
                    updateForm.ShowDialog();

                    if (updateForm.IsModified)
                    {
                        showDay(_month, _year);
                    }
                }
            }
        }

        private void showDay(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;
            string monthName = new DateTimeFormatInfo().GetMonthName(month);
            label8.Text = monthName.ToUpper() + " " + year;
            DateTime startOfMonth = new DateTime(year, month, 1);
            int day = DateTime.DaysInMonth(year, month);
            int week = (int)startOfMonth.DayOfWeek;
            for (int i = 0; i < week; i++)
            {
                ucDays ucDays = new ucDays("");
                flowLayoutPanel1.Controls.Add(ucDays);
            }
            for (int i = 1; i <= day; i++)
            {
                ucDays ucDays = new ucDays(i.ToString());
                DateTime currentDate = new DateTime(year, month, i);
                var daySchedules = schedules.Where(s => s.Date.Date == currentDate.Date).ToList();
                if (daySchedules.Count > 0)
                {
                    ucDays.SetSchedules(daySchedules);
                }
                flowLayoutPanel1.Controls.Add(ucDays);
            }
        }
    }
}