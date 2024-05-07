namespace StudentAdmissionAppApi.Dtos
{
    public class ThreeSubDto
    {
        public int StudentId { get; set; }
        public int StageId { get; set; }
        public int StandardId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public bool IsPhysicallyDisabled { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfApplication { get; set; }
        public string Image { get; set; }

        public decimal? Chemistry { get; set; }
        public decimal? Biology { get; set; }
        public decimal? Physics { get; set; }
    }
}
