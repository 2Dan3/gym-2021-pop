using SR36_2020_POP2021.Exceptions;
using SR36_2020_POP2021.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR36_2020_POP2021.Services
{
    public class UserService : IUserService
    {
        public void DeleteUser(string jmbg)
        {
            RegisteredUser registeredUser = FitnessCenter.Instance.Trainees.ToList().Find(user => user.Jmbg.Equals(jmbg));
            if (registeredUser == null)
            {
                throw new UserNotFoundException($"Trazeni korisnik nije pronadjen; JMBG:{jmbg}");
            }
            registeredUser.Deleted = true;
            FitnessCenter.Instance.SaveEntities("trainees.txt");
        }

        public void ReadUsers(string filename)
        {
            FitnessCenter.Instance.Trainees = new ObservableCollection<Trainee>();
            using (StreamReader file = new StreamReader(@"../../Files/" + filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');

                    Enum.TryParse(parts[3], out EGender gender);
                    Boolean.TryParse(parts[7], out Boolean isDeleted);
                    string addressID = parts[4];
                    //Address adr = FitnessCenter.Instance.Addresses.ToList().Find(ad => ad.Id.Equals(addressID));
                    Address adr = null;

                    Trainee tr = new Trainee
                    {
                        Name = parts[0],
                        LastName = parts[1],
                        Jmbg = parts[2],
                        Gender = gender,
                        Address = adr,
                        Email = parts[5],
                        Password = parts[6],
                        Deleted = isDeleted
                    };

                    FitnessCenter.Instance.Trainees.Add(tr);
                }
            }
        }

        public void SaveUsers(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Files/" + filename))
            {
                foreach (Trainee tr in FitnessCenter.Instance.Trainees)
                {
                    file.WriteLine(tr.ToString());
                }
            }
        }

        public void ReadAddresses(string filename)
        {
            FitnessCenter.Instance.Addresses = new ObservableCollection<Address>();
            using (StreamReader file = new StreamReader(@"../../Files/" + filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    int.TryParse(parts[0], out int iD);

                    Address addr = new Address()
                    {
                        Id = iD,
                        StreetName = parts[1],
                        StreetNum = parts[2],
                        City = parts[3],
                        State = parts[4]
                    };

                    FitnessCenter.Instance.Addresses.Add(addr);
                }
            }
        }

        public void SaveAddresses(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Files/" + filename))
            {
                foreach (Address addr in FitnessCenter.Instance.Addresses)
                {
                    file.WriteLine(addr.ToString());
                }
            }
        }

        public void ReadInstructors(string filename)
        {
            FitnessCenter.Instance.Instructors = new ObservableCollection<Instructor>();
            using (StreamReader file = new StreamReader(@"../../Files/" + filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');

                    Enum.TryParse(parts[3], out EGender gender);
                    Boolean.TryParse(parts[7], out Boolean isDeleted);
                    string addressID = parts[4];
                    Address adr = FitnessCenter.Instance.Addresses.ToList().Find(ad => ad.Id.Equals(addressID));

                    Instructor i = new Instructor
                    {
                        Name = parts[0],
                        LastName = parts[1],
                        Jmbg = parts[2],
                        Gender = gender,
                        Address = adr,
                        Email = parts[5],
                        Password = parts[6],
                        Deleted = isDeleted
                    };

                    FitnessCenter.Instance.Instructors.Add(i);
                }
            }
        }
        public void SaveInstructors(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Files/" + filename))
            {
                foreach (Instructor i in FitnessCenter.Instance.Instructors)
                {
                    file.WriteLine(i.ToString());
                }
            }
        }
    }
}
