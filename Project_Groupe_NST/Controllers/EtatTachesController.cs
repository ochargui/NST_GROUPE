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
    public class EtatTachesController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public EtatTachesController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/EtatTaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtatTache>>> GetEtatTache()
        {
            return await _context.EtatTache.ToListAsync();
        }

        // GET: api/EtatTaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EtatTache>> GetEtatTache(int id)
        {
            var etatTache = await _context.EtatTache.FindAsync(id);

            if (etatTache == null)
            {
                return NotFound();
            }

            return etatTache;
        }

        // PUT: api/EtatTaches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtatTache(int id, EtatTache etatTache)
        {
            if (id != etatTache.idEtatTache)
            {
                return BadRequest();
            }

            _context.Entry(etatTache).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtatTacheExists(id))
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

        // POST: api/EtatTaches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EtatTache>> PostEtatTache(EtatTache etatTache)
        {
            _context.EtatTache.Add(etatTache);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtatTache", new { id = etatTache.idEtatTache }, etatTache);
        }

        // DELETE: api/EtatTaches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtatTache(int id)
        {
            var etatTache = await _context.EtatTache.FindAsync(id);
            if (etatTache == null)
            {
                return NotFound();
            }

            _context.EtatTache.Remove(etatTache);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtatTacheExists(int id)
        {
            return _context.EtatTache.Any(e => e.idEtatTache == id);
        }
    }
}
