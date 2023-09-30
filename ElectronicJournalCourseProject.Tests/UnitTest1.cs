using ElectronicJournalCourseProject.Data.DataContext;
using ElectronicJournalCourseProject.Data.Entities;
using ElectronicJournalCourseProject.Data.Repositories;
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
        }

        [Test]
        public void Test1()
        {
            string json = File.ReadAllText("C:\\Users\\Тимофей\\source\\repos\\ElectronicJournalCourseProject\\Teachers.json");
            var TeachersList = JsonSerializer.Deserialize<List<Teacher>>(json);

            if (TeachersList != null)
                _context.Teachers.AddRange(TeachersList);
            else
                Console.WriteLine("Ты пидор");
        }
    }
}