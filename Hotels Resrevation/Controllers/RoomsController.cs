using Hotels_Resrevation.Constants;
using Hotels_Resrevation.Models;
using Hotels_Resrevation.Repository;
using Hotels_Resrevation.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hotels_Resrevation.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomRepository roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public async Task<ActionResult> Index(string hotelId)
        {
            var rooms = await roomRepository.GetRoomsOfHotel(hotelId);
            var model = new RoomsViewModel
            {
                Rooms = rooms,
                CurrentHotelId = hotelId
            };
            return View(model);
        }

        [Authorize(Roles = Constants.Constants.HotelRole)]
        [HttpPost]
        public async Task<ActionResult> CreateRoom(string hotelId, Room room, HttpPostedFileBase img)
        {
            room.HotelId = hotelId;
            if(ModelState.IsValid)
            {
                var createdRoom = await roomRepository.CreateRoom(room);
                string fullPath = Utility.SaveImage(img, HttpContext);
                string imgName = Path.GetFileName(fullPath);
                RoomImage roomImg = new RoomImage
                {
                    RoomId = createdRoom.Id,
                    Title = imgName
                };
                await roomRepository.CreateRoomImage(roomImg);
            }
            return Redirect(Constants.Constants.RoomsIndexUrl + "?hotelId=" + hotelId);
        }

        [Authorize(Roles = Constants.Constants.HotelRole)]
        [HttpPost]
        public async Task<ActionResult> DeleteRoom(int roomId, string hotelId)
        {
            var room = await roomRepository.GetRoom(roomId);
            if(room != null)
            {
                await roomRepository.DeleteRoom(room);
            }
            return Redirect(Constants.Constants.RoomsIndexUrl + "?hotelId=" + hotelId);
        }

        public async Task<ActionResult> GetRoom(int roomId, string hotelId)
        {
            var hotelRooms = await roomRepository.GetRoomsOfHotel(hotelId);
            var room = hotelRooms.FirstOrDefault(r => r.Id == roomId);

            var model = new OneRoomViewModel
            {
                Room = room,
                RoomImages = room.RoomImages,
                HotelId = hotelId
            };
            return View(model);
        }

        [Authorize(Roles = Constants.Constants.HotelRole)]
        [HttpPost]
        public async Task<ActionResult> UploadRoomImage(int roomId, string hotelId, HttpPostedFileBase img)
        {
            string fullPath = Utility.SaveImage(img, HttpContext);
            string imgName = Path.GetFileName(fullPath);
            var roomImage = new RoomImage
            {
                RoomId = roomId,
                Title = imgName
            };
            await roomRepository.CreateRoomImage(roomImage);
            return Redirect(Constants.Constants.RoomsIndexUrl + "?roomId=" + roomId + "&hotelId=" + hotelId);
        }
    }
}