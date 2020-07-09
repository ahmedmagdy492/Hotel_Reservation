using Hotels_Resrevation.Models;
using Hotels_Resrevation.Repository;
using Hotels_Resrevation.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hotels_Resrevation.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public async Task<ActionResult> GetAll(string hotelId, bool All = false)
        {
            var reviews = await reviewRepository.GetReviewsOfHotel(hotelId);
            if (All)
                reviews = reviews.Take(5);
            var model = new ReviewsViewModel
            {
                Reviews = reviews.ToList()
            };
            return PartialView("_ReviewsSection", model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReview(string comment, int rating, string hotelId)
        {
            var review = new Review { 
                Content = comment,
                Rating = rating,
                HotelId = hotelId,
                Date = DateTime.Now,
                UserId = User.Identity.GetUserId()
            };
            await reviewRepository.CreateReview(review);
            var model = new ReviewsViewModel
            {
                Reviews = (await reviewRepository.GetReviewsOfHotel(hotelId)).ToList()
            };
            return PartialView("_ReviewsSection", model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteReview(string hotelId, int reviewId)
        {
            string userId = User.Identity.GetUserId();
            var review = (await reviewRepository.GetReviewsOfHotel(hotelId)).FirstOrDefault(r => r.Id == reviewId && userId == r.UserId);

            if(review != null)
            {
                await reviewRepository.DeleteReview(review);
                return PartialView("_ReviewsSection", new ReviewsViewModel { Reviews = (await reviewRepository.GetReviewsOfHotel(hotelId)).ToList() });
            }
            return PartialView("_ReviewsSection", new ReviewsViewModel { Reviews = (await reviewRepository.GetReviewsOfHotel(hotelId)).ToList() });
        }
    }
}
