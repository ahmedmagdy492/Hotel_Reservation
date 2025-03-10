﻿using Hotel_reservations_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservations_Management.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DayCount { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
