using ElectronicJournalCourseProject.Data.Entities;

namespace ElectronicJournalCourseProject.Data.Repositories
{
    public class MarkRepository : ElectronicJournalBaseRepository<Mark>
    {
        public MarkRepository() : base() 
        { }

        public List<int> GetAllMarksForStudentBySubjectName(int studentId, string subjectName)
        {
            var marks = _context.Marks.ToList();
            var lessons = _context.Lessons.ToList();
            var loadLists = _context.LoadLists.ToList();
            var plans = _context.Plans.ToList();
            var subjects = _context.Subjects.ToList();

            var marksValues = (
                    from mark in marks
                    where mark.StudentIdNumber == studentId
                    join lesson in lessons on mark.LessonId equals lesson.LessonId
                    join loadList in loadLists on lesson.LoadListId equals loadList.LoadListId
                    join plan in plans on loadList.PlanId equals plan.PlanId
                    join subject in subjects on plan.SubjectId equals subject.SubjectId
                    where subject.SubjectName == subjectName
                    select mark.MarkValue
                );

            return marksValues.ToList();
        }

        public bool IsStudentWithMarkOnDate(int studentId, DateTime date, string subjectName)
        {
            throw new NotImplementedException();
        }
    }
}
