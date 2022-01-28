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
    /// Interaction logic for AddressWindow.xaml
    /// </summary>
    public partial class AddressWindow : Window
    {
        private Address oldAddress;
        private RegisteredUser addressOwner;

        public AddressWindow(RegisteredUser user)
        {
            InitializeComponent();
            this.DataContext = user.Address;

            addressOwner = user;

            oldAddress = user.Address.Clone();

            this.DataContext = user.Address;

            this.Title = this.Title + user.Name + " " + user.LastName + " ( " + user.Jmbg + " )";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {// * TODO IMPLEMENT HERE !!!!!!!!!!!!!!!!!!!!~!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!~!!!!!!!!!!!!!!!!!!!!!
            addressOwner.Address = oldAddress;
            this.Close(); 
        }
        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            DataContext dc = new DataContext(FitnessCenter.CONNECTION_STRING);
            Table<Address> adr = dc.GetTable<Address>();
            
            IEnumerable<Address> res = from a in adr where a.Ad_Id == addressOwner.Address.Ad_Id select a;
            Address foundAdr = res.ElementAt(0);
            foundAdr = addressOwner.Address;
            dc.SubmitChanges();
            this.Close();
        }
    }
}
