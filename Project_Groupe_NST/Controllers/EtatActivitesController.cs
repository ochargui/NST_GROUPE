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
    public class EtatActivitesController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public EtatActivitesController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/EtatActivites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtatActivite>>> GetEtatActivite()
        {
            return await _context.EtatActivite.ToListAsync();
        }

        // GET: api/EtatActivites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EtatActivite>> GetEtatActivite(int id)
        {
            var etatActivite = await _context.EtatActivite.FindAsync(id);

            if (etatActivite == null)
            {
                return NotFound();
            }

            return etatActivite;
        }

        // PUT: api/EtatActivites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtatActivite(int id, EtatActivite etatActivite)
        {
            if (id != etatActivite.idEActivite)
            {
                return BadRequest();
            }

            _context.Entry(etatActivite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtatActiviteExists(id))
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

        // POST: api/EtatActivites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EtatActivite>> PostEtatActivite(EtatActivite etatActivite)
        {
            _context.EtatActivite.Add(etatActivite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtatActivite", new { id = etatActivite.idEActivite }, etatActivite);
        }

        // DELETE: api/EtatActivites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtatActivite(int id)
        {
            var etatActivite = await _context.EtatActivite.FindAsync(id);
            if (etatActivite == null)
            {
                return NotFound();
            }

            _context.EtatActivite.Remove(etatActivite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtatActiviteExists(int id)
        {
            return _context.EtatActivite.Any(e => e.idEActivite == id);
        }
    }
}
