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
    public class RoomsController : ApiController
    {
        private readonly ApplicationDbContext db;

        public RoomsController()
        {
            db = new ApplicationDbContext();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string hotelId)
        {
            return Ok(await db.Rooms.Where(r => r.HotelId == hotelId).ToListAsync());
        }
    }
}
