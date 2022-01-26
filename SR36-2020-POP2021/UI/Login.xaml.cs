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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Table<RegisteredUser> users = FitnessCenter.Instance.Dbdc.GetTable<RegisteredUser>();
            var res = from u in users where (u.Deleted.Equals("N") && u.Jmbg.ToString().Equals(tbUsername.Text) && u.Password.Equals(pbPassword.Password.ToString())) select u;
//* TODO *Upis korisnika kao trenutno Prijavljenog, dok se ne izloguje : u trenutnoj liniji komentara
//* TODO *Redirect na, za njegov tip, glavni prozor : u trenutnoj liniji komentara
            

            /*string filePath;

            if (cbRole.SelectedItem.Equals(ERoles.POLAZNIK))
            {
                filePath = Trainee.filePath;
            }*/
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            //* TODO *Redirect na prozor za registraciju : u trenutnoj liniji komentara *- ! *povratna vrednost uspesnosti registracije za formiranje poruke se preuzima !
            this.Hide();
            RegistrationWindow rw = new RegistrationWindow();
            rw.Show();

            this.Close();
        }
    }
}
