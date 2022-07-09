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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HotelsController(Bookingdb context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        // public async Task<IActionResult> PutHotel(int id,[FromForm] HotelViewModel hotel)

        public async Task<IActionResult> PutHotel(int id,HotelViewModel hotel)
        {
            Hotel oldhotel= await _context.Hotels.FindAsync(id);
            List<HoteImages> oldImages = await _context.HoteImages.ToListAsync();
            List<HotelFeatures> oldFeature= await _context.HotelFeatures.Where(e=>e.HotelId==id).ToListAsync();
            if (id != oldhotel.HotelId)
            {
                return BadRequest();
            }
            oldhotel.name = hotel.name!="string"?hotel.name:oldhotel.name;
            oldhotel.city = hotel.city != "string" ? hotel.city : oldhotel.city;

            oldhotel.country= hotel.country != "string" ? hotel.country : oldhotel.country;

            oldhotel.description = hotel.description != "string" ? hotel.description : oldhotel.description;
            oldhotel.cheapestPrice = hotel.cheapestPrice != 0 ? hotel.cheapestPrice: oldhotel.cheapestPrice;
            oldhotel.rating = hotel.rating !=5 ? hotel.rating: oldhotel.rating;
        
            _context.Entry(oldhotel).State = EntityState.Modified;
            string[] images = UpdateImge(hotel.ImagesFile);



           
            for (var i = 0; i <images?.Length; i++)
            {

                if(_context.HoteImages.FirstOrDefault(r => r.HotelId == oldhotel.HotelId) != null)
                {
                    HoteImages HotelImages = _context.HoteImages.FirstOrDefault(r => r.Name == oldImages[i].Name);


                    HotelImages.Name = images[i] !=null ? images[i] : oldImages[i].Name;
                    _context.Entry(HotelImages).State = EntityState.Modified;
                }

                
            }
            if (hotel.Features[0] !=0) {
                for (var ii = 0; ii < oldFeature.Count; ii++)
                {

                    _context.HotelFeatures.Remove(oldFeature[ii]);
                    _context.SaveChanges();
                }


                for (var i = 0; i < hotel.Features?.Length; i++)
                {
                    HotelFeatures hotelFeatures = new HotelFeatures();
                    hotelFeatures.HotelId = id;

                    hotelFeatures.FeatureId = hotel.Features[i];

                    _context.HotelFeatures.Add(hotelFeatures);

                    _context.SaveChanges();

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
        //        public async Task<ActionResult<Hotel>> PostHotel([FromForm] HotelViewModel hotel)

        public async Task<ActionResult<Hotel>> PostHotel(HotelViewModel hotel)
        {
            Hotel newhotel = new Hotel();
            HoteImages HotelImages ;
            newhotel.name = hotel.name;
            newhotel.city = hotel.city;

            newhotel.country = hotel.country;

            newhotel.description=hotel.description;
            newhotel.cheapestPrice= hotel.cheapestPrice;
            newhotel.rating= hotel.rating;

          

            



          if (_context.Hotels == null)
          {
              return Problem("Entity set 'Bookingdb.Hotels'  is null.");
          }
            _context.Hotels.Add(newhotel);
            await _context.SaveChangesAsync();
            string[] images = UpdateImge(hotel.ImagesFile);
           

            
            for (var i=0;i<images.Length;i++)
            {
                HotelImages = new HoteImages();
                HotelImages.HotelId = newhotel.HotelId;
                HotelImages.Name = images[i];
                _context.HoteImages.Add(HotelImages);
                await _context.SaveChangesAsync();
               
            }
            List<Feature> feature = _context.Features.ToList();
   

                for (var ii = 0; ii < hotel.Features.Length; ii++)
                {
                        for (var i = 0; i < feature.Count; i++)
                        {
                            

                            if (feature[i].FeatureId == hotel.Features[ii])
                                {
                                HotelFeatures hotelFeatures = new HotelFeatures();
                                hotelFeatures.HotelId = newhotel.HotelId;
                                hotelFeatures.FeatureId = feature[i].FeatureId;
                                 
                                _context.HotelFeatures.Add(hotelFeatures);
                                _context.SaveChangesAsync();

                            }
                            else
                            {
                                continue;
                            }

                        }
                
                    
            }


            return Ok("Data Added Successfully");
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
                List<HotelFeatures> hotelFeatures = _context.HotelFeatures.ToList();
                for (var i = 0; i < hotelFeatures.Count; i++)
                {
                    HotelFeatures r = _context.HotelFeatures.FirstOrDefault(d => d.HotelId == id);
                    _context.HotelFeatures.Remove(r);

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
        private string[] UpdateImge(IFormFile[] ImageFiles)
        {

            string[] images = new string[ImageFiles.Length];
            for (var i = 0; i < ImageFiles.Length; i++)
            {
                images[i] = new String(Path.GetFileNameWithoutExtension(ImageFiles[i].FileName)
                    .Take(10).ToArray())
                    .Replace(" ", "-");
                images[i] += DateTime.Now.ToString("yymmssfff");
                var imgPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images/Hotels", images[i]);
                using (FileStream fs = new FileStream(imgPath, FileMode.Create))
                {
                    ImageFiles[i].CopyToAsync(fs);
                }

            }
            return images;


        }
        private bool HotelExists(int id)
        {
            return (_context.Hotels?.Any(e => e.HotelId == id)).GetValueOrDefault();
        }
    }
}
