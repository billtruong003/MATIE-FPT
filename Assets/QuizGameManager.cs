using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizGameManager : MonoBehaviour
{
    [SerializeField] private QuizData quizConfig;

    [Header("UI GamePlay")]
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private TextMeshProUGUI optionA;
    [SerializeField] private TextMeshProUGUI optionB;
    [SerializeField] private TextMeshProUGUI optionC;
    [SerializeField] private TextMeshProUGUI optionD;

    [Header("Game Over Panel")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Image rabbitImage;
    [SerializeField] private Button nextLevelBtn;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI feedback;

    [Header("Data & Color Feedback Flow")]
    [SerializeField] private Color inCorrectCol;
    [SerializeField] private Color correctCol;
    [SerializeField] private Color normTextCol;
    [SerializeField] private int currentAns;
    [SerializeField] private bool picked = false;
    [SerializeField] private int currentPick;
    [SerializeField] private int correctCount = 0;
    [SerializeField] private int WaitTime;
    [SerializeField] private RabbitConfig rabConfig;
    private QuizOption currentQuestion;
    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        InitData();
    }
    private void InitData()
    {
        SetInteractableTrue();
        ResetUI();
        currentQuestion = quizConfig.GetData(currentIndex);
        question.text = currentQuestion.GetQuestion();
        List<string> options = currentQuestion.GetOptions();
        optionA.text = options[0];
        optionB.text = options[1];
        optionC.text = options[2];
        optionD.text = options[3];
        currentAns = currentQuestion.GetAnswer();

    }
    public void checkAns(int i)
    {
        if (picked)
            return;
        currentPick = i;
        if (i == currentAns)
        {
            correctCount++;
            GetButtonIMG(i).color = correctCol;
            StartCoroutine(Cor_CheckAns());
        }
        else
        {
            GetButtonIMG(i).color = inCorrectCol;
            StartCoroutine(Cor_CheckAns());
        }
    }
    public void ResetUI()
    {
        for (int i = 0; i < 4; i++)
        {
            GetButtonReset(i);
        }
    }
    public void SetInteractableFalse()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == currentPick)
                continue;
            GetButton(i).interactable = false;
        }
    }
    public void SetInteractableTrue()
    {
        for (int i = 0; i < 4; i++)
        {
            GetButton(i).interactable = true;
        }
    }
    private Image GetButtonIMG(int i)
    {
        switch (i)
        {
            case 0:
                optionA.color = Color.white;
                return optionA.GetComponentInParent<Image>();
            case 1:
                optionB.color = Color.white;
                return optionB.GetComponentInParent<Image>();
            case 2:
                optionC.color = Color.white;
                return optionC.GetComponentInParent<Image>();
            case 3:
                optionD.color = Color.white;
                return optionD.GetComponentInParent<Image>();
            default:
                return null;
        }
    }
    private Button GetButton(int i)
    {
        switch (i)
        {
            case 0:
                return optionA.GetComponentInParent<Button>();
            case 1:
                return optionB.GetComponentInParent<Button>();
            case 2:
                return optionC.GetComponentInParent<Button>();
            case 3:
                return optionD.GetComponentInParent<Button>();
            default:
                return null;
        }
    }
    private void GetButtonReset(int i)
    {
        switch (i)
        {
            case 0:
                optionA.color = normTextCol;
                optionA.GetComponentInParent<Image>().color = Color.white;
                break;
            case 1:
                optionB.color = normTextCol;
                optionB.GetComponentInParent<Image>().color = Color.white;
                break;
            case 2:
                optionC.color = normTextCol;
                optionC.GetComponentInParent<Image>().color = Color.white;
                break;
            case 3:
                optionD.color = normTextCol;
                optionD.GetComponentInParent<Image>().color = Color.white;
                break;
            default:
                break;
        }
    }
    private void CheckPerf(int CorrectCount)
    {
        if (CorrectCount >= 8)
        {
            rabConfig = quizConfig.GetRabbit(Performance.GOOD);
        }
        else if (CorrectCount < 8 && CorrectCount > 5)
        {
            rabConfig = quizConfig.GetRabbit(Performance.AVERAGE);
        }
        else
        {
            rabConfig = quizConfig.GetRabbit(Performance.BAD);
        }
    }
    private IEnumerator Cor_CheckAns()
    {
        SetInteractableFalse();
        picked = true;
        currentIndex++;
        yield return new WaitForSeconds(WaitTime);
        if (currentIndex >= quizConfig.quizOptions.Count)
        {
            CheckPerf(correctCount);
            TriggerGameOverPanel();
        }
        picked = false;
        InitData();
    }
    public void TriggerGameOverPanel()
    {
        score.text = $"Score: {correctCount}";
        feedback.text = rabConfig.Feedback;
        rabbitImage.sprite = rabConfig.Matie;
        gameOverPanel.SetActive(true);
    }
    public void BackToDashBoard()
    {
        SceneManager.LoadScene("DashBoard");
    }
}
