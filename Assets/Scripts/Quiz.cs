using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    public Color startColor;
    public List<QuestionAn> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject Quizpanel;
    public GameObject GoPanel;
    public Text ScoreTxt;
    int totalQuestions = 0;
    public int score;
    public Text QuestionTxt;
    public Text HighScoreTxt;
    private int highScore = 0;
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreTxt.text = "High Score: " + highScore;
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
    public void Correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());

    }

    public void Wrong()
    {
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());

    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            AnswerScript2 answerScript2 = options[i].GetComponent<AnswerScript2>();
            Image optionImage = options[i].GetComponent<Image>();

            optionImage.color = answerScript2.startColor;
            answerScript2.isCorrect = false;
            answerScript2.SetImg(QnA[currentQuestion].Answers[i]);

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                answerScript2.isCorrect = true;
            }
        }
    }


    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Chuc mung ban da xong chuong trinh");
            GameOver();
        }
    }
}