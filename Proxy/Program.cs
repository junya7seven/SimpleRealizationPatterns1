using System;

// Общий интерфейс для изображения
public interface IImage
{
    void Display();
}

// Реальное изображение
public class RealImage : IImage
{
    private string filename;

    public RealImage(string filename)
    {
        this.filename = filename;
        LoadImage();
    }

    private void LoadImage()
    {
        Console.WriteLine($"Loading image: {filename}");
    }

    public void Display()
    {
        Console.WriteLine($"Displaying image: {filename}");
    }
}

// Заместитель для изображения
public class ProxyImage : IImage
{
    private RealImage realImage;
    private string filename;

    public ProxyImage(string filename)
    {
        this.filename = filename;
    }

    public void Display()
    {
        if (realImage == null)
        {
            realImage = new RealImage(filename);
        }
        realImage.Display();
    }
}

// Клиентский код
class Program
{
    static void Main()
    {
        // Используем заместитель для управления доступом к изображению
        IImage image = new ProxyImage("sample.jpg");

        // Первый раз изображение загружается
        image.Display();

        // Повторный вызов, изображение уже загружено и будет просто отображено
        image.Display();
    }
}
