using UnityEngine;

public class PianoButtonScript : MonoBehaviour
{
    [SerializeField]
    private string keyLetter;

    [SerializeField]
    private PianoManager pianoScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        pianoScript.AddLetter(keyLetter);
    }
}
