namespace BookingApi.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public IList<RoomService> RoomServices { get; set; }
    }
}
