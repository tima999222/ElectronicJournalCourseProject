

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
    }
}
