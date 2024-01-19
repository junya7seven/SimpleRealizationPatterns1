using System;

// Интерфейс состояния
public interface IOrderState
{
    void ProcessOrder(OrderContext context);
}

// Конкретное состояние - обработка нового заказа
public class NewOrderState : IOrderState
{
    public void ProcessOrder(OrderContext context)
    {
        Console.WriteLine("Processing new order...");
        // Логика обработки нового заказа
        context.State = new ShippedOrderState();
    }
}

// Конкретное состояние - обработка отправленного заказа
public class ShippedOrderState : IOrderState
{
    public void ProcessOrder(OrderContext context)
    {
        Console.WriteLine("Processing shipped order...");
        // Логика обработки отправленного заказа
        context.State = new DeliveredOrderState();
    }
}

// Конкретное состояние - обработка доставленного заказа
public class DeliveredOrderState : IOrderState
{
    public void ProcessOrder(OrderContext context)
    {
        Console.WriteLine("Processing delivered order...");
        // Логика обработки доставленного заказа
    }
}

// Класс, содержащий состояние и делегирующий его обработку конкретному объекту состояния
public class OrderContext
{
    private IOrderState state;

    public IOrderState State
    {
        get { return state; }
        set
        {
            Console.WriteLine($"Order state changed to {value.GetType().Name}");
            state = value;
        }
    }

    public OrderContext()
    {
        // Начальное состояние - новый заказ
        State = new NewOrderState();
    }

    public void ProcessOrder()
    {
        // Делегируем обработку текущему состоянию
        state.ProcessOrder(this);
    }
}

// Клиентский код
class Program
{
    static void Main()
    {
        OrderContext orderContext = new OrderContext();

        // Обработка нового заказа
        orderContext.ProcessOrder();

        // Обработка отправленного заказа
        orderContext.ProcessOrder();

        // Обработка доставленного заказа
        orderContext.ProcessOrder();

    }
}
