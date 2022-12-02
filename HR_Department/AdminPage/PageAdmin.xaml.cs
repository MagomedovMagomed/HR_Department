using HR_Department.ApplicationData;
using HR_Department.FormData;
using HR_Department.PageMain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace HR_Department.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible) // Обновление вывода пользователей и соискателей
            {
                //Entities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DBApp.ItemsSource = ApplicantEntities2.GetContent().Applicant.ToList();
                DBUser.ItemsSource = ApplicantEntities2.GetContent().User.ToList();
            }
        }

        private void Edit2_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAdd((sender as Button).DataContext as Applicant, 1));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddUser((sender as Button).DataContext as User));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddUser(null));
        }

        private void Add2_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAdd(null, 1));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AuthorizationPage());
        }

        private void Otdel_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new DataForm(1));
        }
    }
}
