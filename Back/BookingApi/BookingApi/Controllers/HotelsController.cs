
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
        public async Task<ActionResult<IEnumerable<HotelData>>> GetHotels()
        {
            List<HotelData> HotelsData = new List<HotelData>();

            List<Hotel> hotels = _context.Hotels.Include(g => g.RoomsInHotel).ToList();
            if (_context.Hotels == null)
          {
              return NotFound();
          }
            HotelsData = HotelData(hotels);
            return HotelsData;

        }
        [HttpGet("Top Rating")]
        public async Task<ActionResult<IEnumerable<HotelData>>> GetTopRatingOFHotels()
        {
            List<HotelData> HotelsData = new List<HotelData>();

            List<Hotel> hotels = _context.Hotels.Include(g => g.RoomsInHotel).Where(u => u.rating == 5).ToList();
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            HotelsData = HotelData(hotels);

            return HotelsData;


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
        public async Task<IActionResult> PutHotel(int id,[FromForm] HotelViewModel hotel)

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




            for (var i = 0; i < images?.Length; i++)
            {

                if (_context.HoteImages.FirstOrDefault(r => r.HotelId == oldhotel.HotelId) != null)
                {
                    HoteImages HotelImages = _context.HoteImages.FirstOrDefault(r => r.Name == oldImages[i].Name);

                    //HotelImages.HotelId = oldImages[i].HotelId;
                    HotelImages.Name = images[i] != null ? images[i] : oldImages[i].Name;
                    _context.Entry(HotelImages).State = EntityState.Modified;
                }


            }
            if (hotel.Features[0] !=0) {
                for (var ii = 0; ii < oldFeature.Count; ii++)
                {

                    _context.HotelFeatures.Remove(oldFeature[ii]);
                    _context.SaveChanges();
                }

                int[] features = hotel.Features.Substring(1, hotel.Features.Length - 2).Split(',').Select(c => int.Parse(c)).ToArray();

                for (var i = 0; i < features?.Length; i++)
                {
                    HotelFeatures hotelFeatures = new HotelFeatures();
                    hotelFeatures.HotelId = id;

                    hotelFeatures.FeatureId = features[i];

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
        public async Task<ActionResult<Hotel>> PostHotel([FromForm] HotelViewModel hotel)

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



            for (var i = 0; i < images.Length; i++)
            {
                HotelImages = new HoteImages();
                HotelImages.HotelId = newhotel.HotelId;
                HotelImages.Name = images[i];
                _context.HoteImages.Add(HotelImages);
                await _context.SaveChangesAsync();

            }
            List<Feature> feature = _context.Features.ToList();

          

            int[] features = hotel.Features.Substring(1, hotel.Features.Length - 2).Split(',').Select(c => int.Parse(c)).ToArray();
           

            for (var ii = 0; ii < features.Length; ii++)
                {
                        for (var i = 0; i < feature.Count; i++)
                        {
                            

                            if (feature[i].FeatureId == features[ii])
                                {
                                HotelFeatures hotelFeatures = new HotelFeatures();
                                hotelFeatures.HotelId = newhotel.HotelId;
                                hotelFeatures.FeatureId = feature[i].FeatureId;
                                 
                                _context.HotelFeatures.Add(hotelFeatures);

                            }
                            else
                            {
                                continue;
                            }

                        }
                
                    
            }
            _context.SaveChangesAsync();


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
                List<HoteImages> HoteImages = _context.HoteImages.ToList();
                for (var i = 0; i < HoteImages.Count; i++)
                {
                    HoteImages rr = _context.HoteImages.FirstOrDefault(d => d.HotelId == id);
                    if (rr!= null)
                        _context.HoteImages.Remove(rr);

                }
                List<HotelFeatures> hotelFeatures = _context.HotelFeatures.ToList();
                for (var i = 0; i < hotelFeatures.Count; i++)
                {
                    HotelFeatures r = _context.HotelFeatures.FirstOrDefault(d => d.HotelId == id);
                    if(r != null)
                      _context.HotelFeatures.Remove(r);

                }





                List<RoomsInHotel> roomsInHotels = _context.RoomsInHotel.ToList();
                for (var h = 0; h < roomsInHotels.Count; h++)
                {
                    RoomsInHotel  roomsInHotel = _context.RoomsInHotel.FirstOrDefault(s => s.HotelId == roomsInHotels[h].HotelId);

                    if (roomsInHotel != null)

                        _context.RoomsInHotel.Remove(roomsInHotel);

                }
                _context.Hotels.Remove(hotel);

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
                string extention = Path.GetExtension(ImageFiles[i].FileName);
                images[i] += DateTime.Now.ToString("yymmssfff")+extention;
                var imgPath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/Images/Hotels", images[i]);
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
        private List<HotelData> HotelData(List<Hotel> hotels)
        {
            List<HotelData> HotelsData = new List<HotelData>();

            for (var i = 0; i < hotels.Count; i++)
            {
                Hotel Hotel = hotels[i];
                List<HotelFeatures> HotelFeatures = _context.HotelFeatures.Include(u => u.Feature).Where(J => J.HotelId == hotels[i].HotelId).ToList();
                List<HoteImages> HoteImages = _context.HoteImages.Where(J => J.HotelId == hotels[i].HotelId).ToList();
                List<Feature> Features = new List<Feature>();

                for (var ii = 0; ii < HotelFeatures.Count; ii++)
                {
                    Feature Feature = new Feature();



                    Feature = _context.Features.FirstOrDefault(J => J.FeatureId == HotelFeatures[ii].FeatureId);
                    Features.Add(Feature);
                }
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
    }
}
