using ElectronicJournalCourseProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

            var dateTimesOfLesson = new List<DateTime>();

            foreach (DateTime dt in _lessonRepository.GetLessonDatesBySubjectName(_subjectName))
            {
                dataTable.Columns.Add($"_{dt.Day}_{dt.Month}_{dt.Year}_", typeof(string));
                dataTable.Columns[$"_{dt.Day}_{dt.Month}_{dt.Year}_"]!.Caption = dt.ToString("dd/MM/yyyy");
                dateTimesOfLesson.Add(dt);
            }

            foreach(var st in studentsInGroup)
            {
                var row1 = dataTable.NewRow();
                row1["Студент(ка)"] = st.StudentSurname + " " + st.StudentName[0] + "." + st.StudentPatronymic[0];
                foreach (var m in st.Mark)
                {
                    if (dateTimesOfLesson.Contains(m.Lesson.LessonDate))
                        row1[$"_{m.Lesson.LessonDate.Day}_{m.Lesson.LessonDate.Month}_{m.Lesson.LessonDate.Year}_"] = m.MarkValue;
                }
                dataTable.Rows.Add(row1);
            }

            DataGrid dataGrid = new DataGrid()
            {
                IsReadOnly = true,
                AutoGenerateColumns = false
            };

            foreach (DataColumn column in dataTable.Columns)
            {
                DataGridTextColumn textColumn = new DataGridTextColumn()
                {
                    Header = column.Caption,
                    Binding = new Binding("[" + column.ColumnName + "]")
                };
                dataGrid.Columns.Add(textColumn);
            }

            dataGrid.ItemsSource = dataTable.DefaultView;

            Content = dataGrid;
        }  
    }
}
