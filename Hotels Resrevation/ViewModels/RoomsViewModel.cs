using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.ViewModels
{
    public class RoomsViewModel
    {
        public IEnumerable<Room> Rooms { get; set; }
        public string CurrentHotelId { get; set; }
    }
}
