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
    public class CollegeNamesController : ControllerBase
    {
        private readonly DataContext _context;

        public CollegeNamesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CollegeNames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollegeNames>>> GetCollegeName()
        {
            return await _context.CollegeName.ToListAsync();
        }

        // GET: api/CollegeNames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollegeNames>> GetCollegeNames(int id)
        {
            var collegeNames = await _context.CollegeName.FindAsync(id);

            if (collegeNames == null)
            {
                return NotFound();
            }

            return collegeNames;
        }

        // PUT: api/CollegeNames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollegeNames(int id, CollegeNames collegeNames)
        {
            if (id != collegeNames.ID)
            {
                return BadRequest();
            }

            _context.Entry(collegeNames).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeNamesExists(id))
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

        // POST: api/CollegeNames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CollegeNames>> PostCollegeNames(CollegeNames collegeNames)
        {
            _context.CollegeName.Add(collegeNames);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCollegeNames", new { id = collegeNames.ID }, collegeNames);
        }

        // DELETE: api/CollegeNames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollegeNames(int id)
        {
            var collegeNames = await _context.CollegeName.FindAsync(id);
            if (collegeNames == null)
            {
                return NotFound();
            }

            _context.CollegeName.Remove(collegeNames);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollegeNamesExists(int id)
        {
            return _context.CollegeName.Any(e => e.ID == id);
        }
    }
}
