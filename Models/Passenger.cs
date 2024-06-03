namespace Models;

public partial class Passenger
{
    public int PassengerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateBirth { get; set; }

    public string Gender { get; set; } = null!;

    public string DocumentType { get; set; } = null!;

    public string DocumentNumber { get; set; } = null!;

    public string? Email { get; set; }

    public string? ContactPhone { get; set; }

    public string? ContactName { get; set; }

    public string? ContactPhoneNumber { get; set; }
}
