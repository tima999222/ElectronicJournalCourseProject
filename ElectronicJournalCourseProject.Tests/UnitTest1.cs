using ElectronicJournalCourseProject.Data.DataContext;
using ElectronicJournalCourseProject.Data.Entities;
using ElectronicJournalCourseProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ElectronicJournalCourseProject.Tests
{
    public class Tests
    {
        private ElectronicJournalContextDesignTimeFactory _designTimeFactory;
        private ElectronicJournalContext _context;
        private string[] _options = { "TIMA\\SQLEXPRESS", "ElectronicJournalDb" };


        [SetUp]
        public void Setup()
        {
            _designTimeFactory = new ElectronicJournalContextDesignTimeFactory();
            _context = _designTimeFactory.CreateDbContext(_options);
            _context.Database.Migrate();
        }

        [Test]
        public void Test1()
        {
            string json = File.ReadAllText("C:\\Users\\Тимофей\\source\\repos\\ElectronicJournalCourseProject\\Appointments.json");
            var TeachersList = JsonSerializer.Deserialize<List<Appointment>>(json);

            if (TeachersList != null)
            {
                _context.Appointments.AddRange(TeachersList);
                _context.SaveChanges();
            }    
                
            else
                Console.WriteLine("Ты пидор");
        }
    }
}