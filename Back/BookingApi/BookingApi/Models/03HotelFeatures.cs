using System.Text.Json.Serialization;

namespace BookingApi.Models
{
    public class HotelFeatures
    {
        public int FeatureId { get; set; } 

        public int HotelId { get; set; }
        [JsonIgnore]


        public virtual Feature Feature { get; set; }
        [JsonIgnore]
        public virtual Hotel  Hotel{ get; set; }
    }
}
