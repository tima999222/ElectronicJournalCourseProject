using System.Windows.Controls;
using ElectronicJournalCourseProject.Data.Entities;
using ElectronicJournalCourseProject.Data.Repositories;

namespace ElectronicJournalCourseProject.WPFApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для GroupsOfTeacherPage.xaml
    /// </summary>
    public partial class GroupsOfTeacherPage : Page
    {
        private LoadListRepository _loadListRepository;

        public GroupsOfTeacherPage()
        {
            InitializeComponent();
            _loadListRepository = new LoadListRepository();
            DGridGroups.ItemsSource = _loadListRepository.GetGroupsAnsSubjectsForTeacher(TeacherSession.TeacherId);
        }

        private void EditButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var loadList = DGridGroups.SelectedItem as LoadList;

            string abbrebiature = loadList.Group.Abbreviature; //"ПКС-403";
            string subjectName = loadList.Plan.Subject.SubjectName; //"Физическая культура";

            NavigationService.Navigate(new MarksOfTheGroupPage(abbrebiature, subjectName));
        }

        private void GoBackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TeacherSession.TeacherId = 0;
            NavigationService.GoBack();
        }
    }
}
