using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR36_2020_POP2021.Model
{
    [Table(Name = "korisnik")]
    public class RegisteredUser : IDataErrorInfo
    {
        public RegisteredUser() { }

        [Column(IsPrimaryKey = true, Name = "korisnik_id", CanBeNull = true, IsDbGenerated = true)]
        public int Id { get; set; }


        [Column(Name = "ime", CanBeNull = false)]
        public string Name { get; set; }


        [Column(Name = "prezime", CanBeNull = false)]
        public string LastName { get; set; }


        [Column(Name = "jmbg", CanBeNull = true)]
        public long Jmbg { get; set; }/*{ get {; }
                            set { ; } 
                          }*/


        //[Column(Name = "pol", CanBeNull = true)]
        public string Gender { get; set; }


        //[Column(Name = "adresa_id", CanBeNull = true)]
        public Address Address { get; set; }


        [Column(Name = "email", CanBeNull = true)]
        public string Email { get; set; }


        [Column(Name = "lozinka", CanBeNull = true)]
        public string Password { get; set; }


        [Column(Name = "obrisan", CanBeNull = true)]
        public string Deleted { get; set; }


        [Column(Name = "tip", CanBeNull = true)]
        public string Type { get; set; }

        public RegisteredUser Clone()
        {
            RegisteredUser old = new RegisteredUser();
            old.Name = this.Name;
            old.LastName = this.LastName;
            old.Jmbg = this.Jmbg;
            old.Address = this.Address;
            old.Email = this.Email;
            old.Gender = this.Gender;
            old.Password = this.Password;
            old.Deleted = this.Deleted;
            // TODO old.Type = Type;

            return old;
        }

        public string Error
        {
            get
            {
                return "message";
            }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        //if(Name!=null && Name.Equals(String.Empty))
                        if (string.IsNullOrEmpty(Name))
                        {
                            return "Name must be entered";
                        }
                        break;
                }

                return String.Empty;
            }

        }
    }
}
