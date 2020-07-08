using Hotels_Resrevation.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly ApplicationDbContext db;

        public SearchRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllHotels()
        {
            return await db.Users.Include("Images").Where(u => u.IsHotel == true).ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetHotelByName(string username)
        {
            var users = await db.Users.Include("Images").Where(u => u.Email.ToLower().Contains(username.ToLower()) && u.IsHotel == true).ToListAsync();
            return users;
        }
    }
}
