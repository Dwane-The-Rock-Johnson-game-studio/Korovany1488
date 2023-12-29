public abstract class Weapon : GameEntity, IStorable
{
    public int Volume { get; protected set; }
    public float Damage { get; protected set; }
}
