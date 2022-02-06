
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationAPI
{
    public class Users   
    {
        public int ID { get; set; }

        public int UserTypeID { get; set; }
        public UserType? UserType { get; set; }

        [StringLength(20)]

        public string UserName { get; set; } = string.Empty;

        [StringLength(20)]
        public string Password { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }


        public int CollegeNamesID { get; set; }
        public CollegeNames? CollegeNames { get; set; }

    }
}
