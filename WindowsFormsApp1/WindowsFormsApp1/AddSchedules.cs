using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class AddSchedules : Form
    {
        public DateTime ScheduleDate { get; private set; }
        public string ScheduleName { get; private set; }
        public string ScheduleDescription { get; private set; }
        public bool IsSaved { get; private set; }

        

        public AddSchedules()
        {
            InitializeComponent();
            IsSaved = false;
            if (dateTimePicker1 != null)
            {
                dateTimePicker1.Value = DateTime.Now;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //type of schedule
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cancel button
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save button 
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Please enter a schedule name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ScheduleDate = dateTimePicker1.Value.Date;
            ScheduleName = comboBox1.Text.Trim();
            ScheduleDescription = textBox2.Text.Trim();
            IsSaved = true;

            MessageBox.Show("Schedule added successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void AddSchedules_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Checking");
            comboBox1.Items.Add("Open");
            comboBox1.Items.Add("Close");
            comboBox1.Items.Add("Restock");
            comboBox1.Items.Add("Clean");
        }
    }
}