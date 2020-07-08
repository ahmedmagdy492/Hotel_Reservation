using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly ApplicationDbContext db;

        public FacilityRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Facilties> CreateFacility(Facilties facilty)
        {
            db.Facilties.Add(facilty);
            await db.SaveChangesAsync();
            return facilty;
        }

        public async Task<List<Facilties>> GetFaciltiesOfHotel(string hotelId)
        {
            return await db.Facilties.Where(f => f.HotelId == hotelId).ToListAsync();
        }
    }
}
