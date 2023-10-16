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
        private Mark? _mark;

        private ComboBox studentComboBox;
        private TextBox markTextBox;
        private int countOfChanges = 0;

        public EditMarkPage(string subjectName, string abbreviature)
        { 
            _student = new Student();
            _mark = new Mark();

            _subjectName = subjectName;
            _abbreviature = abbreviature;

            _lessonRepository = new LessonRepository();
            _studentRepository = new StudentRepository();
            _markRepository = new MarkRepository();

            studentComboBox = new ComboBox();

            InitializeComponent();
            DatesComboBox.ItemsSource = _lessonRepository.GetLessonsBySubjectName(_subjectName);   
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DatesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            countOfChanges++;
            var lesson = DatesComboBox.SelectedItem as Lesson;
            if (lesson == null)
            {
                MessageBox.Show("Не удалось получить дату занятия");
                return;
            }

            _lessonDate = lesson.LessonDate;
            var st = _studentRepository.HaveMarkOnThisLesson(_lessonDate, _abbreviature, TeacherSession.TeacherId);
            if (countOfChanges == 1)
            {
                
                #region StackPanel editing

                Label label1 = new Label()
                {
                    FontSize = 14,
                    Content = "Выберите студента с оценкой на выбранную дату"
                };



                studentComboBox.ItemsSource = st;
                studentComboBox.DisplayMemberPath = "StudentFullName";
                    
                studentComboBox.SelectionChanged += StudentsComboBox_SelectionChanged;

                Binding binding = new Binding("Student");
                binding.Source = studentComboBox.SelectedItem;

                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(studentComboBox);

                #endregion
            }
            else
            {
                studentComboBox.ItemsSource = st;
            }

        }

        private void StudentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _student = studentComboBox.SelectedItem as Student;

            if (_student == null)
            {
                MessageBox.Show("Не удалось получить студента");
                return;
            }

            _mark = _markRepository.GetMarkOnLessonForStudent(_lessonDate, _student);

            if (_mark == null)
            {
                MessageBox.Show("Не удалось получить оценку для студента");
                return;
            }

            #region StackPanel editing

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

            #endregion
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int markValue = int.Parse(markTextBox.Text);

                if (markValue < 2 || markValue > 5)
                {
                    MessageBox.Show("Оценка должна быть в формате от 2 до 5");
                    return;
                }

            
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
