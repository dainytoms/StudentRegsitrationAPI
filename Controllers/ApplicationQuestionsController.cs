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


    public class ApplicationQuestionsController : ControllerBase
    {
        private readonly DataContext _context;

        public ApplicationQuestionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationQuestions
        // [HttpGet("{CollegeID}")]
        [HttpGet("GetById/{CollegeID}")]
        public ActionResult<IEnumerable<StudentApplicationFields>> GetApplicationQuestionForStudents(int CollegeID)
        {
            List<StudentApplicationFields> studentApplicationFields = new List<StudentApplicationFields>();
            var applicationQuestions = _context.ApplicationQuestion.Where(s => s.CollegeNamesID == CollegeID).ToList();

            foreach (var item in applicationQuestions)
            {
                StudentApplicationFields newStudentApplicationFields = new StudentApplicationFields();

                newStudentApplicationFields.question = item;
                newStudentApplicationFields.StudentChoices = _context.Choices.Where(s => s.FieldQuestionsID == item.FieldQuestionsID).ToList();

                studentApplicationFields.Add(newStudentApplicationFields);

            }

            return studentApplicationFields;
        }

        // GET: api/ApplicationQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationQuestions>> GetApplicationQuestions(int id)
        {
            var applicationQuestions = await _context.ApplicationQuestion.FindAsync(id);

            if (applicationQuestions == null)
            {
                return NotFound();
            }

            return applicationQuestions;
        }

        // PUT: api/ApplicationQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationQuestions(int id, ApplicationQuestions applicationQuestions)
        {
            if (id != applicationQuestions.ID)
            {
                return BadRequest();
            }

            _context.Entry(applicationQuestions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationQuestionsExists(id))
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

        // POST: api/ApplicationQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationQuestions>> PostApplicationQuestions(ApplicationQuestions applicationQuestions)
        {
            _context.ApplicationQuestion.Add(applicationQuestions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationQuestions", new { id = applicationQuestions.ID }, applicationQuestions);
        }

        // DELETE: api/ApplicationQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationQuestions(int id)
        {
            var applicationQuestions = await _context.ApplicationQuestion.FindAsync(id);
            if (applicationQuestions == null)
            {
                return NotFound();
            }

            _context.ApplicationQuestion.Remove(applicationQuestions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationQuestionsExists(int id)
        {
            return _context.ApplicationQuestion.Any(e => e.ID == id);
        }
    }
    public class StudentApplicationFields
    {

        public ApplicationQuestions question { get; set; }
        public List<Choices> StudentChoices { get; set; }

    }
}
