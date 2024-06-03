namespace Models;

public partial class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
