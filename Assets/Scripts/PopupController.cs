using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public Text successText;

    public void ShowSuccessPopup()
    {
        successText.gameObject.SetActive(true);
  
        Invoke("HideSuccessPopup", 2.0f);
    }

    public void HideSuccessPopup()
    {
        successText.gameObject.SetActive(false);
    }
}
