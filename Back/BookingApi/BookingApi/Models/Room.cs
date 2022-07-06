using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [Required]
        public string type { get; set; }
       

        [Required]
        public int maxPeople { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int roomNumber { get; set; }

        public IList<RoomsInHotel> RoomsInHotel { get; set; }
        public IList<RoomService> RoomServices { get; set; }

    }
}
