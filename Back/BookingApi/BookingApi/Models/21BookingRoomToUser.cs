﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models
{
    public class BookingRoomToUser
    {
        public int RoomId { get; set; }

        public string UserId { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public int NumberOfAdult { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfRooms { get; set; }
        public float  TotalPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }

      
        public virtual Hotel Hotel { get; set; }
    }
}
