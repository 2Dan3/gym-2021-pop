
using SR36_2020_POP2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Administrator : RegisteredUser {

    public static sealed filePath = "";

    public Administrator(string name, string lastName, long jmbg, EGender gender, Address address, string email, string password)
        : base(name, lastName, jmbg, gender, address, email, password)
    {
    }

    public override void CancelTraining(Training training)
    {
        // TODO implement here
    }

}