using UnityEngine;

public class StorablePopup : MonoBehaviour
{
    [SerializeField] private ShowPopup _showPopup;
    [SerializeField] private InteractStorableItem _interactStorableItem;

    private void FixedUpdate()
    {
        if (_interactStorableItem.IsStorableItem())
        {
            _showPopup.ShowText();
        }
        else
        {
            _showPopup.HideText();
        }
    }   
}
