using SR36_2020_POP2021.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
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
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Table<RegisteredUser> users = FitnessCenter.Instance.Dbdc.GetTable<RegisteredUser>();
            int existing = (from u in users where (u.Jmbg.ToString() == txtJmbg.Text) select u).Count();
            
            if (existing == 0)
            {
                EGender gend = (EGender)cbGender.SelectedItem;

                RegisteredUser ru = new RegisteredUser()
                {
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    Jmbg = long.Parse(txtJmbg.Text),
                    Gender = gend,
// * TODO               Address = null,
                    Email = txtEmail.Text,
                    Password = pbPassword.Password,
                    Deleted = "N",
                    Type = "TRAINEE"
                };
                
                users.InsertOnSubmit(ru);
                FitnessCenter.Instance.Dbdc.SubmitChanges();
            }
            else
            {
                lblJmbgError.Content = "Nalog sa unetim JMBG vec postoji!";
            }

            this.Hide();
            new Login().Show();
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Login().Show();

            this.Close();
        }
    }
}
