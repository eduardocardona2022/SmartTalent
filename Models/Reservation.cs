namespace Models;

public partial class Reservation
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public int RoomId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime DateEnd { get; set; }

    public int PassengerId { get; set; }

    public int NumberOfPeople { get; set; }

    public string? DestinationCity { get; set; }

}
