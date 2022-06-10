using System;
using Lab4Net.Pattern;

namespace Lab4Net
{
    class Program
    {
        static void Main(string[] args)
        {
            IPizza pizza1 = new PizzaNapoletana();
            PrintPizza(pizza1);

            IPizza pizza2 = new PizzaNapoletana();
            pizza2 = new OliveDecorator(pizza2);
            pizza2 = new SausageSideDecorator(pizza2);
            PrintPizza(pizza2); 

            IPizza pizza3 = new PizzaCalzone();
            pizza3 = new MushroomDecorator(pizza3);
            PrintPizza(pizza3); 

            IPizza pizza4 = new PizzaCalzone();
            pizza4 = new OliveDecorator(pizza4);
            pizza4 = new CheeseSideDecorator(pizza4);
            PrintPizza(pizza4); 

            IPizza pizza5 = new PizzaRomana();
            pizza5 = new TomateDecorator(pizza5);
            pizza5 = new MushroomDecorator(pizza5);
            pizza5 = new SausageSideDecorator(pizza5);
            PrintPizza(pizza5); 

            IPizza pizza6 = new PizzaRomana();
            pizza6 = new TomateDecorator(pizza5);
            pizza6 = new MushroomDecorator(pizza6);
            pizza6 = new OliveDecorator(pizza6);
            pizza6 = new OliveDecorator(pizza6);
            pizza6 = new CheeseSideDecorator(pizza6);
            PrintPizza(pizza6); 
        }
        static void PrintPizza(IPizza pizza)
        {
            Console.WriteLine($"\nСomposition of the pizza: {pizza.GetName()}");
            Console.WriteLine($"Cost: {pizza.GetCost()} UAH");
        }
    }
}
