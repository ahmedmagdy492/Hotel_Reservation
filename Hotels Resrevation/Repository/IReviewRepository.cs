using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsOfHotel(string hotelId);
        Task<Review> CreateReview(Review review);
        Task DeleteReview(Review review);
    }
}
