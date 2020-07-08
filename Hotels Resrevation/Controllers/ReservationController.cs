using Hotels_Resrevation.Models;
using Hotels_Resrevation.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hotels_Resrevation.Controllers
{
    [Authorize(Roles = Hotels_Resrevation.Constants.Constants.UserRole)]
    public class ReservationController : Controller
    {
        private readonly IReservationRepository reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Book(int roomId, DateTime fromDate, DateTime toDate)
        {
            var daysCount = toDate - fromDate;
            var reservation = new Reservation
            {
                StartDate = fromDate,
                EndDate = toDate,
                UserId = User.Identity.GetUserId(),
                DayCount = daysCount.Days,
                RoomId = roomId
            };
            var result = await reservationRepository.Book(reservation);
            if(result == null)
            {
                return Content("Something went wrong: the room is not available at this date");
            }
            return Content("Reservation is Successfull");
        }

        public async Task<ActionResult> CheckReservation(DateTime fromDate, DateTime toDate, int roomId)
        {
            if (await reservationRepository.IsReserved(roomId, fromDate, toDate))
            {
                return Content("Reserved");
            }
            return Content("Not Reserved");
        }
    }
}