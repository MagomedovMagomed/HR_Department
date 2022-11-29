using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Windows.Shapes;
using HR_Department.ApplicationData;
using HR_Department;
using System.Data.Entity;
using System.Windows.Automation.Peers;

namespace HR_Department.FormData
{
    /// <summary>
    /// Логика взаимодействия для DataForm.xaml
    /// </summary>
    public partial class DataForm : Page
    {
        private Applicant _currentApp = new Applicant();
        public DataForm()
        {
            InitializeComponent();

            DataContext = _currentApp;

            Filtr.Items.Add("Все должности");
            Filtr2.Items.Add("Номер этапа собеседования");
            foreach (var i in AppContent.Model1.Post)
            {
                Filtr.Items.Add(i.Name_post);
            }
            foreach(var i in AppContent.Model1.Count_Interview)
            {
                Filtr2.Items.Add(i.Name_Count_Interview);
            }
            Sort.Items.Add("Без сортировки");
            Sort.Items.Add("По возрастанию");
            Sort.Items.Add("По убыванию");
            Sort.SelectedIndex = 0;
            Filtr.SelectedIndex = 0;
            Filtr2.SelectedIndex = 0;
            var _currentAppl = ApplicantEntities2.GetContext().Applicant.ToList();
            Applic.ItemsSource = _currentAppl;
            UpdateApplicant();
        }

        public void UpdateApplicant()
        {
            var CurrentAppl = ApplicantEntities2.GetContext().Applicant.ToList();

            if (Filtr.SelectedIndex > 0)
            {
                var test = Filtr.SelectedItem.ToString();
                CurrentAppl = CurrentAppl.Where(p => p.Post.Name_post == Filtr.SelectedItem.ToString()).ToList();
            }

            if (Filtr2.SelectedIndex > 0)
            {
                var test = Filtr2.SelectedItem.ToString();
                CurrentAppl = CurrentAppl.Where(p => p.Name_applicant == Filtr.SelectedItem.ToString()).ToList();
            }

            CurrentAppl = CurrentAppl.Where(p => p.Surename_applicant.ToLower().Contains(Search.Text.ToLower())).ToList();

            if (Sort.SelectedIndex == 2)
            {
                Applic.ItemsSource = CurrentAppl.OrderByDescending(p => p.Surename_applicant).ToList();
                return;
            }
            if (Sort.SelectedIndex == 1)
            {
                Applic.ItemsSource = CurrentAppl.OrderBy(p => p.Surename_applicant).ToList();
                return;
            }
            Applic.ItemsSource = CurrentAppl.OrderBy(p => p.id_applicant).ToList();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateApplicant();
        }

        private void Filtr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateApplicant();
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateApplicant();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var ApplicantRemove = Applic.SelectedItems.Cast<Applicant>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ApplicantRemove.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ApplicantEntities2.GetContext().Applicant.RemoveRange(ApplicantRemove);
                    ApplicantEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    Applic.ItemsSource = ApplicantEntities2.GetContext().Applicant.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAdd(null));
        }   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAdd((sender as Button).DataContext as Applicant));
        }

        private void Filtr2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateApplicant();
        }
    }
}