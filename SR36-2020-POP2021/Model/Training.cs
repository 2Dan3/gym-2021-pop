using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR36_2020_POP2021.Model
{

    [Table(Name = "trening")]
    public class Training
    {
        public Training() { }

        [Column(IsPrimaryKey = true, Name = "trening_id", CanBeNull = false)]
        public int Tr_id { get; set; }

        //[Column(Name = "datum", CanBeNull = true)]
        public DateTime Date { get; set; }

        //[Column(Name = "vreme", CanBeNull = false)]
        public DateTime TimeStarted { get; set; }

        [Column(Name = "trajanje", CanBeNull = true)]
        public int DurationInMins { get; set; }

        [Column(Name = "status", CanBeNull = false)]
        public string Status { get; set; }


        private EntityRef<RegisteredUser> instructor;
        [Association(Storage = "instructor", ThisKey ="Tr_id", OtherKey = "Id", IsForeignKey=true)]
        public RegisteredUser Instructor
        {
            get { return this.instructor.Entity; }
            set { this.instructor.Entity = value; }
        }

        //public Instructor Instructor { get; set; }


        private EntityRef<RegisteredUser> trainee;
        [Association(Storage = "trainee", ThisKey ="Tr_id", OtherKey ="Id", IsForeignKey =true)]
        public RegisteredUser Trainee
        {
            get { return this.trainee.Entity; }
            set { this.trainee.Entity = value;}
        }


        [Column(Name = "obrisan", CanBeNull = false)]
        public string Deleted { get; set; }



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
