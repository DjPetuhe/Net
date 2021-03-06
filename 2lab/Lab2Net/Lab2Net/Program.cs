using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Lab2Net
{
    class Program
    {
        static void Main()
        {
            // initializing clients
            Client client1 = new("Yura", "Pasternak", 25);
            Client client2 = new("Maxim", "Borisov", 45);
            Client client3 = new("Aleks", "Havrylyuk", 18);
            Client client4 = new("Bohuslav", "Melnyk", 54);
            Client client5 = new("Mykyta", "Shvets", 25);
            Client client6 = new("Tamara", "Chayka", 38);
            Client client7 = new("Melaniya", "Boyko", 42);
            Client client8 = new("Maryana", "Borisova", 23);
            Client client9 = new("Emiliya", "Vasylyshyn", 68);
            Client client10 = new("Lilya", "Vasylyshyn", 20);

            List<Client> clients = new() { client1, client2, client3, client4, client5, client6, client7, client8, client9, client10 };

            // initializing hotel rooms
            HotelRoom room1 = new(10, RoomClass.Standart, 1);
            HotelRoom room2 = new(11, RoomClass.Standart, 2,
                new Dictionary<string, int>
                {
                    { "conditioner", 1 },
                    { "microbar", 1 }
                });
            HotelRoom room3 = new(12, RoomClass.Standart, 4,
                new Dictionary<string, int>
                {
                    { "conditioner", 2 },
                    { "microbar", 2 }
                });
            HotelRoom room4 = new(20, RoomClass.DeLux, 2,
                new Dictionary<string, int>
                {
                    {"conditioner", 2 },
                    {"crib", 1 },
                    {"microbar", 1 },
                });
            HotelRoom room5 = new(21, RoomClass.DeLux, 4,
                new Dictionary<string, int>
                {
                    {"conditioner", 3 },
                    {"crib", 2 },
                    {"microbar", 2 },
                    {"place for pets", 1 }
                });
            HotelRoom room6 = new(30, RoomClass.Presidential, 8,
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
            Booking booking1 = new(client1,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room3, new DateTime(2022, 5, 20), new DateTime(2022, 5, 22))
                });
            Booking booking2 = new(client1,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room3, new DateTime(2022, 5, 25), new DateTime(2022, 5, 30)),
                    (room4, new DateTime(2022, 5, 25), new DateTime(2022, 5, 30))
                });
            Booking booking3 = new(client2,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room5, new DateTime(2022, 5, 18), new DateTime(2022, 5, 21))
                });
            Booking booking4 = new(client3,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room1, new DateTime(2022, 5, 30), new DateTime(2022, 5, 30))
                });
            Booking booking5 = new(client5,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room1, new DateTime(2022, 5, 28), new DateTime(2022, 5, 29))
                });
            Booking booking6 = new(client6,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room4, new DateTime(2022, 6, 10), new DateTime(2022, 6, 20)),
                    (room3, new DateTime(2022, 6, 4), new DateTime(2022, 6, 7)),
                    (room2, new DateTime(2022, 6, 15), new DateTime(2022, 6, 20))
                });
            Booking booking7 = new(client7,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room6, new DateTime(2022, 6, 25), new DateTime(2022, 6, 26))
                });
            Booking booking8 = new(client7,
                new List<(HotelRoom, DateTime, DateTime)>
                {
                    (room6, new DateTime(2022, 7, 25), new DateTime(2022, 7, 26))
                });
            Booking booking9 = new(client8,
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

            //Write to xml file
            XmlWriterSettings settings = new();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create("file.xml", settings))
            {
                writer.WriteStartElement("bookings");
                foreach (var booking in bookings)
                {
                    if (!booking.Canceled)
                    {
                        writer.WriteStartElement("booking");
                        writer.WriteElementString("ID", booking.ID.ToString());
                        writer.WriteElementString("price", booking.Price.ToString());
                        writer.WriteStartElement("client");
                        writer.WriteElementString("name", booking.Person.Name);
                        writer.WriteElementString("surname", booking.Person.Surname);
                        writer.WriteElementString("age", booking.Person.Age.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("bookedRooms");
                        foreach (var rooms in booking.BookedRooms)
                        {
                            writer.WriteStartElement("bookedRoom");
                            writer.WriteElementString("startTime", rooms.Item2.ToShortDateString());
                            writer.WriteElementString("endTime", rooms.Item3.ToShortDateString());
                            writer.WriteElementString("number", rooms.Item1.RoomNumber.ToString());
                            writer.WriteElementString("class", rooms.Item1.Classification.ToString());
                            writer.WriteElementString("capacity", rooms.Item1.Capacity.ToString());
                            if (rooms.Item1.Extra.Count > 0)
                            {
                                writer.WriteStartElement("extras");
                                foreach (var extra in rooms.Item1.Extra)
                                {
                                    writer.WriteStartElement("extra");
                                    writer.WriteElementString("object", extra.Key);
                                    writer.WriteElementString("amount", extra.Value.ToString());
                                    writer.WriteEndElement();
                                }
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();
            }

            //Readig from xml file
            XmlDocument doc = new();
            doc.Load("file.xml");
            foreach (XmlNode booking in doc.DocumentElement)
            {
                Console.WriteLine($"Booking {booking["ID"].InnerText} ID;");
                Console.WriteLine($"Price: {booking["price"].InnerText}");
                Console.WriteLine("Client:");
                XmlNode person = booking["client"];
                Console.WriteLine($"\tName: {person["name"].InnerText}");
                Console.WriteLine($"\tSurname: {person["surname"].InnerText}");
                Console.WriteLine($"\tAge: {person["age"].InnerText}");
                Console.WriteLine("Rooms booked:");
                foreach (XmlNode room in booking["bookedRooms"])
                {
                    Console.WriteLine($"\tRoom number: {room["number"].InnerText}");
                    Console.WriteLine($"\tStart time: {room["startTime"].InnerText}");
                    Console.WriteLine($"\tEnd time: {room["endTime"].InnerText}");
                    Console.WriteLine($"\tClassification: {room["class"].InnerText}");
                    Console.WriteLine($"\tCapacity: {room["capacity"].InnerText}");
                    if (room["extras"] != null)
                    {
                        Console.WriteLine("\tExtras:");
                        foreach (XmlNode extra in room["extras"])
                        {
                            Console.WriteLine($"\t\t{extra["object"].InnerText}, Value: {extra["amount"].InnerText}");
                        }
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("-------------------------------------------------\n");
            }

            //Linq to xml запросы
            XDocument file = XDocument.Load("file.xml");

            // 1. Выбираю и вывожу идинтификационный номер всех бронирований
            Console.WriteLine("#1-----------------------------------------------\n");
            var first = from x in file.Root.Elements("booking")
                        select x.Element("ID").Value;
            Output(first);

            // 2. Выбираю и вывожу имена и фамилии всех клиентов, совершавших бронирования
            Console.WriteLine("#2-----------------------------------------------\n");
            var second = file.Root
                .Descendants("client")
                .Select(b => new
                {
                    Name = b.Element("name").Value,
                    Surname = b.Element("surname").Value
                })
                .Distinct();
            Output(second);

            // 3. Выибраю и вывожу номера комнат и количество бронирований этих номеров
            Console.WriteLine("#3-----------------------------------------------\n");
            var third = from x in file.Root.Descendants("bookedRoom")
                        group x by x.Element("number").Value into gr
                        orderby gr.Key
                        select new
                        {
                            RoomNumber = gr.Key,
                            AmountOfBookings = gr.Count()
                        };
            Output(third);

            // 4. Выбираю и вывожу клиента и количество броней, сделанных этим клиентом
            Console.WriteLine("#4-----------------------------------------------\n");
            var fourth = file.Root
                .Descendants("client")
                .GroupBy(x => new { Name = x.Element("name").Value, Surname = x.Element("surname").Value })
                .Select(x => new { Person = x.Key, AmountOfBookings = x.Count() });
            Output(fourth);

            // 5. Выбираю и вывожу совершавших бронь клиентов, которым больше 30
            Console.WriteLine("#5-----------------------------------------------\n");
            var fifth = (from x in file.Root.Descendants("client")
                         where Convert.ToInt32(x.Element("age").Value) > 30
                         orderby Convert.ToInt32(x.Element("age").Value)
                         select new
                         {
                             Name = x.Element("name").Value,
                             Surname = x.Element("surname").Value,
                             Age = x.Element("age").Value
                         }).Distinct();
            Output(fifth);

            // 6. Выбираю и вывожу идентефикационные номера и цену бронирований,
            //    у которых цена меньше 500
            Console.WriteLine("#6-----------------------------------------------\n");
            var sixth = file.Root
                .Elements("booking")
                .Select(x => new
                {
                    ID = x.Element("ID").Value,
                    Price = x.Element("price").Value
                })
                .Where(x => Convert.ToInt32(x.Price) < 500)
                .OrderByDescending(x => x.Price);
            Output(sixth);

            // 7. Вывожу среднее количество номеров, которые бронируют за раз
            Console.WriteLine("#7-----------------------------------------------\n");
            var seventh = (from x in file.Root.Descendants("bookedRooms")
                           select Convert.ToDouble(x.Elements("bookedRoom").Count())).Average();
            Console.WriteLine(seventh + "\n");

            // 8. Выбираю и вывожу идентефикационные номера броней и количество
            //    доп. опций во всех забронирвоанных комнатах.
            Console.WriteLine("#8-----------------------------------------------\n");
            var eighth = file.Root
                .Elements("booking")
                .GroupBy(x => x.Elements("bookedRooms"))
                .Select(x => new 
                { 
                    bookingID = x.Elements("ID").FirstOrDefault().Value,
                    AmountOfExtras = (
                        from ae in x.Key.Descendants("amount")
                        select Convert.ToInt32(ae.Value)
                        ).Sum()
                });
            Output(eighth);

            // 9. Вывожу самого молодого клиента, совершавшего бронь
            Console.WriteLine("#9-----------------------------------------------\n");
            var ninth = (from x in file.Root.Elements("booking")
                         group x by x.Elements("client") into gr
                         orderby gr.Key.Elements("age").FirstOrDefault().Value
                         select new
                         {
                             Name = gr.Key.Elements("name").FirstOrDefault().Value,
                             Surname = gr.Key.Elements("surname").FirstOrDefault().Value,
                             Age = gr.Key.Elements("age").FirstOrDefault().Value
                         }).FirstOrDefault();

            Console.WriteLine(ninth + "\n");

            // 10. Выбираю и вывожу идентефикационные номера броней и самую
            //    ранюю дату брони комнаты. Сортирую по дате начала бронирвоания
            Console.WriteLine("#10----------------------------------------------\n");
            var tenth = file.Root
                .Elements("booking")
                .OrderBy(x => DateTime.Parse((x.Descendants("startTime")
                                               .OrderBy(x => DateTime.Parse(x.Value)))
                                               .FirstOrDefault()
                                               .Value))
                .Select(x => new
                {
                    bookingID = x.Element("ID").Value,
                    earliestDate = x.Descendants("startTime")
                                    .OrderBy(x => DateTime.Parse(x.Value))
                                    .FirstOrDefault().Value
                });
            Output(tenth);

            // 11. Выбираю и вывожу идентефикационные номера броней и самое большое
            //    количество дней брони комнаты. Сортирую по кол-ву дней
            Console.WriteLine("#11----------------------------------------------\n");
            var eleventh = from x in file.Root.Elements("booking")
                           let BestDays = (from y in x.Descendants("bookedRoom")
                                           let Days = DateTime.Parse(y.Element("endTime").Value).Subtract(DateTime.Parse(y.Element("startTime").Value)).Days + 1
                                           orderby Days descending
                                           select Days).FirstOrDefault()
                           orderby BestDays descending
                           select new
                           {
                               bookingID = x.Element("ID").Value,
                               Days = BestDays
                           };
            Output(eleventh);

            // 12. Выбираю идентефикационные номера броней и цену на бронь.
            //     Вывожу только бронирования в диапазоне от тысячи до двух тысяч
            Console.WriteLine("#12----------------------------------------------\n");
            var twelfth = file.Root
                .Elements("booking")
                .OrderBy(x => Convert.ToInt32(x.Element("price").Value))
                .SkipWhile(x => Convert.ToInt32(x.Element("price").Value) < 1000)
                .TakeWhile(x => Convert.ToInt32(x.Element("price").Value) < 2000)
                .Select(x => new 
                {
                    bookingID = x.Element("ID").Value,
                    price = x.Element("price").Value
                });
            Output(twelfth);

            // 13. Вывожу доп. опции которые начинаются с буквы "с"
            Console.WriteLine("#13----------------------------------------------\n");
            var thirteenth = (from x in file.Root.Descendants("extra")
                             where Regex.IsMatch(x.Element("object").Value, @"^(C|c)")
                             select x.Element("object").Value).Distinct();
            Output(thirteenth);

            // 14. Выбираю идентификационные номера брони, цену и количество забронированных комнат.
            //     Выбираю только те, где цена больше 3000 или те, кто количество забронирвоанных комнат больше 1
            Console.WriteLine("#14----------------------------------------------\n");
            var fourteenth = file.Root.Elements("booking")
                                       .Where(x => Convert.ToInt32(x.Element("price").Value) > 3000)
                                       .Select(x => x)
                              .Concat(file.Root.Elements("booking")
                                               .Where(x => x.Descendants("bookedRoom").Count() > 1)
                                               .Select(x => x))
                              .Select(x => new
                              {
                                  bookingID = x.Element("ID").Value,
                                  price = x.Element("price").Value,
                                  amountOfRooms = x.Descendants("bookedRoom").Count()
                              })
                             .Distinct();

            Output(fourteenth);

            // 15. Выбираю идентефикационные номера брони, колиечство доп. опций и имя клиента.
            //     Выбираю только те, где количество доп. опций больше 5 и имя клиента содержит "ra"
            Console.WriteLine("#15----------------------------------------------\n");
            var fiftheenth = from x in file.Root.Elements("booking")
                             where (from ae in x.Descendants("amount") select Convert.ToInt32(ae.Value)).Sum() > 5
                             join y in file.Root.Elements("booking") on x.Element("ID") equals y.Element("ID")
                             where Regex.IsMatch(y.Descendants("name").FirstOrDefault().Value, @"(\w*)(R|r)a(\w*)")
                             select new
                             {
                                 BookingID = x.Element("ID").Value,
                                 AmountOfExtras = (from ae in x.Descendants("amount")
                                                   select Convert.ToInt32(ae.Value)).Sum(),
                                 Name =  x.Descendants("name").FirstOrDefault().Value
                             };
            Output(fiftheenth);
        }

        public static void Output<T>(IEnumerable<T> l)
        {
            foreach (T el in l)
            {
                Console.WriteLine(el + "\n");
            }
        }
    }
}
