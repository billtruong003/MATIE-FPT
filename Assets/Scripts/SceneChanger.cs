using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    public string sceneName2;
    public string sceneName3;
    public string sceneName4;
    public string sceneName5;
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ChangeScene2()
    {
        SceneManager.LoadScene(sceneName2);
    }
    public void ChangeScene3()
    {
        SceneManager.LoadScene(sceneName3);
    }
    public void ChangeScene4()
    {
        SceneManager.LoadScene(sceneName4);
    }
    public void ChangeScene5()
    {
        SceneManager.LoadScene(sceneName5);
    }
}
