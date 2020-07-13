using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_reservations_Api.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int Capcity { get; set; }
        public bool IsSuite { get; set; }
        public double Price { get; set; }

        [ForeignKey(nameof(Hotel))]
        public string HotelId { get; set; }
        public ApplicationUser Hotel { get; set; }
        public List<RoomImage> RoomImages { get; set; }
        public List<Reservation> Rooms { get; set; }
    }
}
