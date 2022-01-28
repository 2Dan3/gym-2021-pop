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
    /// Interaction logic for InstructorsWindow.xaml
    /// </summary>
    public partial class InstructorsWindow : Window
    {
        ICollectionView view;
        
        public InstructorsWindow()
        {
            InitializeComponent();
            UpdateView();
            view.Filter = CustomFilter;
        }

        private bool CustomFilter(object obj)
        {
            RegisteredUser ru = obj as RegisteredUser;

            if (ru.Deleted.Equals("N") && ru.Type.Equals("INSTRUCTOR") )
            {
                if (txtSearchBar.Text != "")
                {
                    return ru.Name.Contains(txtSearchBar.Text) || ru.LastName.Contains(txtSearchBar.Text) || ru.Email.Contains(txtSearchBar.Text); //|| ru.Address.State.Contains(txtSearchBar.Text) || ru.Address.City.Contains(txtSearchBar.Text) || ru.Address.StreetName.Contains(txtSearchBar.Text);
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
            if (e.PropertyName.Equals("Type"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void TxtSearchBar_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void ShowInstructorProfile_Click(object sender, RoutedEventArgs e)
        {
            RegisteredUser selectedInstructor = view.CurrentItem as RegisteredUser;

            if(selectedInstructor == null) return;

            AddEditTrainee aetWindow = new AddEditTrainee(selectedInstructor);
            this.Hide();
            
            aetWindow.ShowDialog();
                        
            this.Show();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            FitnessCenter.Instance.LoggedUser = null;
            new MainWindow().Show();
            this.Close();
        }
    }
}
