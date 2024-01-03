using StarterAssets;
using UnityEngine;

public class InteractStorableItem : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDetectDistance = 1.5f;
    StarterAssetsInputs _inputs;

    private void Start()
    {
        _inputs = GetComponent<StarterAssetsInputs>();
        _inputs.OnInteractButtonPressed += PickUpStorableItem;
    }

    public bool IsStorableItem()
    {
        return GetStorableItem() != null;
    }

    public IStorable GetStorableItem()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, _maxDetectDistance))
        {
            return hit.collider.GetComponent<IStorable>();
        }
        return null;
    }
    
    public void PickUpStorableItem(bool interactButtonPressed)
    {
        IStorable storableItem = GetStorableItem();
        if (storableItem == null || !interactButtonPressed) return;
        if (GetComponent<Antropomorph>().Inventory.StoreItem(storableItem))
        {
            GameObject storableGameObject = (storableItem as MonoBehaviour).gameObject;
            Destroy(storableGameObject);
        }
    }
}