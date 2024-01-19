// Request prom
public class PromotionReauest
{
    public string EmployeeName { get; set; }
    public int Yeats { get; set; }
    public PromotionReauest(string employeeName, int yeats)
    {
        EmployeeName = employeeName;
        Yeats = yeats;
    }
}
// Abstract handler
public abstract class Handler
{
    protected Handler successor;
    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }
    public abstract void HandleRequest(PromotionReauest request);
}
// 
public class SupervisorHandler : Handler // 0-1 - supvis
{
    public override void HandleRequest(PromotionReauest request)
    {
        if (request.Yeats >= 0 && request.Yeats <= 5)
        {
            Console.WriteLine($"{request.EmployeeName} is promoted to Supervisor.");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}
// Concrete handler - Director
public class DirectorHandler : Handler //6-10 - director
{
    public override void HandleRequest(PromotionReauest request)
    {
        if (request.Yeats > 5 && request.Yeats <= 10)
        {
            Console.WriteLine($"{request.EmployeeName} is promoted to Director.");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}
// Concrete handler - maanger
public class ManagerHandler : Handler //11-15 - manager
{
    public override void HandleRequest(PromotionReauest request)
    {
        if (request.Yeats > 10 && request.Yeats <= 15)
        {
            Console.WriteLine($"{request.EmployeeName} is promoted to Manager.");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create chain handler
        Handler supvis = new SupervisorHandler();
        Handler director = new DirectorHandler();
        Handler maanger = new ManagerHandler();

        supvis.SetSuccessor(maanger);
        maanger.SetSuccessor(director);

        // Create request for prom
        PromotionReauest request1 = new PromotionReauest("Joe", 1);
        PromotionReauest request2 = new PromotionReauest("Alice Smith", 6);
        PromotionReauest request3 = new PromotionReauest("Bob Johnson", 13);

        // Passing requests through the chain of handlers
        supvis.HandleRequest(request1);
        Console.WriteLine("------------------------");
        supvis.HandleRequest(request2);
        Console.WriteLine("------------------------");
        supvis.HandleRequest(request3);
    }
}