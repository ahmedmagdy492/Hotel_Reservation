using Hotels_Resrevation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotels_Resrevation.Controllers
{
    public class ReservationApiController : Controller
    {
        private readonly IReservationRepository reservationRepository;

        public ReservationApiController(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public ActionResult GetAllReservations()
        {
            return View();
        }
    }
}