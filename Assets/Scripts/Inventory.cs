using System.Collections.Generic;
using System.Linq;

public class Inventory : GameEntity
{
    public int MaxCapacity { get; private set; }
    public int CurrentCapacity => ListThings.Sum(t => t.Volume);
    public bool IsInfinity { get; private set; }
    public List<IStorable> ListThings { get; private set; }
    public bool CanEquip { get; private set; }

    public Inventory(int maxCapacity, bool canEquip, bool isInfinity = false)
    {
        MaxCapacity = maxCapacity;
        CanEquip = canEquip;
        IsInfinity = isInfinity;
        ListThings = new List<IStorable>();
    }

    public bool StoreItem(IStorable storableItem)
    {
        if (!IsInfinity && CurrentCapacity + storableItem.Volume > MaxCapacity) return false;
        ListThings.Add(storableItem);
        return true;
    }
}
