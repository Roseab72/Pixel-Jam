using UnityEngine;
using TMPro;

public class Conversion : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField textInput;

    [SerializeField]
    private TMP_Text textOutput;

    private string enteredNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadInputFieldText()
    {
        string playerInput = textInput.text;
        Debug.Log($"User Entered: {playerInput} C");
        CheckText(playerInput);
    }

    private void CheckText(string playerInput)
    {
        float degreeValue;
        float outputValue;

        if (playerInput != null)
        {
            degreeValue = float.Parse(playerInput.Trim());
        }
        else
        {
            degreeValue = 0.0f;
        }

        outputValue = (degreeValue * 1.8f) + 32;

        textOutput.text = $"{outputValue:F1} F";
    }
}
