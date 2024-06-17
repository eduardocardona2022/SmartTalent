using Data;

namespace Services
{
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton(null));

        public static Singleton Instance { get { return lazy.Value; } }

        public HotelService HotelService { get; private set; }
        public RoomService RoomService { get; private set; }

        public ReservationService ReservationService { get; private set; }

        private Singleton(HoteldbContext? Context)
        {
            Context ??= new HoteldbContext();
            HotelService ??= new HotelService(Context);
            RoomService ??= new RoomService(Context);
            ReservationService ??= new ReservationService(Context, HotelService, RoomService);
        }
    }
}
