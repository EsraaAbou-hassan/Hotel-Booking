using System.ComponentModel.DataAnnotations;

namespace BookingApi.ViewModel
{
    public class HotelViewModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string type { get; set; }

        [Required]
        public string city { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string distance { get; set; }

        [Required]
        public string title { get; set; }
        public string[] Images { get; set; }


        [Required]
        public string description { get; set; }
        [Range(0, 5)]
        public int rating { get; set; }
        [Required]
        public int cheapestPrice { get; set; }//to know the cheapest room 
        public bool featured { get; set; } = false;
    }
}
