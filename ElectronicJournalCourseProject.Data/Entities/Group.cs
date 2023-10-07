#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ElectronicJournalCourseProject.Data.Entities
{
    public class Group
    {
        [Key]
        public int GroupCode { get; set; }

        [Required]
        [ForeignKey(nameof(Specialty))]
        public int SpecialtyCode { get; set; }

        [Required]
        public string Abbreviature { get; set; }

        #region Navigation

        public virtual Specialty Specialty { get; set; }

        public virtual List<LoadList> LoadList { get; set; }

        public virtual List<Student> Student { get; set; }

        #endregion
    }
}
