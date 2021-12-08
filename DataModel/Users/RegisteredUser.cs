
using SR36_2020_POP2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR36_2020_POP2021.DataModel.Users
{

    public abstract class RegisteredUser : /*IUserEditor,*/ ITrainingEditor
    {

        public RegisteredUser() { }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Jmbg { get; set; }

        public EGender Gender { get; set; }

        public Address Address { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Deleted { get; set; }


        /*public void Modify(string name, string lastName, EGender gender, Address address,
         string email)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Gender = gender;
            this.Address = new Address(Id, streetName, streetNum, city, state);
            this.Email = email;
        }*/

        public void SetDeleted()
        {
            Deleted = true;
        }
        public void ChangePassword(string password)
        {
            Password = password;
        }


        public abstract void CancelTraining(Training training);
    }
}