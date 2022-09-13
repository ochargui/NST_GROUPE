using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Groupe_NST.Models;

namespace Project_Groupe_NST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointagesController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public PointagesController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/Pointages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pointage>>> GetPointage()
        {
            return await _context.Pointage.ToListAsync();
        }

        // GET: api/Pointages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pointage>> GetPointage(int id)
        {
            var pointage = await _context.Pointage.FindAsync(id);

            if (pointage == null)
            {
                return NotFound();
            }

            return pointage;
        }

        // PUT: api/Pointages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPointage(int id, Pointage pointage)
        {
            if (id != pointage.idPointage)
            {
                return BadRequest();
            }

            _context.Entry(pointage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointageExists(id))
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

        // POST: api/Pointages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pointage>> PostPointage(Pointage pointage)
        {
            _context.Pointage.Add(pointage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPointage", new { id = pointage.idPointage }, pointage);
        }

        // DELETE: api/Pointages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePointage(int id)
        {
            var pointage = await _context.Pointage.FindAsync(id);
            if (pointage == null)
            {
                return NotFound();
            }

            _context.Pointage.Remove(pointage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PointageExists(int id)
        {
            return _context.Pointage.Any(e => e.idPointage == id);
        }
    }
}
