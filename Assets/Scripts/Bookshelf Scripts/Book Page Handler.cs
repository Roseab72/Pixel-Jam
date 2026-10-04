using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookPageHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject specialPage;

    [SerializeField]
    private List<GameObject> pagePrefabs = new List<GameObject>();

    [SerializeField]
    private List<GameObject> book = new List<GameObject>();

    private GameObject currentPage;

    [SerializeField]
    private TMP_InputField textInput;

    [SerializeField]
    private TMP_Text pageNumberText;

    private int pageNum;

    private List<GameObject> activePrefabs = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < pagePrefabs.Count; i++)
        {
            activePrefabs.Add(Instantiate(pagePrefabs[i]));
            activePrefabs[i].SetActive(false);

        }

        activePrefabs.Add(Instantiate(specialPage));
        activePrefabs[3].SetActive(false);

        for (int i = 0; i < 251; i++)
        {
            if (i != 174)
            {

                book.Add(activePrefabs[Random.Range(0, 3)]);
            }
            else
            {
                book.Add(activePrefabs[3]);
            }

        }

        currentPage = book[0];

        pageNum = 1;

        currentPage.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        pageNumberText.text = $"{pageNum}";
    }

    public void ReadInputFieldText()
    {
        string playerInput = textInput.text;
        Debug.Log($"Current Page: {playerInput}");
        PageChange(playerInput);
    }

    private void PageChange(string playerInput)
    {
        currentPage.SetActive(false);

        pageNum = int.Parse(playerInput.Trim());

        book[pageNum - 1].SetActive(true);

        currentPage = book[pageNum - 1];

        if (currentPage == specialPage)
        {
            PlayerProgressData.Instance.UpdateProgress("Special Page Found", true);
        }
    }
}
