using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentAdmissionMVC.ViewModels
{
    public class UpdateStudentViewModel
    {
        public int studentId { get; set; }

        [Required(ErrorMessage = "Student Name is required.")]
        [StringLength(15)]
        [DisplayName("Student Name")]
        public string studentName { get; set; }

        [Required(ErrorMessage = "Stage Id is required.")]
        public int StageId { get; set; }


        /* [Required(ErrorMessage = "Stage Name is required.")]
         [DisplayName("Stage Name")]
         public string stageName { get; set; }*/


        [Required(ErrorMessage = "Standard is required.")]
        public string StandardId { get; set; }


        /*[Required(ErrorMessage = "Student Name is required.")]
        [DisplayName("Standard Name")]
        public string StandardName { get; set; }*/


        [Required(ErrorMessage = "Student Email is required.")]
        [DisplayName("Student Email")]
        public string StudentEmail { get; set; }


        [Required(ErrorMessage = "required.")]
        [DisplayName("Physically Disabled")]
        public bool IsPhysicallyDisabled { get; set; }


        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Admission date is required.")]
        [DisplayName("Admission date")]
        public DateTime dateOfApplication { get; set; }

        public string Image { get; set; }

        public decimal maths { get; set; }
        public decimal Science { get; set; }
        public decimal SocialStudies { get; set; }
        public decimal Hindi { get; set; }
        public decimal English { get; set; }
        public decimal Chemistry { get; set; }
        public decimal Biology { get; set; }
        public decimal Physics { get; set; }
        public decimal TotalMarks { get; set; }
        public decimal Percentages { get; set; }

        public decimal IsAddmissionConfirmed { get; set; }


        public List<StandardStageViewModel>? Stages { get; set; }
        public List<StandardViewModel>? Standards { get; set; }

        public StandardViewModel? standardViewModel { get; set; }

        public StandardStageViewModel? standardStageViewModel { get; set; }
    }
}
