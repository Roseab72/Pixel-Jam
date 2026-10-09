using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PianoManager : MonoBehaviour
{
    [SerializeField]
    private List<string> pianoCode = new List<string>();

    [SerializeField]
    private string code;

    private int lengthOfCode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lengthOfCode = code.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (pianoCode.Count == lengthOfCode)
        {
            CheckPianoCode();
        }   
    }

    public void AddLetter(string letter)
    {
        pianoCode.Add(letter);
    }

    private void CheckPianoCode()
    {
        string inputCode = "";

        for (int i = 0; i < pianoCode.Count; i++)
        {
            inputCode += pianoCode[i];
        }

        if (inputCode == code)
        {
            PlayerProgressData.Instance.UpdateProgress("Piano Code Success", true);
        }
        else
        {
            pianoCode.Clear();
        }
    }
}
