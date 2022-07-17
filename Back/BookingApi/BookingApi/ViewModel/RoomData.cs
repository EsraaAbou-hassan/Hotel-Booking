using BookingApi.Models;

namespace BookingApi.ViewModel
{
    public class RoomData
    {
        public Room roomData { get; set; }
        public List<RoomService> roomService { get; set; }
        public List<Service> Service { get; set; }

        public List<RoomImages> roomImages { get; set; }


    }
}
