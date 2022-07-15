


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
        List<HoteImages> avalibalehotels = new List<HoteImages>();


        public BookingRoomToUsersController(Bookingdb context)
        {
            _context = context;
        }
        [HttpPost("ChooseHotel")]


        public async Task<ActionResult<IEnumerable<HoteImages>>> HotelFilter(HotelFilterViewModeles filterViewModeles)
        {
            if (filterViewModeles == null)
            {
                return NotFound();

            }

            List<BookingRoomToUser> BookingRoomToUsers = _context.BookingRoomToUser.Where(e => e.EndDate == filterViewModeles.EndDate && e.StartDate == filterViewModeles.StartDate).ToList();

            List<Hotel> hotels = _context.Hotels.Where(d => d.city == filterViewModeles.city).ToList();

            List<RoomsInHotel> roomsInHoteles = new List<RoomsInHotel>();
            for (var i = 0; i < hotels.Count; i++)
            {
                RoomsInHotel RoomsInHotel;
                if (BookingRoomToUsers.Count > 0)
                {
                    for (var ii = 0; ii < BookingRoomToUsers.Count; ii++)
                    {
                        RoomsInHotel = _context.RoomsInHotel.FirstOrDefault(d => d.HotelId != BookingRoomToUsers[ii].HotelId && d.HotelId == hotels[i].HotelId && d.RoomId != BookingRoomToUsers[ii].RoomId);
                        roomsInHoteles.Add(RoomsInHotel);
                    }

                }
                else
                {
                    roomsInHoteles = _context.RoomsInHotel.Where(b => b.HotelId == hotels[i].HotelId).ToList();

                }



            }
            


            for (var i = 0; i < roomsInHoteles.Count; i++)
            {
                HoteImages avalibalehotel = _context.HoteImages.Include(e => e.Hotel).ThenInclude(e => e.HotelFeatures).FirstOrDefault(t => t.HotelId == roomsInHoteles[i].HotelId);
                if (avalibalehotels.Count > 0)
                {

                    foreach (var ii in avalibalehotels)
                    {
                        if (ii.HotelId != avalibalehotel.HotelId)
                            avalibalehotels.Add(avalibalehotel);



                    }
                }
                else
                {
                    avalibalehotels.Add(avalibalehotel);

                }


            }




            return avalibalehotels;


        }
        [HttpPost("ChooseRoom")]


        public async Task<ActionResult<IEnumerable<RoomImages>>> RoomFilter(int id)
        {
            


           //avalibalehotels.Where(e)

           

           // if (hotel == null)
           // {
           //     return NotFound();

           // }

            List<RoomsInHotel> roomsInHoteles = new List<RoomsInHotel>(); 
          
           

            List<RoomImages> rooms = new List<RoomImages>();
            if (roomsInHoteles.Count > 0)
            {
                for (var i = 0; i < roomsInHoteles.Count; i++)
                {
                    RoomImages room= _context.RoomImages.Include(e => e.Room).ThenInclude(e => e.RoomServices).FirstOrDefault(t => t.RoomId == roomsInHoteles[i].RoomId);
                    rooms.Add(room);




                }
            }
            else
            {
                rooms = _context.RoomImages.Include(e => e.Room).ThenInclude(e => e.RoomServices).ToList();
            }


            return rooms;
          

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
