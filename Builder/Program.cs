// Product
public class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string GPU { get; set; }
    public string Storage { get; set; }
    public void Display()
    {
        Console.WriteLine($"Computer Configuration:\nCPU: {CPU}\nRAM: {RAM}\nGPU: {GPU}\nStorage: {Storage}\n");
    }
}
// Abstract Builder
public interface ComputerBuilder
{
    void BuildCPU();
    void BuildRAM();
    void BuildGPU();
    void BuildStorage();
    Computer GetComputer();
}
// ConcreteBuilder 1 GAMING PC
public class GamingComputer : ComputerBuilder
{
    private Computer computer = new Computer();
    public void BuildCPU()
    {
        computer.CPU = "Gaming CPU";
    }
    public void BuildRAM()
    {
        computer.GPU = "64GB";
    }
    public void BuildGPU()
    {
        computer.Storage = "RTX 3080";
    }
    public void BuildStorage()
    {
        computer.Storage = "1TB SSD";
    }
    public Computer GetComputer()
    {
        return computer;
    }
}
// ConcreteBuilder 2 OFFICE PC
public class OfficeComputer : ComputerBuilder
{
    private Computer computer = new Computer();
    public void BuildCPU()
    {
        computer.CPU = "Standart CPU";
    }
    public void BuildRAM()
    {
        computer.GPU = "8GB";
    }
    public void BuildGPU()
    {
        computer.Storage = "Integrated graphics";
    }
    public void BuildStorage()
    {
        computer.Storage = "500TB HDD";
    }
    public Computer GetComputer()
    {
        return computer;
    }
}
// Director
public class ComputerDirector
{
    private ComputerBuilder computerBuilder;
    public ComputerDirector(ComputerBuilder computerBuilder)
    {
        this.computerBuilder = computerBuilder;
    }
    public void ConstructComputer()
    {
        computerBuilder.BuildCPU();
        computerBuilder.BuildRAM();
        computerBuilder.BuildGPU();
        computerBuilder.BuildStorage();
    }
    public Computer GetComputer()
    {
        return computerBuilder.GetComputer();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose pc - gaming | office");
        string choosePC = Console.ReadLine();

        if (choosePC == "gaming")
        {
            // Build Gaming PC
            ComputerBuilder gamingBuilder = new GamingComputer();
            ComputerDirector gamingDirector = new ComputerDirector(gamingBuilder);
            gamingDirector.ConstructComputer();
            Computer gamingComputer = gamingDirector.GetComputer();
            gamingComputer.Display();
        }
        if (choosePC == "office")
        {
            // Build Office PC
            ComputerBuilder officeBuilder = new OfficeComputer();
            ComputerDirector officeDirector = new ComputerDirector(officeBuilder);

            officeDirector.ConstructComputer();
            Computer officeComputer = officeDirector.GetComputer();
            officeComputer.Display();
        }
    }
}