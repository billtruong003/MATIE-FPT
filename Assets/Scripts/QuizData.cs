using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "NewQuizData", menuName = "Quiz System/Quiz Data", order = 1)]
public class QuizData : ScriptableObject
{
    [SerializeField]
    private TextAsset quizDataTextAsset;
    public List<QuizOption> quizOptions;
    public List<RabbitConfig> performance;
    public QuizOption GetData(int index)
    {
        return quizOptions[index];
    }
    public RabbitConfig GetRabbit(Performance perf)
    {
        foreach (RabbitConfig rabbit in performance)
        {
            if (rabbit.Perf == perf)
            {
                return rabbit;
            }
        }
        return null;
    }
    [Button]
    public void InitializeQuizOptions()
    {
        string[] lines = quizDataTextAsset.text.Split('\n');

        quizOptions = new List<QuizOption>();
        int index = 0;
        QuizOption quizOption = null;

        foreach (string line in lines)
        {
            Debug.Log("Line: " + line);

            if (line.StartsWith($"quizOptions[{index}].question"))
            {
                quizOption = new QuizOption();
                quizOption.question = GetValue(line);
            }
            else if (line.StartsWith($"quizOptions[{index}].optionA"))
            {
                quizOption.optionA = GetValue(line);
            }
            else if (line.StartsWith($"quizOptions[{index}].optionB"))
            {
                quizOption.optionB = GetValue(line);
            }
            else if (line.StartsWith($"quizOptions[{index}].optionC"))
            {
                quizOption.optionC = GetValue(line);
            }
            else if (line.StartsWith($"quizOptions[{index}].optionD"))
            {
                quizOption.optionD = GetValue(line);
            }
            else if (line.StartsWith($"quizOptions[{index}].answer"))
            {
                quizOption.answer = int.Parse(GetValue(line));
                quizOption.QuestionNum = index + 1;
                quizOptions.Add(quizOption);
                index++;
            }
        }
        // Debug statements to check the state of the data
        Debug.Log("Quiz Data Initialization Complete");
        Debug.Log("Number of quiz options: " + quizOptions.Count);
        if (quizOptions.Count > 0)
        {
            Debug.Log("Question of the first quiz option: " + quizOptions[0].GetQuestion());
            Debug.Log("Options of the first quiz option: " + string.Join(", ", quizOptions[0].GetOptions().ToArray()));
            Debug.Log("Correct answer of the first quiz option: " + quizOptions[0].GetAnswer());
        }
    }
    public string GetValue(string info)
    {
        int equalSignIndex = info.IndexOf('=');
        if (equalSignIndex != -1)
        {
            // Lấy toàn bộ giá trị phía sau dấu "="
            string valueAfterEqualSign = info.Substring(equalSignIndex + 1);
            return valueAfterEqualSign;
        }
        else
        {
            Debug.Log("Không tìm thấy dấu '=' trong chuỗi.");
            return "none";
        }
    }
}
[System.Serializable]
public class RabbitConfig
{
    public Performance Perf;
    public string Feedback;
    public Sprite Matie;
}
public enum Performance
{
    GOOD,
    AVERAGE,
    BAD,
}

[System.Serializable]
public class QuizOption
{
    public int QuestionNum;
    [Header("Question")]
    public string question;

    [Header("Options")]
    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;

    [Header("Correct Option Index")]
    [Range(0, 3)]
    public int answer;

    public List<string> GetOptions()
    {
        List<string> options = new List<string>()
        {
            $"A. {optionA}",
            $"B. {optionB}",
            $"C. {optionC}",
            $"D. {optionD}"
        };
        return options;
    }

    public string GetQuestion()
    {
        return $"{QuestionNum}. {question}";
    }

    public int GetAnswer()
    {
        return answer;
    }
}
