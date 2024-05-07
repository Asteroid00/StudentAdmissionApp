namespace StudentAdmissionAppApi.Dtos
{
    public class AddStudentDto
    {
        public int StageId { get; set; }
        public int StandardId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public bool IsPhysicallyDisabled { get; set; }
        public string Gender { get; set; }
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
    }
}
