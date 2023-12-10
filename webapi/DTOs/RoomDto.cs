
namespace DTOs;

public class RoomDto
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public int AmountOfPersons { get; set; }
    public double PricePrNight { get; set; }
    public string RoomImage { get; set; }
}
