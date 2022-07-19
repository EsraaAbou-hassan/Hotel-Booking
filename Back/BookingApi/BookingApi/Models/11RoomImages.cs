using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models
{
    public class RoomImages
    {
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
