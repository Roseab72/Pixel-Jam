using UnityEngine;

public class CodeCompleteManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pianoOpen;

    [SerializeField]
    private GameObject crowbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerProgressData.Instance.progressDataDict["Piano Code Success"] == true)
        {
            pianoOpen.SetActive(true);
            crowbar.SetActive(true);
            gameObject.SetActive(false);
            
        }
    }
}
