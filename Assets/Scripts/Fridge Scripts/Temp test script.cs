using UnityEngine;

public class Temptestscript : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerProgressData.Instance.progressDataDict["Fridge Unfrozen"] == true)
        {
            spriteRenderer.color = Color.yellow;
        }
    }
}
