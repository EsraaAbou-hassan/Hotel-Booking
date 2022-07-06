using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApi.Models;
using BookingApi.ViewModel;

using BookingApi.database;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly Bookingdb _context;

        public ServicesController(Bookingdb context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
          if (_context.Services == null)
          {
              return NotFound();
          }
            return await _context.Services.ToListAsync();
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
          if (_context.Services == null)
          {
              return NotFound();
          }
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, FeatureAndServiceViewModel nservice)
        {
            Service service = _context.Services.FirstOrDefault(s => s.ServiceId == id);
            if (id != service.ServiceId)
            {
                return BadRequest();
            }
            service.Name = nservice.Name != "string" ? nservice.Name : service.Name;
            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Data Updated Successfully");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<Service>> PostService(FeatureAndServiceViewModel nservice)
        {
            Service service = new Service();
          if (_context.Services == null)
          {
              return Problem("Entity set 'Bookingdb.Services'  is null.");
          }
            service.Name=nservice.Name;
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return Ok("Data Added Successfully");
        }

        // DELETE: api/Services/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (_context.Services == null)
            {
                return NotFound();
            }
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();


            return Ok("Data Deleted Successfully");
        }

        private bool ServiceExists(int id)
        {
            return (_context.Services?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }
}
