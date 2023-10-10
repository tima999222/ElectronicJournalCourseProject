using ElectronicJournalCourseProject.Data.Repositories;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ElectronicJournalCourseProject.WPFApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для MarksOfTheGroupPage.xaml
    /// </summary>
    public partial class MarksOfTheGroupPage : Page
    {
        private DataTable dataTable;

        private StudentRepository _studentRepository;
        private LessonRepository _lessonRepository;

        private string _abbreviature;
        private string _subjectName;

        public MarksOfTheGroupPage(string abbreviature, string subjectName)
        {
            _abbreviature = abbreviature;
            _subjectName = subjectName;
            _studentRepository = new StudentRepository();
            _lessonRepository = new LessonRepository();

            InitializeComponent();
            Loaded += LoadPage;
            
        }

        private void LoadPage(object sender, RoutedEventArgs e)
        {
            var studentsInGroup = _studentRepository.GetStudentByGroupAbbreviature(_abbreviature);

            dataTable = new DataTable();
            dataTable.Columns.Add("Студент(ка)", typeof(string));

            foreach (DateTime dt in _lessonRepository.GetLessonDatesBySubjectName(_subjectName))
            {
                dataTable.Columns.Add(dt.ToString("dd/MM/yyyy"), typeof(string)); 
            }

            foreach(var st in studentsInGroup)
            {
                var row1 = dataTable.NewRow();
                row1["Студент(ка)"] = st.StudentSurname + " " + st.StudentName + "." + st.StudentPatronymic;
                foreach (var m in st.Mark)
                {
                    row1[m.Lesson.LessonDate.ToString("dd/MM/yyyy")] = m.MarkValue;
                }
                dataTable.Rows.Add(row1);
            }

            dataGrid.ItemsSource = dataTable.DefaultView;
        }  
    }
}
