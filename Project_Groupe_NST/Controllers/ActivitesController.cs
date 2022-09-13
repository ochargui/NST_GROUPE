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
    public class ActivitesController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public ActivitesController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/Activites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activite>>> GetActivite()
        {
            return await _context.Activite.ToListAsync();
        }

        // GET: api/Activites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activite>> GetActivite(int id)
        {
            var activite = await _context.Activite.FindAsync(id);

            if (activite == null)
            {
                return NotFound();
            }

            return activite;
        }

        // PUT: api/Activites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivite(int id, Activite activite)
        {
            if (id != activite.idActivite)
            {
                return BadRequest();
            }

            _context.Entry(activite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiviteExists(id))
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

        // POST: api/Activites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Activite>> PostActivite(Activite activite)
        {
            _context.Activite.Add(activite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivite", new { id = activite.idActivite }, activite);
        }

        // DELETE: api/Activites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivite(int id)
        {
            var activite = await _context.Activite.FindAsync(id);
            if (activite == null)
            {
                return NotFound();
            }

            _context.Activite.Remove(activite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActiviteExists(int id)
        {
            return _context.Activite.Any(e => e.idActivite == id);
        }
    }
}
