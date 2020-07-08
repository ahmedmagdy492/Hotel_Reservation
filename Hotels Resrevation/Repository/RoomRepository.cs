using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext db;

        public RoomRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Room> CreateRoom(Room room)
        {
            db.Rooms.Add(room);
            await db.SaveChangesAsync();
            return room;
        }

        public async Task CreateRoomImage(RoomImage img)
        {
            db.RoomImages.Add(img);
            await db.SaveChangesAsync();
        }

        public async Task DeleteRoom(Room room)
        {
            db.Rooms.Remove(room);
            await db.SaveChangesAsync();
            db.Entry(room).State = EntityState.Deleted;
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await db.Rooms.Include("Hotel").Include("RoomImages").ToListAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            return await db.Rooms.Include("RoomImages").FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Room>> GetRoomsOfHotel(string hotelId)
        {
            var rooms = await db.Rooms.Include("RoomImages").Where(r => r.HotelId == hotelId).ToListAsync();
            return rooms;
        }
    }
}
