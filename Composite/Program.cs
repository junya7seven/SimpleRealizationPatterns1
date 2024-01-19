// Abstract component
public interface IOgranizationComponent
{
    void DisplayInfo();
}
// Concrete list - employee
public class Employee : IOgranizationComponent
{
    private readonly string name;
    private readonly string position;
    public Employee(string name, string position)
    {
        this.name = name;
        this.position = position;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"{position} - {name}");
    }
}
// Composite - department
public class Department : IOgranizationComponent
{
    private readonly string name;
    private readonly List<IOgranizationComponent> members = new List<IOgranizationComponent>();
    public Department(string name)
    {
        this.name = name;
    }
    public void AddMember(IOgranizationComponent member)
    {
        members.Add(member);
    }
    public void RemoveMember(IOgranizationComponent member)
    {
        members.Remove(member);
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Department - {name}");
        Console.WriteLine("Members:");
        foreach (var member in members)
        {
            member.DisplayInfo();
        }
        Console.WriteLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create individual members
        IOgranizationComponent employee1 = new Employee("Artur", "Police man");
        IOgranizationComponent employee2 = new Employee("Oleg", "Software Engineer");
        // Create department
        IOgranizationComponent securityDepartment = new Department("Security");
        IOgranizationComponent developmentDepartment = new Department("IT");
        // Add members in department
        ((Department)securityDepartment).AddMember(employee1);
        ((Department)developmentDepartment).AddMember(employee2);
        // Create super department and Add another departments
        IOgranizationComponent mainOrganization = new Department("Main Organization");
        ((Department)mainOrganization).AddMember(securityDepartment);
        ((Department)mainOrganization).AddMember(developmentDepartment);
        ((Department)mainOrganization).AddMember(new Employee("Alice", "CEO"));

        mainOrganization.DisplayInfo();


    }
}