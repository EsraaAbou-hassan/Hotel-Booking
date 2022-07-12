namespace BookingApi.ViewModel
{
    public class DataUserAfterService
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string UserId { get; set; }
        public int NumberOfAdult { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfRooms { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int visaNumber { get; set; }
        public int visapassword { get; set; }

       
    }
}
