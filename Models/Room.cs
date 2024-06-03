namespace Models;

public partial class Room
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public decimal BaseCost { get; set; }

    public decimal Tax { get; set; }

    public string Location { get; set; } = null!;

    public int? HotelId { get; set; }

    public bool IsEnabled { get; set; }

    public virtual Hotel? Hotel { get; set; }
}
