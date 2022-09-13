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
    public class Type_ProjetController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public Type_ProjetController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/Type_Projet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type_Projet>>> GetType_Projet()
        {
            return await _context.Type_Projet.ToListAsync();
        }

        // GET: api/Type_Projet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Type_Projet>> GetType_Projet(int id)
        {
            var type_Projet = await _context.Type_Projet.FindAsync(id);

            if (type_Projet == null)
            {
                return NotFound();
            }

            return type_Projet;
        }

        // PUT: api/Type_Projet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutType_Projet(int id, Type_Projet type_Projet)
        {
            if (id != type_Projet.idTProjet)
            {
                return BadRequest();
            }

            _context.Entry(type_Projet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Type_ProjetExists(id))
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

        // POST: api/Type_Projet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Type_Projet>> PostType_Projet(Type_Projet type_Projet)
        {
            _context.Type_Projet.Add(type_Projet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetType_Projet", new { id = type_Projet.idTProjet }, type_Projet);
        }

        // DELETE: api/Type_Projet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType_Projet(int id)
        {
            var type_Projet = await _context.Type_Projet.FindAsync(id);
            if (type_Projet == null)
            {
                return NotFound();
            }

            _context.Type_Projet.Remove(type_Projet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Type_ProjetExists(int id)
        {
            return _context.Type_Projet.Any(e => e.idTProjet == id);
        }
    }
}
