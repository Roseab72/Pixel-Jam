using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class ClickManager : MonoBehaviour
{
    [SerializeField]
    private string targetSceneName;

    private Collider2D objectCollider;

    private Vector2 mousePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            
        }
        
    }

    private void SceneChange()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogWarning("Target scene name does not exist");
        }
    }
}
