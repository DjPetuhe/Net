
namespace Lab4Net.Pattern
{
    interface IPizza
    {
        public string GetName();
        public int GetCost();
    }
    class PizzaNapoletana : IPizza
    {
        public string GetName() => "Pizza Napoletana";
        public int GetCost() => 300;
    }
    class PizzaCalzone : IPizza
    {
        public string GetName() => "Calzone";
        public int GetCost() => 250;
    }
    class PizzaRomana : IPizza
    {
        public string GetName() => "Pizza Romana";
        public int GetCost() => 350;
    }
}
