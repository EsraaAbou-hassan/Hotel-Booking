﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models
{
    public class Hotel
    {
        public int HotelId{ get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string type { get; set; }

        [Required]
        public string city { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string distance { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }
        [Range(0,5)]
        public int rating { get; set; }
        [Required]
        public int cheapestPrice { get; set; }//to know the cheapest room 
        public bool featured { get; set; }=false;

        public IList<RoomAvailabe> RoomAvailabe { get; set; }



    }
}
