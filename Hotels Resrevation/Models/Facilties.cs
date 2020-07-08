using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Models
{
    public class Facilties
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(Hotel))]
        public string HotelId { get; set; }
        public ApplicationUser Hotel { get; set; }
    }
}
