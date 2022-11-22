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
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
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
        public PageEdit(Applicant appapp)
        {
            InitializeComponent();
            Post.ItemsSource = ApplicantEntities2.GetContext().Post.ToList();

            if(appapp != null)
            {
                _currentApp = appapp;
            }
            DataContext = _currentApp;
            Post.SelectedIndex = send_post;
            Interview.DisplayDate = Convert.ToDateTime(send_date);
        }
        public PageEdit(Applicant applicant, string send_name, string send_surename, string send_lasrname, string send_letter, bool send_document, string send_date, int send_post, int send_telephon, int send_SNILS, string send_email, Substation send_sub, string send_note, The_result_of_the_meeting send_result, string send_expirence)
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

        private void Out_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new DataForm());
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            string Send_name = Name.Text;
            string Send_letter = Letter.Text;
            string Send_surename = Surename.Text;
            string Send_lasrname = Lastname.Text;
            bool Send_document = (bool)Document.IsChecked;
            string Send_date = Interview.DataContext.ToString();
            int Send_post = Post.SelectedIndex;
            AppFrame.frameMain.Navigate(new PageEdit2((sender as Button).DataContext as Applicant));
        }
        private void DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            //Interview.DisplayDateStart = DateTime.Now;
            //Interview.DisplayDateEnd = DateTime.Now + TimeSpan.FromDays(31);

            //var minDate = Interview.DisplayDateStart ?? DateTime.MinValue;
            //var maxDate = Interview.DisplayDateEnd ?? DateTime.MaxValue;

            //for (var d = minDate; d <= maxDate && DateTime.MaxValue > d; d = d.AddDays(1))
            //{
            //    if (d.DayOfWeek == DayOfWeek.Wednesday || d.DayOfWeek == DayOfWeek.Tuesday || d.DayOfWeek == DayOfWeek.Sunday || d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Friday)
            //    {
            //        Interview.BlackoutDates.Add(new CalendarDateRange(d));
            //    }
            //}
        }

        private void Interview_CalendarOpened(object sender, RoutedEventArgs e)
        {

        }
    }
}
