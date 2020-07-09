using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.ViewModels
{
    public class HotelProfileViewModel
    {
        public ApplicationUser CurrentUserProfile { get; set; }
        public IEnumerable<UserImage> Images { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Facilties> Facilties { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
