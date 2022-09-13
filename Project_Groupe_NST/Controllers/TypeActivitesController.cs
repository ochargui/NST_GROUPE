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
    public class TypeActivitesController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public TypeActivitesController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/TypeActivites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeActivite>>> GettypeActivite()
        {
            return await _context.typeActivite.ToListAsync();
        }

        // GET: api/TypeActivites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeActivite>> GetTypeActivite(int id)
        {
            var typeActivite = await _context.typeActivite.FindAsync(id);

            if (typeActivite == null)
            {
                return NotFound();
            }

            return typeActivite;
        }

        // PUT: api/TypeActivites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeActivite(int id, TypeActivite typeActivite)
        {
            if (id != typeActivite.idTActivite)
            {
                return BadRequest();
            }

            _context.Entry(typeActivite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeActiviteExists(id))
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

        // POST: api/TypeActivites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeActivite>> PostTypeActivite(TypeActivite typeActivite)
        {
            _context.typeActivite.Add(typeActivite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeActivite", new { id = typeActivite.idTActivite }, typeActivite);
        }

        // DELETE: api/TypeActivites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeActivite(int id)
        {
            var typeActivite = await _context.typeActivite.FindAsync(id);
            if (typeActivite == null)
            {
                return NotFound();
            }

            _context.typeActivite.Remove(typeActivite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeActiviteExists(int id)
        {
            return _context.typeActivite.Any(e => e.idTActivite == id);
        }
    }
}
