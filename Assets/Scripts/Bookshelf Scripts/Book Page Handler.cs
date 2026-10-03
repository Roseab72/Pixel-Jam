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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 251; i++)
        {
            if (i != 174)
            {
                GameObject page = pagePrefabs[Random.Range(0, pagePrefabs.Count)];

                book.Add(page);
            }
            else
            {
                book.Add(specialPage);
            }
            
        }

        currentPage = book[0];

        pageNum = 1;

        Instantiate(currentPage, transform.position, Quaternion.identity);
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
        pageNum = int.Parse(playerInput.Trim());

        //Destroy(currentPage);               //How to remove pages without destroying.

        currentPage = book[pageNum - 1];

        Instantiate(currentPage, transform.position, Quaternion.identity);

        if (currentPage == specialPage)
        {
            PlayerProgressData.Instance.UpdateProgress("Special Page Found", true);
        }
    }
}
