using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FliesCollected : MonoBehaviour
{
    private Collider2D objectCollider;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Vector2 mousePosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null && PlayerProgressData.Instance.progressDataDict["Flies Collected"] == true)
        {
            Destroy(gameObject);
        }
    }

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (ctx.canceled)
        {
            //Debug.Log("pressed");
            mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

            if (objectCollider != null && objectCollider.OverlapPoint(mousePosition))
            {
                spriteRenderer.color = Color.yellow;
                PlayerProgressData.Instance.UpdateProgress("Flies Collected", true);
            }

        }

    }
}
