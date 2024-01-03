using StarterAssets;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryUI;

    [SerializeField] private Transform _itemSlots;
    [SerializeField] private GameObject _slotPrefab;

    [SerializeField] private GameObject _player;
    [SerializeField] private StarterAssetsInputs _inputs;

    private Inventory _inventory;
    private FirstPersonController _controller;

    private void Awake()
    {
        _inventory = _player.GetComponent<Human>().Inventory;
        _controller = _player.GetComponent<FirstPersonController>();
    }

    private void Start()
    {
        _inputs.OnInventoryButtonPressed += OpenInventory;
        _inventory.OnItemAdded += UpdateUIOnItemAdded;
    }

    private void UpdateUIOnItemAdded(IStorable item) => Debug.Log("Added item in inventory");

    private void OpenInventory(bool buttonPressed)
    {
        if (buttonPressed)
        {
            _inventoryUI.SetActive(!_inventoryUI.activeSelf);
            FreezeGame(_inventoryUI.activeSelf);
        }
    }

    // я думаю это тут не должно быть, но ладно
    private void FreezeGame(bool state)
    {
        Time.timeScale = state ? 0f : 1f;
        _controller.enabled = !state;
        Cursor.visible = state;
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
