using System.Linq;
using System.Windows.Controls;
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

        }
    }
}
