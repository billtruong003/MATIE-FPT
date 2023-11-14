using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonMenu : MonoBehaviour
{
    public void OpenLesson(int lessonId)
    {
        string lessonName = "Lesson" + lessonId;
        SceneManager.LoadScene(lessonName);
    }
}
