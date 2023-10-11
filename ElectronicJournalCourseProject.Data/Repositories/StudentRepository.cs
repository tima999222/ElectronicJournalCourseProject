using ElectronicJournalCourseProject.Data.Entities;
using System.Net;

namespace ElectronicJournalCourseProject.Data.Repositories
{
    public class StudentRepository : ElectronicJournalBaseRepository<Student>
    {
        public StudentRepository() : base()
        {

        }

        public Student GetStudentById(int id)
        {
            var res = GetListOfItem().FirstOrDefault(s => s.StudentIdNumber == id);
            if (res != null)
                return res;
            else
                throw new Exception();
        }

        public List<Student> GetStudentByGroupAbbreviature(string abbreviature)
        {
            var res = _context.Students.Where(s => s.Group.Abbreviature == abbreviature).ToList();
            if (res != null) return res;

            throw new Exception();
        }

        public List<Student> HaveMarkOnThisLesson(DateTime lessonDate)
        {

            var res = from student in _context.Students
                      join mark in _context.Marks on student.StudentIdNumber equals mark.StudentIdNumber
                      join _lesson in _context.Lessons on mark.LessonId equals _lesson.LessonId
                      where _lesson.LessonDate == lessonDate  
                      select student;

            return res.ToList();
        }
    }
}
