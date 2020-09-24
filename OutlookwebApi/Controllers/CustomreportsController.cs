using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutlookwebApi.Model;

namespace OutlookwebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomreportsController : ControllerBase
    {
        private readonly CompanyCalContext _context;

        public CustomreportsController(CompanyCalContext context)
        {
            _context = context;
        }

        // GET: api/Customreports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customreport>>> GetCustomreport()
        {
            return await _context.Customreport.ToListAsync();
        }

        // GET: api/Customreports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customreport>> GetCustomreport(int id)
        {
            var customreport = await _context.Customreport.FindAsync(id);

            if (customreport == null)
            {
                return NotFound();
            }

            return customreport;
        }

        // PUT: api/Customreports/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomreport(int id, Customreport customreport)
        {
            if (id != customreport.Id)
            {
                return BadRequest();
            }

            _context.Entry(customreport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomreportExists(id))
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

        // POST: api/Customreports
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Customreport>> PostCustomreport(Customreport customreport)
        {
            _context.Customreport.Add(customreport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomreport", new { id = customreport.Id }, customreport);
        }

        // DELETE: api/Customreports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customreport>> DeleteCustomreport(int id)
        {
            var customreport = await _context.Customreport.FindAsync(id);
            if (customreport == null)
            {
                return NotFound();
            }

            _context.Customreport.Remove(customreport);
            await _context.SaveChangesAsync();

            return customreport;
        }

        private bool CustomreportExists(int id)
        {
            return _context.Customreport.Any(e => e.Id == id);
        }
    }
}
