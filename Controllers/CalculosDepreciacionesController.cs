using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ActivosFijosAPI;
using ActivosFijosAPI.Models;

namespace ActivosFijosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculosDepreciacionesController : ControllerBase
    {
        private readonly ActivosFijosDb _context;

        public CalculosDepreciacionesController(ActivosFijosDb context)
        {
            _context = context;
        }

        // GET: api/CalculosDepreciaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalculoDepreciacion>>> GetCalculosDepreciaciones()
        {
            return await _context.CalculosDepreciaciones.ToListAsync();
        }

        // GET: api/CalculosDepreciaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalculoDepreciacion>> GetCalculoDepreciacion(int id)
        {
            var calculoDepreciacion = await _context.CalculosDepreciaciones.FindAsync(id);

            if (calculoDepreciacion == null)
            {
                return NotFound();
            }

            return calculoDepreciacion;
        }

        // PUT: api/CalculosDepreciaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculoDepreciacion(int id, CalculoDepreciacion calculoDepreciacion)
        {
            if (id != calculoDepreciacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(calculoDepreciacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculoDepreciacionExists(id))
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

        // POST: api/CalculosDepreciaciones
        [HttpPost]
        public async Task<ActionResult<CalculoDepreciacion>> PostCalculoDepreciacion(CalculoDepreciacion calculoDepreciacion)
        {
            _context.CalculosDepreciaciones.Add(calculoDepreciacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalculoDepreciacion", new { id = calculoDepreciacion.Id }, calculoDepreciacion);
        }

        // DELETE: api/CalculosDepreciaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CalculoDepreciacion>> DeleteCalculoDepreciacion(int id)
        {
            var calculoDepreciacion = await _context.CalculosDepreciaciones.FindAsync(id);
            if (calculoDepreciacion == null)
            {
                return NotFound();
            }

            _context.CalculosDepreciaciones.Remove(calculoDepreciacion);
            await _context.SaveChangesAsync();

            return calculoDepreciacion;
        }

        private bool CalculoDepreciacionExists(int id)
        {
            return _context.CalculosDepreciaciones.Any(e => e.Id == id);
        }
    }
}
