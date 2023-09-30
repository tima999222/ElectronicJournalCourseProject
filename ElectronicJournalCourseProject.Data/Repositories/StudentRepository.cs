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
    }
}
