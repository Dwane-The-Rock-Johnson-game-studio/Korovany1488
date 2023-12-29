using UnityEngine;

public class StorablePopup : MonoBehaviour
{
    [SerializeField] private ShowPopup _showPopup;
    [SerializeField] private DetectStorableItem _detectStorableItem;

    private void FixedUpdate()
    {
        if (_detectStorableItem.IsStorableItem())
        {
            _showPopup.ShowText();
        }
        else
        {
            _showPopup.HideText();
        }
    }

    
}
