


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
        private static List<RoomsInHotel> roomsInHoteles;



        public BookingRoomToUsersController(Bookingdb context)
        {
            _context = context;
        }
        [HttpPost("ChooseHotel")]


        public async Task<ActionResult<IEnumerable<HotelData>>> HotelFilter(HotelFilterViewModeles filterViewModeles)
        {
            if (filterViewModeles == null)
            {
                return NotFound();

            }

            List<BookingRoomToUser> BookingRoomToUsers = _context.BookingRoomToUser.Where(e => e.EndDate == filterViewModeles.EndDate && e.StartDate == filterViewModeles.StartDate).ToList();

            List<Hotel> hotels = _context.Hotels.Where(d => d.city == filterViewModeles.city).ToList();

            roomsInHoteles = new List<RoomsInHotel>();
            for (var i = 0; i < hotels.Count; i++)
            {
                RoomsInHotel RoomsInHotel = new RoomsInHotel();
                if (BookingRoomToUsers.Count > 0)
                {
                    for (var ii = 0; ii < BookingRoomToUsers.Count; ii++)
                    {
                        RoomsInHotel = _context.RoomsInHotel.FirstOrDefault(d => d.HotelId != BookingRoomToUsers[ii].HotelId && d.HotelId == hotels[i].HotelId && d.RoomId != BookingRoomToUsers[ii].RoomId);

                        if (RoomsInHotel != null)

                            roomsInHoteles.Add(RoomsInHotel);


                    }

                }
                else
                {
                    var b = _context.RoomsInHotel.Where(b => b.HotelId == hotels[i].HotelId).Include(t => t.Room).ToList();
                    if (b.Count > 0) {
                        for (var ii = 0; ii < b.Count; ii++)
                        {


                            roomsInHoteles.Add(b[ii]);


                        }
                    }
                }



            }

            List<Hotel> avalibalehotels = new List<Hotel>();

            for (var i = 0; i < roomsInHoteles.Count; i++)
            {
                Hotel avalibalehotel = _context.Hotels.FirstOrDefault(t => t.HotelId == roomsInHoteles[i].HotelId);
                if (avalibalehotels.Count > 0)
                {


                    var t = avalibalehotels.FindAll(e => e.HotelId == avalibalehotel.HotelId);
                    if (t.Count == 0)
                    {

                        avalibalehotels.Add(avalibalehotel);
                    }






                }
                else
                {
                    avalibalehotels.Add(avalibalehotel);

                }


            }

            List<HotelData> HotelsData = new List<HotelData>();

            HotelsData = HotelData(avalibalehotels);

            return HotelsData;


        }
        [HttpPost("ChooseRoom")]


        public async Task<ActionResult<IEnumerable<RoomData>>> RoomFilter(int id)
        {
            List<Room> rooms = new List<Room>();
            var avalibalerooms = roomsInHoteles.Where(e => e.HotelId == id).Select(o => o.Room).ToList();


            for (var i = 0; i < avalibalerooms.Count; i++)
            {

                Room room = _context.Rooms.Include(i => i.RoomsInHotel).FirstOrDefault(ii => ii.RoomId == avalibalerooms[i].RoomId);
                rooms.Add(room);




            }

            List<RoomData> roomsData = new List<RoomData>();

            roomsData = RoomsData(rooms);
            return roomsData;


        }
        // GET: api/BookingRoomToUsers
        [HttpGet("all booking for userr")]
        public async Task<ActionResult<IEnumerable<BookingRoomToUser>>> GetBookingRoomToUser()
        {
            if (_context.BookingRoomToUser == null)
            {
                return NotFound();
            }
            return await _context.BookingRoomToUser.ToListAsync();
        }

        // GET: api/BookingRoomToUsers/5
        [HttpGet]
        public async Task<ActionResult<BookingRoomToUser>> GetBookingRoomToUser(string userName)
        {
            User user = _context.Users.FirstOrDefault(w => w.UserName == userName);

            if (_context.BookingRoomToUser == null)
          {
              return NotFound();
          }
            BookingRoomToUser bookingRoomToUser = await _context.BookingRoomToUser.FirstOrDefaultAsync(r=>r.UserId==user.Id);

            if (bookingRoomToUser == null)
            {
                return NotFound();
            }

            return bookingRoomToUser;
        }

        // PUT: api/BookingRoomToUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutBookingRoomToUser(string userName,int RoomId,int HotelId, DataUserAfterService nbookingRoomToUser)
        {
            User user = _context.Users.FirstOrDefault(w => w.UserName == userName);


            BookingRoomToUser obookingRoomToUser = _context.BookingRoomToUser
                                        .FirstOrDefault(w => w.UserId ==user.Id && w.RoomId == RoomId&&w.HotelId==HotelId);

            //int HotelId = _context.RoomsInHotel.FirstOrDefault(w => w.RoomId == RoomId).HotelId;


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
                _context.BookingRoomToUser.Remove(_context.BookingRoomToUser.FirstOrDefault(f => f.RoomId == RoomId && f.UserId == user.Id));
               if(nbookingRoomToUser.RoomId==0)
                    bookingRoomToUser.RoomId = obookingRoomToUser.RoomId;
               else
                    bookingRoomToUser.RoomId = nbookingRoomToUser.RoomId;

                bookingRoomToUser.UserId = user.Id;
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
                if (user==null)
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
            bookingRoomToUser.UserId =_context.Users.FirstOrDefault(h=>h.UserName== nbookingRoomToUser.Usename).Id;
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
        public async Task<IActionResult> DeleteBookingRoomToUser(string userName, int RoomId)
        {
            User user = _context.Users.FirstOrDefault(w => w.UserName == userName);

            if (_context.BookingRoomToUser == null)
            {
                return NotFound();
            }
            var bookingRoomToUser = await _context.BookingRoomToUser.FirstOrDefaultAsync(d=>d.UserId== user.Id && d.RoomId==RoomId);
            if (bookingRoomToUser == null)
            {
                return NotFound();
            }

            _context.BookingRoomToUser.Remove(bookingRoomToUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingRoomToUserExists(string userName)
        {
            User user = _context.Users.FirstOrDefault(w => w.UserName == userName);

            return (_context.BookingRoomToUser?.Any(e => e.UserId == user.Id)).GetValueOrDefault();
        }
        private List<HotelData> HotelData(List<Hotel> hotels)
        {
            List<HotelData> HotelsData = new List<HotelData>();

            for (var i = 0; i < hotels.Count; i++)
            {
                Hotel Hotel = hotels[i];
                List<HotelFeatures> HotelFeatures = _context.HotelFeatures.Include(u => u.Feature).Where(J => J.HotelId == hotels[i].HotelId).ToList();
                List<HoteImages> HoteImages = _context.HoteImages.Where(J => J.HotelId == hotels[i].HotelId).ToList();
                List<Feature> Features = new List<Feature>();
                List<HoteImages> ImagesWithPath = new List<HoteImages>();
                for (var j = 0; j < HoteImages.Count; j++)
                {
                    HoteImages ImageWithPath = new HoteImages();
                    ImageWithPath.Id = HoteImages[j].Id;
                    ImageWithPath.Name = String.Format("{0}://{1}{2}/Images/Hotels/{3}", Request.Scheme, Request.Host, Request.PathBase, HoteImages[j].Name);
                    Console.WriteLine(ImageWithPath.Name);
                    ImagesWithPath.Add(ImageWithPath);
                }


                HotelData HotelData = new HotelData();
                HotelData.hotelData = Hotel;
                HotelData.hotelImages = ImagesWithPath;
                HotelData.hotelFeatures = HotelFeatures;
                HotelData.Feature = Features;
                HotelsData.Add(HotelData);

            }
            return HotelsData;
        }
        private List<RoomData> RoomsData(List<Room> rooms)
        {
            List<RoomData> roomsData = new List<RoomData>();
            for (var i = 0; i < rooms.Count; i++)
            {
                Room room = rooms[i];
                List<RoomService> RoomService = _context.RoomServices.Include(u => u.Service).Where(J => J.RoomId == rooms[i].RoomId).ToList();

                List<RoomImages> RoomImages = _context.RoomImages.Where(J => J.RoomId == rooms[i].RoomId).ToList();
                List<Service> services = new List<Service>();

                List<RoomImages> ImagesWithPath = new List<RoomImages>();

                for (var j = 0; j < RoomImages.Count; j++)
                {
                    RoomImages ImageWithPath = new RoomImages();
                    ImageWithPath.Id = RoomImages[j].Id;
                    ImageWithPath.Name = String.Format("{0}://{1}{2}/Images/Rooms/{3}", Request.Scheme, Request.Host, Request.PathBase, RoomImages[j].Name);
                    Console.WriteLine(ImageWithPath.Name);
                    ImagesWithPath.Add(ImageWithPath);
                }

                RoomData roomData = new RoomData();
                roomData.roomData = room;
                roomData.roomImages = ImagesWithPath;
                roomData.roomService = RoomService;
                roomData.Service = services;
                roomsData.Add(roomData);

            }
            return roomsData;

        }
    }
}
