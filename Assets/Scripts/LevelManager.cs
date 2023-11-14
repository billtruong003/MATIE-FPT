using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] objectsToReset; // G?n các ??i t??ng c?n ??t l?i tr?ng thái ban ??u vào ?ây

    public void ResetLevel()
    {
        foreach (var obj in objectsToReset)
        {
            obj.SendMessage("ResetToInitialState", SendMessageOptions.DontRequireReceiver);
        }
    }
}
