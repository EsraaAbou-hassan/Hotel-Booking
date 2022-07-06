using System.ComponentModel.DataAnnotations;

namespace BookingApi.ViewModel
{
    public class FeatureAndServiceViewModel
    {
       
        [Required]
        public string Name { get; set; }
    }
}
