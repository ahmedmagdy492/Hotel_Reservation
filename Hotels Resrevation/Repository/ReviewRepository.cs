using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext db;

        public ReviewRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Review> CreateReview(Review review)
        {
            db.Reviews.Add(review);
            await db.SaveChangesAsync();
            return review;
        }

        public async Task DeleteReview(Review review)
        {
            db.Reviews.Remove(review);
            await db.SaveChangesAsync();
            db.Entry(review).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Review>> GetReviewsOfHotel(string hotelId)
        {
            return await db.Reviews.Include("User").Where(r => r.HotelId == hotelId).ToListAsync();
        }
    }
}
