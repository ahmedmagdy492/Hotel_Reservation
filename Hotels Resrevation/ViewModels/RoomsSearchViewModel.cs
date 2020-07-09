using Hotels_Resrevation.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.ViewModels
{
    public class RoomsSearchViewModel
    {
        public IPagedList<Room> Rooms { get; set; }
    }
}
