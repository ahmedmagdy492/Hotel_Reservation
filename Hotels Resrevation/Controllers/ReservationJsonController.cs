using Hotels_Resrevation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hotels_Resrevation.Controllers
{
    [Authorize(Roles = Constants.Constants.HotelRole)]
    public class ReservationJsonController : ApiController
    {
        private readonly IReservationRepository reservationRepository;

        public ReservationJsonController(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string hotelId)
        {
            if (hotelId == null) return NotFound();

            var reservations = await reservationRepository.GetHotelReservations(hotelId);
            return Ok(reservations);
        }
    }
}
