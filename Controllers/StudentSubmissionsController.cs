#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationAPI;
using StudentRegistrationAPI.Data;

namespace StudentRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubmissionsController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentSubmissionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/StudentSubmissions
        [HttpGet("GetCollegeID/{CollegeID}")]
        public ActionResult<IEnumerable<Users>> GetSubmittedStudentList(int CollegeID)
        {
         
            
            var studentSubList = (from a in _context.StudentSubmissions
                                        join s in _context.User on a.UsersID equals s.ID
                                        where s.UserTypeID == 2 select s).ToList();


            return studentSubList;
        }

        [HttpGet("GetStudentID/{StudentID}")]
        public ActionResult<IEnumerable<SubmissionList>> GetStudentSubmissionList(int StudentID)
        {


            var studentSubmissionList = (from a in _context.StudentSubmissions
                                  join s in _context.ApplicationQuestion on a.ApplicationQuestionsID equals s.ID
                                  where a.UsersID == StudentID
                                  select new SubmissionList
                                  {
                                    question =   s.FieldQuestions.FieldDescription,
                                    answers = a.Answers
            }).ToList();


            return studentSubmissionList;




        }



        // GET: api/StudentSubmissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentSubmissions>> GetStudentSubmissions(int id)
        {
            var studentSubmissions = await _context.StudentSubmissions.FindAsync(id);

            if (studentSubmissions == null)
            {
                return NotFound();
            }

            return studentSubmissions;
        }

        // PUT: api/StudentSubmissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentSubmissions(int id, StudentSubmissions studentSubmissions)
        {
            if (id != studentSubmissions.ID)
            {
                return BadRequest();
            }

            _context.Entry(studentSubmissions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentSubmissionsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentSubmissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentSubmissions>> PostStudentSubmissions(StudentSubmissions studentSubmissions)
        {
            _context.StudentSubmissions.Add(studentSubmissions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentSubmissions", new { id = studentSubmissions.ID }, studentSubmissions);
        }

        // DELETE: api/StudentSubmissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentSubmissions(int id)
        {
            var studentSubmissions = await _context.StudentSubmissions.FindAsync(id);
            if (studentSubmissions == null)
            {
                return NotFound();
            }

            _context.StudentSubmissions.Remove(studentSubmissions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentSubmissionsExists(int id)
        {
            return _context.StudentSubmissions.Any(e => e.ID == id);
        }
    }

    public class SubmissionList
    {

        public string question { get; set; }
        public string answers { get; set; }

    }
}
