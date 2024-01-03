using UnityEngine;

public class Food : GameEntity, IStorable
{
    [field: SerializeField] public int Volume { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public float HealthBonus { get; private set; }
    [field: SerializeField] public float StaminaBonus { get; private set; }
}
