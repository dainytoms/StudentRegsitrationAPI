using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationAPI
{
    public class FieldQuestions
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string FieldDescription { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UsersID { get; set; }
        public Users? Users { get; set; }

        public int DetailsCategoryID { get; set; }
        public DetailsCategory? DetailsCategory { get; set; }
    }
}
