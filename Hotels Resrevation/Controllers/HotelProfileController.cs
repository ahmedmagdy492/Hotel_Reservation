using Hotels_Resrevation.Constants;
using Hotels_Resrevation.Models;
using Hotels_Resrevation.Repository;
using Hotels_Resrevation.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hotels_Resrevation.Controllers
{
    [Authorize(Roles = Constants.Constants.HotelRole + "," + Constants.Constants.UserRole)]
    public class HotelProfileController : Controller
    {
        private readonly IProfileRepository profileRepository;
        private readonly IImageRepository imageRepository;
        private readonly IRoomRepository roomRepository;
        private readonly IFacilityRepository facilityRepository;

        public HotelProfileController(
            IProfileRepository profileRepository,
            IImageRepository imageRepository,
            IRoomRepository roomRepository,
            IFacilityRepository facilityRepository
            )
        {
            this.profileRepository = profileRepository;
            this.imageRepository = imageRepository;
            this.roomRepository = roomRepository;
            this.facilityRepository = facilityRepository;
        }

        [Authorize(Roles = Constants.Constants.HotelRole + "," + Constants.Constants.UserRole)]
        public async Task<ActionResult> Index(string userId)
        {
            ApplicationUser user = null;
            if (userId == null && !User.IsInRole(Constants.Constants.HotelRole))
            {
                return Redirect("/Home/Index");
            }
            else if(User.IsInRole(Constants.Constants.HotelRole))
            {
                user = await profileRepository.GetUser(User.Identity.GetUserId());
            }
            else
            {
                user = await profileRepository.GetUser(userId);
            }
            var images = new List<UserImage>();
            foreach(var img in (await imageRepository.GetAllImages(user.Id)))
            {
                img.Title = "/Content/imgs/" + Path.GetFileName(img.Title);
                images.Add(img);
            }
            var model = new HotelProfileViewModel
            {
                CurrentUserProfile = user,
                Images = images,
                Rooms = await roomRepository.GetRoomsOfHotel(user.Id),
                Facilties = await facilityRepository.GetFaciltiesOfHotel(userId ?? user.Id)
            };
            return View(model);
        }

        [Authorize(Roles = Constants.Constants.HotelRole)]
        [HttpPost]
        public async Task<ActionResult> UploadImage(HttpPostedFileBase img)
        {
            if(img != null)
            {
                string imgFullPath = Utility.SaveImage(img, HttpContext);
                bool isProfileImg = false;
                if((await imageRepository.GetAllImages(User.Identity.GetUserId())).Count() == 0)
                {
                    isProfileImg = true;
                }
                await imageRepository.SaveImage(imgFullPath, User.Identity.GetUserId(), isProfileImg);
                return Redirect(Constants.Constants.HotelIndexUrl);
            }
            return Redirect(Constants.Constants.HotelIndexUrl);
        }

        [Authorize(Roles = Constants.Constants.HotelRole)]
        [HttpPost]
        public async Task<ActionResult> DeleteImage(int id)
        {
            await imageRepository.DeleteImage(id);
            return Redirect(Constants.Constants.HotelIndexUrl);
        }

        [Authorize(Roles = Constants.Constants.HotelRole)]
        [HttpPost]
        public async Task<ActionResult> MakeProfileImage(int id)
        {
            var images = (await imageRepository.GetAllImages(User.Identity.GetUserId())).Where(i => i.IsProfileImg == true);
            foreach(var img in images)
            {
                await imageRepository.MakeAsProfile(img.Id, false);
            }

            await imageRepository.MakeAsProfile(id, true);

            return Redirect(Constants.Constants.HotelIndexUrl);
        }
    }
}