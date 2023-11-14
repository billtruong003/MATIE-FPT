using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Color startColor;

    public void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
       
        GetComponent<Image>().color = startColor;

        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            UnityEngine.Debug.Log("Correct");
            quizManager.Correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            UnityEngine.Debug.Log("Wrong");
            quizManager.Wrong();
        }
    }
}
