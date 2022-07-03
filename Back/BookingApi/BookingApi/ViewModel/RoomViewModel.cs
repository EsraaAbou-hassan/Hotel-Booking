using System.ComponentModel.DataAnnotations;

namespace BookingApi.ViewModel
{
    public class RoomViewModel
    {
        [Required]
        public string title { get; set; }
        [Required]

       
        public int maxPeople { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int roomNumber { get; set; }
        [Required]

        public int HotelId { get; set; }
        [Required]
        
        public int Price { get; set; }
        public string[] Images { get; set; }
    }
}
