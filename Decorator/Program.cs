public interface ICoffee
{
    string GetDescription();
    float GetCost();
}
public class StandartCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Standart Coffee";
    }
    public float GetCost()
    {
        return 3.5f;
    }
}
// Abstract decorator
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee decoratedCoffee;
    public CoffeeDecorator(ICoffee decoratedCoffee)
    {
        this.decoratedCoffee = decoratedCoffee;
    }
    public virtual string GetDescription()
    {
        return decoratedCoffee.GetDescription();
    }
    public virtual float GetCost()
    {
        return decoratedCoffee.GetCost();
    }
}
// Concrete decorators - add to coffee
public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }
    public override string GetDescription()
    {
        return $"{decoratedCoffee.GetDescription()}, sugar";
    }
    public override float GetCost()
    {
        return decoratedCoffee.GetCost() + 0.5f;
    }
}
// Concrete decorators - add to coffee
public class CreamDecorator : CoffeeDecorator
{
    public CreamDecorator(ICoffee coffee) : base(coffee) { }
    public override string GetDescription()
    {
        return $"{decoratedCoffee.GetDescription()}, cream";
    }
    public override float GetCost()
    {
        return decoratedCoffee.GetCost() + 0.3f;
    }
}

class program
{
    static void Main(string[] args)
    {
        // Create standart coffee
        ICoffee coffee = new StandartCoffee();
        Console.WriteLine($"{coffee.GetCost()},{coffee.GetDescription()}");
        // Decorate coffee with sugar
        ICoffee coffeeSugar = new SugarDecorator(coffee);
        Console.WriteLine($"{coffeeSugar.GetCost()},{coffeeSugar.GetDescription()}");
        // Decorate coffe with sugar + cream
        ICoffee coffeCream = new CreamDecorator(coffeeSugar);
        Console.WriteLine($"{coffeCream.GetCost()},{coffeCream.GetDescription()}");
    }
}