/*
Абстрактный класс - Автобус:Транспорт Машина:Транспорт Мотоцикл: Транспорт (Все передвигаются при помощи колёс)
    Общий функционал родственных объектов
    Много базового функционала
    Общая реализация производных классах на всех уровнял наследования
Интерфейс - Солнце:Тепло Лава:Тепло Лампа:Тепло НагретыйГаджет:Тепло (Все дают тепло, но не связаны между собой)
    Общий функционал для разрозненных объектов, которые никак не связаны между собой
    Проекция небольшого функционального типа
    Поддерживают множественное наследование
*/
class Differences
{
    static void Main(string[] args)
    {
        Transport[] transports = new Transport[] { new Bus(), new Car(), new Moto() };
        IWarm[] warm = new IWarm[] { new Sun(), new Lava(), new Lamp() };
        ILight[] light = new ILight[] { new Sun(), new Lava(), new Lamp() };
        foreach (Transport transport in transports)
        {
            transport.Move();
        }
        Console.WriteLine();
        foreach (IWarm warms in warm)
        {
            warms.Warm();
        }
        Console.WriteLine();
        foreach (ILight lights in light)
        {
            lights.Light();
        }
    }
}
public abstract class Transport
{
    public abstract void Move();
}
public class Bus : Transport
{
    public override void Move()
    {
        Console.WriteLine("Автобус едет");
    }
}
public class Car : Transport
{
    public override void Move()
    {
        Console.WriteLine("Машина едет");
    }
}
public class Moto : Transport
{
    public override void Move()
    {
        Console.WriteLine("Мотоцикл едет");
    }
}


public interface IWarm
{
    void Warm();
}
public interface ILight
{
    void Light();
}
class Sun : IWarm, ILight
{
    public void Warm()
    {
        Console.WriteLine("Солнце даёт тепло");
    }
    public void Light()
    {
        Console.WriteLine("Солнце даёт свет");
    }
}
class Lava : IWarm, ILight
{
    public void Warm()
    {
        Console.WriteLine("Лава даёт тепло");
    }
    public void Light()
    {
        Console.WriteLine("Лава даёт свет");
    }
}
class Lamp : IWarm, ILight
{
    public void Warm()
    {
        Console.WriteLine("Лампа даёт тепло");
    }
    public void Light()
    {
        Console.WriteLine("Лампа даёт свет");
    }
}