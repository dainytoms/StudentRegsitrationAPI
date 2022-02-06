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
    public class ResponseLogsController : ControllerBase
    {
        private readonly DataContext _context;

        public ResponseLogsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ResponseLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseLog>>> GetResponseLogs()
        {
            return await _context.ResponseLogs.ToListAsync();
        }

        // GET: api/ResponseLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseLog>> GetResponseLog(int id)
        {
            var responseLog = await _context.ResponseLogs.FindAsync(id);

            if (responseLog == null)
            {
                return NotFound();
            }

            return responseLog;
        }

        // PUT: api/ResponseLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponseLog(int id, ResponseLog responseLog)
        {
            if (id != responseLog.ID)
            {
                return BadRequest();
            }

            _context.Entry(responseLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponseLogExists(id))
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

        // POST: api/ResponseLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseLog>> PostResponseLog(ResponseLog responseLog)
        {
            _context.ResponseLogs.Add(responseLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResponseLog", new { id = responseLog.ID }, responseLog);
        }

        // DELETE: api/ResponseLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponseLog(int id)
        {
            var responseLog = await _context.ResponseLogs.FindAsync(id);
            if (responseLog == null)
            {
                return NotFound();
            }

            _context.ResponseLogs.Remove(responseLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResponseLogExists(int id)
        {
            return _context.ResponseLogs.Any(e => e.ID == id);
        }
    }
}
