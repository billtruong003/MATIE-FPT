using UnityEngine;
using UnityEngine.UI;

public class PasswordInput : MonoBehaviour
{
    public InputField passwordInputField;

    void Start()
    {
   
        passwordInputField.contentType = InputField.ContentType.Password;

        passwordInputField.inputType = InputField.InputType.Password;
    }

   
    public void SubmitPassword()
    {
        string enteredPassword = passwordInputField.text;
        Debug.Log("Entered Password: " + enteredPassword);
       
    }
}
