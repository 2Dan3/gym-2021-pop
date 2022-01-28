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
    /// Interaction logic for FCWindow.xaml
    /// </summary>
    public partial class FCWindow : Window
    {
        public FCWindow()
        {
            InitializeComponent();

            DataContext dc = new DataContext(FitnessCenter.CONNECTION_STRING);
            Table<FitnessCenterInfo> fc = dc.GetTable<FitnessCenterInfo>();

            // *UPIT KA BAZI :
            IEnumerable<FitnessCenterInfo> res = from f in fc select f;
            FitnessCenterInfo fitC = res.ElementAt(0);

            txtId.Text = fitC.FcId.ToString();
            txtName.Text = fitC.FcName;
            /*txtAddressName.Text = fitC.Location.StreetName;
            txtAddressNum.Text = fitC.Location.StreetNum.ToString();
            txtCity.Text = fitC.Location.City;
            txtState.Text = fitC.Location.State;*/

               Table<Address> ad = dc.GetTable<Address>();
            IEnumerable<Address> ad2 = from a in ad where a.Ad_Id == fitC.Adr_Id_FK select a;
            var ad3 = ad2.ElementAt(0);

            txtAddressName.Text = ad3.StreetName;
            txtAddressNum.Text = ad3.StreetNum.ToString();
            txtCity.Text = ad3.City;
            txtState.Text = ad3.State;   

            if (FitnessCenter.Instance.LoggedUser == null)
            {
                txtAddressName.IsEnabled = false;
                txtAddressNum.IsEnabled = false;
                txtCity.IsEnabled = false;
                txtName.IsEnabled = false;
                txtState.IsEnabled = false;
                btnConfirm.Visibility = Visibility.Hidden;
            }
        }


        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            // *TODO* Impl here
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }


    }
}
