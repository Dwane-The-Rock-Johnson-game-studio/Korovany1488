public class Food : GameEntity, IStorable
{
    public int Volume { get; private set; }
    public float HealthBonus { get; private set; }
    public float StaminaBonus { get; private set; }
}
