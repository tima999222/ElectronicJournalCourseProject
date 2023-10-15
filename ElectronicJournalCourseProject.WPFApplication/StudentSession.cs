
using ElectronicJournalCourseProject.Data.Repositories;

namespace ElectronicJournalCourseProject.WPFApplication
{
    public static class StudentSession
    {
        public static long StudentId { get; set; } = 0;

        public static string? StudentName
        {
            get
            {
                return new StudentRepository().GetStudentById(StudentId).StudentFullName;
            }
        }
    }
}
