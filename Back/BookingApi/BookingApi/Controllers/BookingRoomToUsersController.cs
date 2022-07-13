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
    public class BookingRoomToUsersController : ControllerBase
    {
        private readonly Bookingdb _context;

        public BookingRoomToUsersController(Bookingdb context)
        {
            _context = context;
        }
        [HttpPost("ChooseRoomAndHotel")]


        public async Task<ActionResult<IEnumerable<Hotel>>> Filter(HotelFilterViewModeles filterViewModeles)
        {
            BookingRoomToUser b = _context.BookingRoomToUser
                .FirstOrDefault(e => e.EndDate == filterViewModeles.EndDate && e.StartDate == filterViewModeles.StartDate);
            if (filterViewModeles.city== null)
            {
                return NotFound();

            }
            return await _context.Hotels.Where(e => e.city == filterViewModeles.city).Include(t => t.RoomsInHotel).ThenInclude(f => f.Room).ThenInclude(r => r.RoomServices).ToListAsync();
           //return await _context.RoomsInHotel.Include(d => d.Room).Include(e => e.Hotel)
           //     .Where(w => w.Hotel.city == filterViewModeles.city).ToListAsync();
         
        }
        // GET: api/BookingRoomToUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingRoomToUser>>> GetBookingRoomToUser()
        {
          if (_context.BookingRoomToUser == null)
          {
              return NotFound();
          }
            return await _context.BookingRoomToUser.ToListAsync();
        }

        // GET: api/BookingRoomToUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingRoomToUser>> GetBookingRoomToUser(string id)
        {
          if (_context.BookingRoomToUser == null)
          {
              return NotFound();
          }
            var bookingRoomToUser = await _context.BookingRoomToUser.FindAsync(id);

            if (bookingRoomToUser == null)
            {
                return NotFound();
            }

            return bookingRoomToUser;
        }

        // PUT: api/BookingRoomToUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingRoomToUser(string id,int RoomId,int HotelId, DataUserAfterService nbookingRoomToUser)
        {

            BookingRoomToUser obookingRoomToUser = _context.BookingRoomToUser
                                        .FirstOrDefault(w => w.UserId == id && w.RoomId == RoomId&&w.HotelId==HotelId);

            //int HotelId = _context.RoomsInHotel.FirstOrDefault(w => w.RoomId == RoomId).HotelId;


            User user =_context.Users.FirstOrDefault(w=>w.Id== id);
            float nprice;
            if (nbookingRoomToUser.NumberOfRooms != 0)
                nprice = _context.RoomsInHotel.FirstOrDefault(w => w.RoomId == RoomId && w.HotelId == HotelId).Price * nbookingRoomToUser.NumberOfRooms;
            else
                nprice = obookingRoomToUser.TotalPrice;
            BookingRoomToUser bookingRoomToUser = new BookingRoomToUser();

            if (bookingRoomToUser==null)
            {
                return BadRequest();
            }
            if (RoomId != nbookingRoomToUser.RoomId)
            {
                _context.BookingRoomToUser.Remove(_context.BookingRoomToUser.FirstOrDefault(f => f.RoomId == RoomId && f.UserId == id));
               if(nbookingRoomToUser.RoomId==0)
                    bookingRoomToUser.RoomId = obookingRoomToUser.RoomId;
               else
                    bookingRoomToUser.RoomId = nbookingRoomToUser.RoomId;

                bookingRoomToUser.UserId = id;
                bookingRoomToUser.HotelId = HotelId;
                _context.BookingRoomToUser.Add(bookingRoomToUser);

            }
          
            bookingRoomToUser.NumberOfChildren = nbookingRoomToUser.NumberOfChildren!=0?nbookingRoomToUser.NumberOfChildren:obookingRoomToUser.NumberOfRooms;
            bookingRoomToUser.NumberOfRooms=nbookingRoomToUser.NumberOfRooms != 0 ? nbookingRoomToUser.NumberOfRooms : obookingRoomToUser.NumberOfRooms;   
            bookingRoomToUser.NumberOfAdult=nbookingRoomToUser.NumberOfAdult != 0 ? nbookingRoomToUser.NumberOfAdult : obookingRoomToUser.NumberOfAdult;
            bookingRoomToUser.EndDate = nbookingRoomToUser.EndDate!=bookingRoomToUser.EndDate?nbookingRoomToUser.EndDate:obookingRoomToUser.EndDate;
            bookingRoomToUser.StartDate=nbookingRoomToUser.StartDate != bookingRoomToUser.StartDate ? nbookingRoomToUser.StartDate : obookingRoomToUser.EndDate;
            bookingRoomToUser.TotalPrice = nprice;
            
            
         


            _context.Entry(bookingRoomToUser).State = EntityState.Modified;
            _context.SaveChanges();

            user.visaNumber=nbookingRoomToUser.visaNumber!=0?nbookingRoomToUser.visaNumber:user.visaNumber;
            user.visapassword=nbookingRoomToUser.visapassword!=0?nbookingRoomToUser.visapassword:user.visapassword;

            _context.Entry(user).State=EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingRoomToUserExists(nbookingRoomToUser.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Data Updated Successfully");
        }

        // POST: api/BookingRoomToUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingRoomToUser>> PostBookingRoomToUser(DataUserAfterService nbookingRoomToUser)
        {
            BookingRoomToUser bookingRoomToUser = new BookingRoomToUser();
            float price = _context.RoomsInHotel.FirstOrDefault(w => w.RoomId == nbookingRoomToUser.RoomId && w.HotelId == nbookingRoomToUser.HotelId).Price;


            if (bookingRoomToUser == null)
            {
                return BadRequest();
            }
            bookingRoomToUser.UserId = nbookingRoomToUser.UserId;
            bookingRoomToUser.RoomId = nbookingRoomToUser.RoomId;
            bookingRoomToUser.HotelId = nbookingRoomToUser.HotelId;
            bookingRoomToUser.NumberOfChildren = nbookingRoomToUser.NumberOfChildren;
            bookingRoomToUser.NumberOfRooms = nbookingRoomToUser.NumberOfRooms ;
            bookingRoomToUser.NumberOfAdult = nbookingRoomToUser.NumberOfAdult;
            bookingRoomToUser.EndDate = nbookingRoomToUser.EndDate ;
            bookingRoomToUser.StartDate = nbookingRoomToUser.StartDate ;

            bookingRoomToUser.TotalPrice = price * nbookingRoomToUser.NumberOfRooms;



            _context.BookingRoomToUser.Add(bookingRoomToUser);

            User user = _context.Users.FirstOrDefault(w => w.Id == bookingRoomToUser.UserId);
            if(user == null)
            {
                return NotFound();
            }
            else
            {
                if (user.visaNumber==0)
                {
                    user.visaNumber = nbookingRoomToUser.visaNumber;
                    user.visapassword = nbookingRoomToUser.visapassword;
                }
            }
           

            
            if (_context.BookingRoomToUser == null)
          {
              return Problem("Entity set 'Bookingdb.BookingRoomToUser'  is null.");
          }
            _context.BookingRoomToUser.Add(bookingRoomToUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingRoomToUserExists(bookingRoomToUser.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Data added Successfully");
        }

        // DELETE: api/BookingRoomToUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingRoomToUser(string id, int RoomId)
        {
            if (_context.BookingRoomToUser == null)
            {
                return NotFound();
            }
            var bookingRoomToUser = await _context.BookingRoomToUser.FirstOrDefaultAsync(d=>d.UserId==id&&d.RoomId==RoomId);
            if (bookingRoomToUser == null)
            {
                return NotFound();
            }

            _context.BookingRoomToUser.Remove(bookingRoomToUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingRoomToUserExists(string id)
        {
            return (_context.BookingRoomToUser?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
