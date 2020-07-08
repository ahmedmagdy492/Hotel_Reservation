using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext db;
        public ProfileRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
