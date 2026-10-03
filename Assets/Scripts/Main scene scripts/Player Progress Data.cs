using UnityEngine;

public class PlayerProgressData : MonoBehaviour
{
    //Make it so that this script scores all data related to the player's puzzle progress,
    //and that it remains through scene changes
    public static PlayerProgressData Instance {  get; private set; }

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
    }
}
