// Abstraction
public abstract class RemoteControl
{
    protected IDevice device;
    public RemoteControl(IDevice device)
    {
        this.device = device;
    }
    public abstract void TurnOn();
    public abstract void TurnOff();
    public abstract void SetChannel(int channel);
}
// Realization abstraction
public interface IDevice
{
    void TurnOn();
    void TurnOff();
    void SetChannel(int channel);
}
// Concrete realization device - TV
public class TV : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine(" TV is ON");
    }
    public void TurnOff()
    {
        Console.WriteLine(" TV is OFF");
    }
    public void SetChannel(int channel)
    {
        Console.WriteLine($"Set TV channel to {channel}");
    }
}
// Concrete realization device - Radio
public class Radio : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine(" Radio is ON");
    }
    public void TurnOff()
    {
        Console.WriteLine(" Radio is OFF");
    }
    public void SetChannel(int channel)
    {
        Console.WriteLine($"Set Radio channel to {channel}");
    }
}
// Concrete abstraction - control for TV
public class TVControl : RemoteControl
{
    public TVControl(IDevice device) : base(device)
    {
    }

    public override void TurnOn()
    {
        Console.Write("TV Remote: ");
        device.TurnOn();
    }

    public override void TurnOff()
    {
        Console.Write("TV Remote: ");
        device.TurnOff();
    }

    public override void SetChannel(int channel)
    {
        Console.Write("TV Remote: ");
        device.SetChannel(channel);
    }
}
// Concrete abstraction - control for Radio
public class RadioControl : RemoteControl
{
    public RadioControl(IDevice device) : base(device)
    {
    }

    public override void TurnOn()
    {
        Console.Write("Radio Remote: ");
        device.TurnOn();
    }

    public override void TurnOff()
    {
        Console.Write("Radio Remote: ");
        device.TurnOff();
    }

    public override void SetChannel(int channel)
    {
        Console.Write("Radio Remote: ");
        device.SetChannel(channel);
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create TV and Radio
        IDevice tv = new TV();
        IDevice radio = new Radio();
        // Create controls for TV and Radio
        RemoteControl tvControl = new TVControl(tv);
        RemoteControl radioControl = new RadioControl(radio);
        // use controls
        tvControl.TurnOn();
        tvControl.TurnOff();
        tvControl.SetChannel(4);

        radioControl.TurnOn();
        radioControl.TurnOff();
        radioControl.SetChannel(7);
    }
}