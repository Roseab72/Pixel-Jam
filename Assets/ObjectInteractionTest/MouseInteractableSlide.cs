using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInteractableSlide : MouseInteractable
{
    [SerializeField, Tooltip("The starting direction this object can slide in.")]
    private Vector2 direction;
    [SerializeField, Tooltip("The distance in pixels this object can slide.")]
    private float distancePixels;
    private float distance;

    private void Awake()
    {
        // 1/64. Currently hardcoded. Not sure how to make a global setting for this in Unity.
        float unitsPerPixel = 0.015625f;
        distance = distancePixels * unitsPerPixel;
        direction.Normalize();
    }

    protected override float UpdateAnimation(Vector2 mouseStartPosition, Vector2 currentMousePosition)
    {
        Vector2 v = direction * distance;
        Vector2 w = currentMousePosition - mouseStartPosition;

        // ||p|| = (v dot w)/||v|| to get the length p from orthogonal projection
        float currentDistance = Vector2.Dot(v, w) / v.magnitude;

        currentDistance = Mathf.Clamp(currentDistance, 0, distance);
        float animationProgress = Mathf.InverseLerp(0, distance, currentDistance);

        return animationProgress;
    }

    // private void OnDrawGizmosSelected()
    private void OnDrawGizmos()
    {
        // Change color to differentiate selection
        Gizmos.color = Color.magenta;
        
        // Draw a wireframe box around the object
        // Gizmos.DrawWireCube(transform.position, boxSize);
        Gizmos.DrawRay(transform.position, direction * distance * 10);
        // Gizmos.DrawCube(transform.position, Vector2.one);
    }
}