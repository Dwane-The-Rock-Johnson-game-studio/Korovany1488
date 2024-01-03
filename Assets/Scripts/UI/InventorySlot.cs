using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _sprite;

    private IStorable _item;

    public void AddItem(IStorable item)
    {
        _item = item;
        _sprite.sprite = _item.Sprite;
        _sprite.enabled = true;
    }

    public void ClearSlot()
    {
        _item = null;
        _sprite.sprite = null;
        _sprite.enabled = false;
    }
}
