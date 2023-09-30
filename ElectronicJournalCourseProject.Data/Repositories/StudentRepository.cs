using ElectronicJournalCourseProject.Data.Entities;

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

        public List<LoadList> GetAllLessonsForStudent(int studentId)
        {
            var loadList = new List<LoadList>();
            var groupId = this.GetStudentById(studentId).CurrentGroupId;
            loadList = _context.LoadLists.Where(ll => ll.GroupId == groupId).ToList();

            if (loadList.Count > 0)
                return loadList;
            else 
                throw new Exception();

        }
    }
}
