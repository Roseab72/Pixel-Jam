using UnityEngine;
using TMPro;

public class TempInput : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField tempuratureInput;

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
        string playerInput = tempuratureInput.text;
        Debug.Log($"Tempurature at {playerInput} Degrees F");
    }
}
