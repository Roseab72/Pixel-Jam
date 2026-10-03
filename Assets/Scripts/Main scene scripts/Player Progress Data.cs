using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;


public class PlayerProgressData : MonoBehaviour
{
    //Make it so that this script scores all data related to the player's puzzle progress,
    //and that it remains through scene changes
    public static PlayerProgressData Instance {  get; private set; }

    [Serializable]
    public struct ProgressDataTypes
    {
        public string key;
        public bool value;
    }

    //Dictionary of bools marking different points of progress. Fast for look up.
    public Dictionary<string, bool> progressDataDict = new Dictionary<string, bool>();

    //list to edit and see key/values in the inspector
    [SerializeField]
    private List<ProgressDataTypes> dataList;

    //fields for holding progress data
    

    //make sure only one game object with this script ever exists
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //puts list data into the dictionary
        foreach (ProgressDataTypes data in dataList)
        {
            if (!progressDataDict.ContainsKey(data.key))
            {
                progressDataDict.Add(data.key, data.value);
            }
        }
    }

    //void Start()
    //{
    //    progressDataDict.Add("Fridge Unfrozen", false);
    //}

    public void UpdateProgress(string dataKey, bool dataValue)
    {
        if (progressDataDict.ContainsKey(dataKey))
        {
            progressDataDict[dataKey] = dataValue;
        }
        else
        {
            Debug.LogWarning("Dictonary Value does not exist");
        }
    }
}
