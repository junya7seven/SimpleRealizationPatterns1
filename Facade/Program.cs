// Subsystem 1 - Engine
public class Engine
{
    public void Start()
    {
        Console.WriteLine("Engine on");
    }
    public void Stop() { Console.WriteLine("Engine off"); }
}
// Subsystem 2 - fuel system
public class FuelSystem
{
    public void SupplyFiel()
    {
        Console.WriteLine("Fuel suplied to the engine");
    }
    public void StopFuelSupply()
    {
        Console.WriteLine("Fuel supply stopped");
    }
}
// Subsystem 3 - control system
public class ControlSystem
{
    public void Activate()
    {
        Console.WriteLine("Control system activated");
    }
    public void Deactivate()
    {
        Console.WriteLine("Control system deactivate");
    }
}
// Facade - cotrol car
public class CarFacade
{
    private Engine engine;
    private FuelSystem fuelSystem;
    private ControlSystem controlSystem;
    public CarFacade()
    {
        engine = new Engine();
        fuelSystem = new FuelSystem();
        controlSystem = new ControlSystem();
    }
    // Simple method for starting the car
    public void StartCar()
    {
        engine.Start();
        fuelSystem.SupplyFiel();
        controlSystem.Activate();
        Console.WriteLine("Car is reaty to go");
    }
    // Simple method for stopping the car
    public void StopCar()
    {
        engine.Stop();
        fuelSystem.StopFuelSupply();
        controlSystem.Deactivate();
        Console.WriteLine("Car stopped");
    }
}
class Program
{
    // use facade for control car
    static void Main(string[] args)
    {
        CarFacade carFacade = new CarFacade();
        carFacade.StartCar();
        Console.WriteLine("GO");
        carFacade.StopCar();
        Console.WriteLine("STOP");
    }
}