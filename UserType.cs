
using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationAPI
{
    public class UserType
    {

        public int ID { get; set; }

        [StringLength(20)]
        public string UserTypeName { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
