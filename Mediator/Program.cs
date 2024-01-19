using System;
using System.Collections.Generic;

// Интерфейс посредника
public interface IChatMediator
{
    void SendMessage(User sender, string message);
}

// Класс посредника - чат
public class ChatMediator : IChatMediator
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void SendMessage(User sender, string message)
    {
        foreach (var user in users)
        {
            // Исключаем отправителя из получателей
            if (user != sender)
            {
                user.ReceiveMessage(message);
            }
        }
    }
}

// Класс участника чата
public class User
{
    private IChatMediator chatMediator;
    public string Name { get; private set; }

    public User(IChatMediator chatMediator, string name)
    {
        this.chatMediator = chatMediator;
        Name = name;
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"{Name} sent message: {message}");
        chatMediator.SendMessage(this, message);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} received message: {message}");
    }
}

// Клиентский код
class Program
{
    static void Main()
    {
        // Создаем посредника - чат
        IChatMediator chat = new ChatMediator();

        // Создаем пользователей и добавляем их в чат
        User user1 = new User(chat, "John");
        User user2 = new User(chat, "Alice");
        User user3 = new User(chat, "Bob");

        /*chat.AddUser(user1);
        chat.AddUser(user2);
        chat.AddUser(user3);*/

        // Пользователи отправляют сообщения через чат
        user1.SendMessage("Hello, everyone!");
        user2.SendMessage("Hi, John!");
        user3.SendMessage("Nice to meet you!");

        /*
        Вывод:
        John sent message: Hello, everyone!
        Alice received message: Hello, everyone!
        Bob received message: Hello, everyone!

        Alice sent message: Hi, John!
        John received message: Hi, John!
        Bob received message: Hi, John!

        Bob sent message: Nice to meet you!
        John received message: Nice to meet you!
        Alice received message: Nice to meet you!
        */
    }
}
