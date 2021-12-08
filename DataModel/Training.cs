
using SR36_2020_POP2021.DataModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR36_2020_POP2021.DataModel
{
    public class Training
    {

        public Training() { }

        public long Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime TimeStarted { get; set; }

        public double DurationInMins { get; set; }

        public bool Free { get; set; }

        public Instructor Instructor { get; set; }

        public Trainee Trainee { get; set; }

        public bool Deleted { get; set; }



        public void ScheduleAppointment()
        {
            // TODO implement here
        }

        public void CancelAppointment()
        {
            // TODO implement here
        }

        /*public void delete() {
            // TODO implement here
        }*/

    }
}