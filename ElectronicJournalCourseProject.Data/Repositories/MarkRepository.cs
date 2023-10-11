using ElectronicJournalCourseProject.Data.Entities;

namespace ElectronicJournalCourseProject.Data.Repositories
{
    public class MarkRepository : ElectronicJournalBaseRepository<Mark>
    {
        public MarkRepository() : base() 
        { }

        public Mark GetMarkOnLessonForStudent(DateTime lessonDate, Student student)
        {
            var lesson = _context.Marks.FirstOrDefault(l => l.Lesson.LessonDate == lessonDate && l.StudentIdNumber == student.StudentIdNumber);

            var res = _context.Marks.FirstOrDefault(m => m.LessonId == lesson.LessonId && m.StudentIdNumber == student.StudentIdNumber);

            return res;
        }
    }
}
