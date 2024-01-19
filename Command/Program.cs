using System;
using System.Collections.Generic;

// Интерфейс команды
public interface ICommand
{
    void Execute();
    void Undo();
}

// Конкретная команда - команда для вставки текста
public class InsertCommand : ICommand
{
    private Editor editor;
    private string text;

    public InsertCommand(Editor editor, string text)
    {
        this.editor = editor;
        this.text = text;
    }

    public void Execute()
    {
        editor.InsertText(text);
    }

    public void Undo()
    {
        //editor.DeleteLastText(text.Length);
    }
}

// Конкретная команда - команда для удаления текста
public class DeleteCommand : ICommand
{
    private Editor editor;
    private string deletedText;

    public DeleteCommand(Editor editor)
    {
        this.editor = editor;
    }

    public void Execute()
    {
        deletedText = editor.DeleteSelectedText();
    }

    public void Undo()
    {
        editor.InsertText(deletedText);
    }
}

// Класс редактора, который будет получать и выполнять команды
public class Editor
{
    private string text = "";
    private int selectionStart = 0;

    public void InsertText(string insertedText)
    {
        text = text.Insert(selectionStart, insertedText);
        selectionStart += insertedText.Length;
        Console.WriteLine($"Inserted Text: {insertedText}");
        Console.WriteLine($"Current Text: {text}");
    }

    public string DeleteSelectedText()
    {
        int selectionEnd = Math.Min(selectionStart + 5, text.Length);
        string deletedText = text.Substring(selectionStart, selectionEnd - selectionStart);
        text = text.Remove(selectionStart, selectionEnd - selectionStart);
        Console.WriteLine($"Deleted Text: {deletedText}");
        Console.WriteLine($"Current Text: {text}");
        return deletedText;
    }

    public void SetSelection(int start)
    {
        selectionStart = Math.Max(0, Math.Min(start, text.Length));
        Console.WriteLine($"Selection Start: {selectionStart}");
    }

    public void DisplayText()
    {
        Console.WriteLine($"Current Text: {text}");
    }
}

// Объект, вызывающий команды
public class Invoker
{
    private List<ICommand> commandHistory = new List<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandHistory.Add(command);
    }

    public void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            ICommand lastCommand = commandHistory[commandHistory.Count - 1];
            lastCommand.Undo();
            commandHistory.RemoveAt(commandHistory.Count - 1);
        }
    }
}

// Клиентский код
class Program
{
    static void Main()
    {
        Editor editor = new Editor();
        Invoker invoker = new Invoker();

        ICommand insertCommand = new InsertCommand(editor, "Hello, ");
        ICommand deleteCommand = new DeleteCommand(editor);

        invoker.ExecuteCommand(insertCommand);
        invoker.ExecuteCommand(deleteCommand);

        editor.DisplayText();

        invoker.UndoLastCommand();

        editor.DisplayText();
    }
}
