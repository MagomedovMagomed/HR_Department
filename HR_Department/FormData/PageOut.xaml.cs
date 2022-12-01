using HR_Department.ApplicationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для PageOut.xaml
    /// </summary>
    public partial class PageOut : Page
    {
        private Applicant _currentApp = new Applicant();

        private int role = 0;
        public PageOut(Applicant appapp, int roleA)
        {
            InitializeComponent();

            if (appapp != null)
            {
                _currentApp = appapp;
            }
            DataContext = _currentApp;

            if (Document.ToString() == "False" || Document.ToString() == "false")
            {
                Document.Content = "Не проверены";
            }
            else
            {
                Document.Content = "Проверены";
            }
            role = roleA;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new DataForm(role));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция находиться на доработке");
            //AppFrame.frameMain.Navigate(new PageAdd(_currentApp, role));
        }
    }
}
