namespace Models;
public class Room
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public int AmountOfPersons { get; set; }
    public double PricePrNight { get; set; }
    public string RoomImage { get; set; }

    // Nav
    public Hotel Hotel { get; set; }
}

