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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly Bookingdb _context;
      

        public HotelsController(Bookingdb context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            if (_context.Hotels == null)
          {
              return NotFound();
          }
            return await _context.Hotels.ToListAsync();
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
          if (_context.Hotels == null)
          {
              return NotFound();
          }
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelViewModel hotel)
        {
            Hotel oldhotel= await _context.Hotels.FindAsync(id);
            List<HoteImages> oldImages = await _context.HoteImages.ToListAsync();
            if (id != oldhotel.HotelId)
            {
                return BadRequest();
            }
            oldhotel.name = hotel.name!="string"?hotel.name:oldhotel.name;
            oldhotel.type = hotel.type != "string" ? hotel.type : oldhotel.type;
            oldhotel.city = hotel.city != "string" ? hotel.city : oldhotel.city;

            oldhotel.address = hotel.address != "string" ? hotel.address : oldhotel.address;
            oldhotel.distance = hotel.distance != "string" ? hotel.distance : oldhotel.distance;

            oldhotel.description = hotel.description != "string" ? hotel.description : oldhotel.description;
            oldhotel.featured = hotel.featured != true ? hotel.featured : oldhotel.featured;
            oldhotel.cheapestPrice = hotel.cheapestPrice != 0 ? hotel.cheapestPrice: oldhotel.cheapestPrice;
            oldhotel.rating = hotel.rating !=5 ? hotel.rating: oldhotel.rating;
            oldhotel.title = hotel.title != "string" ? hotel.title : oldhotel.title;
        
            _context.Entry(oldhotel).State = EntityState.Modified;
            for (var i = 0; i < hotel.Images?.Length; i++)
            {

                if(_context.HoteImages.FirstOrDefault(r => r.HotelId == oldhotel.HotelId) != null)
                {
                    HoteImages HotelImages = _context.HoteImages.FirstOrDefault(r => r.Name == oldImages[i].Name);


                    HotelImages.Name = hotel.Images[i] != "string" ? hotel.Images[i] : oldImages[i].Name;
                    _context.Entry(HotelImages).State = EntityState.Modified;
                }

                
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Data Updated Successfully");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<Hotel>> PostHotel(HotelViewModel hotel)
        {
            Hotel newhotel = new Hotel();
            HoteImages HotelImages ;
            newhotel.name = hotel.name;
            newhotel.type = hotel.type;
            newhotel.city = hotel.city;

            newhotel.address = hotel.address;
            newhotel.distance = hotel.distance;

            newhotel.description=hotel.description;
            newhotel.featured= hotel.featured;
            newhotel.cheapestPrice= hotel.cheapestPrice;
            newhotel.rating= hotel.rating;
            newhotel.title= hotel.title;

            



          if (_context.Hotels == null)
          {
              return Problem("Entity set 'Bookingdb.Hotels'  is null.");
          }
            _context.Hotels.Add(newhotel);
            await _context.SaveChangesAsync();
            for (var i=0;i< hotel.Images.Length;i++)
            {
                HotelImages = new HoteImages();
                HotelImages.HotelId = newhotel.HotelId;
                HotelImages.Name = hotel.Images[i];
                _context.HoteImages.Add(HotelImages);
                await _context.SaveChangesAsync();
                return Ok("Data Added Successfully");
            }

            return CreatedAtAction("GetHotel", new { id = newhotel.HotelId }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

             else
            {
                _context.Hotels.Remove(hotel);
                List<HoteImages> HoteImages = _context.HoteImages.ToList();
                for (var i = 0; i < HoteImages.Count; i++)
                {
                    HoteImages r = _context.HoteImages.FirstOrDefault(d => d.HotelId == id);
                    _context.HoteImages.Remove(r);

                }





                List<RoomsInHotel> roomsInHotels = _context.RoomsInHotel.ToList();
                for (var h = 0; h < roomsInHotels.Count; h++)
                {
                    RoomsInHotel  roomsInHotel = _context.RoomsInHotel.FirstOrDefault(s => s.HotelId == roomsInHotels[h].HotelId);
                    _context.RoomsInHotel.Remove(roomsInHotel);

                }
                await _context.SaveChangesAsync();

                return Ok("data deleted Successfully");

            }

            
        }

        private bool HotelExists(int id)
        {
            return (_context.Hotels?.Any(e => e.HotelId == id)).GetValueOrDefault();
        }
    }
}
