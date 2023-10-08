
using System.Windows.Controls;
using System.Windows;
using ElectronicJournalCourseProject.Data.Repositories;

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
                    TeacherSession.TeacherId = _loginRepository.GetTeacherNameByLoginAndPassword(login, password);
                    NavigationService.Navigate(new GroupsOfTeacherPage());
                }
            }
            else
            {
                result = _loginRepository.ValidateStudent(login, password);
                if (result == true)
                {
                    MessageBox.Show("Вы вошли как студент");
                    StudentSession.StudentId = _loginRepository.GetStudentIdByLoginAndPassword(login, password);
                    NavigationService.Navigate(new SubjectsForStudentPage());
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
