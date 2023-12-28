public abstract class Antropomorph : Alive
{
    public Helmet Helmet { get; set; }      
    public Body Body { get; set; }
    public Pants Pants { get; set; }
    public Shoes Shoes { get; set; }
    public Weapon RightHand { get; set; }
    public Weapon LeftHand { get; set; }
    public Inventory Inventory { get; set; }

    public void Eat(Food food)
    {

    }

}
