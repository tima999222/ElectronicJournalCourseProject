using ElectronicJournalCourseProject.Data.Repositories;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace ElectronicJournalCourseProject.WPFApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для MarksForTheLesson.xaml
    /// </summary>
    public partial class MarksForTheLessonPage : Page
    {
        private MarkRepository _markRepository;

        public MarksForTheLessonPage(string subjectName, int teacherId)
        {
            _markRepository = new MarkRepository();

            InitializeComponent();
            DGridMarks.ItemsSource = _markRepository.GetAllMarksForStudentLesson(subjectName, StudentSession.StudentId, teacherId);
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
