using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript2 : MonoBehaviour
{
    public bool isCorrect = false;
    public Quiz quiz;
    public Color startColor;
    public Image imgAnswer;

    public void Start()
    {
        startColor = GetComponent<Image>().color;
    }
    public void SetImg(Sprite sprite)
    {
        imgAnswer = transform.GetChild(0).GetComponent<Image>();
        imgAnswer.sprite = sprite;

    }

    public void Answer()
    {

        GetComponent<Image>().color = startColor;

        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            UnityEngine.Debug.Log("Correct");
            quiz.Correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            UnityEngine.Debug.Log("Wrong");
            quiz.Wrong();
        }
    }
}
