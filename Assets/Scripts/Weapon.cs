public abstract class Weapon : GameEntity, IStorable
{
    public int Volume { get; private set; }
    public float Damage { get; private set; }
}
