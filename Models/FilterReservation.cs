namespace Models;

public partial class FilterReservation
{

    public DateTime StartDate { get; set; }

    public DateTime DateEnd { get; set; }

    public int NumberOfPeople { get; set; }

    public string? DestinationCity { get; set; }

}
