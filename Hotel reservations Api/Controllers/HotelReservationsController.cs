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
    [Authorize]
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

        private async Task<bool> IsReserved(int roomId, DateTime fromDate, DateTime toDate)
        {
            var reservation = await db.Reservations.FirstOrDefaultAsync(r => r.RoomId == roomId && ((fromDate >= r.StartDate && toDate <= r.EndDate) || (toDate > r.StartDate && toDate < r.EndDate) || (fromDate > r.StartDate && fromDate < r.EndDate) || (fromDate < r.StartDate && toDate > r.EndDate)));
            return reservation != null;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(BookRoomViewModel model)
        {
            if(!(await IsReserved(model.RoomId, model.FromDate, model.ToDate)))
            {
                db.Reservations.Add(new Reservation
                {
                    StartDate = model.FromDate,
                    EndDate = model.ToDate,
                    DayCount = (model.ToDate - model.FromDate).Days,
                    RoomId = model.RoomId,
                    UserId = model.HotelId
                });
                await db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Invalid Date");
        }
    }
}
