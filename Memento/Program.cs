using System;
using System.Collections.Generic;

// Объект-хранитель, который хранит состояние текстового документа
public class DocumentMemento
{
    public string Content { get; private set; }
    public DateTime Timestamp { get; private set; }

    public DocumentMemento(string content)
    {
        Content = content;
        Timestamp = DateTime.Now;
    }
}

// Объект-оригинатор, который создает мементо и восстанавливает состояние
public class TextDocument
{
    private string content;

    public TextDocument(string content)
    {
        this.content = content;
    }

    // Создание мементо
    public DocumentMemento CreateMemento()
    {
        return new DocumentMemento(content);
    }

    // Восстановление состояния из мементо
    public void RestoreFromMemento(DocumentMemento memento)
    {
        content = memento.Content;
        Console.WriteLine($"Document restored to version from {memento.Timestamp}");
    }

    // Изменение содержимого документа
    public void EditContent(string newContent)
    {
        content = newContent;
        Console.WriteLine($"Document content edited: {content}");
    }

    // Вывод текущего содержимого
    public void Display()
    {
        Console.WriteLine($"Current Document Content: {content}");
    }
}

// Объект-хранитель истории версий
public class VersionHistory
{
    private List<DocumentMemento> history = new List<DocumentMemento>();

    public void AddMemento(DocumentMemento memento)
    {
        history.Add(memento);
    }

    public DocumentMemento GetMemento(int index)
    {
        if (index >= 0 && index < history.Count)
        {
            return history[index];
        }
        else
        {
            throw new IndexOutOfRangeException("Invalid version index");
        }
    }
}

// Клиентский код
class Program
{
    static void Main()
    {
        // Создаем документ и объект для хранения истории версий
        TextDocument document = new TextDocument("Initial content");
        VersionHistory versionHistory = new VersionHistory();

        // Редактируем и сохраняем версии документа
        document.EditContent("Version 1");
        versionHistory.AddMemento(document.CreateMemento());

        document.EditContent("Version 2");
        versionHistory.AddMemento(document.CreateMemento());

        document.EditContent("Version 3");
        versionHistory.AddMemento(document.CreateMemento());

        // Вывод текущего состояния и восстановление предыдущей версии
        document.Display();
        document.RestoreFromMemento(versionHistory.GetMemento(1));
        document.Display();
    }
}
