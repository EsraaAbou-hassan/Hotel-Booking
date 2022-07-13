using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookingApi.Models
{
    public class RoomsInHotel
    {

        public int RoomId { get; set; }

        public int HotelId { get; set; }

        public int Price { get; set; }

        [JsonIgnore]
        public virtual Room Room { get; set; }
        [JsonIgnore]
        public virtual Hotel Hotel { get; set; }
      
        
    }
}
