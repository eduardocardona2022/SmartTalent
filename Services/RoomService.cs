using Data;
using Models;

namespace Services
{
    public class RoomService
    {

        private readonly HoteldbContext _context;

        public RoomService(HoteldbContext context)
        {
            _context = context;
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.Where(x => x.IsEnabled).ToList();
        }
        public Room GetById(int id)
        {
            return _context.Rooms.Where(x => x.Id == id && x.IsEnabled).FirstOrDefault();
        }

        public void AddRoom(Room room) => _context.Rooms.Add(room);

        public void UpdateRoom(Room room)
        {
            var existingRoom = _context.Rooms.FirstOrDefault(r => r.Id == room.Id);
            if (existingRoom != null)
            {
                existingRoom.Type = room.Type;
                existingRoom.BaseCost = room.BaseCost;
                existingRoom.Tax = room.Tax;
                existingRoom.Location = room.Location;
                existingRoom.IsEnabled = room.IsEnabled;
            }
            _context.SaveChanges();
        }

        public void EnableDisableRoom(int id, bool isEnabled)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == id);
            if (room != null)
            {
                room.IsEnabled = isEnabled;
                _context.SaveChanges();
            }
        }
    }
}
