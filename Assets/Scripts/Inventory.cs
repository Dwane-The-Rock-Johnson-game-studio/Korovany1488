using System.Collections.Generic;

public class Inventory : GameEntity
{
    public int MaxCapacity { get; private set; }
    public bool IsInfinity { get; private set; }
    public List<IStorable> ListThings { get; private set; }
    public bool CanEquip { get; private set; }
}
