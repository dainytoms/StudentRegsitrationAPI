using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationAPI
{
    public class StudentSubmissions
    {
        public int ID { get; set; }


        public int CollegeNamesID { get; set; }

        public CollegeNames? CollegeNames { get; set; }
        public int ApplicationQuestionsID { get; set; }
        public ApplicationQuestions? ApplicationQuestions { get; set; }

        [StringLength(20)]
        public string Answers { get; set; }=string.Empty;

        public bool IsActive { get; set; }

        public int DetailsCategoryID { get; set; }
        public DetailsCategory? DetailsCategory { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UsersID { get; set; }
        public Users? Users { get; set; }
    }
}
