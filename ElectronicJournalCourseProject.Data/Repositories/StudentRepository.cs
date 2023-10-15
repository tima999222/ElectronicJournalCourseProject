using ElectronicJournalCourseProject.Data.Entities;
using System.Net;

namespace ElectronicJournalCourseProject.Data.Repositories
{
    public class StudentRepository : ElectronicJournalBaseRepository<Student>
    {
        public StudentRepository() : base()
        {

        }

        public Student GetStudentById(long id)
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

        public List<Student> HaveMarkOnThisLesson(DateTime lessonDate, string abbreviature, int teacherId)
        {

            var group1 = _context.Groups.FirstOrDefault(g => g.Abbreviature == abbreviature);
            var ll = _context.LoadLists.FirstOrDefault(ll => ll.TeacherId == teacherId && ll.Group.GroupCode == group1.GroupCode);

            var res = from student in _context.Students
                      join _group in _context.Groups on student.CurrentGroupId equals _group.GroupCode
                      join mark in _context.Marks on student.StudentIdNumber equals mark.StudentIdNumber
                      join _lesson in _context.Lessons on mark.LessonId equals _lesson.LessonId
                      where _lesson.LessonDate == lessonDate && ll.LoadListId == _lesson.LoadListId && _group.GroupCode == group1.GroupCode && mark.MarkValue != null
                      select student;

            return res.ToList();
        }
    }
}
