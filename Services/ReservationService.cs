using Data;
using Models;
using System.Linq;

namespace Services
{
    public class ReservationService
    {
        private readonly HoteldbContext _context;

        public ReservationService(HoteldbContext context)
        {
            _context = context;
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public List<Reservation> GetFilterReservations(FilterReservation filter)
        {
            return _context.Reservations.Where(x => x.NumberOfPeople == filter.NumberOfPeople || 
                                               x.DestinationCity == filter.DestinationCity ||
                                               x.StartDate == filter.StartDate ||
                                               x.DateEnd == filter.DateEnd).ToList();
        }

        public void AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }
    }
}
