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
    /// Interaction logic for AllTrainingsWindow.xaml
    /// </summary>
    public partial class AllTrainingsWindow : Window
    {

        ICollectionView view;
        public AllTrainingsWindow()
        {
            InitializeComponent();

            UpdateView();
            view.Filter=CustomFilter;
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
            //view = CollectionViewSource.GetDefaultView(FitnessCenter.Instance.RegisteredUsers);
            view = CollectionViewSource.GetDefaultView(FitnessCenter.Instance.Dbdc.GetTable<Training>().ToList());

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

        private void AddTraining_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ModifyTraining_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteTraining_Click(object sender, RoutedEventArgs e)
        {
            Training trainingToBeDeleted = view.CurrentItem as Training;

            if(trainingToBeDeleted == null) { return; }

            Table<Training> trainings = FitnessCenter.Instance.Dbdc.GetTable<Training>();
            IEnumerable<Training> res = from t in trainings where t.Tr_id == trainingToBeDeleted.Tr_id select t;
            Training tr = res.ElementAt(0);
            tr.Deleted = "D";
            FitnessCenter.Instance.Dbdc.SubmitChanges();

            UpdateView();
            view.Filter = CustomFilter;
            view.Refresh();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
                FitnessCenter.Instance.LoggedUser = null;
                new MainWindow().Show();
                this.Close();
        }

        private void ShowUsers_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new TraineesWindow().Show();
            this.Close();
        }

        private void ShowInstructors_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new InstructorsWindow().Show();
            this.Close();
        }
    }
}
