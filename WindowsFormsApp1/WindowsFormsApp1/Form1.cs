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

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void showDay(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;

            string monthName = new DateTimeFormatInfo().GetMonthName(month);
            label8.Text = monthName.ToUpper() + " " + year;

            DateTime startOfMonth = new DateTime(year, month, 1);
            int day = DateTime.DaysInMonth(year, month);

            // FIX: DayOfWeek is 0 = Sunday, no need for string/convert
            int week = (int)startOfMonth.DayOfWeek + 1;

            for (int i = 1; i <= week + 1; i++)
            {
                ucDays ucDays = new ucDays("");
                flowLayoutPanel1.Controls.Add(ucDays);
            }

            for (int i = 1; i <= day; i++)
            {
                ucDays ucDays = new ucDays(i.ToString());
                flowLayoutPanel1.Controls.Add(ucDays);
            }

        }
    }
}
