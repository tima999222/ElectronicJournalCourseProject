#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ElectronicJournalCourseProject.Data.Entities
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        [Required]
        public DateTime LessonDate { get; set; }

        [Required]
        [ForeignKey(nameof(LoadList))]
        public int LoadListId { get; set; }

        #region Navigation

        public virtual LoadList LoadList { get; set; }

        public virtual List<Mark> Mark { get; set; }

        #endregion
    }
}
