#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ElectronicJournalCourseProject.Data.Entities
{
    public class Mark
    {
        [Key]
        public int MarkId { get; set; }

        [Required]
        [ForeignKey(nameof(Lesson))]
        public int LessonId { get; set; }

        [Required]
        [ForeignKey(nameof(Student))]
        public long StudentIdNumber { get; set; }

        [Required]
        public bool Attendance { get; set; }

        public int? MarkValue { get; set; }

        #region Navigation

        public virtual Lesson Lesson { get; set; }

        public virtual Student Student { get; set; }

        #endregion
    }
}
