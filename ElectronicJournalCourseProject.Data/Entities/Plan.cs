#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace ElectronicJournalCourseProject.Data.Entities
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }

        [Required]
        [ForeignKey(nameof(Specialty))]
        public int SpecialtyCode { get; set; }

        [Required]
        public int SemesterNumber { get; set; }

        [Required]
        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }

        [Required]
        public int HoursCount { get; set; }

        [Required]
        public int AcademicYear { get; set; }

        #region Navigation

        public virtual Subject Subject { get; set; }

        public virtual Specialty Specialty { get; set; }


        public virtual List<LoadList> LoadList { get; set; }

        #endregion
    }
}
