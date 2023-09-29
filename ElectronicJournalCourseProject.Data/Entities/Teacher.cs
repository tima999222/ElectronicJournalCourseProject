#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace ElectronicJournalCourseProject.Data.Entities
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]

        public string TeacherSurname { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string TeacherName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string TeacherPatronymic { get; set; }

        #region Navigation

        List<LoadList> LoadList { get; set; }

        #endregion

        #region Account 

        public string Login { get; set; }

        public string Password { get; set; }

        #endregion
    }
}
