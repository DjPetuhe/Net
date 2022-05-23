using System;
using System.Collections.Generic;

namespace lab1Net
{
    internal class Booking
    {
        public readonly Client Person;
        public readonly int Price;
        public readonly List<(HotelRoom, DateTime, DateTime)> BookedRooms;
        public bool Canceled { get; set; } = false;

        public Booking(Client Person, List<(HotelRoom, DateTime, DateTime)> BookedRooms)
        {
            this.Person = Person;
            if (BookingPossible(BookedRooms))
            {
                this.BookedRooms = BookedRooms;
                this.Person.Bookings.Add(this);
                foreach (var room in BookedRooms)
                {
                    room.Item1.RoomBookings.Add(this);
                }
                this.Price = CalculatePrice(); 
            }
            else
            {
                Console.WriteLine("Booking error!");
                this.BookedRooms = null;
                Canceled = true;
            }
        }

        public override string ToString()
        {
            if (!Canceled)
            {
                string bookingStr = $"Person: {Person.Name} {Person.Surname},\nPrice: {Price},\nBooked:";
                foreach (var booked in BookedRooms)
                {
                    bookingStr += $"\n\nFrom: {booked.Item2.ToShortDateString()}," +
                                  $"\nTo: {booked.Item3.ToShortDateString()}" +
                                  $"\n{booked.Item1}";
                }
                return bookingStr;
            }
            else return "Booking canceled!";
        }

        private static bool BookingPossible(List<(HotelRoom, DateTime, DateTime)> BookedRooms)
        {
            HashSet<HotelRoom> doppelgangerFinder = new ();
            foreach (var room in BookedRooms)
            {
                if (!doppelgangerFinder.Add(room.Item1) || room.Item3.Date < room.Item2.Date || room.Item1.IsBooked(room.Item2, room.Item3))
                    return false;
            }
            return true;
        }

        private int CalculatePrice()
        {
            int totalPrice = 0;
            foreach (var room in BookedRooms)
            {
                int tempPrice = room.Item1.Classification switch
                {
                    RoomClass.Standart => 50 + 10 * room.Item1.Capacity,
                    RoomClass.DeLux => 100 + 20 * room.Item1.Capacity,
                    RoomClass.Presidential => 500 + 50 * room.Item1.Capacity,
                    _ => 0
                };
                foreach (var extra in room.Item1.Extra)
                {
                    tempPrice += 10 * extra.Value;
                }
                tempPrice *= (room.Item3 - room.Item2).Days + 1;
                totalPrice += tempPrice;
            }
            return totalPrice;
        }
    }
}
