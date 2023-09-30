using ElectronicJournalCourseProject.Data.Entities;

namespace ElectronicJournalCourseProject.Data.Repositories
{
    public class SubjectRepository : ElectronicJournalBaseRepository<SubjectRepository>
    {
        SubjectRepository() : base() 
        { }

        public Subject GetSubjectById(int id)
        {
            var subject = _context.Subjects.FirstOrDefault(subject => subject.SubjectId == id);
            if (subject == null)
                throw new Exception();

            return subject;
        }
    }
}
