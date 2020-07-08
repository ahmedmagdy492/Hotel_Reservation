using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetRoomsOfHotel(string hotelId);
        Task<Room> CreateRoom(Room room);
        Task DeleteRoom(Room room);
        Task CreateRoomImage(RoomImage img);
        Task<Room> GetRoom(int id);
        Task<List<Room>> GetAllRooms();
    }
}
