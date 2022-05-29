using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2Net
{
    enum RoomClass
    {
        Standart,
        DeLux,
        Presidential
    }

    internal class HotelRoom
    {
        private static readonly List<int> roomNumbers = new();

        private int _roomNumber;
        public int RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                if (value <= 0 || IsThereRoom(value))
                    Console.WriteLine("Wrong room number.");
                else
                {
                    if (_roomNumber > 0) roomNumbers.Remove(_roomNumber);
                    _roomNumber = value;
                    roomNumbers.Add(_roomNumber);
                }
            }
        }

        private int _capacity;
        public int Capacity
        {
            get { return _capacity; }
            set
            {
                if (value < 0) Console.WriteLine("Capacity must be positive number.");
                else _capacity = value;
            }
        }

        public RoomClass Classification { get; set; }

        public Dictionary<string, int> Extra { get; private set; } = new();

        public List<Booking> RoomBookings { get; set; } = new();

        public HotelRoom(int RoomNumber, RoomClass Classification = RoomClass.Standart, int Capacity = 1, Dictionary<string, int> Extra = null)
        {
            this.RoomNumber = RoomNumber;
            this.Classification = Classification;
            this.Capacity = Capacity;
            this.Extra = Extra ?? new();
        }

        public void SetExtra(string Ex, int Amount)
        {
            if (Amount > 0)
            {
                if (Extra.ContainsKey(Ex)) Extra[Ex] = Amount;
                else Extra.Add(Ex, Amount);
            }
            else Console.WriteLine("Amount must be positive number.");
        }

        public void RemoveExtra(string Ex)
        {
            if (Extra.ContainsKey(Ex)) Extra.Remove(Ex);
            else Console.WriteLine($"There is no {Ex} in extras.");
        }

        private static bool IsThereRoom(int number)
        {
            if (roomNumbers.Contains(number)) return true;
            return false;
        }

        public bool IsBooked(DateTime start, DateTime finish)
        {
            foreach (var booking in RoomBookings)
            {
                var room = booking.BookedRooms.Select(b => b).Where(b => b.Item1.RoomNumber == this.RoomNumber).First();
                if (start.Date < room.Item3.Date && room.Item2.Date < finish.Date) return true;
            }
            return false;
        }
    }
}