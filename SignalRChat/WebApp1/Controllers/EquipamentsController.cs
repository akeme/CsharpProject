using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentsController : ControllerBase
    {
        private readonly WebApp1Context _context;

        public EquipamentsController(WebApp1Context context)
        {
            _context = context;
        }

        // GET: api/Equipaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipament>>> GetEquipament()
        {
            return await _context.Equipament.ToListAsync();
        }

        // GET: api/Equipaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipament>> GetEquipament(long id)
        {
            var equipament = await _context.Equipament.FindAsync(id);

            if (equipament == null)
            {
                return NotFound();
            }

            return equipament;
        }

        // PUT: api/Equipaments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipament(long id, Equipament equipament)
        {
            if (id != equipament.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipamentExists(id))
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

        // POST: api/Equipaments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Equipament>> PostEquipament(Equipament equipament)
        {
            _context.Equipament.Add(equipament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipament", new { id = equipament.Id }, equipament);
        }

        // DELETE: api/Equipaments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Equipament>> DeleteEquipament(long id)
        {
            var equipament = await _context.Equipament.FindAsync(id);
            if (equipament == null)
            {
                return NotFound();
            }

            _context.Equipament.Remove(equipament);
            await _context.SaveChangesAsync();

            return equipament;
        }

        private bool EquipamentExists(long id)
        {
            return _context.Equipament.Any(e => e.Id == id);
        }
    }
}
