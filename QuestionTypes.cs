using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationAPI
{
    public class QuestionTypes
    {
        public int ID { get; set; }

        [StringLength(20)]
        public string QuestionTypeName { get; set; }=String.Empty;

        public bool IsActive { get; set; }


    }
}
