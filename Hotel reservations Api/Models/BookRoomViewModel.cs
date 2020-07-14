using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_reservations_Api.Models
{
    public class BookRoomViewModel
    {
        public string HotelId { get; set; }
        public int RoomId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}