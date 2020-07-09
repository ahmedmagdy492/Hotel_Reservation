using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext db;

        public ReservationRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Reservation> Book(Reservation reservation)
        {
            if(!(await IsReserved(reservation.RoomId, reservation.StartDate, reservation.EndDate)) && !(reservation.StartDate < DateTime.Now || reservation.EndDate < DateTime.Now) && !(reservation.StartDate > reservation.EndDate) )
            {
                db.Reservations.Add(reservation);
                await db.SaveChangesAsync();
                return reservation;
            }
            return null;
        }

        public async Task<IEnumerable<Reservation>> GetMyReservations(string userId)
        {
            var reservations = await db.Reservations.Include("Room").Include("Room.Hotel").Where(r => r.UserId == userId).ToListAsync();
            return reservations;
        }

        public async Task<bool> IsReserved(int roomId, DateTime fromDate, DateTime toDate)
        {
            var reservation = await db.Reservations.FirstOrDefaultAsync(r => r.RoomId == roomId && ((fromDate >= r.StartDate && toDate <= r.EndDate) || (toDate > r.StartDate && toDate < r.EndDate) || (fromDate > r.StartDate && fromDate < r.EndDate) || (fromDate < r.StartDate && toDate > r.EndDate)));
            return reservation != null;
        }
    }
}
