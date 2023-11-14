using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panelToActivate; // Panel bạn muốn kích hoạt
    public GameObject panelToDeactivate; // Panel bạn muốn tắt

    public void ActivateNewPanel()
    {
        panelToActivate.SetActive(true); // Kích hoạt panel mới
        panelToDeactivate.SetActive(false); // Tắt panel cũ
    }

}
