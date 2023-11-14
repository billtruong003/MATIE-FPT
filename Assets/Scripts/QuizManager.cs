using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAns> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject Quizpanel;
    public GameObject GoPanel;
    public Text ScoreTxt;
    int totalQuestions = 0;
    public int score;
    public Image QuestionImage;
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
            AnswerScript answerScript = options[i].GetComponent<AnswerScript>();
            Image optionImage = options[i].GetComponent<Image>();

            optionImage.color = answerScript.startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Image>().sprite = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionImage.sprite = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Chúc mừng bạn đã xong chương trình");
            GameOver();
        }
    }
}
