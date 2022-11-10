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

            

            var _currentAppl = ApplicantEntities1.GetContext().Applicant.ToList();
            Applicant.ItemsSource = _currentAppl;
        }
    }
}
