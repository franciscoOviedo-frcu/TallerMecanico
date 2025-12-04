using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerMecanico.Api.Data;
using TallerMecanico.Api.Models;

namespace TallerMecanico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajosController : ControllerBase
    {
        private readonly TallerDbContext _context;

        public TrabajosController(TallerDbContext context)
        {
            _context = context;
        }

        // GET: api/Trabajos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trabajo>>> GetTrabajos()
        {
            return await _context.Trabajos.ToListAsync();
        }

        // GET: api/Trabajos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trabajo>> GetTrabajo(int id)
        {
            var trabajo = await _context.Trabajos.FindAsync(id);

            if (trabajo == null)
            {
                return NotFound();
            }

            return trabajo;
        }

        // PUT: api/Trabajos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajo(int id, Trabajo trabajo)
        {
            if (id != trabajo.id)
            {
                return BadRequest();
            }

            _context.Entry(trabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabajoExists(id))
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

        // POST: api/Trabajos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trabajo>> PostTrabajo(Trabajo trabajo)
        {
            _context.Trabajos.Add(trabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrabajo", new { id = trabajo.id }, trabajo);
        }

        // DELETE: api/Trabajos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajo(int id)
        {
            var trabajo = await _context.Trabajos.FindAsync(id);
            if (trabajo == null)
            {
                return NotFound();
            }

            _context.Trabajos.Remove(trabajo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrabajoExists(int id)
        {
            return _context.Trabajos.Any(e => e.id == id);
        }
    }
}
