using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR36_2020_POP2021.Model
{
    public class Instructor
    {
        public Instructor() { }

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
            //TODO
        }
    }
}
