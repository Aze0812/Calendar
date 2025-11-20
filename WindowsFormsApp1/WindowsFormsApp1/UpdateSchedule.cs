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
        public partial class UpdateSchedules : Form
        {
            private DateTime selectedDate;
            private List<Schedule> daySchedules;
            private Schedule currentSchedule;
            public bool IsModified { get; private set; }

            public UpdateSchedules(DateTime date)
            {
                InitializeComponent();
                selectedDate = date;
                IsModified = false;
            }

            private void UpdateSchedule_Load(object sender, EventArgs e)
            {
                

            dateTimePicker1.Value = selectedDate;

              
                daySchedules = Form1.schedules.Where(s => s.Date.Date == selectedDate.Date).ToList();

                if (daySchedules.Count == 0)
                {
                    MessageBox.Show("No schedule set.", "No Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                
                comboBox1.Items.Clear();
                foreach (var schedule in daySchedules)
                {
                    comboBox1.Items.Add(schedule.Name);
                }

               
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }

            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                comboBox1.Items.Add("Checking");
                comboBox1.Items.Add("Open");
                comboBox1.Items.Add("Close");
                comboBox1.Items.Add("Restock");
                comboBox1.Items.Add("Clean");
            if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex < daySchedules.Count)
                {
                    currentSchedule = daySchedules[comboBox1.SelectedIndex];
                    textBox1.Text = currentSchedule.Description;
                    dateTimePicker1.Value = currentSchedule.Date;
                }
            }

            private void SaveBtn_Click(object sender, EventArgs e)
            {
                if (currentSchedule == null)
                {
                    MessageBox.Show("Please select a schedule to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //check if the new date has any schedules
                DateTime newDate = dateTimePicker1.Value.Date;
                if (newDate != selectedDate.Date)
                {
                    var schedulesOnNewDate = Form1.schedules.Where(s => s.Date.Date == newDate.Date).ToList();
                    if (schedulesOnNewDate.Count == 0)
                    {
                        MessageBox.Show("No schedule set.", "No Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                //update schedule
                currentSchedule.Date = dateTimePicker1.Value;
                currentSchedule.Description = textBox1.Text;

                MessageBox.Show("Schedule updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsModified = true;
                this.Close();
            }

            private void DelBtn_Click(object sender, EventArgs e)
            {
                if (currentSchedule == null)
                {
                    MessageBox.Show("Please select a schedule to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the schedule '{currentSchedule.Name}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    Form1.schedules.Remove(currentSchedule);
                    MessageBox.Show("Schedule deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsModified = true;
                    this.Close();
                }
            }

            private void BckBtn_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                
            }

            private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
            {
                
            }
        }
    }