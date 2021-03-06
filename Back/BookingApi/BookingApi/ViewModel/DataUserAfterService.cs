using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.ViewModel
{
    public class DataUserAfterService
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string Usename { get; set; }
        public int NumberOfAdult { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfRooms { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime EndDate { get; set; }

        public int visaNumber { get; set; }
        public int visapassword { get; set; }

       
    }
}
