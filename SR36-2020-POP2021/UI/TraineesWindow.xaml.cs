using SR36_2020_POP2021;
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
    /// Interaction logic for TraineesWindow.xaml
    /// </summary>
    public partial class TraineesWindow : Window
    {
        ICollectionView view;
        public TraineesWindow()
        {
            InitializeComponent();
            UpdateView();
            view.Filter=CustomFilter;
        }

        private bool CustomFilter(object obj)
        {
            RegisteredUser ru = obj as RegisteredUser;
            //*TODO* Dodati proveru da li je type.equals("TRAINEE")
            if (ru.Deleted.Equals("N"))
            {
                if (txtSearchBar.Text != "")
                {
                    return ru.Name.Contains(txtSearchBar.Text) || ru.LastName.Contains(txtSearchBar.Text);
                }
                else
                    return true;
            }
            return false;
        }

        private void UpdateView()
        {
            DGTrainees.ItemsSource = null;
            //view = CollectionViewSource.GetDefaultView(FitnessCenter.Instance.RegisteredUsers);
            view = CollectionViewSource.GetDefaultView(FitnessCenter.Instance.Dbdc.GetTable<RegisteredUser>().ToList());
            /*List<RegisteredUser> lk = new List<RegisteredUser>();
            RegisteredUser testUser1 = new RegisteredUser
            {
                Name = "Marko",
                LastName = "Markovic",
                Jmbg = 2812001800011,
                Gender = EGender.M,
                //Address = new Address(),
                Email = "marko@gmail.com",
                Password = "123",
                Deleted = "N"

            };
            lk.Add(testUser1);

            RegisteredUser testUser2 = new RegisteredUser
            {
                Name = "Darko",
                LastName = "Darkevic",
                Jmbg = 3132001800011,
                Gender = EGender.M,
                //Address = new Address(),
                Email = "darko@gmail.com",
                Password = "111",
                Deleted = "N"

            };
            lk.Add(testUser2);
            view = CollectionViewSource.GetDefaultView(lk);*/
            DGTrainees.ItemsSource = view;
            DGTrainees.IsSynchronizedWithCurrentItem = true;

            DGTrainees.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            DGTrainees.SelectedItems.Clear();
        }

        private void DGTrainees_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
        }

        private void TxtSearchBar_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void AddTrainee_Click(object sender, RoutedEventArgs e)
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

        private void ModifyTrainee_Click(object sender, RoutedEventArgs e)
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
            DGTrainees.SelectedItems.Clear();

        }

        private void MIDeleteTrainee_Click(object sender, RoutedEventArgs e)
        {
//* TODO *Check how it's working
            RegisteredUser traineeToBeDeleted = view.CurrentItem as RegisteredUser;
            
            Table<RegisteredUser> users = FitnessCenter.Instance.Dbdc.GetTable<RegisteredUser>();
            IEnumerable<RegisteredUser> res = from u in users where u.Id == traineeToBeDeleted.Id select u;
            RegisteredUser ru = res.ElementAt(0);
            ru.Deleted = "D";
            FitnessCenter.Instance.Dbdc.SubmitChanges();

            UpdateView();
            view.Refresh();
        }
        // TODO Otkomentarisi i preradi metodu

        //
        /*FitnessCenter.Instance.DeleteUser(traineeToBeDeleted.Jmbg);

        int index = FitnessCenter.Instance.RegisteredUsers.ToList().FindIndex(user => user.Jmbg.Equals(traineeToBeDeleted.Jmbg));
        FitnessCenter.Instance.RegisteredUsers[index].Deleted = "D";


        UpdateView();
        view.Refresh(); */

    }
}
