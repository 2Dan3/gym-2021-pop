
using SR36_2020_POP2021;
using SR36_2020_POP2021.DataModel.Users;
using SR36_2020_POP2021.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SR36_2020_POP2021.DataModel
{
    public sealed class FitnessCenter
    {

        private static readonly FitnessCenter instance = new FitnessCenter();
        private IUserService userService;
        //private IInstructorService instructorService;

        private FitnessCenter()
        {
            userService = new UserService();
            //instructorService = new InstructorService();
        }

        static FitnessCenter() { }


        public static FitnessCenter Instance
        {
            get { return instance; }
        }

        //public ObservableCollection<Instructor> Instructors { get; set; }

        public ObservableCollection<Trainee> Trainees { get; set; }
        public ObservableCollection<Address> Addresses { get; set; }

        //public ObservableCollection<Training> Trainings { get; set; }



        public long Id { get; set; }

        public string Name { get; set; }

        public Address Location { get; set; }


        public void Initialize()
        {

            Trainees = new ObservableCollection<Trainee>();
            //Instructors = new ObservableCollection<Instructor>();
            //Trainings = new ObservableCollection<Training>();
            Addresses = new ObservableCollection<Address>();


        }

        public void SaveEntities(string filename)
        {
            if (filename.Contains("trainees"))
            {
                userService.SaveUsers(filename);
            }
            /*else if (filename.Contains("instructors"))
            {
                instructorService.SaveUsers(filename);
            }*/
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
            /*else if (filename.Contains("instruktori"))
            {
                instructorService.ReadUsers(filename);
            }*/
        }

        public void DeleteUser(string jmbg)
        {
            userService.DeleteUser(jmbg);
        }

    }
}