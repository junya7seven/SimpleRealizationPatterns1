// Prototype
public abstract class CardPrototype : ICloneable
{
    public string Name { get; init; }
    public int Cost { get; init; }
    public CardPrototype(string name, int cost)
    {
        Name = name;
        Cost = cost;
    }
    public Object Clone()
    {
        return MemberwiseClone();
    }
    public abstract void DisplayInfo();
}
// ConcretePrototype 1 - Card Creature
public class CreatureCard : CardPrototype
{
    public int Attack { get; init; }
    public int Defense { get; init; }
    public CreatureCard(string name, int cost, int attack, int defense) : base(name, cost)
    {
        Attack = attack;
        Defense = defense;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Creature Card - Name: {Name}, Cost: {Cost}, Attack: {Attack}, Defense: {Defense}");

    }
}
// ConcretePrototype 2 - Card Spells
public class SpellCard : CardPrototype
{
    public string Effect { get; init; }
    public SpellCard(string name, int cost, string effect) : base(name, cost)
    {
        Effect = effect;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Spell Card - Name: {Name}, Cost: {Cost}, Effect: {Effect}");

    }
}
// Client
class Program
{
    static void Main(string[] args)
    {
        // Create prototype card
        CreatureCard creatureCardProt = new CreatureCard("Mage", 6, 1, 5);
        // creatureCardProt.Cost = 2; ERROR
        // creatureCardProt.Attack = "asd"; ERROR
        SpellCard spellCardProt = new SpellCard("Fireball", 4, "AOE spell");
        // Clone prototypies and create new cards
        CardPrototype newCreatureCard = (CardPrototype)creatureCardProt.Clone();
        SpellCard newSpellCard = (SpellCard)spellCardProt.Clone();
        // result
        Console.WriteLine("Prot");
        creatureCardProt.DisplayInfo();
        spellCardProt.DisplayInfo();
        Console.WriteLine("Clone");
        newCreatureCard.DisplayInfo();
        newSpellCard.DisplayInfo();

    }
}