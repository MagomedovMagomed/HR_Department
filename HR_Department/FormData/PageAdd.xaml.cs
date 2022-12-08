using HR_Department.AdminPage;
using HR_Department.ApplicationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для epidimology.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        private Applicant _currentApp = new Applicant();

        private int role;
        public PageAdd(Applicant appapp, int roleA)
        {
            InitializeComponent();
            if (appapp != null)
            {
                _currentApp = appapp;
                Interview.Text = appapp.Date_of_the_interview.ToString();
            }
            DataContext = _currentApp;

            Substation.ItemsSource = Entities.GetContent().Substation.ToList(); // Вывод списка подстанций
            Pos.ItemsSource = Entities.GetContent().Post.ToList(); // Вывод списка должностей
            Result.ItemsSource = Entities.GetContent().The_result_of_the_meeting.ToList(); // Вывод списка результатов встречи
            role = roleA;
            Pos.Text = appapp.Post.Name_post;
            Substation.Text = appapp.Substation.Name_substation;
            Result.Text = appapp.The_result_of_the_meeting.Name_the_result_of_the_meeting;
            //SendMessage("Добавлен новый пользователь");
        }

        //public void SendMessage(string message) // отправка сообщения телеграмм
        //{
        //    string retval = string.Empty;
        //    string token = "5407916923:AAGEa-Y_-bZgf-vrkzuv-u4a-04RitSJXW8";
        //    string chatId;


        //    foreach (var i in AppContent.Model1.User)
        //    {
        //        chatId = i.ID_TG;
        //        if (chatId != null)
        //        {
        //            string url = $"https://api.telegram.org/bot{token}/sendMessage?chat_id={chatId}&text={message}";

        //            using (var webClient = new WebClient())
        //            {
        //                retval = webClient.DownloadString(url);
        //            }
        //        }
        //    }
        //}

        private void Sav_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder(); // проверка на обязательные поля

            var subs = Substation.SelectedItem as Substation;
            var id_sub = 0;

            if (subs != null)
            {
                id_sub = subs.Id_substation;
            }

            var Res = Result.SelectedItem as The_result_of_the_meeting;
            var id_rm = 0;

            if (Res != null)
            {
                id_rm = Res.Id_the_result_of_the_meeting;
            }
            var post = Pos.SelectedItem as Post;
            var id_pos = 0;

            if (post != null)
            {
                id_pos = post.Id_post;
            }
            if (string.IsNullOrEmpty(_currentApp.Surename_applicant))
                error.AppendLine("Укажите Фамилию");
            if (string.IsNullOrEmpty(_currentApp.Name_applicant))
                error.AppendLine("Укажите Имя");
            if (string.IsNullOrEmpty(_currentApp.Lastname_applicant))
                error.AppendLine("Укажите Отчество");
            if (id_pos == 0)
                if (_currentApp.Id_applicant != 0)
                    _currentApp.Id_post = Pos.SelectedIndex;
                else
                    error.AppendLine("Укажите должность");
            if (id_rm == 0)
                if (_currentApp.Id_applicant != 0)
                    _currentApp.Id_the_result_of_the_meeting = Result.SelectedIndex;
                else
                    error.AppendLine("Укажите результат встречи");
            if (string.IsNullOrEmpty(_currentApp.SNILS))
                error.AppendLine("Укажите СНИЛС");
            if (string.IsNullOrEmpty(_currentApp.Email))
                error.AppendLine("Укажите электронную почту");
            if (string.IsNullOrEmpty(_currentApp.Date_of_the_interview.ToString()))
                error.AppendLine("Укажите фату собеседования");
            if (string.IsNullOrEmpty(_currentApp.Telephon))
                error.AppendLine("Укажите телефон");
            if (id_sub == 0)
                if (_currentApp.Id_applicant != 0)
                    _currentApp.Id_substation = Substation.SelectedIndex;
                else
                    error.AppendLine("Укажите Подстанцию");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                Applicant appobj = new Applicant()
                {
                    Surename_applicant = Surename.Text,
                    Name_applicant = Name.Text,
                    Lastname_applicant = Lastname.Text,
                    Telephon = Telephon.Text,
                    SNILS = SNILS.Text,
                    Email = Email.Text,
                    Date_of_the_interview = Interview.DisplayDate,
                    Id_post = id_pos,
                    document_education = (bool)Document.IsChecked,
                    Cover_lettter = Letter.Text,
                    Id_substation = id_sub,
                    Note = Note.Text,
                    Id_the_result_of_the_meeting = id_rm,
                    Where_by_whom_experience = Expirence.Text,
                    Id_Count_interview = 1 
                };
                ////AppFrame.frameMain.Navigate(new DataForm());
                if (_currentApp.Id_applicant == 0)
                    Entities.GetContent().Applicant.Add(_currentApp);
                try
                {
                    _currentApp.Id_post = id_pos;
                    _currentApp.Id_the_result_of_the_meeting = id_rm;
                    _currentApp.Id_substation = id_sub;
                    _currentApp.Id_Count_interview = 1;

                    AppContent.Model1.Applicant.Add(appobj);
                    //AppContent.Model1.SaveChanges();
                    Entities.GetContent().SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    
                    //MessageBox.Show("Информация сохранена!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при изменении!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Out_Click(object sender, RoutedEventArgs e) // переход как администратор или сотрудник отдела кадров
        {
            if(role == 1)
            {
                AppFrame.frameMain.Navigate(new PageAdmin());
            }
            else
            {
                AppFrame.frameMain.Navigate(new DataForm(role));
            }
        }
    }
}