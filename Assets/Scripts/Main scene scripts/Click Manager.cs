using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class ClickManager : MonoBehaviour
{
    [SerializeField]
    private string targetSceneName;

    private Collider2D objectCollider;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Vector2 mousePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        //mousePosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(InputAction.CallbackContext ctx)        //CURRENT GLITCH WHERE TWO LAYERED ZOOM IN SCENES HAVE THE BACK BUTTONS REPEATEDLY TRIGGER AND GO ALL THE WAY BACK TO THE MAIN SCENE
    {
        if (ctx.performed)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

            if (objectCollider.OverlapPoint(mousePosition))
            {
                //mousePosition = Vector2.zero;
                spriteRenderer.color = Color.yellow;
                SceneChange();
            }
            //else
            //{
            //    Debug.LogWarning("Not an object to click");
            //}
        }
        
    }

    private void SceneChange()
    {
        if (string.IsNullOrEmpty(targetSceneName) == false)
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogWarning("Target scene name does not exist");
        }
    }
}
