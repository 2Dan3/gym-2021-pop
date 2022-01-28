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
            Table<FitnessCenter> fc = dc.GetTable<FitnessCenter>();

            // *UPIT KA BAZI

            if(FitnessCenter.Instance.LoggedUser == null)
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
