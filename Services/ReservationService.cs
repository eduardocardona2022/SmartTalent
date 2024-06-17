using Data;
using Models;

namespace Services
{
    public class ReservationService
    {
        private readonly HoteldbContext _context;
        private HotelService _hotelService;
        private RoomService _roomService;


        public ReservationService(HoteldbContext context, HotelService hotelService, RoomService roomService)
        {
            _context = context;
            _hotelService = hotelService;
            _roomService = roomService;
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public List<Reservation> GetFilterReservations(Reservation filter)
        {
            return _context.Reservations.Where(x => x.NumberOfPeople == filter.NumberOfPeople &&
                                               x.DestinationCity == filter.DestinationCity &&
                                               (
                                               (x.StartDate <= filter.StartDate && x.DateEnd <= filter.StartDate) ||
                                               (x.StartDate <= filter.DateEnd && x.DateEnd <= filter.DateEnd)
                                               )).ToList();
        }

        public List<Reservation> ValidateReservations(Reservation filter)
        {
            return _context.Reservations.Where(x => x.HotelId == filter.HotelId &&
                                               x.RoomId == filter.RoomId &&
                                               (
                                               (x.StartDate <= filter.StartDate && x.DateEnd <= filter.StartDate) ||
                                               (x.StartDate <= filter.DateEnd && x.DateEnd <= filter.DateEnd)
                                               )).ToList();
        }

        public void AddReservation(Reservation reservation)
        {
            //Validation Hotel
            if (_hotelService.GetById(reservation.HotelId) == null)
            {
                throw new Exception("Hotel no existe o no esta disponible en el momento");
            }

            //Validation Room
            var _room = _roomService.GetById(reservation.RoomId);

            if (_room == null)
            {
                throw new Exception("Habitacion no existe o no esta disponible en el momento");
            }

            if (_room.CapacityOfPeople < reservation.NumberOfPeople)
            {
                throw new Exception($"La habitacion solo tiene capacidad para {_room.CapacityOfPeople}");
            }

            //Validation Reservation
            if (ValidateReservations(reservation).Count > 0)
            {
                throw new Exception("Ya existe una reserva para ese hotel y habitacion para ese rango de fechas");
            }

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

        }
    }
}
