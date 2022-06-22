using System;
using System.Threading;

namespace Lab5Net.Pattern
{
    public interface IObserver
    {
        protected static int IDcounter = 0;
        public void Update(Product product);
    }

    public class Client : IObserver
    {
        public string Name { get; set; }
        public readonly int ID;
        public Client(string Name = "Unknown")
        {
            IObserver.IDcounter++;
            this.Name = Name;
            this.ID = IObserver.IDcounter;
        }
        public void Update(Product product)
        {
            Console.WriteLine($"\nNotification!!!\nFor client, ID#{ID}:");
            Console.WriteLine($"{Name}, у вашего товара №{product.Number} новый статус!");
            Console.WriteLine($"Актуальный статус: {product.Status}");
            if (product.Status.Equals("Доставлен в точку выдачи"))
            {
                Console.WriteLine("\nНажмите любую клавишу, чтоб забрать товар...");
                Console.ReadKey();
                TakeProduct(product);
            }
        }
        void TakeProduct(Product product)
        {
            Thread.Sleep(5000);
            product.Status = "Товар успешно получен!";
        }
    }

    public class Storekeeper : IObserver
    {
        public string Name { get; set; }
        public readonly int ID;
        public Storekeeper(string Name = "Unknown")
        {
            IObserver.IDcounter++;
            this.Name = Name;
            this.ID = IObserver.IDcounter;
        }
        public void Update(Product product)
        {
            if (product.Status.Equals("Разрешена отгрузка"))
            {
                Console.WriteLine($"\nNotification!!!\nFor storekeeper, ID#{ID}:");
                Console.WriteLine($"{Name}, товар №{product.Number} ожидает вашей отгрузки!");
                Shipment(product);
            }
        }
        private void Shipment(Product product)
        {
            Thread.Sleep(5000);
            Console.WriteLine($"\nstorekeeper ID#{ID} starts shipment.");
            Thread.Sleep(10000);
            Console.WriteLine($"\nstorekeper ID#{ID} ends shipment.");
            Thread.Sleep(5000);
            product.Status = "Разрешена доставка";
        }
    }

    public class Courier : IObserver
    {
        public string Name { get; set; }
        public readonly int ID;
        public Courier(string Name = "Unknown")
        {
            IObserver.IDcounter++;
            this.Name = Name;
            this.ID = IObserver.IDcounter;
        }
        public void Update(Product product)
        {
            if (product.Status.Equals("Разрешена доставка"))
            {
                Console.WriteLine($"\nNotification!!!\nFor courier, ID#{ID}:");
                Console.WriteLine($"{Name}, товар №{product.Number} ожидает вашей доставки!");
                Delivery(product);
            }
        }
        private void Delivery(Product product)
        {
            Thread.Sleep(5000);
            Console.WriteLine($"\ncourier ID#{ID} starts delivery.");
            Thread.Sleep(10000);
            Console.WriteLine($"\ncourier ID#{ID} ends delivery.");
            Thread.Sleep(5000);
            product.Status = "Доставлен в точку выдачи";
        }
    }
}
