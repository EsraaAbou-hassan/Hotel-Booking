using System.ComponentModel.DataAnnotations;

namespace BookingApi.Models
{
    public class Feature
    {

        public int FeatureId { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<HotelFeatures> HotelFeatures { get; set; }

    }
}
