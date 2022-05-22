using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1Net.Classes
{
    internal class Booking
    {
        public readonly Client Person;
        public readonly int Price;
        public readonly List<(HotelRoom, DateTime, DateTime)> BookedRooms;
        public bool Canceled { get; set; } = false;

        //TODO: Сделать, чтоб клиенту и отелю добавлялись данные об этом бронировании
        public Booking(Client Person, List<(HotelRoom, DateTime, DateTime)> BookedRooms)
        {
            this.Person = Person;
            if (BookingPossible(BookedRooms))
            {
                this.BookedRooms = BookedRooms;
            }
            else
            {
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

        //TODO: Доделать проверку на то, можно ли бронировать в это время эти номера
        private bool BookingPossible(List<(HotelRoom, DateTime, DateTime)> BookedRooms)
        {
            return false;
        }

        //TODO: Доделать метод, который будет подсчитывать цену
        private int CalculatePrice(List<(HotelRoom, DateTime, DateTime)> BookedRooms)
        {
            return 0;
        }
    }
}
