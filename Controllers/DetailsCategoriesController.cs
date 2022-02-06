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
    public class DetailsCategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public DetailsCategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DetailsCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailsCategory>>> GetDetailsCategory()
        {
            return await _context.DetailsCategory.ToListAsync();
        }

        // GET: api/DetailsCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailsCategory>> GetDetailsCategory(int id)
        {
            var detailsCategory = await _context.DetailsCategory.FindAsync(id);

            if (detailsCategory == null)
            {
                return NotFound();
            }

            return detailsCategory;
        }

        // PUT: api/DetailsCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailsCategory(int id, DetailsCategory detailsCategory)
        {
            if (id != detailsCategory.ID)
            {
                return BadRequest();
            }

            _context.Entry(detailsCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailsCategoryExists(id))
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

        // POST: api/DetailsCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetailsCategory>> PostDetailsCategory(DetailsCategory detailsCategory)
        {
            _context.DetailsCategory.Add(detailsCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailsCategory", new { id = detailsCategory.ID }, detailsCategory);
        }

        // DELETE: api/DetailsCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetailsCategory(int id)
        {
            var detailsCategory = await _context.DetailsCategory.FindAsync(id);
            if (detailsCategory == null)
            {
                return NotFound();
            }

            _context.DetailsCategory.Remove(detailsCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetailsCategoryExists(int id)
        {
            return _context.DetailsCategory.Any(e => e.ID == id);
        }
    }
}
