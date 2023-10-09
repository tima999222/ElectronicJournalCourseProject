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

        public List<Student> GetStudentByGroupAbbreviature(string abbreviature)
        {
            var res = _context.Students.Where(s => s.Group.Abbreviature == abbreviature).ToList();
            if (res != null) return res;

            throw new Exception();
        }
    }
}
