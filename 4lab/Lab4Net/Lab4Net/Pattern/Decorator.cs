
namespace Lab4Net.Pattern
{
    abstract class Decorator : IPizza
    {
        protected IPizza pizza;
        public Decorator(IPizza pizza)
        {
            this.pizza = pizza;
        }
        public abstract int GetCost();
        public abstract string GetName();
    }
    class MushroomDecorator : Decorator
    {
        public MushroomDecorator(IPizza pizza) : base(pizza) { }
        public override int GetCost() => pizza.GetCost() + 20;
        public override string GetName() => $"{pizza.GetName()} + mushrooms";
    }
    class TomateDecorator : Decorator
    {
        public TomateDecorator(IPizza pizza) : base(pizza) { }
        public override int GetCost() => pizza.GetCost() + 10;
        public override string GetName() => $"{pizza.GetName()} + tomatos";
    }
    class OliveDecorator : Decorator
    {
        public OliveDecorator(IPizza pizza) : base(pizza) { }
        public override int GetCost() => pizza.GetCost() + 30;
        public override string GetName() => $"{pizza.GetName()} + olives";
    }
    class CheeseSideDecorator : Decorator
    {
        public CheeseSideDecorator(IPizza pizza) : base(pizza) { }
        public override int GetCost() => pizza.GetCost() + 25;
        public override string GetName() => $"{pizza.GetName()} + cheese side";
    }
    class SausageSideDecorator : Decorator
    {
        public SausageSideDecorator(IPizza pizza) : base(pizza) { }
        public override int GetCost() => pizza.GetCost() + 35;
        public override string GetName() => $"{pizza.GetName()} + sausage side";
    }
}
