using HR_Department.ApplicationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для PageEdit2.xaml
    /// </summary>
    public partial class PageEdit2 : Page
    {
        private Applicant _currentApp = new Applicant();
        private Applicant applicant;
        private string send_name;
        private string send_surename;
        private string send_lasrname;
        private string send_letter;
        private bool send_document;
        private string send_date;
        private int send_post;
        private Int64 send_telephon;
        private Int64 send_SNILS;
        private string send_email;
        private Substation send_sub;
        private string send_note;
        private The_result_of_the_meeting send_result;
        private string send_expirence;
        public PageEdit2(Applicant appapp)
        {
            InitializeComponent();

            Substation.ItemsSource = ApplicantEntities2.GetContext().Substation.ToList();

            Result.ItemsSource = ApplicantEntities2.GetContext().The_result_of_the_meeting.ToList();

            if (appapp != null)
            {
                _currentApp = appapp;
            }
            DataContext = _currentApp;
        }

        public PageEdit2(Applicant applicant, string send_name, string send_surename, string send_lasrname, string send_letter, bool send_document, string send_date, int send_post, int send_telephon, int send_SNILS, string send_email, Substation send_sub, string send_note, The_result_of_the_meeting send_result, string send_expirence)
        {
            this.applicant = applicant;
            this.send_name = send_name;
            this.send_surename = send_surename;
            this.send_lasrname = send_lasrname;
            this.send_letter = send_letter;
            this.send_document = send_document;
            this.send_date = send_date;
            this.send_post = send_post;
            this.send_telephon = send_telephon;
            this.send_SNILS = send_SNILS;
            this.send_email = send_email;
            this.send_sub = send_sub;
            this.send_note = send_note;
            this.send_result = send_result;
            this.send_expirence = send_expirence;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageEdit((sender as Button).DataContext as Applicant));
        }

        private void Out_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new DataForm());
        }

        private void Save_Click_1(object sender, RoutedEventArgs e)
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
            var post = send_post;
            var id_pos = 0;

            if (post != null)
            {
                id_pos = post;
            }


            if (string.IsNullOrEmpty(_currentApp.Surename_applicant))
                error.AppendLine("Укажите Фамилию");
            if (string.IsNullOrEmpty(_currentApp.Name_applicant))
                error.AppendLine("Укажите Имя");
            if (string.IsNullOrEmpty(_currentApp.Lastname_applicant))
                error.AppendLine("Укажите Отчество");
            if (id_pos == 0)
                error.AppendLine("Укажите должность");
            if (SNILS == null)
                error.AppendLine("Укажите СНИЛС");
            if (string.IsNullOrEmpty(_currentApp.Email))
                error.AppendLine("Укажите электронную почту");
            if (string.IsNullOrEmpty(_currentApp.Date_of_the_interview.ToString()))
                error.AppendLine("Укажите фату собеседования");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                Applicant appobj = new Applicant()
                {
                    Surename_applicant = send_surename.ToString(),
                    Name_applicant = send_name.ToString(),
                    Lastname_applicant = send_lasrname.ToString(),
                    Telephon = Telephon.ToString(),
                    SNILS = SNILS.ToString(),
                    Email = Email.ToString(),
                    Date_of_the_interview = Convert.ToDateTime(send_date),
                    id_post = id_pos,
                    documents_education = send_document,
                    Cover_letter = send_letter,
                    Id_substation = id_sub,
                    Note = Note.Text,
                    id_the_result_of_the_meeting = id_rm,
                    Where_by_whom_experience = Expirence.Text
                };
                if (_currentApp.id_applicant == 0)
                    ApplicantEntities2.GetContext().Applicant.Add(_currentApp);
                try
                {
                    _currentApp.id_post = id_pos;
                    _currentApp.id_the_result_of_the_meeting = id_rm;
                    _currentApp.Id_substation = id_sub;
                    AppContent.Model1.Applicant.Add(appobj);
                    AppContent.Model1.SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    AppFrame.frameMain.GoBack();
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
            AppFrame.frameMain.Navigate(new DataForm());
        }
    }
}