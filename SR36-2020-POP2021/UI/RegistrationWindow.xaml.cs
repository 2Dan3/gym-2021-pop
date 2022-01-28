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
            /*cbGender.Items.Add("M");
            cbGender.Items.Add("Z");*/
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            DataContext dc = new DataContext(FitnessCenter.CONNECTION_STRING);
            Table<RegisteredUser> users = dc.GetTable<RegisteredUser>();
            int existing = (from u in users where (u.Jmbg.ToString() == txtJmbg.Text) select u).Count();
            
            if (existing == 0)
            {
                //int lastUsedID = (from u in users select u.Id).Max();
                ComboBoxItem cbi = (ComboBoxItem)cbGender.SelectedItem;
                string selectedText = cbi.Content.ToString();

                RegisteredUser ru = new RegisteredUser()
                {
                    //Id = lastUsedID + 1,
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    Jmbg = long.Parse(txtJmbg.Text),
                    Gender = selectedText  /*.SelectedItem.ToString()*/ ,
// * TODO               Address = null,
                    Email = txtEmail.Text,
                    Password = pbPassword.Password,
                    Deleted = "N",
                    Type = "TRAINEE"
                };
                

                users.InsertOnSubmit(ru);
                dc.SubmitChanges();
            }
            else
            {
                lblJmbgError.Content = "Nalog sa takvim JMBG vec postoji!";
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
