using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR36_2020_POP2021.Model
{
    public class Trainee
    {
        public Trainee() { }

        public List<Training> trainings;

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private RegisteredUser _user;

        public RegisteredUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        public void CancelTraining(Training training)
        {
            // TODO implement here
            Console.WriteLine("Pozvana CancelTraining()");
        }

        /*public override string ToString()
        {
            return Name + ";" + LastName + ";" + Jmbg + ";" + Gender + ";" + Address.Id + ";" + Email + ";" + Password + ";" + Deleted;


        }*/


        
    }
}
