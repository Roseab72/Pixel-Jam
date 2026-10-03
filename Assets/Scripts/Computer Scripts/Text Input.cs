using UnityEngine;
using TMPro;

public class TextInput : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField textInput;

    [SerializeField]
    private TMP_Text textPrompt;

    private string enteredPassword;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerProgressData.Instance.progressDataDict["Password Entered"] == true)
        {
            textPrompt.text = "Password Accepted";
        }
    }

    public void ReadInputFieldText()
    {
        string playerInput = textInput.text;
        Debug.Log($"User Entered: {playerInput}");
        CheckText(playerInput);
    }

    private void CheckText(string playerInput)
    {
        enteredPassword = playerInput.Trim().ToLower();

        if (enteredPassword == "password")
        {
            PlayerProgressData.Instance.UpdateProgress("Password Entered", true);
            textInput.text = "";
        }
        else
        {
            textInput.text = "";
        }
    }
}
