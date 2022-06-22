using Lab5Net.Pattern;

namespace Lab5Net
{
    class Program
    {
        static void Main()
        {
            Product product = new("Table");
            Client client = new("Виталий");
            Courier courier = new("Василий");
            Storekeeper storekeeper = new("Екатерина");
            product.AddObserverers(client, courier, storekeeper);
            product.NextStep();
            product.NextStep();
        }
    }
}
