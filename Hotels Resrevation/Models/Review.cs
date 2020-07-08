using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [ForeignKey(nameof(Hotel))]
        public string HotelId { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationUser Hotel { get; set; }
    }
}
