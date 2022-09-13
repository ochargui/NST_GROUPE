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
    public class EtatProjetsController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public EtatProjetsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/EtatProjets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtatProjet>>> GetEtatProjet()
        {
            return await _context.EtatProjet.ToListAsync();
        }

        // GET: api/EtatProjets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EtatProjet>> GetEtatProjet(int id)
        {
            var etatProjet = await _context.EtatProjet.FindAsync(id);

            if (etatProjet == null)
            {
                return NotFound();
            }

            return etatProjet;
        }

        // PUT: api/EtatProjets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtatProjet(int id, EtatProjet etatProjet)
        {
            if (id != etatProjet.idEProjet)
            {
                return BadRequest();
            }

            _context.Entry(etatProjet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtatProjetExists(id))
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

        // POST: api/EtatProjets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EtatProjet>> PostEtatProjet(EtatProjet etatProjet)
        {
            _context.EtatProjet.Add(etatProjet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtatProjet", new { id = etatProjet.idEProjet }, etatProjet);
        }

        // DELETE: api/EtatProjets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtatProjet(int id)
        {
            var etatProjet = await _context.EtatProjet.FindAsync(id);
            if (etatProjet == null)
            {
                return NotFound();
            }

            _context.EtatProjet.Remove(etatProjet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtatProjetExists(int id)
        {
            return _context.EtatProjet.Any(e => e.idEProjet == id);
        }
    }
}
