using System;
using System.Collections.Generic;

namespace lab1Net.Classes
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

        public HotelRoom(RoomClass Classification = RoomClass.Standart, int Capacity = 1, Dictionary<string, int> Extra = null)
        {
            this.Classification = Classification;
            this.Capacity = Capacity;
            this.Extra = Extra;
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

        public override string ToString()
        {
            string hotelRoomStr = $"Room number: {RoomNumber}, \nCapacity: {Capacity}, \nClass: {Classification}";
            if (Extra.Count > 0)
            {
                hotelRoomStr += $",\nAdditionaly:";
                foreach (var ex in Extra)
                {
                    hotelRoomStr += $"\n{ex.Key}, Amount: {ex.Value};";
                }
            }
            return hotelRoomStr;
        }
        private static bool IsThereRoom(int number)
        {
            if (roomNumbers.Contains(number)) return true;
            return false;
        }
    }
}
