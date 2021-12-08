using SR36_2020_POP2021.DataModel;
using SR36_2020_POP2021.DataModel.Users;
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
        private Trainee selectedTrainee;

        public AddEditTrainee(Trainee tr)
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
                if (selectedTrainee.Equals(null))
                {

                    Trainee t = new Trainee
                    {
                        Name = txtName.Text,
                        LastName = txtLastName.Text,
                        Jmbg = txtJmbg.Text,
                        Gender = (EGender)CBGender.SelectedItem,
                        Email = txtEmail.Text,
                        Password = "123",
                        Deleted = false,
                        Address = new Address
                        {
                            Id = (int)FitnessCenter.Instance.Addresses[-1].Id + 1,
                            City = "Novi Sad",
                            State = "Srbija",
                            StreetName = "Veselina Maslese",
                            StreetNum = "10"
                        }
                        
                    };
                    FitnessCenter.Instance.Trainees.Add(t);
                }

                FitnessCenter.Instance.SaveEntities("trainees.txt");

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
