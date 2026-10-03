using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class MouseInteractable : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AudioSource soundEffect;
    [SerializeField]
    private bool interactionEnabled;

    public UnityEvent InteractionCompleted;

    private bool isDragging;
    private Vector2 mouseStartPosition;
    private new Collider2D collider;
    private new Camera camera;

    void Start()
    {
        camera = Camera.main;
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!interactionEnabled)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            mousePos = camera.ScreenToWorldPoint(mousePos);
            mouseStartPosition = mousePos;

            if (collider.OverlapPoint(mousePos))
                isDragging = true;
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            isDragging = false;
            if (interactionEnabled)
            {
                SetAnimationProgress(0f);
            }
        }

        // if isDragging, handle animation progression
        if (isDragging)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            mousePos = camera.ScreenToWorldPoint(mousePos);
            SetAnimationProgress(UpdateAnimation(mouseStartPosition, mousePos));
        }
    }

    /// <summary>   
    /// Set how far along the animation is.
    /// </summary>
    /// <param name="percentage">Value between 0 and 1.</param>
    protected void SetAnimationProgress(float percentage)
    {
        animator.SetFloat("AnimationProgress", percentage);
        // Could be floating point precision issues in the future?
        // Try Math.isclose()
        if (percentage == 1f)
        {
            OnAnimationCompleted();
        }
    }

    /// <summary>
    /// Is called every frame the mouse is dragging. 
    /// </summary>
    /// <returns>Must return a new animation progress percentage between 0 and 1.</returns>
    protected abstract float UpdateAnimation(Vector2 mouseStartPosition, Vector2 currentMousePosition);

    protected virtual void OnAnimationCompleted()
    {
        isDragging = false;
        interactionEnabled = false;
        InteractionCompleted.Invoke();
        if (soundEffect != null)
            soundEffect.Play();
    }

    public void EnableInteraction() => interactionEnabled = true;
    public void DisableInteraction() => interactionEnabled = false;
}
