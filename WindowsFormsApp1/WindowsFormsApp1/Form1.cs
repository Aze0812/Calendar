using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void showDay(int month, int year)
        {   
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;

            //fix
            string monthName = new DateTimeFormatInfo().getMonthName(month);
            label8.Text = monthName.ToUpper() + " " + year;

            DateTime startOfMonth = new DateTime(year, month, 1);
            int day = DateTime.DaysInMonth(year, month);
            int week = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d") + 1);

            for (int i = 1; i < week + 1; i++)
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
