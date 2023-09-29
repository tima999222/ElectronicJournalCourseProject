#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ElectronicJournalCourseProject.Data.Entities
{
    public class LoadList
    {
        [Key]
        public int LoadListId { get; set; }

        [Required]
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }

        [Required]
        [ForeignKey(nameof(Plan))]
        public int PlanId { get; set; }

        [Required]
        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        #region Navigation

        public Plan Plan { get; set; }

        public Teacher Teacher { get; set; }

        public Group Group { get; set; }

        public List<Lesson> Lesson { get; set; }

        #endregion
    }
}
