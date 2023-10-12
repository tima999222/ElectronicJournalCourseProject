
using ElectronicJournalCourseProject.Data.Entities;
using ElectronicJournalCourseProject.Data.Repositories;
using System.Windows;
using System.Windows.Controls;

namespace ElectronicJournalCourseProject.WPFApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для SubjectsForStudentPage.xaml
    /// </summary>
    public partial class SubjectsForStudentPage : Page
    {
        private LoadListRepository _loadListRepository; 

        public SubjectsForStudentPage()
        {
            _loadListRepository = new LoadListRepository();
            InitializeComponent();
            var list = _loadListRepository.GetSubjectsForStudent(StudentSession.StudentId);
            DGridSubjects.ItemsSource = list;
        }

        private void ShowMarksButton_Click(object sender, RoutedEventArgs e)
        {
            var subject = DGridSubjects.SelectedItem as LoadList;

            if (subject ==  null)
            {
                MessageBox.Show("Не удалось получить имя предмета");
                return;
            }

            NavigationService.Navigate(new MarksForTheLessonPage(subject.Plan.Subject.SubjectName, subject.Teacher.TeacherId));
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            StudentSession.StudentId = 0;
        }
    }
}
