﻿
using ElectronicJournalCourseProject.Data.Entities;
using ElectronicJournalCourseProject.Data.Repositories;
using System.Linq;
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
            NameLabel.Content = StudentSession.StudentName;
            UpdateGroups();
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

        private void UpdateGroups()
        {
            var subjects = _loadListRepository.GetSubjectsForStudent(StudentSession.StudentId);

            subjects = subjects.Where(s => s.Plan.Subject.SubjectName.ToLower().Contains(FindTextBox.Text.ToLower())).ToList();
            DGridSubjects.ItemsSource = subjects;
        }

        private void FindTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateGroups();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            StudentSession.StudentId = 0;
        }
    }
}
