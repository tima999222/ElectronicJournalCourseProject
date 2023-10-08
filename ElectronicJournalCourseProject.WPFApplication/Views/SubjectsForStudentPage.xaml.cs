
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

        }
    }
}
