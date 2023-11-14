using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PremiumCheck : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string premiumScene;
    void Start()
    {
        string premium = PlayerPrefs.GetString("premium", "");
        if (!string.IsNullOrEmpty(premium))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void LoadScenePremium()
    {
        SceneManager.LoadScene(premiumScene);
    }
}
