using UnityEngine;

public class Temptestscript : MonoBehaviour
{
    [SerializeField]
    private GameObject unfrozenObjects;

    [SerializeField]
    private GameObject openFridge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerProgressData.Instance.progressDataDict["Fridge Unfrozen"] == true && openFridge.activeSelf == false)
        {
            gameObject.SetActive(false);
            unfrozenObjects.SetActive(true);
        }
    }
}
