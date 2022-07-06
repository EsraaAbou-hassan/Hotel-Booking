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
    public class RoomsController : ControllerBase
    {
        private readonly Bookingdb _context;

        public RoomsController(Bookingdb context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
          if (_context.Rooms == null)
          {
              return NotFound();
          }
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
          if (_context.Rooms == null)
          {
              return NotFound();
          }
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateRoom(int id, RoomViewModel nroom)
        {
            Room room =  await _context.Rooms.FindAsync(id);
            List<RoomImages> oldImages = await _context.RoomImages.ToListAsync();
            List<RoomsInHotel> oldroomsInHotels = await _context.RoomsInHotel.ToListAsync();   
            if (id != room.RoomId)
            {
                return BadRequest();
            }
            
            room.type = nroom.type != "string" ? nroom.type : room.type;
            room.description = nroom.description != "string" ? nroom.description : room.description;
            room.roomNumber = nroom.roomNumber != 0 ? nroom.roomNumber : room.roomNumber;

            room.maxPeople = nroom.maxPeople != 0 ? nroom.maxPeople : room.maxPeople ;
            _context.Entry(room).State = EntityState.Modified;

            for (var i = 0; i < nroom.Images?.Length; i++)
            {

                if (_context.RoomImages.FirstOrDefault(r => r.RoomId ==room.RoomId) != null)
                {
                    RoomImages roomImages = _context.RoomImages.FirstOrDefault(r => r.Name == oldImages[i].Name);
                    roomImages.RoomId = room.RoomId;

                    roomImages.Name = nroom.Images[i] != "string" ? nroom.Images[i] : oldImages[i].Name;
                    _context.Entry(roomImages).State = EntityState.Modified;
                }


            }
            if (oldroomsInHotels.Count > 0) { 
                    for (var i = 0; i < oldroomsInHotels?.Count; i++)
                {
               
                    RoomsInHotel roomsInHotel = await _context.RoomsInHotel.FirstOrDefaultAsync(d => d.RoomId == id && d.HotelId == oldroomsInHotels[i].HotelId);
                if (roomsInHotel!=null) {
                    roomsInHotel.HotelId = nroom.HotelId != 0 ? nroom.HotelId : roomsInHotel.HotelId;
                    roomsInHotel.RoomId = room.RoomId;
                    roomsInHotel.Price = nroom.Price != 0 ? nroom.Price : roomsInHotel.Price;
                    _context.Entry(roomsInHotel).State = EntityState.Modified;
                } else
                {
                    RoomsInHotel hotelroom = new RoomsInHotel();
                    hotelroom.HotelId = nroom.HotelId;
                    hotelroom.RoomId = room.RoomId;
                    hotelroom.Price = nroom.Price;
                    _context.RoomsInHotel.Add(hotelroom);
                }

                   

                }
            }else
            {
                RoomsInHotel hotelrooms = new RoomsInHotel();
                hotelrooms.HotelId = nroom.HotelId;
                hotelrooms.RoomId = room.RoomId;
                hotelrooms.Price = nroom.Price;
                _context.RoomsInHotel.Add(hotelrooms);
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Data Updted Successfully");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<Room>> AddRoom(RoomViewModel nroom)
        {
            
            if (_context.Rooms == null)
            {
              return Problem("Entity set 'Bookingdb.Rooms'  is null.");
            }
            else
            {
                Room room = new Room();
                room.type = nroom.type;
                room.description = nroom.description;
                room.roomNumber = nroom.roomNumber;

                room.maxPeople = nroom.maxPeople;
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();

                RoomsInHotel roomsInHotel = new RoomsInHotel();
                roomsInHotel.HotelId = nroom.HotelId;
                roomsInHotel.RoomId = room.RoomId;
                roomsInHotel.Price = nroom.Price;
                _context.RoomsInHotel.Add(roomsInHotel);
                await _context.SaveChangesAsync();

                RoomImages roomImages;

                for (var i = 0; i < nroom.Images.Length; i++)
                {
                    roomImages = new RoomImages();
                    roomImages.RoomId=room.RoomId;
                    roomImages.Name = nroom.Images[i];
                    _context.RoomImages.Add(roomImages);
                    await _context.SaveChangesAsync();
                }
                return (Ok("data added successfully"));
            }
           

            
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            else
            {
                
                List<RoomImages> roomImages = _context.RoomImages.ToList();
                for (var i = 0; i < roomImages.Count; i++)
                {
                    RoomImages r = _context.RoomImages.FirstOrDefault(d => d.RoomId == id);
                    _context.RoomImages.Remove(r);

                }


                RoomsInHotel roomsInHotel = _context.RoomsInHotel.FirstOrDefault(d => d.RoomId == id);
                _context.RoomsInHotel.Remove(roomsInHotel);

                _context.Rooms.Remove(room);

                await _context.SaveChangesAsync();
                return Ok("data deleted Successfully");
            }

           

            return NoContent();
        }
        private void UpdateImge()
        {

        }
        private bool RoomExists(int id)
        {
            return (_context.Rooms?.Any(e => e.RoomId == id)).GetValueOrDefault();
        }
    }
}
