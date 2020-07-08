using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public interface IReservationRepository
    {
        Task<Reservation> Book(Reservation reservation);
        Task<bool> IsReserved(int roomId, DateTime fromDate, DateTime toDate);
    }
}
