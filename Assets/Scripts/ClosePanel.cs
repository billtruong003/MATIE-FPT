using UnityEngine;
using UnityEngine.UI;

public class ClosePanel : MonoBehaviour
{
    public GameObject panelToClose;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mousePosition = Input.mousePosition;
            RectTransform panelRect = panelToClose.GetComponent<RectTransform>();

            if (!RectTransformUtility.RectangleContainsScreenPoint(panelRect, mousePosition))
            {

                panelToClose.SetActive(false);

            }
        }
    }
    public void TriggerPremium()
    {
        PlayerPrefs.SetString("premium", "open");
    }
}
