using HR_Department.ApplicationData;
using HR_Department;
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
using System.Windows.Shapes;

namespace HR_Department.FormData
{
    /// <summary>
    /// Логика взаимодействия для DataForm.xaml
    /// </summary>
    public partial class DataForm : Page
    {
        public DataForm()
        {
            InitializeComponent();

            AppContent.Model1 = new ApplicantEntities1();
            Filtr.Items.Add("Все типы");
            foreach (var i in AppContent.Model1.Post)
            {
                Filtr.Items.Add(i.Name_post);
            }
            Sort.Items.Add("Без сортировки");
            Sort.Items.Add("По возрастанию");
            Sort.Items.Add("По убыванию");
            Sort.SelectedIndex = 0;
            Filtr.SelectedIndex = 0;

            var _currentAppl = ApplicantEntities1.GetContext().Applicant.ToList();
            Applicant.ItemsSource = _currentAppl;
            UpdateApplicant();
        }

        public void UpdateApplicant()
        {
            var CurrentAgent = ApplicantEntities1.GetContext().Applicant.ToList();

            if (Filtr.SelectedIndex > 0)
            {
                var test = Filtr.SelectedItem.ToString();
                CurrentAgent = CurrentAgent.Where(p => p.Post.Name_post == Filtr.SelectedItem.ToString()).ToList();
            }

            CurrentAgent = CurrentAgent.Where(p => p.Surename_applicant.ToLower().Contains(Search.Text.ToLower())).ToList();

            Applicant.ItemsSource = CurrentAgent.OrderBy(p => p.Surename_applicant).ToList();
        }

    }
}
