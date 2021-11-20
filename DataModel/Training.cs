
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Training {

    public Training(long id, DateTime date, DateTime timeStarted, double durationInMins, bool free, Instructor instructor, Trainee trainee) {
        this.id = id;
        this.date = date;
        this.timeStarted = timeStarted;
        this.durationInMins = durationInMins;
        this.free = free;
        this.instructor = instructor;
        this.trainee = trainee;
        deleted = false;
    }

    private long id { get; set; }

    private DateTime date { get; set; }

    private DateTime timeStarted { get; set; }

    private double durationInMins { get; set; }

    private bool free { get; set; }

    private Instructor instructor { get; set; }

    private Trainee trainee { get; set; }

    private bool deleted { get; set; }



    public void ScheduleAppointment() {
        // TODO implement here
    }

    public void CancelAppointment() {
        // TODO implement here
    }

    /*public void delete() {
        // TODO implement here
    }*/

}