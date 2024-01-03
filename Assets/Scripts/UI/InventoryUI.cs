using StarterAssets;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private GameObject _itemSlotsParent;

    private StarterAssetsInputs _inputs;
    private Inventory _inventory;
    private InventorySlot[] _slots;
    private FirstPersonController _controller;

    private void Awake()
    {
        _inventory = _player.GetComponent<Human>().Inventory;
        _inputs = _player.GetComponent<StarterAssetsInputs>();
        _controller = _player.GetComponent<FirstPersonController>();
    }

    private void Start()
    {
        _inputs.OnInventoryButtonPressed += OpenInventory;
        _inventory.OnItemAdded += UpdateUIOnItemAdded;

        _slots = _itemSlotsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void UpdateUIOnItemAdded(IStorable item) => FillItemSlots();

    private void FillItemSlots()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i < _inventory.ListThings.Count)
            {
                _slots[i].AddItem(_inventory.ListThings[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }

    private void OpenInventory(bool buttonPressed)
    {
        if (buttonPressed)
        {
            _inventoryUI.SetActive(!_inventoryUI.activeSelf);
            FreezeGame(_inventoryUI.activeSelf);
        }
    }

    public void FreezeGame(bool state)
    {
        Time.timeScale = state ? 0f : 1f;
        _controller.enabled = !state;
        Cursor.visible = state;
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
