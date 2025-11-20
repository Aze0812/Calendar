using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    //Internal Class za
    public class Schedule
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Schedule(DateTime date, string name, string description)
        {
            Date = date;
            Name = name;
            Description = description;
        }
    }
}
