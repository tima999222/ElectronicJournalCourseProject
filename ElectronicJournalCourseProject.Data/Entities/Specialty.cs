#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicJournalCourseProject.Data.Entities
{
    public class Specialty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SpecialtyCode { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string SpecialtyName { get; set; }

        #region Navigation

        public virtual List<Plan> Plan { get; set; }

        public virtual List<Group> Group { get; set; }

        #endregion
    }
}
