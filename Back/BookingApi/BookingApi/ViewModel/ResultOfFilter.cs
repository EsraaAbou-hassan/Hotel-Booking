namespace BookingApi.ViewModel
{
    public class ResultOfFilter
    {
       
        public string type { get; set; }
      

        public int maxPeople { get; set; }
  
        public string description { get; set; }
        public int roomNumber { get; set; }

        public int HotelId { get; set; }

        public int Price { get; set; }
        public string[] ImagesFile { get; set; }

        public int[] Services { get; set; }
        public string name { get; set; }

    }
}
