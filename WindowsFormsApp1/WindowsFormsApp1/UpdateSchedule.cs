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
            // Load schedules for the selected date
            daySchedules = Form1.schedules.Where(s => s.Date.Date == selectedDate.Date).ToList();

            if (daySchedules.Count == 0)
            {
                MessageBox.Show("No schedule set.", "No Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            CmbTypeOfSchedUpd.Items.Clear();
            CmbTypeOfSchedUpd.Items.Add("Open");
            CmbTypeOfSchedUpd.Items.Add("Close");
            CmbTypeOfSchedUpd.Items.Add("Restock");
            CmbTypeOfSchedUpd.Items.Add("Clean");

           
            if (daySchedules.Count > 0)
            {
                currentSchedule = daySchedules[0];
                CmbTypeOfSchedUpd.SelectedItem = currentSchedule.Name;
                txtBoxUpdSched.Text = currentSchedule.Description;
            }
        }

        private void CmbTypeOfSchedUpd_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string selectedName = CmbTypeOfSchedUpd.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedName))
            {
                var schedule = daySchedules.FirstOrDefault(s => s.Name == selectedName);
                if (schedule != null)
                {
                    currentSchedule = schedule;
                    txtBoxUpdSched.Text = currentSchedule.Description;
                }
            }
        }

        private void SaveBtnUpdSched_Click(object sender, EventArgs e)
        {
            if (currentSchedule == null)
            {
                MessageBox.Show("Please select a schedule to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CmbTypeOfSchedUpd.SelectedItem == null)
            {
                MessageBox.Show("Please select a schedule type.", "No Type Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //update schedule name and description
            currentSchedule.Name = CmbTypeOfSchedUpd.SelectedItem.ToString();
            currentSchedule.Description = txtBoxUpdSched.Text;

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

        private void TxtBoxUpdSched_TextChanged(object sender, EventArgs e)
        {

        }
    }
}