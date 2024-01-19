// AbstractProduct A
public interface Mage
{
    void CastSpell();
    void Stats();
}
// ConcreteProduct A1
public class FireMage : Mage
{
    private int health;
    private int damage;
    public FireMage()
    {
        health = 40;
        damage = 90;
    }
    public void CastSpell()
    {
        Console.WriteLine("Fire mag casts a damage spells");
    }
    public void Stats()
    {
        Console.WriteLine($"HP - {health}, damage - {damage}");
    }
}
// ConcreteProduct A2
public class IceMage : Mage
{
    private int health;
    private int damage;
    public IceMage()
    {
        health = 90;
        damage = 20;
    }
    public void CastSpell()
    {
        Console.WriteLine("Ice mag casts a slowing spells");
    }
    public void Stats()
    {
        Console.WriteLine($"HP - {health}, damage - {damage}");
    }
}
// AbstractProduct B
public interface Spells
{
    void Effect();
}
// ConcreteProduct B1
public class FireSpell : Spells
{
    public void Effect()
    {
        Console.WriteLine("Big FireBall");
    }
}
// ConcreteProduct B2
public class IceSpell : Spells
{
    public void Effect()
    {
        Console.WriteLine("Slowing  down");
    }
}
// AbstractFactory
public interface MageFactory
{
    Mage CreateMage();
    Spells CreateSpell();
}
// ConcreteFactory 1
public class FireMageFactory : MageFactory
{
    public Mage CreateMage()
    {
        return new FireMage();
    }
    public Spells CreateSpell()
    {
        return new FireSpell();
    }
}
// ConcreteFactory 2
public class IceMageFactory : MageFactory
{
    public Mage CreateMage()
    {
        return new IceMage();
    }
    public Spells CreateSpell()
    {
        return new IceSpell();
    }
}
// Client
public class Fight
{
    private MageFactory megaFactory;
    public Fight(MageFactory megaFactory)
    {
        this.megaFactory = megaFactory;
    }
    public void Play()
    {
        Mage mage = megaFactory.CreateMage();
        Spells spell = megaFactory.CreateSpell();
        Console.WriteLine("Start");
        mage.Stats();
        spell.Effect();
    }
}
class Program
{
    static void Main(string[] args)
    {
        MageFactory fireMageFactory = new FireMageFactory();
        Fight fire = new Fight(fireMageFactory);
        fire.Play();
        Console.WriteLine("------------------------------");
        MageFactory iceMageFactory = new IceMageFactory();
        Fight ice = new Fight(iceMageFactory);
        ice.Play();
        Console.ReadLine();
    }
}