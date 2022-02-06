using Microsoft.EntityFrameworkCore;
using StudentRegistrationAPI;

namespace StudentRegistrationAPI.Data
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ApplicationQuestions> ApplicationQuestion { get; set; }

        public DbSet<CollegeNames> CollegeName     { get; set; }

        public DbSet<FieldQuestions> FieldQuestion { get; set; }

        public DbSet<QuestionTypes> QuestionType { get; set; }

        public DbSet<ResponseLog> ResponseLogs { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Users> User { get; set; }

        public DbSet<StudentRegistrationAPI.StudentSubmissions> StudentSubmissions { get; set; }

        public DbSet<StudentRegistrationAPI.DetailsCategory> DetailsCategory { get; set; }

        public DbSet<StudentRegistrationAPI.Choices> Choices { get; set; }

    }
}
