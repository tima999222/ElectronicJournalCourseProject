#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicJournalCourseProject.Data.Entities
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string SubjectName { get; set; }

        #region Navigation

        public List<Plan> Plan { get; set; }

        #endregion
    }
}
