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
    public class LauncheventsController : ControllerBase
    {
        private readonly CompanyCalContext _context;

        public LauncheventsController(CompanyCalContext context)
        {
            _context = context;
        }

        // GET: api/Launchevents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Launchevent>>> GetLaunchevent()
        {
            return await _context.Launchevent.ToListAsync();
        }

        // GET: api/Launchevents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Launchevent>> GetLaunchevent(int id)
        {
            var launchevent = await _context.Launchevent.FindAsync(id);

            if (launchevent == null)
            {
                return NotFound();
            }

            return launchevent;
        }

        // PUT: api/Launchevents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaunchevent(int id, Launchevent launchevent)
        {
            if (id != launchevent.Id)
            {
                return BadRequest();
            }

            _context.Entry(launchevent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LauncheventExists(id))
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

        // POST: api/Launchevents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Launchevent>> PostLaunchevent(Launchevent launchevent)
        {
            _context.Launchevent.Add(launchevent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LauncheventExists(launchevent.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLaunchevent", new { id = launchevent.Id }, launchevent);
        }

        // DELETE: api/Launchevents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Launchevent>> DeleteLaunchevent(int id)
        {
            var launchevent = await _context.Launchevent.FindAsync(id);
            if (launchevent == null)
            {
                return NotFound();
            }

            _context.Launchevent.Remove(launchevent);
            await _context.SaveChangesAsync();

            return launchevent;
        }

        private bool LauncheventExists(int id)
        {
            return _context.Launchevent.Any(e => e.Id == id);
        }
    }
}
