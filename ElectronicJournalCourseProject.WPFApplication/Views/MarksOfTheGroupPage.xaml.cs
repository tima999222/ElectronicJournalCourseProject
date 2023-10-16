using ElectronicJournalCourseProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Controls;
using System.Windows.Data;
using ElectronicJournalCourseProject.RepostExcelServise;

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
        private MarkRepository _markRepositoy;

        private string _abbreviature;
        private string _subjectName;

        public MarksOfTheGroupPage(string abbreviature, string subjectName)
        {
            _abbreviature = abbreviature;
            _subjectName = subjectName;
            _studentRepository = new StudentRepository();
            _lessonRepository = new LessonRepository();
            _markRepositoy = new MarkRepository();

            InitializeComponent();
            LoadPage();
        }

        //Метод для заполнения DataGrid данными
        #region Load Page

        private void LoadPage()
        {
            var studentsInGroup = _studentRepository.GetStudentByGroupAbbreviature(_abbreviature);

            dataTable = new DataTable();
            dataTable.Columns.Add("Студент(ка)", typeof(string));

            var dateTimesOfLesson = new List<DateTime>();

            var dates = _lessonRepository.GetLessonDatesBySubjectNameForGroup(_subjectName, _abbreviature, TeacherSession.TeacherId).Distinct().ToList();

            foreach (DateTime dt in dates)
            {
                dataTable.Columns.Add($"_{dt.Day}_{dt.Month}_{dt.Year}_", typeof(string));
                dataTable.Columns[$"_{dt.Day}_{dt.Month}_{dt.Year}_"]!.Caption = dt.ToString("dd/MM/yyyy");
                dateTimesOfLesson.Add(dt);
            }

            foreach(var st in studentsInGroup)
            {
                var row1 = dataTable.NewRow();
                row1["Студент(ка)"] = st.StudentSurname + " " + st.StudentName[0] + "." + st.StudentPatronymic[0];


                var marks = _markRepositoy.GetMarksForStudentBySubjectName(st.StudentIdNumber, _subjectName, TeacherSession.TeacherId);
                foreach (var m in marks)
                {
                    if (dateTimesOfLesson.Contains(m.Lesson.LessonDate))
                        if (m.Attendance == true)
                        {
                            row1[$"_{m.Lesson.LessonDate.Day}_{m.Lesson.LessonDate.Month}_{m.Lesson.LessonDate.Year}_"] = m.MarkValue;
                        }
                        else
                        {
                            row1[$"_{m.Lesson.LessonDate.Day}_{m.Lesson.LessonDate.Month}_{m.Lesson.LessonDate.Year}_"] = "НБ";
                        }
                       
                }
                dataTable.Rows.Add(row1);
            }

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
        }

        #endregion

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddMarkPage(_abbreviature, _subjectName));
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditMarkPage(_subjectName, _abbreviature));
        }

        private void CreateReportButton_Click(object sender, RoutedEventArgs e)
        {
            var service = new ExcelReportService(_abbreviature, _subjectName);

            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string pathToFolder = dialog.FileName;
                service.ConvertDataTableToExcel(dataTable, pathToFolder);
                MessageBox.Show("Отчет создан");
            }
        }
    }
}
