using StudentAdmissionAppApi.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentAdmissionAppApi.Dtos
{
    public class StudentDto
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public int StageId { get; set; }

        [Required]
        public int StandardId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string StudentEmail { get; set; }

        [Required]
        public bool IsPhysicallyDisabled { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfApplication { get; set; }
        public string Image { get; set; }
        public decimal? Maths { get; set; }
        public decimal? Science { get; set; }
        public decimal? SocialStudies { get; set; }
        public decimal? Hindi { get; set; }
        public decimal? English { get; set; }
        public decimal? Chemistry { get; set; }
        public decimal? Biology { get; set; }
        public decimal? Physics { get; set; }
        public decimal? TotalMarks { get; set; }
        public decimal? Percentages { get; set; }
        public bool? IsAdmisisonConfirmed { get; set; }

        public Stages Stages { get; set; }

        public Standards Standards { get; set; }
    }
}
