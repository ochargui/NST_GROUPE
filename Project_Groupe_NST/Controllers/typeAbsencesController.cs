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
    public class typeAbsencesController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public typeAbsencesController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/typeAbsences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<typeAbsence>>> GettypeAbsence()
        {
            return await _context.typeAbsence.ToListAsync();
        }

        // GET: api/typeAbsences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<typeAbsence>> GettypeAbsence(int id)
        {
            var typeAbsence = await _context.typeAbsence.FindAsync(id);

            if (typeAbsence == null)
            {
                return NotFound();
            }

            return typeAbsence;
        }

        // PUT: api/typeAbsences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttypeAbsence(int id, typeAbsence typeAbsence)
        {
            if (id != typeAbsence.idTAbsence)
            {
                return BadRequest();
            }

            _context.Entry(typeAbsence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!typeAbsenceExists(id))
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

        // POST: api/typeAbsences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<typeAbsence>> PosttypeAbsence(typeAbsence typeAbsence)
        {
            _context.typeAbsence.Add(typeAbsence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettypeAbsence", new { id = typeAbsence.idTAbsence }, typeAbsence);
        }

        // DELETE: api/typeAbsences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetypeAbsence(int id)
        {
            var typeAbsence = await _context.typeAbsence.FindAsync(id);
            if (typeAbsence == null)
            {
                return NotFound();
            }

            _context.typeAbsence.Remove(typeAbsence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool typeAbsenceExists(int id)
        {
            return _context.typeAbsence.Any(e => e.idTAbsence == id);
        }
    }
}
