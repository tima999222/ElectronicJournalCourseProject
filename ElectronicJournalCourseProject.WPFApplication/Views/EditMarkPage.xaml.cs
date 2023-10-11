using ElectronicJournalCourseProject.Data.Entities;
using ElectronicJournalCourseProject.Data.Repositories;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;

namespace ElectronicJournalCourseProject.WPFApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для EditMarkPage.xamlc
    /// </summary>
    public partial class EditMarkPage : Page
    {
        
        private LessonRepository _lessonRepository;
        private StudentRepository _studentRepository;
        private MarkRepository _markRepository;

        private string _subjectName;
        private string _abbreviature;

        private DateTime _lessonDate;
        private Student _student;
        private Mark _mark;

        private ComboBox studentComboBox;
        private TextBox markTextBox;

        public EditMarkPage(string subjectName, string abbreviature)
        { 
            _student = new Student();
            _mark = new Mark();

            _subjectName = subjectName;
            _abbreviature = abbreviature;

            _lessonRepository = new LessonRepository();
            _studentRepository = new StudentRepository();
            _markRepository = new MarkRepository();

            InitializeComponent();
            DatesComboBox.ItemsSource = _lessonRepository.GetLessonsBySubjectName(_subjectName);   
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DatesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lesson = DatesComboBox.SelectedItem as Lesson;
            _lessonDate = lesson.LessonDate;    

            Label label1 = new Label()
            {
                FontSize = 14,
                Content = "Выберите студента с оценкой на выбранную дату"
            };

            studentComboBox = new ComboBox()
            {
                ItemsSource = _studentRepository.HaveMarkOnThisLesson(_lessonDate),
                DisplayMemberPath = "StudentFullName"
            };

            studentComboBox.SelectionChanged += StudentsComboBox_SelectionChanged;

            Binding binding = new Binding("Student");
            binding.Source = studentComboBox.SelectedItem;

            stackPanel.Children.Add(label1);
            stackPanel.Children.Add(studentComboBox);
        }

        private void StudentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _student = studentComboBox.SelectedItem as Student;
            _mark = _markRepository.GetMarkOnLessonForStudent(_lessonDate, _student);

            markTextBox = new TextBox()
            {
                FontSize = 14,
                Height = 30,
                Text = _mark.MarkValue.ToString()
            };

            Button saveButton = new Button()
            {
                Height = 30,
                Margin = new Thickness(0, 5, 0, 0),
                Content = "Сохранить"
            };

            saveButton.Click += SaveButton_Click;

            stackPanel.Children.Add(markTextBox);
            stackPanel.Children.Add(saveButton);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int markValue = int.Parse(markTextBox.Text);

            try
            {
                _mark.MarkValue = markValue;
                _markRepository.UpdateItem(_mark);
                MessageBox.Show("Оценка отредактирована");
                NavigationService.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
