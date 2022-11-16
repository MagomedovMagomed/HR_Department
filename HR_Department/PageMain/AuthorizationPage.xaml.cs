using HR_Department.ApplicationData;
using HR_Department;
using HR_Department.PageMain;
using HR_Department.Properties;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace HR_Department.PageMain
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var usetObj = AppContent.Model1.User.FirstOrDefault(x => x.Login == login.Text && x.Password == password.Password);
                if (usetObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (usetObj.id_role)
                    {
                        case 1:
                            AppFrame.frameMain.Navigate(new FormData.DataForm());
                            MessageBox.Show("Здравствуйте, Администратор " + usetObj.Login + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;  
                        case 2:
                            AppFrame.frameMain.Navigate(new FormData.DataForm());
                            MessageBox.Show("Здравствуйте, Эпидимиолог " + usetObj.Login + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 3:
                            AppFrame.frameMain.Navigate(new FormData.DataForm());
                            MessageBox.Show("Здравствуйте, Сотрудник отдела кадров " + usetObj.Login + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены !", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
