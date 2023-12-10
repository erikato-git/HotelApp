using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<DataContext>());
    }

    public static void SeedData(DataContext context)
    {
        context.Database.Migrate();

        if(context.Hotels.Any())
        {
            Console.WriteLine("Already have data - no need for seed");
        }

        // 1. Mockaroo: generate Json-file, 2. ChatGPT: translate to C#

        var hotels = new List<Hotel>()
        {
            new Hotel
            {
                Id = Guid.Parse("aefb04f1-e706-40bc-8171-548e6eb7840c"),
                HotelName = "Goldner-Fisher",
                Street = "54860 Golf View Trail",
                City = "Casalinho",
                Country = "Portugal",
                Stars = 1,
                Description = "Ischiocapsular ligament sprain of unspecified hip, subsequent encounter",
                BackgroundImage = "http://dummyimage.com/144x100.png/5fa2dd/ffffff",
                CreatedBy = "Admin",
                Rooms = new List<Room>
                {
                    new Room
                    {
                        Id = Guid.Parse("fdb3f00a-7846-4ed8-88f7-b4747bdebe04"),
                        Type = "Drama",
                        AmountOfPersons = 1,
                        PricePrNight = 22,
                        RoomImage = "http://dummyimage.com/177x100.png/ff4444/ffffff"
                    },
                    new Room
                    {
                        Id = Guid.Parse("09a6b2f6-6e13-4211-9cd0-1a43f1863020"),
                        Type = "Drama",
                        AmountOfPersons = 2,
                        PricePrNight = 65,
                        RoomImage = "http://dummyimage.com/220x100.png/5fa2dd/ffffff"
                    }
                }
            },
            new Hotel
            {
                Id = Guid.Parse("23430db5-ab14-4638-b5e0-37c7dbe1fde6"),
                HotelName = "Zboncak-Emmerich",
                Street = "34869 Lyons Street",
                City = "Plagiári",
                Country = "Greece",
                Stars = 3,
                Description = "Burn of first degree of wrist and hand",
                BackgroundImage = "http://dummyimage.com/179x100.png/dddddd/000000",
                CreatedBy = "Admin",
                Rooms = new List<Room>
                {
                    new Room
                    {
                        Id = Guid.Parse("d3faa68a-ef23-40c7-b494-4b90e1e8a8aa"),
                        Type = "Drama",
                        AmountOfPersons = 1,
                        PricePrNight = 33,
                        RoomImage = "http://dummyimage.com/100x100.png/5fa2dd/ffffff"
                    },
                    new Room
                    {
                        Id = Guid.Parse("6e924c70-8233-4c16-97d7-2fb4cb4980b9"),
                        Type = "Horror|Mystery|Thriller",
                        AmountOfPersons = 2,
                        PricePrNight = 42,
                        RoomImage = "http://dummyimage.com/177x100.png/cc0000/ffffff"
                    },
                    new Room
                    {
                        Id = Guid.Parse("b8a0edaa-96f7-4b75-84d4-e218d3fd7227"),
                        Type = "Drama|Thriller",
                        AmountOfPersons = 3,
                        PricePrNight = 3,
                        RoomImage = "http://dummyimage.com/127x100.png/dddddd/000000"
                    }
                }
            },
                        new Hotel
            {
                Id = Guid.Parse("1fdf3d13-263d-4142-9471-faafe2b8e30c"),
                HotelName = "Klocko, Schumm and Bradtke",
                Street = "677 Jay Trail",
                City = "Longhua",
                Country = "China",
                Stars = 4,
                Description = "Other specified injury of superficial vein at shoulder and upper arm level",
                BackgroundImage = "http://dummyimage.com/158x100.png/dddddd/000000",
                CreatedBy = "Admin",
                Rooms = new List<Room>
                {
                    new Room
                    {
                        Id = Guid.Parse("aa65dde7-8c31-48bb-82cf-0a57dac83960"),
                        Type = "Comedy",
                        AmountOfPersons = 1,
                        PricePrNight = 15,
                        RoomImage = "http://dummyimage.com/244x100.png/5fa2dd/ffffff"
                    },
                    new Room
                    {
                        Id = Guid.Parse("dc07b13e-2820-48bd-b7d6-38d829073d13"),
                        Type = "Action|Adventure|Comedy|Documentary|Fantasy",
                        AmountOfPersons = 2,
                        PricePrNight = 85,
                        RoomImage = "http://dummyimage.com/198x100.png/ff4444/ffffff"
                    },
                    new Room
                    {
                        Id = Guid.Parse("62ab8f59-86e2-4555-ac0a-cb0003eebc54"),
                        Type = "(no genres listed)",
                        AmountOfPersons = 3,
                        PricePrNight = 82,
                        RoomImage = "http://dummyimage.com/138x100.png/dddddd/000000"
                    }
                }
            },      

        };

        context.AddRange(hotels);

        context.SaveChanges();

    }
}

