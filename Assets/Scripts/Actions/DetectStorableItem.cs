using UnityEngine;

public class DetectStorableItem : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDetectDistance = 1.5f;

    public bool IsStorableItem()
    {
        IStorable storableItem;
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, _maxDetectDistance))
        {
            storableItem = hit.collider.GetComponent<IStorable>();

            return storableItem != null;
        }
        else
        {
            return false;
        }
    }
}
