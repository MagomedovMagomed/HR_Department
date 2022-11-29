using HR_Department.ApplicationData;
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
    /// Логика взаимодействия для epidimology.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        private Applicant _currentApp = new Applicant();
        public PageAdd(Applicant appapp)
        {
            InitializeComponent();
            if (appapp != null)
            {
                _currentApp = appapp;
            }
            DataContext = _currentApp;
            
            Substation.ItemsSource = ApplicantEntities2.GetContext().Substation.ToList(); // Вывод списка подстанций
            Pos.ItemsSource = ApplicantEntities2.GetContext().Post.ToList(); // Вывод списка должностей
            Result.ItemsSource = ApplicantEntities2.GetContext().The_result_of_the_meeting.ToList(); // Вывод списка результатов встречи
        }

        private void Sav_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            var subs = Substation.SelectedItem as Substation;
            var id_sub = 0;

            if (subs != null)
            {
                id_sub = subs.id_substation;
            }

            var Res = Result.SelectedItem as The_result_of_the_meeting;
            var id_rm = 0;

            if (Res != null)
            {
                id_rm = Res.id_the_result_of_the_meeting;
            }
            var post = Pos.SelectedItem as Post;
            var id_pos = 0;

            if (post != null)
            {
                id_pos = post.id_post;
            }
            if (string.IsNullOrEmpty(_currentApp.Surename_applicant))
                error.AppendLine("Укажите Фамилию");
            if (string.IsNullOrEmpty(_currentApp.Name_applicant))
                error.AppendLine("Укажите Имя");
            if (string.IsNullOrEmpty(_currentApp.Lastname_applicant))
                error.AppendLine("Укажите Отчество");
            if (id_pos == 0)
                error.AppendLine("Укажите должность");
            if (id_rm == 0)
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
                    id_post = id_pos,
                    documents_education = Document.IsChecked,
                    Cover_letter = Letter.Text,
                    Id_substation = id_sub,
                    Note = Note.Text,
                    id_the_result_of_the_meeting = id_rm,
                    Where_by_whom_experience = Expirence.Text
                };
                ////AppFrame.frameMain.Navigate(new DataForm());
                if (_currentApp.id_applicant == 0)
                    ApplicantEntities2.GetContext().Applicant.Add(_currentApp);
                try
                {
                    //_currentApp.id_post = id_pos;
                    //_currentApp.id_the_result_of_the_meeting = id_rm;
                    //_currentApp.Id_substation = id_sub;

                    AppContent.Model1.Applicant.Add(appobj);
                    AppContent.Model1.SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    //ApplicantEntities2.GetContext().SaveChanges();
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

        private void Out_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new DataForm());
        }
    }
}