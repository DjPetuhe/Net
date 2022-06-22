using System.Threading;
using System.Collections.Generic;

namespace Lab5Net.Pattern
{
    public class Product
    {
        protected static int NumberCount = 0;
        public readonly int Number;
        private string _status;
        private readonly List<IObserver> Observerers = new();
        public string Name { get; set; }
        public string Status 
        {
            get { return _status; }
            set 
            {
                _status = value;
                NotifyObservers();
            }
        }
        public Product(string Name = "undefiend")
        {
            NumberCount++;
            this.Name = Name;
            this.Number = NumberCount;
        }
        public void AddObserverers(IObserver client, params IObserver[] observerers)
        {
            Observerers.Add(client);
            this.Status = "Принятый";
            foreach (IObserver observerer in observerers)
            {
                Observerers.Add(observerer);
            }
        }
        public void RemoveObserverers(params IObserver[] observerers)
        {
            foreach (IObserver observerer in observerers)
            {
                Observerers.Remove(observerer);
            }
        }
        public void NotifyObservers()
        {
            foreach (IObserver observerer in Observerers)
            {
                observerer.Update(this);
            }
        }
        public void NextStep()
        {
            Thread.Sleep(10000);
            Status = Status switch
            {
                "Оплачено" => "Принятый",
                "Принятый" => "В обработке",
                "В обработке" => "Разрешена отгрузка",
                _ => "Помилка"
            };
        }
    }
}
