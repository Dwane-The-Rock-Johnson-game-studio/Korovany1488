public class Human : Antropomorph
{
    public int Rank { get; private set; }

    public Human()
    {
        Health = 100f;
        Stamina = 100f;
        Inventory = new Inventory(20, true);
    }
}
