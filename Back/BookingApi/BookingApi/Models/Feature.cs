namespace BookingApi.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public IList<HotelFeatures> HotelFeatures { get; set; }

    }
}
