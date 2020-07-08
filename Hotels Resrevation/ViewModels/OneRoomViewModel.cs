using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.ViewModels
{
    public class OneRoomViewModel
    {
        public Room Room { get; set; }
        public List<RoomImage> RoomImages { get; set; }
        public string HotelId { get; set; }
    }
}
