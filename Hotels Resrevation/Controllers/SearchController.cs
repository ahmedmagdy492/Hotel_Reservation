using Hotels_Resrevation.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace Hotels_Resrevation.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchRepository searchRepo;

        public SearchController(ISearchRepository searchRepo)
        {
            this.searchRepo = searchRepo;
        }

        public async Task<ActionResult> Index(int? i)
        {
            var hotels = (await searchRepo.GetAllHotels()).ToPagedList(i ?? 1, 4);
            return View(hotels);
        }

        [HttpPost]
        public async Task<ActionResult> Search(string searchQuery, int? i)
        {
            var hotels = await searchRepo.GetHotelByName(searchQuery);
            return PartialView("_SearchResult", hotels.ToPagedList(i ?? 1, 4));
        }
    }
}