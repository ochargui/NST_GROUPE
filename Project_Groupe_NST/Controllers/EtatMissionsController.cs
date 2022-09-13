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
    public class EtatMissionsController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public EtatMissionsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/EtatMissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtatMission>>> GetEtatMission()
        {
            return await _context.EtatMission.ToListAsync();
        }

        // GET: api/EtatMissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EtatMission>> GetEtatMission(int id)
        {
            var etatMission = await _context.EtatMission.FindAsync(id);

            if (etatMission == null)
            {
                return NotFound();
            }

            return etatMission;
        }

        // PUT: api/EtatMissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtatMission(int id, EtatMission etatMission)
        {
            if (id != etatMission.idEtatMission)
            {
                return BadRequest();
            }

            _context.Entry(etatMission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtatMissionExists(id))
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

        // POST: api/EtatMissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EtatMission>> PostEtatMission(EtatMission etatMission)
        {
            _context.EtatMission.Add(etatMission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtatMission", new { id = etatMission.idEtatMission }, etatMission);
        }

        // DELETE: api/EtatMissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtatMission(int id)
        {
            var etatMission = await _context.EtatMission.FindAsync(id);
            if (etatMission == null)
            {
                return NotFound();
            }

            _context.EtatMission.Remove(etatMission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtatMissionExists(int id)
        {
            return _context.EtatMission.Any(e => e.idEtatMission == id);
        }
    }
}
