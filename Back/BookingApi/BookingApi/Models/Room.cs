using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [Required]
        public string title { get; set; }
        [Required]
        public int price { get; set; }

        [Required]
        public int maxPeople { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int roomNumbers { get; set; }

        public IList<RoomAvailabe> RoomAvailabe { get; set; }

    }
}
