public abstract class Armor : GameEntity
{
    public float DamageSuppression {  get; private set; }
    public float DamageThreshold {  get; private set; }

    public float SuppressDamage(float damage) 
    { 
        return DamageSuppression * damage; // plug
    }
}
