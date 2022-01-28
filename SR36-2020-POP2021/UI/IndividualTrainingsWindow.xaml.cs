using SR36_2020_POP2021.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for IndividualTrainingsWindow.xaml
    /// </summary>
    public partial class IndividualTrainingsWindow : Window
    {
        private RegisteredUser loggedUser;
        ICollectionView view;

        public IndividualTrainingsWindow(RegisteredUser loggedUser)
        {
            this.loggedUser = loggedUser;

            if(loggedUser.Type == "INSTRUCTOR")
            {
                Menu.Visibility = Visibility.Hidden;
            }

            InitializeComponent();
            UpdateView();
            view.Filter = CustomFilter;
        }

        private bool CustomFilter(object obj)
        {
            Training t = obj as Training;
            // *
            if (t.Deleted.Equals("N"))
            {
                if (txtSearchBar.Text != "")
                {
                    return t.Instructor.Name.Contains(txtSearchBar.Text) || t.Instructor.LastName.Contains(txtSearchBar.Text) || t.Instructor.Email.Contains(txtSearchBar.Text);
                }
                else
                    return true;
            }
            return false;
        }

        private void UpdateView()
        {
            DGTrainings.ItemsSource = null;
            // * Dobavlja sve treninge gde ucestvuje prijavljeni korisnik *

            Table<Training> allTrainings = FitnessCenter.Instance.Dbdc.GetTable<Training>();
            List<Training> ownTrainings = (from t in allTrainings where (t.Instructor.Id == loggedUser.Id || t.Trainee.Id == loggedUser.Id) select t).ToList();
            
            view = CollectionViewSource.GetDefaultView(ownTrainings);

            DGTrainings.ItemsSource = view;
            DGTrainings.IsSynchronizedWithCurrentItem = true;

            DGTrainings.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            DGTrainings.SelectedItems.Clear();
        }

        private void DGTrainings_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //* TODO *Doraditi

            if (e.PropertyName.Equals("Error"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void TxtSearchBar_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void MakeOrCancelAppointment_Click(object sender, RoutedEventArgs e)
        {
            Training selectedTraining = view.CurrentItem as Training;
            if (selectedTraining == null) { return; }

            DataContext dc = new DataContext(FitnessCenter.CONNECTION_STRING);
            Table<Training> t = dc.GetTable<Training>();
            IEnumerable<Training> foundTrainings = from a in t where a.Tr_id == selectedTraining.Tr_id select a;
            Training foundTraining = foundTrainings.ElementAt(0);

            if (FitnessCenter.Instance.LoggedUser.Type == "TRAINEE" && selectedTraining.Status == "FREE")
            {
                foundTraining.Status = "TAKEN";
                foundTraining.Trainee = FitnessCenter.Instance.LoggedUser;
            }
            else if (FitnessCenter.Instance.LoggedUser.Type == "TRAINEE" && selectedTraining.Status == "TAKEN")
            {
                foundTraining.Status = "FREE";
                foundTraining.Trainee = null;
            }
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            FitnessCenter.Instance.LoggedUser = null;
            new MainWindow().Show();
            this.Close();
        }
        private void BtnAddressInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new AddressWindow(FitnessCenter.Instance.LoggedUser).ShowDialog();
            this.Show();
        }

        private void ShowAllTrainings_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new AllTrainingsWindow().Show();
            this.Show();
        }
    }
}
