using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;


public class PlayerProgressData : MonoBehaviour, ISerializationCallbackReceiver
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

    /// <summary>
    /// Saves dictionary data into the inspector list before serializing
    /// </summary>
    public void OnBeforeSerialize()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        dataList.Clear();
        
        foreach (var kvp in progressDataDict)
        {
            dataList.Add(new ProgressDataTypes { key = kvp.Key, value = kvp.Value });
        }
    }

    /// <summary>
    /// Loads Inspector list data back into the Dictionary immediatly after a change
    /// </summary>
    public void OnAfterDeserialize()
    {
        progressDataDict.Clear();

        for (int i = 0; i <  dataList.Count; i++)
        {
            string key = dataList[i].key;
            bool value = dataList[i].value;

            if (key != null && !progressDataDict.ContainsKey(key))
            {
                progressDataDict.Add(key, value);
            }
        }
    }
}
