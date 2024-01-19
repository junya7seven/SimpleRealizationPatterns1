using System;

// Абстрактный класс, представляющий алгоритм приготовления напитка
public abstract class CaffeineBeverage
{
    // Шаблонный метод, определяющий основной алгоритм
    public void PrepareBeverage()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
        Console.WriteLine("Beverage is ready!");
    }

    // Абстрактные методы, которые должны быть реализованы в подклассах
    protected abstract void Brew();
    protected abstract void AddCondiments();

    // Общие шаги, реализованные в базовом классе
    private void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    private void PourInCup()
    {
        Console.WriteLine("Pouring into cup");
    }
}

// Конкретная реализация для чая
public class Tea : CaffeineBeverage
{
    protected override void Brew()
    {
        Console.WriteLine("Steeping the tea");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding lemon");
    }
}

// Конкретная реализация для кофе
public class Coffee : CaffeineBeverage
{
    protected override void Brew()
    {
        Console.WriteLine("Dripping coffee through filter");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding sugar and milk");
    }
}

// Клиентский код
class Program
{
    static void Main()
    {
        Console.WriteLine("Making tea...");
        Tea tea = new Tea();
        tea.PrepareBeverage();

        Console.WriteLine("\nMaking coffee...");
        Coffee coffee = new Coffee();
        coffee.PrepareBeverage();
    }
}
