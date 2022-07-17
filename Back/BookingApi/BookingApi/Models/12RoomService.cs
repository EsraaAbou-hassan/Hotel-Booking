using System.Text.Json.Serialization;

namespace BookingApi.Models
{
    public class RoomService
    {
        public int RoomId { get; set; }
        public int ServiceId { get; set; }
        [JsonIgnore]
        public virtual Room Room { get; set; }
        [JsonIgnore]

        public virtual Service Service { get; set; }
    }
}
