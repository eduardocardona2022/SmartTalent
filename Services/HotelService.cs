using Data;
using Models;

namespace Services
{
    public class HotelService
    {
        private readonly HoteldbContext _context;

        public HotelService(HoteldbContext context)
        {
            _context = context;
        }

        public List<Hotel> GetAllHotels()
        {
            return _context.Hotels.Where(x=> x.IsEnabled == true).ToList();
        }

        public Hotel GetById(int id)
        {
            return _context.Hotels.Where(x => x.Id == id && x.IsEnabled).FirstOrDefault();
        }


        public void AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

        public void UpdateHotel(Hotel hotel)
        {
            var existingHotel = _context.Hotels.FirstOrDefault(r => r.Id == hotel.Id);
            if (existingHotel != null)
            {
                existingHotel.Name = hotel.Name;
                existingHotel.Location = hotel.Location;
                existingHotel.IsEnabled = hotel.IsEnabled;
                existingHotel.Rooms = hotel.Rooms;
            }
            _context.SaveChanges();
        }

        public void EnableDisableHotel(int id, bool isEnabled)
        {
            var hotel = _context.Hotels.FirstOrDefault(r => r.Id == id);
            if (hotel != null)
            {
                hotel.IsEnabled = isEnabled;
            }
        }
    }
}
