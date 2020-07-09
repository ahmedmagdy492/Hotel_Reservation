using Hotels_Resrevation.Constants;
using Hotels_Resrevation.Repository;
using Hotels_Resrevation.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hotels_Resrevation.Controllers
{
    public class RoomSearchController : Controller
    {
        private readonly IRoomRepository roomRepository;

        public RoomSearchController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public async Task<ActionResult> Index(int? i)
        {
            var model = new RoomsSearchViewModel
            {
                Rooms = (await roomRepository.GetAllRooms()).ToPagedList(i ?? 1, 4)
            };
            return View(model);
        }

        public async Task<ActionResult> FilterBy(string filter, string filter2, int? i)
        {
            var rooms = Filters.FilterByPriceAndCapacity(await roomRepository.GetAllRooms(), filter2, filter);
            return PartialView("_RoomSearch", new RoomsSearchViewModel { Rooms = rooms.ToPagedList(i ?? 1, 4) });
        }

        public async Task<ActionResult> FilterByPrices(string filter, string filter2, int? i)
        {
            var rooms = Filters.FilterByPriceAndCapacity(await roomRepository.GetAllRooms(), filter, filter2);
            return PartialView("_RoomSearch", new RoomsSearchViewModel { Rooms = rooms.ToPagedList(i ?? 1, 4) });
        }
    }
}