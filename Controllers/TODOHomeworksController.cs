using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe19TodoApp.Data;
using TARpe19TodoApp.Models;

namespace TARpe19TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TODOHomeworksController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TODOHomeworksController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/TODOHomeworks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TODOHomework>>> GetTODOHomework()
        {
            return await _context.TODOHomework.ToListAsync();
        }

        // GET: api/TODOHomeworks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TODOHomework>> GetTODOHomework(int id)
        {
            var tODOHomework = await _context.TODOHomework.FindAsync(id);

            if (tODOHomework == null)
            {
                return NotFound();
            }

            return tODOHomework;
        }

        // PUT: api/TODOHomeworks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTODOHomework(int id, TODOHomework tODOHomework)
        {
            if (id != tODOHomework.Id)
            {
                return BadRequest();
            }

            _context.Entry(tODOHomework).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TODOHomeworkExists(id))
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

        // POST: api/TODOHomeworks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TODOHomework>> PostTODOHomework(TODOHomework tODOHomework)
        {
            _context.TODOHomework.Add(tODOHomework);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTODOHomework", new { id = tODOHomework.Id }, tODOHomework);
        }

        // DELETE: api/TODOHomeworks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTODOHomework(int id)
        {
            var tODOHomework = await _context.TODOHomework.FindAsync(id);
            if (tODOHomework == null)
            {
                return NotFound();
            }

            _context.TODOHomework.Remove(tODOHomework);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TODOHomeworkExists(int id)
        {
            return _context.TODOHomework.Any(e => e.Id == id);
        }
    }
}
