using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationAPI
{
    public class DetailsCategory
    {
        public int ID { get; set; }

        [StringLength(20)]
        public string CategoryName { get; set; } = String.Empty;

        public bool IsActive { get; set; }
    }
}
