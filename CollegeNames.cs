using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationAPI
{
    public class CollegeNames
    {

        public int ID { get; set; }

        [StringLength(100)]
        public string CollegeName { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

      
    }
}
