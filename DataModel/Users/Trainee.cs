
using SR36_2020_POP2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR36_2020_POP2021.DataModel.Users {

    public class Trainee : RegisteredUser {


        public Trainee()
        {
        }

        public List<Training> trainings;


        public override void CancelTraining(Training training)
        {
            // TODO implement here
        }

        public override string ToString()
        {
            return Name + ";" + LastName + ";" + Jmbg + ";" + Gender + ";" + Address.Id + ";" + Email + ";" + Password + ";" + Deleted;


        }


        public Trainee Clone()
        {
            Trainee copyTr = new Trainee();
            copyTr.Name = Name;
            copyTr.LastName = LastName;
            copyTr.Jmbg = Jmbg;
            copyTr.Gender = Gender;
            copyTr.Email = Email;
            copyTr.Password = Password;
            copyTr.Deleted = Deleted;
/* */            copyTr.Address = Address;

            return copyTr;
        }
    }
}