using SR36_2020_POP2021.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SR36_2020_POP2021.UI
{
    /// <summary>
    /// Interaction logic for AddEditTrainee.xaml
    /// </summary>
    public partial class AddEditTrainee : Window
    {
        /*public AddEditTrainee()
        {
            InitializeComponent();
        }*/
        private RegisteredUser selectedTrainee;

        public AddEditTrainee(RegisteredUser tr)
        {
            InitializeComponent();

            this.DataContext = tr;

            selectedTrainee = tr;

            if (tr != null)
            {
                this.Title = "Izmena polaznika";
            }
            else
            {
                this.Title = "Dodaj polaznika";
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                if (selectedTrainee == null)
                {
                    //*TODO* Change this !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!~!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!~!!!!!!!!!!
                    /*   RegisteredUser t = new RegisteredUser
                       {
                           Name = txtName.Text,
                           LastName = txtLastName.Text,
                           Jmbg = long.Parse(txtJmbg.Text),
                           Gender = (EGender)CBGender.SelectedItem,
                           Email = txtEmail.Text,
                           Password = "123",
                           Deleted = "N",
                           Address = new Address
                           {
                               Id = (int)FitnessCenter.Instance.Addresses[-1].Id + 1,
                               City = "Novi Sad",
                               State = "Srbija",
                               StreetName = "Veselina Maslese",
                               StreetNum = "10"
                           }

                       };
                       FitnessCenter.Instance.RegisteredUsers.Add(t);*/
                }

                //*TODO*  umesto ovoga ispod poziv dbdc.submitChanges();

                //FitnessCenter.Instance.SaveEntities("trainees.txt");

                this.DialogResult = true;
                this.Close();
            }
        }

        private bool IsValid()
        {
            return !Validation.GetHasError(txtJmbg) && !Validation.GetHasError(txtEmail) && !Validation.GetHasError(txtName);
        }
    }
}
