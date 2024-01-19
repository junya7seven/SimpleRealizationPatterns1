// Product
public interface IShape
{
    void Print();

}
// ConcreteProduct 1
public class Square : IShape
{
    public void Print()
    {
        Console.WriteLine("Draw Square");
    }
}
// ConcreteProduct 2
public class Circle : IShape
{
    public void Print()
    {
        Console.WriteLine("Draw Circle");
    }
}


// Creator
public abstract class ShapeFactory
{
    // Factory
    public abstract IShape Create();
    // Realization
    public void PrintShape()
    {
        IShape shape = Create();
        shape.Print();
    }
}
// ConcreteCreaator1
public class SquareFactory : ShapeFactory
{
    public override IShape Create()
    {
        return new Square();
    }
}
// ConcreteCreaator2
public class CircleFactory : ShapeFactory
{
    public override IShape Create()
    {
        return new Circle();
    }
}
// The client chooses the product
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("asd");
        string s = Console.ReadLine();
        if (s == "1")
        {
            ShapeFactory squareFactory = new SquareFactory();
            squareFactory.PrintShape();
        }
        if (s == "2")
        {
            ShapeFactory circleFactory = new CircleFactory();
            circleFactory.PrintShape();
        }
    }
}