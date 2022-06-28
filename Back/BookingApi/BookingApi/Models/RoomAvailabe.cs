using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models
{
    public class RoomAvailabe
    {

        public int RoomId { get; set; }

        public int HotelId { get; set; }

        public DateTime Date { get; set; }
        public bool isAvalable { get; set; } = true;
        public virtual Room Room { get; set; }
        public virtual Hotel Hotel { get; set; }
      
        
    }
}
