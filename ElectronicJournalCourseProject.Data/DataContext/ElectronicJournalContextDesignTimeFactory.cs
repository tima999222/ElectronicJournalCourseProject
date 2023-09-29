using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournalCourseProject.Data.DataContext
{
    public class ElectronicJournalContextDesignTimeFactory : IDesignTimeDbContextFactory<ElectronicJournalContext>
    {
        private ElectronicJournalContext _context;

        public ElectronicJournalContext CreateDbContext(string[] args)
        {
            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ElectronicJournalContext>();
                optionsBuilder.UseSqlServer(
                    //$"Server={args[0]};Database={args[1]};Integrated Security=True;TrustServerCertificate=True"
                    "Server=TIMA\\SQLEXPRESS;Database=ElectronicJournalDb;Integrated Security=True;TrustServerCertificate=True"

                );

                _context = new ElectronicJournalContext(optionsBuilder.Options);
            }

            return _context;
        }
    }
}
