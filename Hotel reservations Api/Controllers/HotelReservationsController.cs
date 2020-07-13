using Hotel_reservations_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hotel_reservations_Api.Controllers
{
    public class HotelReservationsController : ApiController
    {
        private readonly ApplicationDbContext db;

        public HotelReservationsController()
        {
            db = new ApplicationDbContext();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string hotelId)
        {
            var reservations = await db.Reservations.Include("Room").Include("User").Where(r => r.Room.HotelId == hotelId).ToListAsync();
            return Ok(reservations);
        }

        //[HttpPost]
        //public async Task<IHttpActionResult> Post(string hotelId, string roomId)
        //{

        //}
    }
}
