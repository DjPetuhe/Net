using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1Net
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing clients
            Client client1 = new ("Yura", "Pasternak", 25);
            Client client2 = new ("Maxim", "Borisov", 45);
            Client client3 = new ("Aleks", "Havrylyuk", 18);
            Client client4 = new ("Bohuslav", "Melnyk", 54);
            Client client5 = new ("Mykyta", "Shvets", 25);
            Client client6 = new ("Tamara", "Chayka", 38);
            Client client7 = new ("Melaniya", "Boyko", 42);
            Client client8 = new ("Maryana", "Borisova", 23);
            Client client9 = new ("Emiliya", "Vasylyshyn", 68);
            Client client10 = new ("Lilya", "Vasylyshyn", 20);

            List<Client> clients = new(){ client1, client2, client3, client4, client5, client6, client7, client8, client9, client10 };

            // initializing hotel rooms
            HotelRoom room1 = new (10, RoomClass.Standart, 1);
            HotelRoom room2 = new (11, RoomClass.Standart, 2, 
                new Dictionary<string, int> 
                { 
                    { "conditioner", 1 },
                    { "microbar", 1 }
                });
            HotelRoom room3 = new (12, RoomClass.Standart, 4,
                new Dictionary<string, int>
                {
                    { "conditioner", 2 },
                    { "microbar", 2 }
                });
            HotelRoom room4 = new (20, RoomClass.DeLux, 2,
                new Dictionary<string, int>
                {
                    {"conditioner", 2 },
                    {"crib", 1 },
                    {"microbar", 1 },
                });
            HotelRoom room5 = new (21, RoomClass.DeLux, 4,
                new Dictionary<string, int>
                {
                    {"conditioner", 3 },
                    {"crib", 2 },
                    {"microbar", 2 },
                    {"place for pets", 1 }
                });
            HotelRoom room6 = new (30, RoomClass.Presidential, 8,
                new Dictionary<string, int>
                {
                    {"conditioner", 6 },
                    {"crib", 3 },
                    {"microbar", 4 },
                    {"place for pets", 2 },
                    {"jackuzzi", 1 }
                });

            List<HotelRoom> hotelRooms = new() { room1, room2, room3, room4, room5, room6 };

            //initializing bookings
            Booking booking1 = new (client1,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room3, new DateTime(2022, 5, 20), new DateTime(2022, 5, 22))
                });
            Booking booking2 = new (client1,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room3, new DateTime(2022, 5, 25), new DateTime(2022, 5, 30)),
                    (room4, new DateTime(2022, 5, 25), new DateTime(2022, 5, 30))
                });
            Booking booking3 = new (client2,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room5, new DateTime(2022, 5, 18), new DateTime(2022, 5, 21))
                });
            Booking booking4 = new (client3,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room1, new DateTime(2022, 5, 30), new DateTime(2022, 5, 30))
                });
            Booking booking5 = new (client5,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room1, new DateTime(2022, 5, 28), new DateTime(2022, 5, 29))
                });
            Booking booking6 = new (client6,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room4, new DateTime(2022, 6, 10), new DateTime(2022, 6, 20)),
                    (room3, new DateTime(2022, 6, 4), new DateTime(2022, 6, 7)),
                    (room2, new DateTime(2022, 6, 15), new DateTime(2022, 6, 20))
                });
            Booking booking7 = new (client7,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room6, new DateTime(2022, 6, 25), new DateTime(2022, 6, 26))
                });
            Booking booking8 = new (client7,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room6, new DateTime(2022, 7, 25), new DateTime(2022, 7, 26))
                });
            Booking booking9 = new (client8,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room1, new DateTime(2022, 6, 1), new DateTime(2022, 6, 2)),
                    (room2, new DateTime(2022, 6, 1), new DateTime(2022, 6, 1))
                });
            Booking booking10 = new(client10,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room4, new DateTime(2022, 7, 1), new DateTime(2022, 7, 30))
                });

            List<Booking> bookings = new() { booking1, booking2, booking3, booking4, booking5, booking6, booking7, booking8, booking9, booking10 };

        }
    }
}
