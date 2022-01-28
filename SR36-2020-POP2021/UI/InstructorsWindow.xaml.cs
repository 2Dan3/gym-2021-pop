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
                //*TODO* Dodati proveru da li je type.equals("TRAINEE")
                if (ru.Deleted.Equals("N") && ru.Type.Equals("INSTRUCTOR") )
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

            private void AddInstructor_Click(object sender, RoutedEventArgs e)
            {
                //* TODO *Preraditi
                //Trainee tr = new Trainee();
                AddEditTrainee addEditTrainee = new AddEditTrainee(null); //tr
                this.Hide();
                if (!(bool)addEditTrainee.ShowDialog())
                {

                }
                this.Show();
            }

            private void ModifyInstructor_Click(object sender, RoutedEventArgs e)
            {
                //* TODO *Preraditi
                RegisteredUser selectedTrainee = view.CurrentItem as RegisteredUser;

                RegisteredUser oldTr = selectedTrainee.Clone();

                AddEditTrainee addEditTrainee = new AddEditTrainee(selectedTrainee);
                this.Hide();
                if (!(bool)addEditTrainee.ShowDialog())
                {
                    int index = FitnessCenter.Instance.RegisteredUsers.ToList().FindIndex(u => u.Jmbg.Equals(oldTr.Jmbg));
                    FitnessCenter.Instance.RegisteredUsers[index] = oldTr;
                }
                this.Show();

                view.Refresh();
                DGInstructors.SelectedItems.Clear();

            }

            private void MIDeleteInstructor_Click(object sender, RoutedEventArgs e)
            {
                //* TODO *Check how it's working
                RegisteredUser instructorToBeDeleted = view.CurrentItem as RegisteredUser;

                Table<RegisteredUser> users = FitnessCenter.Instance.Dbdc.GetTable<RegisteredUser>();
                IEnumerable<RegisteredUser> res = from u in users where u.Id == instructorToBeDeleted.Id select u;
                RegisteredUser ru = res.ElementAt(0);
                ru.Deleted = "D";
                FitnessCenter.Instance.Dbdc.SubmitChanges();

                UpdateView();
                view.Filter = CustomFilter;
                view.Refresh();
            }
        }
}
