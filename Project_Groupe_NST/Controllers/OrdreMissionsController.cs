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
    public class OrdreMissionsController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public OrdreMissionsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/OrdreMissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdreMission>>> GetOrdreMission()
        {
            return await _context.OrdreMission.ToListAsync();
        }

        // GET: api/OrdreMissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdreMission>> GetOrdreMission(int id)
        {
            var ordreMission = await _context.OrdreMission.FindAsync(id);

            if (ordreMission == null)
            {
                return NotFound();
            }

            return ordreMission;
        }

        // PUT: api/OrdreMissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdreMission(int id, OrdreMission ordreMission)
        {
            if (id != ordreMission.idOrdreMission)
            {
                return BadRequest();
            }

            _context.Entry(ordreMission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdreMissionExists(id))
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

        // POST: api/OrdreMissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdreMission>> PostOrdreMission(OrdreMission ordreMission)
        {
            _context.OrdreMission.Add(ordreMission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdreMission", new { id = ordreMission.idOrdreMission }, ordreMission);
        }

        // DELETE: api/OrdreMissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdreMission(int id)
        {
            var ordreMission = await _context.OrdreMission.FindAsync(id);
            if (ordreMission == null)
            {
                return NotFound();
            }

            _context.OrdreMission.Remove(ordreMission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdreMissionExists(int id)
        {
            return _context.OrdreMission.Any(e => e.idOrdreMission == id);
        }
    }
}
