namespace DTOs;

public class UpdateHotelDto
{
    public string HotelName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public int? Stars { get; set; }
    public string Description { get; set; }
    public string BackgroundImage { get; set; }
    public string CreatedBy { get; set; }

}