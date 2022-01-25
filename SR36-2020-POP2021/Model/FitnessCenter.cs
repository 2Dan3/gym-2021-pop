//using SR36_2020_POP2021.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR36_2020_POP2021.Model
{
    public sealed class FitnessCenter
    {

        public const string CONNECTION_STRING = @"Integrated Security=true;
        Initial Catalog=fitness_center;
        Data Source=desktop-bs3gdcj\sqlexpress";

        private static readonly FitnessCenter instance = new FitnessCenter();
        /* private IUserService userService;*/
        //private IInstructorService instructorService;

        DataContext dbdc = new DataContext(CONNECTION_STRING);

        public DataContext Dbdc { get { return dbdc; } }

        private FitnessCenter()
        {
            // userService = new UserService();
            //instructorService = new InstructorService();
        }

        static FitnessCenter() { }


        public static FitnessCenter Instance
        {
            get { return instance; }
        }

        //public ObservableCollection<RegisteredUser> RegisteredUsers { get; set; }
        public List<RegisteredUser> RegisteredUsers { get; set; }
        public ObservableCollection<Instructor> Instructors { get; set; }
        public ObservableCollection<Trainee> Trainees { get; set; }
        public ObservableCollection<Address> Addresses { get; set; }
        public ObservableCollection<Training> Trainings { get; set; }



        public long Id { get; set; }

        public string Name { get; set; }

        public Address Location { get; set; }


        public void Initialize()
        {
            //Table<RegisteredUser> rUsers = Dbdc.GetTable<RegisteredUser>();
/*Postupni Convert */            
            //List<RegisteredUser> listOfUsers = rUsers.ToList();
            //RegisteredUsers = new ObservableCollection<RegisteredUser>(listOfUsers);
            //RegisteredUsers = rUsers.ToList();
/* */            RegisteredUsers = new List<RegisteredUser>();
            Trainees = new ObservableCollection<Trainee>();
            Instructors = new ObservableCollection<Instructor>();
            Trainings = new ObservableCollection<Training>();
            Addresses = new ObservableCollection<Address>();

            //ReadEntities("addresses.txt");
            //ReadEntities("trainees.txt");

// OTKOM TEST PODATKE
            /*RegisteredUser testUser1 = new RegisteredUser
            {
                Name = "Marko",
                LastName = "Markovic",
                Jmbg = 2812001800011,
                Gender = EGender.M,
                //Address = new Address(),
                Email = "marko@gmail.com",
                Password = "123",
                Deleted = "N"

            };
           RegisteredUsers.Add(testUser1);

            RegisteredUser testUser2 = new RegisteredUser
            {
                Name = "Darko",
                LastName = "Darkovic",
                Jmbg = 3132001800011,
                Gender = EGender.M,
                //Address = new Address(),
                Email = "darko@gmail.com",
                Password = "111",
                Deleted = "N"

            };
            RegisteredUsers.Add(testUser2);*/


            /*Trainee testTrainee1 = new Trainee
            {
                User = testUser1
            };

            Trainee testTrainee2 = new Trainee
            {
                User = testUser2
            };

            Trainees.Add(testTrainee1);
            Trainees.Add(testTrainee2);*/

        }
        /*
        public void SaveEntities(string filename)
        {
            if (filename.Contains("addresses"))
            {
                userService.SaveAddresses(filename);
            }
            else if (filename.Contains("trainees"))
            {
                userService.SaveUsers(filename);
            }
//            else if (filename.Contains("instructors"))
//            {
//                userService.SaveInstructors(filename);
//            }
        }

        public void ReadEntities(string filename)
        {
            if (filename.Contains("addresses"))
            {
                userService.ReadAddresses(filename);
            }
            else if (filename.Contains("trainees"))
            {
                userService.ReadUsers(filename);
            }
//            /*else if (filename.Contains("instructors"))
//            {
//               userService.ReadInstructors(filename);
            }
        }

        public void DeleteUser(string jmbg)
        {
            userService.DeleteUser(jmbg);
        }*/

    }
}
