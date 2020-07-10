using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotels_Resrevation.Controllers
{
    [Authorize(Roles = Constants.Constants.HotelRole)]
    public class DownloadsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}