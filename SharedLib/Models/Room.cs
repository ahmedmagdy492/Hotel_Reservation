using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Capcity { get; set; }
        public bool IsSuite { get; set; }
        public double Price { get; set; }

        public string HotelId { get; set; }
        public ApplicationUser Hotel { get; set; }
        public List<RoomImage> RoomImages { get; set; }
        public List<Reservation> Rooms { get; set; }
    }
}
