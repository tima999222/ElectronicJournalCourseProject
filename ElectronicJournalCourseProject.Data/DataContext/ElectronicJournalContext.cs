using ElectronicJournalCourseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace ElectronicJournalCourseProject.Data.DataContext
{
    public class ElectronicJournalContext : DbContext, IElectronicJournalContext
    {
        public ElectronicJournalContext(DbContextOptions<ElectronicJournalContext> options) : base(options)
        {
        }

        #region DbSets

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LoadList> LoadLists { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoadList>()
                .HasOne(ll => ll.Plan)
                .WithMany(p => p.LoadList)
                .HasForeignKey(ll => ll.PlanId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Mark)
                .HasForeignKey(m => m.StudentIdNumber)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
