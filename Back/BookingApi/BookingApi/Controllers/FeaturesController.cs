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
    public class FeaturesController : ControllerBase
    {
        private readonly Bookingdb _context;

        public FeaturesController(Bookingdb context)
        {
            _context = context;
        }

        // GET: api/Features
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feature>>> GetFeatures()
        {
          if (_context.Features == null)
          {
              return NotFound();
          }
            return await _context.Features.ToListAsync();
        }

        // GET: api/Features/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feature>> GetFeature(int id)
        {
          if (_context.Features == null)
          {
              return NotFound();
          }
            var feature = await _context.Features.FindAsync(id);

            if (feature == null)
            {
                return NotFound();
            }

            return feature;
        }

        // PUT: api/Features/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutFeature(int id, FeatureAndServiceViewModel nfeature)
        {
            Feature feature=_context.Features.FirstOrDefault(i=>i.FeatureId==id);
            if (id != feature.FeatureId)
            {
                return BadRequest();
            }
            
                feature.Name = nfeature.Name!="string"?nfeature.Name:feature.Name;
            

            _context.Entry(feature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("data updated Sucessfully");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureExists(id))
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

        // POST: api/Features
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<Feature>> PostFeature(FeatureAndServiceViewModel nfeature)
        {
            Feature feature=new Feature();
            feature.Name = nfeature.Name;
          if (_context.Features == null)
          {
              return Problem("Entity set 'Bookingdb.Features'  is null.");
            }
            else { 
            _context.Features.Add(feature);
            await _context.SaveChangesAsync();

            return Ok("data added succssefully");
            }
        }

        // DELETE: api/Features/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            if (_context.Features == null)
            {
                return NotFound();
            }
            var feature = await _context.Features.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();

            return Ok("Data Deleted Successfully");
        }

        private bool FeatureExists(int id)
        {
            return (_context.Features?.Any(e => e.FeatureId == id)).GetValueOrDefault();
        }
    }
}
