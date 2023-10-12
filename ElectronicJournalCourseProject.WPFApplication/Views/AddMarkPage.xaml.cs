using ElectronicJournalCourseProject.Data.Entities;
using ElectronicJournalCourseProject.Data.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ElectronicJournalCourseProject.WPFApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для AddMarkPage.xaml
    /// </summary>
    public partial class AddMarkPage : Page
    {
        private StudentRepository _studentRepository;
        private LoadListRepository _loadListRepository;
        private LessonRepository _lessonRepository;
        private MarkRepository _markRepository;

        private Mark _currentMark;

        private string _abbreviature;
        private string _subjectName;

        public AddMarkPage(string abbreviature, string subjectName)
        {
            _studentRepository = new StudentRepository();
            _loadListRepository = new LoadListRepository();
            _lessonRepository = new LessonRepository();
            _markRepository = new MarkRepository();

            _abbreviature = abbreviature;
            _subjectName = subjectName;

            _currentMark = new Mark();

            InitializeComponent();

            StudentsComboBox.ItemsSource = _studentRepository.GetStudentByGroupAbbreviature(_abbreviature);
        }



        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var ll = _loadListRepository.GetLoadListByTeacherAndSubjectAndGroup(TeacherSession.TeacherId, _abbreviature, _subjectName);

            if (ll == null)
            {
                MessageBox.Show("Невозможно получить нагрузочный лист");
                return;
            }

            var selectedDate = LessonDatePicker.SelectedDate;

            if (selectedDate == null)
            {
                MessageBox.Show("Дата не выбрана");
                return;
            }
            var lesson = new Lesson() { LessonDate = (DateTime)selectedDate, LoadListId = ll.LoadListId };

            try
            {
                _lessonRepository.AddItem(lesson);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var student = StudentsComboBox.SelectedItem as Student;

            StringBuilder errors = new StringBuilder();

            if (student != null)
            {
                _currentMark.StudentIdNumber = student.StudentIdNumber;
                _currentMark.MarkValue = int.Parse(MarkTextBox.Text);
                _currentMark.Attendance = true;
                _currentMark.LessonId = lesson.LessonId;
            }

            if (_currentMark.MarkValue < 2 || _currentMark.MarkValue > 5) errors.AppendLine("Оценка должна быть в формате от 2 до 5");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
          

            try
            {
                _markRepository.AddItem(_currentMark);
                MessageBox.Show("Информация о занятии и оценке добавлена");
                NavigationService.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
