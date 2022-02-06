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
    public class FieldQuestionsController : ControllerBase
    {
        private readonly DataContext _context;

        public FieldQuestionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FieldQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FieldQuestions>>> GetFieldQuestion()
        {
            return await _context.FieldQuestion.ToListAsync();
        }

        // GET: api/FieldQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FieldQuestions>> GetFieldQuestions(int id)
        {
            var fieldQuestions = await _context.FieldQuestion.FindAsync(id);

            if (fieldQuestions == null)
            {
                return NotFound();
            }

            return fieldQuestions;
        }

        // PUT: api/FieldQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFieldQuestions(int id, FieldQuestions fieldQuestions)
        {
            if (id != fieldQuestions.ID)
            {
                return BadRequest();
            }

            _context.Entry(fieldQuestions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FieldQuestionsExists(id))
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

        // POST: api/FieldQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FieldQuestions>> PostFieldQuestions(FieldQuestions fieldQuestions)
        {
            _context.FieldQuestion.Add(fieldQuestions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFieldQuestions", new { id = fieldQuestions.ID }, fieldQuestions);
        }

        // DELETE: api/FieldQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFieldQuestions(int id)
        {
            var fieldQuestions = await _context.FieldQuestion.FindAsync(id);
            if (fieldQuestions == null)
            {
                return NotFound();
            }

            _context.FieldQuestion.Remove(fieldQuestions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FieldQuestionsExists(int id)
        {
            return _context.FieldQuestion.Any(e => e.ID == id);
        }
    }
}
