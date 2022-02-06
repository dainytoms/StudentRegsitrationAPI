namespace StudentRegistrationAPI
{
    public class ApplicationQuestions
    {
        public int ID { get; set; }

        
        public int CollegeNamesID { get; set; }

        public CollegeNames? CollegeNames { get; set; }
        public int FieldQuestionsID { get; set; }
        public FieldQuestions? FieldQuestions { get; set; }

        public int QuestionTypesID { get; set; }
        public QuestionTypes? QuestionTypes { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UsersID { get; set; }
        public Users? Users { get; set; }
    }
}
