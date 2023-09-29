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

namespace ElectronicJournalCourseProject.WPFApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        private LoginRepository _loginRepository;

        public SignInPage()
        {
            _loginRepository = new LoginRepository();
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            bool result = false;

            if (IsTeacherCheckBox.IsChecked == true)
            {
                result = _loginRepository.ValidateTeacher(login, password);
                if (result == true)
                {
                    MessageBox.Show("Вы вошли как учитель");
                }
            }
            else
            {
                result = _loginRepository.ValidateStudent(login, password);
                if (result == true)
                {
                    MessageBox.Show("Вы вошли как студент");
                }
            }

            if (result == false)
            {
                MessageBox.Show("Неправильный логин или пароль");
                return;
            }
        }
    }
}
