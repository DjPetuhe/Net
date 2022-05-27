using System;

namespace Lab2Net
{
    internal class Client
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 1 || value > 120)
                    Console.WriteLine("Age must be between 1 and 120");
                else age = value;
            }
        }

        public int BookingsCount { get; set; } = 0;
        public Client(string Name = "Unknown", string Surname = "Unknown", int Age = 1)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nAge: {Age}";
        }
    }
}
