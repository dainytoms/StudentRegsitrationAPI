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
    public class ChoicesController : ControllerBase
    {
        private readonly DataContext _context;

        public ChoicesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Choices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Choices>>> GetChoices()
        {
            return await _context.Choices.ToListAsync();
        }

        // GET: api/Choices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Choices>> GetChoices(int id)
        {
            var choices = await _context.Choices.FindAsync(id);

            if (choices == null)
            {
                return NotFound();
            }

            return choices;
        }

        // PUT: api/Choices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChoices(int id, Choices choices)
        {
            if (id != choices.ID)
            {
                return BadRequest();
            }

            _context.Entry(choices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoicesExists(id))
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

        // POST: api/Choices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Choices>> PostChoices(Choices choices)
        {
            _context.Choices.Add(choices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChoices", new { id = choices.ID }, choices);
        }

        // DELETE: api/Choices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChoices(int id)
        {
            var choices = await _context.Choices.FindAsync(id);
            if (choices == null)
            {
                return NotFound();
            }

            _context.Choices.Remove(choices);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChoicesExists(int id)
        {
            return _context.Choices.Any(e => e.ID == id);
        }
    }
}
