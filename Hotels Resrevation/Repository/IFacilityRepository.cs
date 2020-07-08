using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public interface IFacilityRepository
    {
        Task<List<Facilties>> GetFaciltiesOfHotel(string hotelId);
        Task<Facilties> CreateFacility(Facilties facilty);
    }
}
