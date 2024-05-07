namespace StudentAdmissionAppApi.Dtos
{
    public class StandardDto
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public string ClassTeacherName { get; set; }

        public int StageId { get; set; }
        public string StageName { get; set; }
        public string StageDescription { get; set; }
        public StageDto? Stage { get; set; }
    }
}
