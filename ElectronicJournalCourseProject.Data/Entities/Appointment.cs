
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicJournalCourseProject.Data.Entities
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        [ForeignKey(nameof(Student))]
        public long StudentIdNumber { get; set; }

        [Required]
        public int GroupId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public DateTime? DropOutDate { get; set; }

        #region Navigation

        public Student Student { get; set; }

        #endregion
    }
}
