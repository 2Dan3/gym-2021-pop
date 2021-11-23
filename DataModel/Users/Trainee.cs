
using SR36_2020_POP2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Trainee : RegisteredUser {

    public static sealed filePath = "";

    public Trainee(string name, string lastName, long jmbg, EGender gender, Address address, string email, string password) 
        : base(name, lastName, jmbg, gender, address, email, password)
    {
    }

    public List<Training> trainings;


    public override void CancelTraining(Training training)
    {
        // TODO implement here
    }
}