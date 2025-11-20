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
    
    public partial class ucDays : UserControl
    {
        string _day, date, weekday;
        public ucDays(string day)
        {
            InitializeComponent();
            _day = day;
            label1.Text = day;
            checkBox1.Hide();
            date = day + "/" + Form1._month + "/" + Form1._year;


        }

        public void Sundays()
        {
           try
            {
                DateTime day = DateTime.Parse(date);
                weekday = day.ToString("ddd");

                if (weekday == "Sun")
                {
                    this.BackColor = Color.FromArgb(255, 128, 128);
                }
                else
                {
                    label1.ForeColor = Color.FromArgb(64, 64, 64);

                }
            }
            catch (Exception)
            {

            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                checkBox1.Checked = true;
                //fix
                this.checkBox1 = Color.FromArgb( 25, 10, 79);
            }
            else
            {
                checkBox1.Checked = false;
                this.BackColor = Color.White;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ucDays_Load(object sender, EventArgs e)
        {
            Sundays();
        }
    }
}
