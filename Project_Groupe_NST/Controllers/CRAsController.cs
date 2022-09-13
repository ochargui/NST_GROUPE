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
    public class CRAsController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public CRAsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/CRAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CRA>>> GetCRA()
        {
            return await _context.CRA.ToListAsync();
        }

        // GET: api/CRAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CRA>> GetCRA(int id)
        {
            var cRA = await _context.CRA.FindAsync(id);

            if (cRA == null)
            {
                return NotFound();
            }

            return cRA;
        }

        // PUT: api/CRAs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCRA(int id, CRA cRA)
        {
            if (id != cRA.idCRA)
            {
                return BadRequest();
            }

            _context.Entry(cRA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CRAExists(id))
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

        // POST: api/CRAs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CRA>> PostCRA(CRA cRA)
        {
            _context.CRA.Add(cRA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCRA", new { id = cRA.idCRA }, cRA);
        }

        // DELETE: api/CRAs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCRA(int id)
        {
            var cRA = await _context.CRA.FindAsync(id);
            if (cRA == null)
            {
                return NotFound();
            }

            _context.CRA.Remove(cRA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CRAExists(int id)
        {
            return _context.CRA.Any(e => e.idCRA == id);
        }
    }
}
