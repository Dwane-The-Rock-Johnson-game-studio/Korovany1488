using UnityEngine;

public class ShowPopup : MonoBehaviour
{
    public void ShowText()
    {
        gameObject.SetActive(true);
    }

    public void HideText()
    {
        gameObject.SetActive(false);
    }
}
