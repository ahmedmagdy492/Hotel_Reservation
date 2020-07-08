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
    public class FacilityController : Controller
    {
        private readonly IFacilityRepository facilityRepository;

        public FacilityController(IFacilityRepository facilityRepository)
        {
            this.facilityRepository = facilityRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddFacility(string name)
        {
            if(name != null)
            {
                Facilties facilties = new Facilties
                {
                    Name = name,
                    HotelId = User.Identity.GetUserId()
                };
                await facilityRepository.CreateFacility(facilties);
                return PartialView("_HotelFacilites", await facilityRepository.GetFaciltiesOfHotel(User.Identity.GetUserId()));
            }
            return PartialView("_HotelFacilites", await facilityRepository.GetFaciltiesOfHotel(User.Identity.GetUserId()));
        }
    }
}