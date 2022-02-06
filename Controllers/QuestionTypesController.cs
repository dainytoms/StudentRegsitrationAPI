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
    public class QuestionTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public QuestionTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/QuestionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionTypes>>> GetQuestionType()
        {
            return await _context.QuestionType.ToListAsync();
        }

        // GET: api/QuestionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionTypes>> GetQuestionTypes(int id)
        {
            var questionTypes = await _context.QuestionType.FindAsync(id);

            if (questionTypes == null)
            {
                return NotFound();
            }

            return questionTypes;
        }

        // PUT: api/QuestionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionTypes(int id, QuestionTypes questionTypes)
        {
            if (id != questionTypes.ID)
            {
                return BadRequest();
            }

            _context.Entry(questionTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTypesExists(id))
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

        // POST: api/QuestionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionTypes>> PostQuestionTypes(QuestionTypes questionTypes)
        {
            _context.QuestionType.Add(questionTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionTypes", new { id = questionTypes.ID }, questionTypes);
        }

        // DELETE: api/QuestionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionTypes(int id)
        {
            var questionTypes = await _context.QuestionType.FindAsync(id);
            if (questionTypes == null)
            {
                return NotFound();
            }

            _context.QuestionType.Remove(questionTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionTypesExists(int id)
        {
            return _context.QuestionType.Any(e => e.ID == id);
        }
    }
}
