using SR36_2020_POP2021.Model;
using SR36_2020_POP2021.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SR36_2020_POP2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICollectionView view;
        
        public MainWindow()
        {
            InitializeComponent();
            UpdateView();
            view.Filter = CustomFilter;

            //this.Hide();
            //TraineesWindow tw = new TraineesWindow();
            //AllTrainingsWindow tw = new AllTrainingsWindow();
            //Login tw = new Login();
            //tw.Show();

            //this.Close();

        }

        private bool CustomFilter(object obj)
        {
            RegisteredUser ru = obj as RegisteredUser;
            //*TODO* Dodati proveru da li je type.equals("TRAINEE")
            if (ru.Deleted.Equals("N") && ru.Type.Equals("INSTRUCTOR"))
            {
                if (txtSearchBar.Text != "")
                {
                    return ru.Name.Contains(txtSearchBar.Text) || ru.LastName.Contains(txtSearchBar.Text) || ru.Email.Contains(txtSearchBar.Text) || ru.Address.State.Contains(txtSearchBar.Text) || ru.Address.City.Contains(txtSearchBar.Text) || ru.Address.StreetName.Contains(txtSearchBar.Text);
                }
                else
                    return true;
            }
            return false;
        }

        private void UpdateView()
        {
            DGInstructors.ItemsSource = null;

            DataContext dc = new DataContext(FitnessCenter.CONNECTION_STRING);

            view = CollectionViewSource.GetDefaultView(dc.GetTable<RegisteredUser>().ToList());

            DGInstructors.ItemsSource = view;
            DGInstructors.IsSynchronizedWithCurrentItem = true;

            DGInstructors.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            DGInstructors.SelectedItems.Clear();
        }

        private void DGInstructors_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //* TODO *Doraditi

            if (e.PropertyName.Equals("Deleted"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.PropertyName.Equals("Error"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.PropertyName.Equals("Password"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void TxtSearchBar_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void InstructorProfile_Click(object sender, RoutedEventArgs e)
        {
            RegisteredUser selectedInstructor = view.CurrentItem as RegisteredUser;

            if (selectedInstructor == null) {
                return;
            }

            AddEditTrainee aetWindow = new AddEditTrainee(selectedInstructor);

            this.Hide();
            aetWindow.ShowDialog();

            this.Show();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void BtnFcInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new FCWindow().ShowDialog();

            this.Show();
        }
    }
}
