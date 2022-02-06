using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationAPI
{
    public class ResponseLog
    {
        public int ID { get; set; }

        public int StudentSubmissionsID { get; set; }
        public StudentSubmissions? StudentSubmissions { get; set; }

        [StringLength(500)]

        public string Comments { get; set; } = string.Empty;

        public int UsersID { get; set; }

        public Users? Users { get; set; }

        public DateTime CreatedDate { get; set; }

       
       

    }
}
