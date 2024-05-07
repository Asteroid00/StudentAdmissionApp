namespace StudentAdmissionMVC.ViewModels
{
    public class StandardViewModel
    {
        public int StandardId { get; set; }

        public string StandardName { get; set; }


        public string TeacherName { get; set; }

        public int StageId { get; set; }

        public string StageName { get; set; }

        public string StageDescription { get; set; }


        public StandardStageViewModel Stage { get; set; }
    }
}
