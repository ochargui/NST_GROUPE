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
    public class EtatAbsencesController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public EtatAbsencesController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/EtatAbsences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtatAbsence>>> GetEtatAbsence()
        {
            return await _context.EtatAbsence.ToListAsync();
        }

        // GET: api/EtatAbsences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EtatAbsence>> GetEtatAbsence(int id)
        {
            var etatAbsence = await _context.EtatAbsence.FindAsync(id);

            if (etatAbsence == null)
            {
                return NotFound();
            }

            return etatAbsence;
        }

        // PUT: api/EtatAbsences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtatAbsence(int id, EtatAbsence etatAbsence)
        {
            if (id != etatAbsence.idEAbsence)
            {
                return BadRequest();
            }

            _context.Entry(etatAbsence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtatAbsenceExists(id))
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

        // POST: api/EtatAbsences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EtatAbsence>> PostEtatAbsence(EtatAbsence etatAbsence)
        {
            _context.EtatAbsence.Add(etatAbsence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtatAbsence", new { id = etatAbsence.idEAbsence }, etatAbsence);
        }

        // DELETE: api/EtatAbsences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtatAbsence(int id)
        {
            var etatAbsence = await _context.EtatAbsence.FindAsync(id);
            if (etatAbsence == null)
            {
                return NotFound();
            }

            _context.EtatAbsence.Remove(etatAbsence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtatAbsenceExists(int id)
        {
            return _context.EtatAbsence.Any(e => e.idEAbsence == id);
        }
    }
}
