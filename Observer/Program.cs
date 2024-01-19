using System;
using System.Collections.Generic;

// Интерфейс для наблюдателя
public interface IObserver
{
    void Update(string message);
}

// Интерфейс для субъекта (наблюдаемого объекта)
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string message);
}

// Конкретный класс наблюдателя
public class ConcreteObserver : IObserver
{
    private string name;

    public ConcreteObserver(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{name} received message: {message}");
    }
}

// Конкретный класс субъекта
public class ConcreteSubject : ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"Message sent: {message}");
        Notify(message);
    }
}

// Клиентский код
class Program
{
    static void Main()
    {
        // Создаем наблюдателей
        ConcreteObserver observer1 = new ConcreteObserver("Observer 1");
        ConcreteObserver observer2 = new ConcreteObserver("Observer 2");
        ConcreteObserver observer3 = new ConcreteObserver("Observer 3");

        // Создаем наблюдаемый объект и добавляем наблюдателей
        ConcreteSubject subject = new ConcreteSubject();
        subject.Attach(observer1);
        subject.Attach(observer2);
        subject.Attach(observer3);

        // Наблюдатели получают уведомление при отправке сообщения
        subject.SendMessage("Hello, observers!");
    }
}
