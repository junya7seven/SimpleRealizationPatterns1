using System;
using System.Collections;
using System.Collections.Generic;

// Интерфейс итератора
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Интерфейс агрегата
public interface ILibrary
{
    IIterator<Book> CreateIterator();
}

// Конкретный класс книги
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}

// Конкретный класс библиотеки
public class Library : ILibrary
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public IIterator<Book> CreateIterator()
    {
        return new LibraryIterator(this);
    }

    // Вложенный класс итератора
    private class LibraryIterator : IIterator<Book>
    {
        private Library library;
        private int currentIndex = 0;

        public LibraryIterator(Library library)
        {
            this.library = library;
        }

        public bool HasNext()
        {
            return currentIndex < library.books.Count;
        }

        public Book Next()
        {
            if (HasNext())
            {
                Book book = library.books[currentIndex];
                currentIndex++;
                return book;
            }
            else
            {
                throw new InvalidOperationException("No more books in the library.");
            }
        }
    }
}

// Клиентский код
class Program
{
    static void Main()
    {
        Library library = new Library();
        library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald"));
        library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));
        library.AddBook(new Book("1984", "George Orwell"));
        library.AddBook(new Book("The Catcher in the Rye", "J.D. Salinger"));

        // Используем итератор для перебора книг в библиотеке
        IIterator<Book> iterator = library.CreateIterator();
        while (iterator.HasNext())
        {
            Book book = iterator.Next();
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
        }
    }
}
