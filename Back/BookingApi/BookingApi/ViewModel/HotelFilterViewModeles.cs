using System.ComponentModel.DataAnnotations;

namespace BookingApi.ViewModel
{
    public class HotelFilterViewModeles
    {
        public string city { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

    }
}
