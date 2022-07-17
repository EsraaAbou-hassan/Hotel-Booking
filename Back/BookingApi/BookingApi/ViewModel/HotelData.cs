using BookingApi.Models;

namespace BookingApi.ViewModel
{
    public class HotelData
    {
        public Hotel hotelData { get; set; }
        public List<HotelFeatures> hotelFeatures { get; set; }
        public List<Feature> Feature { get; set; }

        public List<HoteImages> hotelImages { get; set; }


    }
}
