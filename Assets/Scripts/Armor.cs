public abstract class Armor : GameEntity
{
    public float DamageSuppression {  get; protected set; }
    public float DamageThreshold {  get; protected set; }

    public float SuppressDamage(float damage) 
    { 
        return DamageSuppression * damage; // plug
    }
}
