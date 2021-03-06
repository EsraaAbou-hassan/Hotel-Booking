
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
        private static IWebHostEnvironment _webHostEnvironment;
        public RoomsController(Bookingdb context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Rooms
        [HttpGet]

        public async Task<ActionResult<IEnumerable<RoomData>>> GetRooms()

        {
            List<RoomData> roomsData = new List<RoomData>();

            List<Room> rooms = _context.Rooms.Include(g => g.RoomsInHotel).ToList();


            if (_context.Rooms == null)
            {
                return NotFound();
            }
            roomsData = RoomsData(rooms);



            return roomsData;
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
        public async Task<IActionResult> UpdateRoom(int id, [FromForm] RoomViewModel nroom)

        {
            Room room = await _context.Rooms.FindAsync(id);
            List<RoomImages> oldImages = await _context.RoomImages.ToListAsync();
            List<RoomsInHotel> oldroomsInHotels = await _context.RoomsInHotel.ToListAsync();
            List<RoomService> oldServices = await _context.RoomServices.Where(i => i.RoomId == id).ToListAsync();
            if (id != room.RoomId)
            {
                return BadRequest();
            }

            room.type = nroom.type != "string" ? nroom.type : room.type;
            room.description = nroom.description != "string" ? nroom.description : room.description;
            room.roomNumber = nroom.roomNumber != 0 ? nroom.roomNumber : room.roomNumber;

            room.maxPeople = nroom.maxPeople != 0 ? nroom.maxPeople : room.maxPeople;
            _context.Entry(room).State = EntityState.Modified;

            string[] images = UpdateImge(nroom.ImagesFile, id);





            for (var i = 0; i < images?.Length; i++)
            {
                for (var j = 0; j < oldImages.Count; j++)
                {
                    if (_context.RoomImages.FirstOrDefault(R => R.RoomId == room.RoomId) != null)
                    {
                        RoomImages roomImages = _context.RoomImages.FirstOrDefault(r => r.Id == oldImages[j].Id && r.RoomId == id);
                        if (roomImages != null)
                        {


                            roomImages.RoomId = room.RoomId;

                            //roomImages.Name = oldImages[j].Name != images[i] && images[i] != null ? images[i] : oldImages[j].Name;
                            roomImages.Name = images[i];

                            _context.Entry(roomImages).State = EntityState.Modified;
                        }
                    }
                        else
                        {
                            RoomImages roomImage = new RoomImages();
                            roomImage.RoomId = room.RoomId;
                            roomImage.Name = images[i];
                            _context.RoomImages.Add(roomImage);


                        }
                    _context.SaveChanges();

                }
            }
            if (oldroomsInHotels.Count > 0)
            {
                for (var i = 0; i < oldroomsInHotels?.Count; i++)
                {

                    RoomsInHotel roomsInHotel = await _context.RoomsInHotel.FirstOrDefaultAsync(d => d.RoomId == id && d.HotelId == oldroomsInHotels[i].HotelId);
                    if (roomsInHotel != null)
                    {
                        //roomsInHotel.HotelId = nroom.HotelId != 0 ? nroom.HotelId : roomsInHotel.HotelId;
                        //roomsInHotel.RoomId = room.RoomId;
                        roomsInHotel.Price = nroom.Price != 0 ? nroom.Price : roomsInHotel.Price;
                        _context.Entry(roomsInHotel).State = EntityState.Modified;
                    }
                    //else
                    //{
                    //    RoomsInHotel hotelroom = new RoomsInHotel();
                    //    hotelroom.HotelId = nroom.HotelId;
                    //    hotelroom.RoomId = room.RoomId;
                    //    hotelroom.Price = nroom.Price;
                    //    _context.RoomsInHotel.Add(hotelroom);
                    //}



                }
            }
            else
            {
                RoomsInHotel hotelrooms = new RoomsInHotel();
                hotelrooms.HotelId = nroom.HotelId;
                hotelrooms.RoomId = room.RoomId;
                hotelrooms.Price = nroom.Price;
                _context.RoomsInHotel.Add(hotelrooms);
            }
            if (nroom.Services[0] != 0)
            {
                for (var ii = 0; ii < oldServices.Count; ii++)
                {

                    _context.RoomServices.Remove(oldServices[ii]);
                    _context.SaveChanges();
                }

                int[] services = nroom.Services.Substring(1, nroom.Services.Length - 2).Split(',').Select(c => int.Parse(c)).ToArray();

                for (var i = 0; i < services?.Length; i++)
                {
                    RoomService roomService = new RoomService();
                    roomService.RoomId = id;

                    roomService.ServiceId = services[i];

                    _context.RoomServices.Add(roomService);

                    _context.SaveChanges();

                }


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
        public async Task<ActionResult<Room>> AddRoom([FromForm] RoomViewModel nroom)
        // public async Task<ActionResult<Room>> AddRoom(RoomViewModel nroom)
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
                string[] images = UpdateImge(nroom.ImagesFile, room.RoomId);
                RoomImages roomImages;

                for (var i = 0; i < images.Length; i++)
                {
                    roomImages = new RoomImages();
                    roomImages.RoomId = room.RoomId;
                    roomImages.Name = images[i];
                    _context.RoomImages.Add(roomImages);
                    await _context.SaveChangesAsync();
                }
                List<Service> Services = _context.Services.ToList();
                int[] services = nroom.Services.Substring(1, nroom.Services.Length - 2).Split(',').Select(c => int.Parse(c)).ToArray();


                for (var ii = 0; ii < services.Length; ii++)
                {
                    for (var i = 0; i < Services.Count; i++)
                    {


                        if (services[i] == Services[ii].ServiceId)
                        {
                            RoomService roomService = new RoomService();
                            roomService.ServiceId = Services[ii].ServiceId;
                            roomService.RoomId = room.RoomId;

                            _context.RoomServices.Add(roomService);


                        }
                        else
                        {
                            continue;
                        }

                    }


                }
                _context.SaveChangesAsync();
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


            List<RoomImages> roomImages = _context.RoomImages.ToList();
            for (var i = 0; i < roomImages.Count; i++)
            {
                RoomImages RoomImages = _context.RoomImages.FirstOrDefault(d => d.RoomId == id);
                if (RoomImages != null)

                    _context.RoomImages.Remove(RoomImages);

            }

            List<RoomService> RoomServices = _context.RoomServices.ToList();
            for (var i = 0; i < RoomServices.Count; i++)
            {
                RoomService RoomService = _context.RoomServices.FirstOrDefault(d => d.RoomId == id);
                if (RoomService != null)
                    _context.RoomServices.Remove(RoomService);

            }






            //List<RoomsInHotel> roomsInHotels = _context.RoomsInHotel.ToList();
            //for (var h = 0; h < roomsInHotels.Count; h++)
            //{
            //    RoomsInHotel roomsInHotel = _context.RoomsInHotel.FirstOrDefault(s => s.HotelId == roomsInHotels[h].HotelId && s.RoomId == roomsInHotels[h].RoomId);
            //    if (roomsInHotel != null)
            //        _context.RoomsInHotel.Remove(roomsInHotel);

            //}
            _context.Rooms.Remove(room);

            await _context.SaveChangesAsync();
            return Ok("data deleted Successfully");


        }
        private string[] UpdateImge(IFormFile[] ImageFiles, int RoomId)
        {

            string[] images = new string[ImageFiles.Length];
            for (var i = 0; i < ImageFiles.Length; i++)
            {
                string[] arr = ImageFiles[i].FileName.Split('.');
                images[i] = RoomId.ToString()+ ImageFiles[i] + "." + arr[arr.Length - 1];
                using (var std = new FileStream("./wwwroot/Images/Rooms/" + images[i], FileMode.Create))
                {
                    ImageFiles[i].CopyTo(std);
                }

            }
            return images;


        }
        //private string[] UpdateImge(IFormFile[] ImageFiles)
        //{

        //    string[] images = new string[ImageFiles.Length];
        //    for (var i = 0; i < ImageFiles.Length; i++)
        //    {
        //        images[i] = new String(Path.GetFileNameWithoutExtension(ImageFiles[i].FileName)
        //            .Take(10).ToArray())
        //            .Replace(" ", "-");
        //        string extention = Path.GetExtension(ImageFiles[i].FileName);
        //        images[i] += DateTime.Now.ToString("yymmssfff") + extention;
        //        var imgPath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/Images/Rooms", images[i]);
        //        using (FileStream fs = new FileStream(imgPath, FileMode.Create))
        //        {
        //            ImageFiles[i].CopyToAsync(fs);
        //        }

        //    }
        //    return images;


        //}
        private bool RoomExists(int id)
        {
            return (_context.Rooms?.Any(e => e.RoomId == id)).GetValueOrDefault();
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

                for (var ii = 0; ii < RoomService.Count; ii++)
                {
                    Service service = new Service();

                    service = _context.Services.FirstOrDefault(J => J.ServiceId == RoomService[ii].ServiceId);
                    services.Add(service);
                }
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
