using ElectronicJournalCourseProject.Data.Entities;

namespace ElectronicJournalCourseProject.Data.Repositories
{
    public class MarkRepository : ElectronicJournalBaseRepository<Mark>
    {
        public MarkRepository() : base() 
        { }

        public Mark? GetMarkOnLessonForStudent(DateTime lessonDate, Student student)
        {
            var lesson = _context.Marks.FirstOrDefault(l => l.Lesson.LessonDate == lessonDate && l.StudentIdNumber == student.StudentIdNumber);

            if (lesson == null)
            {
                return null;
            }

            var res = _context.Marks.FirstOrDefault(m => m.LessonId == lesson.LessonId && m.StudentIdNumber == student.StudentIdNumber);

            return res;
        }

        public List<Mark> GetAllMarksForStudentLesson(string subjectName, long studentId, int teacherId) 
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentIdNumber == studentId);
            var ll = new LoadListRepository().GetLoadListByTeacherAndSubjectAndGroup(teacherId, student.Group.Abbreviature, subjectName);

            var marks = _context.Marks.Where(m => m.StudentIdNumber == studentId 
            && m.Lesson.LoadListId == ll.LoadListId 
            && ll.Plan.Subject.SubjectName == subjectName)
                .ToList();

            return marks;
        }
    }
}
