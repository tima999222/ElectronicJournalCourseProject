using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournalCourseProject.Data.DataContext
{
    public class ElectronicJournalContextDesignTimeFactory : IDesignTimeDbContextFactory<ElectronicJournalContext>
    {
        private ElectronicJournalContext? _context;
        private string? _connectionString;


        public ElectronicJournalContext CreateDbContext(string[] args)
        {
            if (_context == null)
            {
                _connectionString = "Server=DESKTOP-P72B69L\\SQLEXPRESS;Database=ElectronicJournalDb;Integrated Security=True;TrustServerCertificate=True";

                var optionsBuilder = new DbContextOptionsBuilder<ElectronicJournalContext>();
                optionsBuilder.UseSqlServer(
                    _connectionString 
                );

                _context = new ElectronicJournalContext(optionsBuilder.Options);
            }

            return _context;
        }
    }
}
