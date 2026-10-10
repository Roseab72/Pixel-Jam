using UnityEditor.PackageManager;
using UnityEngine;

public class Flytrap : MonoBehaviour
{
    [SerializeField]
    string meatExistsDataName;

    [SerializeField]
    Sprite meatExistsSprite;

    void Start()
    {
        // If meat has been collected from fridge, show it and enable drag interaction
        if (PlayerProgressData.Instance.progressDataDict[meatExistsDataName])
        {
            GetComponent<MouseInteractableSlide>().EnableInteraction();
            if (meatExistsSprite == null)
                Debug.LogError("Flytrap missing meat sprite.");
            GetComponent<SpriteRenderer>().sprite = meatExistsSprite;
            GetComponent<Animator>().SetTrigger("MeatExists");
        }
    }
}
