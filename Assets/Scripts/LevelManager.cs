using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] objectsToReset; // G?n c�c ??i t??ng c?n ??t l?i tr?ng th�i ban ??u v�o ?�y

    public void ResetLevel()
    {
        foreach (var obj in objectsToReset)
        {
            obj.SendMessage("ResetToInitialState", SendMessageOptions.DontRequireReceiver);
        }
    }
}
