using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models
{
    public class HoteImages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

    }
}
