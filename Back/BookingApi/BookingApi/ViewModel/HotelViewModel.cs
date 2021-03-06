
using System.ComponentModel.DataAnnotations;

namespace BookingApi.ViewModel
{
    public class HotelViewModel
    {
        [Required]
        public string name { get; set; }
       

        [Required]
        public string city { get; set; }
        [Required]
        public string country { get; set; }
       
        public IFormFile[] ImagesFile { get; set; }
        //public int[] Features { get; set; }
        public  string Features { get; set; }


        [Required]
        public string description { get; set; }
        [Range(0, 5)]
        public int rating { get; set; }
        [Required]
        public int cheapestPrice { get; set; }//to know the cheapest room 
    }
}
