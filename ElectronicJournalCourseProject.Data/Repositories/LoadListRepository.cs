

using ElectronicJournalCourseProject.Data.Entities;

namespace ElectronicJournalCourseProject.Data.Repositories
{
    public class LoadListRepository : ElectronicJournalBaseRepository<LoadList>
    {
        public LoadListRepository() : base()
        { }

        public List<LoadList> GetAllLoadListsForStudentById(int studentId)
        {
            var loadList = new List<LoadList>();
            // groupId = this.GetStudentById(studentId).CurrentGroupId;
            var student = _context.Students.FirstOrDefault(s => s.StudentIdNumber == studentId);

            if (student == null)
                throw new Exception();

            var groupId = student.CurrentGroupId;
            loadList = _context.LoadLists.Where(ll => ll.GroupId == groupId).ToList();

            if (loadList.Count > 0)
                return loadList;
            else
                throw new Exception();

        }

        public List<LoadList> GetGroupsAnsSubjectsForTeacher(int teacherId)
        {
            var query = from loadList in _context.LoadLists
                        join teacher in _context.Teachers on loadList.TeacherId equals teacher.TeacherId
                        where teacher.TeacherId == teacherId
                        select loadList;

            return query.ToList();
        }

        public List<LoadList> GetSubjectsForStudent(long studentId)
        {
            var query = from loadList in _context.LoadLists
                        join _group in _context.Groups on loadList.GroupId equals _group.GroupCode
                        join student in _context.Students on _group.GroupCode equals student.CurrentGroupId
                        where student.StudentIdNumber == studentId
                        select loadList;

            return query.ToList();
        }

        public LoadList GetLoadListByTeacherAndSubjectAndGroup(int teacherId, string abbreviature, string subjectName)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Abbreviature == abbreviature);
            var spec = group.Specialty;

            var plan = _context.Plans.FirstOrDefault(p => p.SpecialtyCode == spec.SpecialtyCode && p.Subject.SubjectName == subjectName);

            var loadList = _context.LoadLists.FirstOrDefault(ll => ll.PlanId == plan.PlanId && ll.TeacherId == teacherId && ll.GroupId == group.GroupCode);

            return loadList;
        }
    }
}
