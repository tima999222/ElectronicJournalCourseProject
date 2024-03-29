﻿#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ElectronicJournalCourseProject.Data.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentIdNumber { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string StudentSurname { get; set; }


        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string StudentName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string StudentPatronymic { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [ForeignKey(nameof(Group))]
        public int CurrentGroupId { get; set; }

        #region Navigation

        public virtual Group Group { get; set; }

        public virtual List<Appointment> Appointment { get; set; }

        public virtual List<Mark> Mark { get; set; }

        #endregion

        #region Account 

        public string Login { get; set; }

        public string Password { get; set; }

        #endregion

        [NotMapped]
        public string StudentFullName
        {
            get
            {
                return StudentSurname + " " + StudentName + " " + StudentPatronymic;
            }
        }
    }
}
