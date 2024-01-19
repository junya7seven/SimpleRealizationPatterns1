using System;
using System.Collections.Generic;

// Интерфейс посетителя
public interface IShapeVisitor
{
    void VisitCircle(Circle circle);
    void VisitSquare(Square square);
}

// Интерфейс элемента, который может быть посещен
public interface IShape
{
    void Accept(IShapeVisitor visitor);
}

// Конкретная реализация элемента - круг
public class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public void Accept(IShapeVisitor visitor)
    {
        visitor.VisitCircle(this);
    }
}

// Конкретная реализация элемента - квадрат
public class Square : IShape
{
    public double SideLength { get; }

    public Square(double sideLength)
    {
        SideLength = sideLength;
    }

    public void Accept(IShapeVisitor visitor)
    {
        visitor.VisitSquare(this);
    }
}

// Конкретная реализация посетителя - вычисление площади
public class AreaCalculator : IShapeVisitor
{
    public void VisitCircle(Circle circle)
    {
        double area = Math.PI * Math.Pow(circle.Radius, 2);
        Console.WriteLine($"Area of circle with radius {circle.Radius}: {area}");
    }

    public void VisitSquare(Square square)
    {
        double area = Math.Pow(square.SideLength, 2);
        Console.WriteLine($"Area of square with side length {square.SideLength}: {area}");
    }
}

// Клиентский код
class Program
{
    static void Main()
    {
        List<IShape> shapes = new List<IShape>
        {
            new Circle(5),
            new Square(4),
            new Circle(3),
            new Square(6)
        };

        AreaCalculator areaCalculator = new AreaCalculator();

        // Посетитель вычисляет площадь каждой фигуры
        foreach (var shape in shapes)
        {
            shape.Accept(areaCalculator);
        }
    }
}
