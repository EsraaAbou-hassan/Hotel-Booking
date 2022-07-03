using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models
{
    public class RoomsInHotel
    {

        public int RoomId { get; set; }

        public int HotelId { get; set; }

        public int Price { get; set; }
        public virtual Room Room { get; set; }
        public virtual Hotel Hotel { get; set; }
      
        
    }
}
