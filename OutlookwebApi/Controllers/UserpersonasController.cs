using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutlookwebApi.Model;

namespace OutlookwebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserpersonasController : ControllerBase
    {
        private readonly CompanyCalContext _context;

        public UserpersonasController(CompanyCalContext context)
        {
            _context = context;
        }

        // GET: api/Userpersonas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userpersonas>>> GetUserpersonas()
        {
            return await _context.Userpersonas.ToListAsync();
        }

        // GET: api/Userpersonas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userpersonas>> GetUserpersonas(int id)
        {
            var userpersonas = await _context.Userpersonas.FindAsync(id);

            if (userpersonas == null)
            {
                return NotFound();
            }

            return userpersonas;
        }

        // PUT: api/Userpersonas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserpersonas(int id, Userpersonas userpersonas)
        {
            if (id != userpersonas.Id)
            {
                return BadRequest();
            }

            _context.Entry(userpersonas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserpersonasExists(id))
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

        // POST: api/Userpersonas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Userpersonas>> PostUserpersonas(Userpersonas userpersonas)
        {
            _context.Userpersonas.Add(userpersonas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserpersonasExists(userpersonas.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserpersonas", new { id = userpersonas.Id }, userpersonas);
        }

        // DELETE: api/Userpersonas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Userpersonas>> DeleteUserpersonas(int id)
        {
            var userpersonas = await _context.Userpersonas.FindAsync(id);
            if (userpersonas == null)
            {
                return NotFound();
            }

            _context.Userpersonas.Remove(userpersonas);
            await _context.SaveChangesAsync();

            return userpersonas;
        }

        private bool UserpersonasExists(int id)
        {
            return _context.Userpersonas.Any(e => e.Id == id);
        }
    }
}
