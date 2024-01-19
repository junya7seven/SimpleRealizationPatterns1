public interface IGraphicObject
{
    void Draw(int x, int y);
}
// Concrete Flyweight - circle
public class Circle : IGraphicObject
{
    private string color;
    private int radius;
    public Circle(string color, int radius)
    {
        this.color = color;
        this.radius = radius;
    }
    public void Draw(int x, int y)
    {
        Console.WriteLine($"Drawing Circle with color {color}, radius {radius} at ({x}, {y})");
    }
}
// Fabric flyweight - graphic objects
public class GraphicObjectFactory
{
    private readonly Dictionary<string, IGraphicObject> graphicObjects;

    public GraphicObjectFactory()
    {
        graphicObjects = new Dictionary<string, IGraphicObject>();
    }

    public IGraphicObject GetCircle(string color, int radius)
    {
        // Use key to identify the lightweight
        string key = $"{color}_{radius}";

        if (!graphicObjects.ContainsKey(key))
        {
            graphicObjects[key] = new Circle(color, radius);
        }

        return graphicObjects[key];
    }
}
class Program
{
    static void Main()
    {
        GraphicObjectFactory objectFactory = new GraphicObjectFactory();
        // Creating and displaying many circles with different parameters
        IGraphicObject redCircle1 = objectFactory.GetCircle("Red", 5);
        IGraphicObject redCircle2 = objectFactory.GetCircle("Red", 5);
        IGraphicObject blueCircle = objectFactory.GetCircle("Blue", 10);
        IGraphicObject greenCircle = objectFactory.GetCircle("Green", 8);

        redCircle1.Draw(1, 1);
        redCircle2.Draw(2, 2);
        blueCircle.Draw(3, 3);
        greenCircle.Draw(4, 4);
    }
}