using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservations_Management.Models
{
    public class RoomImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
