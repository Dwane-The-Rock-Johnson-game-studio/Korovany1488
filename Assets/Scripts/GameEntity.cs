using UnityEngine;

public abstract class GameEntity : MonoBehaviour
{
    public int TypeId { get; protected set; }
    public int UniqueId { get; protected set; }
    public string Name { get; protected set; }
}
