﻿#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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

        [Required]
        public int MarkValue { get; set; }

        #region Navigation

        public Lesson Lesson { get; set; }

        public Student Student { get; set; }

        #endregion
    }
}
