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
        if (PlayerProgressData.Instance.progressDataDict["Fridge Unfrozen"] == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    public void ReadInputFieldText()
    {
        string playerInput = tempuratureInput.text;
        Debug.Log($"Tempurature at {playerInput} Degrees F");
        CheckTemp(playerInput);
    }

    private void CheckTemp(string playerInput)
    {
        float degreeValue;

        if (playerInput != null)
        {
            degreeValue = float.Parse(playerInput.Trim());
        }
        else
        {
            degreeValue=0.0f;
        }


        if (degreeValue == 35.7f)
        {
            PlayerProgressData.Instance.UpdateProgress("Fridge Unfrozen", true);
        }
    }
}
