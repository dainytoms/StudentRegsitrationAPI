using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationAPI
{
    public class Choices
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string DisplayText { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int FieldQuestionsID { get; set; }
        public FieldQuestions? FieldQuestions { get; set; }

        public int UsersID { get; set; }
        public Users? Users { get; set; }

       
    }
}
