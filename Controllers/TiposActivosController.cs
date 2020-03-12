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
    public class TiposActivosController : ControllerBase
    {
        private readonly ActivosFijosDb _context;

        public TiposActivosController(ActivosFijosDb context)
        {
            _context = context;
        }

        // GET: api/TiposActivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoActivo>>> GetTiposActivos()
        {
            return await _context.TiposActivos.ToListAsync();
        }

        // GET: api/TiposActivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoActivo>> GetTipoActivo(int id)
        {
            var tipoActivo = await _context.TiposActivos.FindAsync(id);

            if (tipoActivo == null)
            {
                return NotFound();
            }

            return tipoActivo;
        }

        // PUT: api/TiposActivos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoActivo(int id, TipoActivo tipoActivo)
        {
            if (id != tipoActivo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoActivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoActivoExists(id))
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

        // POST: api/TiposActivos
        [HttpPost]
        public async Task<ActionResult<TipoActivo>> PostTipoActivo(TipoActivo tipoActivo)
        {
            _context.TiposActivos.Add(tipoActivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoActivo", new { id = tipoActivo.Id }, tipoActivo);
        }

        // DELETE: api/TiposActivos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoActivo>> DeleteTipoActivo(int id)
        {
            var tipoActivo = await _context.TiposActivos.FindAsync(id);
            if (tipoActivo == null)
            {
                return NotFound();
            }

            _context.TiposActivos.Remove(tipoActivo);
            await _context.SaveChangesAsync();

            return tipoActivo;
        }

        private bool TipoActivoExists(int id)
        {
            return _context.TiposActivos.Any(e => e.Id == id);
        }
    }
}
