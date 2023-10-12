using System.Windows;
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

            if (loadList == null) 
            {
                MessageBox.Show("Не удалось получить нагрузочный лист");
                return;
            }

            string abbrebiature = loadList.Group.Abbreviature;
            string subjectName = loadList.Plan.Subject.SubjectName; 

            NavigationService.Navigate(new MarksOfTheGroupPage(abbrebiature, subjectName));
        }

        private void GoBackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TeacherSession.TeacherId = 0;
            NavigationService.GoBack();
        }
    }
}
