using ElectronicJournalCourseProject.Data.DataContext;
using ElectronicJournalCourseProject.Data.Entities;
using ElectronicJournalCourseProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Text.Json;

namespace ElectronicJournalCourseProject.Tests
{
    public class Tests
    {
        private ElectronicJournalContextDesignTimeFactory _designTimeFactory;
        private ElectronicJournalContext _context;
        private string[] _options = { "TIMA\\\\SQLEXPRESS", "ElectronicJournalDb" };
        //private string[] _options = { "DESKTOP-P72B69L\\\\SQLEXPRESS", "ElectronicJournalDb" };


        [SetUp]
        public void Setup()
        {
            _designTimeFactory = new ElectronicJournalContextDesignTimeFactory();
            _context = _designTimeFactory.CreateDbContext(_options);
            _context.Database.Migrate();
        }

        [Test]
        public void AddTeachersToDb()
        {
            string json = File.ReadAllText("C:\\Users\\Тимофей\\source\\repos\\ElectronicJournalCourseProject\\Teachers.json");
            var TeachersList = JsonSerializer.Deserialize<List<Teacher>>(json);

            if (TeachersList != null)
            {
                _context.Teachers.AddRange(TeachersList);
                _context.SaveChanges();
            }    
                
            else
                Console.WriteLine("Teachers Что то не так");
        }

        [Test]
        public void AddSubjectsToDb()
        {
            string json = File.ReadAllText("C:\\Users\\Тимофей\\source\\repos\\ElectronicJournalCourseProject\\Subjects.json");
            var SubjectsList = JsonSerializer.Deserialize<List<Subject>>(json);

            if (SubjectsList != null)
            {
                _context.Subjects.AddRange(SubjectsList);
                _context.SaveChanges();
            }

            else
                Console.WriteLine("Subjets Что то не так");
        }

        [Test]
        public void AddSpecToDb()
        {
            string json = File.ReadAllText("C:\\Users\\Тимофей\\source\\repos\\ElectronicJournalCourseProject\\Specialties.json");
            var SpecialtiesList = JsonSerializer.Deserialize<List<Specialty>>(json);

            if (SpecialtiesList != null)
            {
                _context.Specialties.AddRange(SpecialtiesList);
                _context.SaveChanges();
            }

            else
                Console.WriteLine("Specs Что то не так");
        }

        [Test]
        public void AddPlansToDb()
        {
            string json = File.ReadAllText("C:\\Users\\Тимофей\\source\\repos\\ElectronicJournalCourseProject\\Plan.json");
            var PlansList = JsonSerializer.Deserialize<List<Plan>>(json);

            if (PlansList != null)
            {
                _context.Plans.AddRange(PlansList);
                _context.SaveChanges();
            }

            else
                Console.WriteLine("Plans Что то не так");
        }

        [Test]
        public void AddGroupsToDb()
        {
            string json = File.ReadAllText("C:\\Users\\Тимофей\\source\\repos\\ElectronicJournalCourseProject\\Groups.json");
            var GroupsList = JsonSerializer.Deserialize<List<Group>>(json);

            if (GroupsList != null)
            {
                _context.Groups.AddRange(GroupsList);
                _context.SaveChanges();
            }

            else
                Console.WriteLine("Groups Что то не так");
        }

        [Test]
        public void AddStudentsToDb()
        {
            string json = File.ReadAllText("C:\\Users\\Тимофей\\source\\repos\\ElectronicJournalCourseProject\\Students.json");
            var StudentsList = JsonSerializer.Deserialize<List<Student>>(json);

            if (StudentsList != null)
            {
                _context.Students.AddRange(StudentsList);
                _context.SaveChanges();
            }

            else
                Console.WriteLine("Students Что то не так");
        }

        [Test]
        public void AddAppointmentsToDb()
        {
            string json = File.ReadAllText("C:\\Users\\Тимофей\\source\\repos\\ElectronicJournalCourseProject\\Appointments.json");
            var AppointmentsList = JsonSerializer.Deserialize<List<Appointment>>(json);

            if (AppointmentsList != null)
            {
                _context.Appointments.AddRange(AppointmentsList);
                _context.SaveChanges();
            }

            else
                Console.WriteLine("Appointments Что то не так");
        }

        [Test]
        public void AddLoadListsToDb()
        {
            string json = File.ReadAllText("C:\\Users\\Тимофей\\source\\repos\\ElectronicJournalCourseProject\\LoadList.json");
            var LoadList = JsonSerializer.Deserialize<List<LoadList>>(json);

            if (LoadList != null)
            {
                _context.LoadLists.AddRange(LoadList);
                _context.SaveChanges();
            }

            else
                Console.WriteLine("LoadList Что то не так");
        }

        [Test]
        public void AddLessonsToDb()
        {
            string json = File.ReadAllText("C:\\Users\\Тимофей\\source\\repos\\ElectronicJournalCourseProject\\Lessons.json");
            var LessonsList = JsonSerializer.Deserialize<List<Lesson>>(json);

            if (LessonsList != null)
            {
                _context.Lessons.AddRange(LessonsList);
                _context.SaveChanges();
            }

            else
                Console.WriteLine("LoadList Что то не так");
        }

        [Test]
        public void AddMarksToDb()
        {
            string json = File.ReadAllText("C:\\Users\\Тимофей\\source\\repos\\ElectronicJournalCourseProject\\Marks.json");
            var MarksList = JsonSerializer.Deserialize<List<Mark>>(json);

            if (MarksList != null)
            {
                _context.Marks.AddRange(MarksList);
                _context.SaveChanges();
            }

            else
                Console.WriteLine("Mark Что то не так");
        }


    }
}