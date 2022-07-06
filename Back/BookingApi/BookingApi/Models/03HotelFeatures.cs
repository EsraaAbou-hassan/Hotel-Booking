namespace BookingApi.Models
{
    public class HotelFeatures
    {
        public int FeatureId { get; set; }

        public int HotelId { get; set; }

        
        public virtual Feature Feature { get; set; }
        public virtual Hotel  Hotel{ get; set; }
    }
}
