using ElectronicJournalCourseProject.Data.DataContext;
using ElectronicJournalCourseProject.Data.Repositories.Interfaces;

namespace ElectronicJournalCourseProject.Data.Repositories
{
    public class ElectronicJournalBaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ElectronicJournalContext _context;
        private string[] _options = { "TIMA\\SQLEXPRESS", "ElectronicJournalDb" };

        public ElectronicJournalBaseRepository()
        {
            var factory = new ElectronicJournalContextDesignTimeFactory();
            _context = factory.CreateDbContext(_options);
        }

        public void AddItem(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void AddItem(IEnumerable<T> items)
        {
            _context.Set<T>().AddRange(items);
            _context.SaveChanges();
        }

        public void DeleteItem(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public void DeleteItem(IEnumerable<T> items)
        {
            _context.Set<T>().RemoveRange(items);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetListOfItem()
        {
            return _context.Set<T>();
        }

        public void UpdateItem(T item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
