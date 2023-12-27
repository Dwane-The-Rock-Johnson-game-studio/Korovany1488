using UnityEngine;

public abstract class GameEntity : MonoBehaviour
{
    public int TypeId { get; private set; }
    public int UniqueId { get; private set; }
    public string Name { get; private set; }
}
