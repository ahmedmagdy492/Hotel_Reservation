using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public interface ISearchRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllHotels();
        Task<IEnumerable<ApplicationUser>> GetHotelByName(string username);
    }
}
