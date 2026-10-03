using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInteractableRotate : MouseInteractable
{
    [SerializeField, Tooltip("The starting direction of the rotating object.")]
    private Vector2 direction;

    [SerializeField, Tooltip("Final angle in degrees from the starting direction.")]
    private float angle;

    private Vector2 finalDirection;

    private void Awake()
    {
        finalDirection = Quaternion.AngleAxis(angle, Vector3.forward) * direction;
    }

    protected override float UpdateAnimation(Vector2 mouseStartPosition, Vector2 currentMousePosition)
    {
        // from origin to mouse
        Vector2 currentMouseDirectionVector = currentMousePosition - (Vector2)transform.position;
        // from origin to starting mouse position
        Vector2 mouseStartDirectionVector = mouseStartPosition - (Vector2)transform.position;

        float directionAngle = Vector2.Angle(direction, Vector2.right);
        float currentAngle = directionAngle - Vector2.SignedAngle(currentMouseDirectionVector, mouseStartDirectionVector);

        float finalAngle = directionAngle + angle;

        currentAngle = Mathf.Clamp(currentAngle, finalAngle, directionAngle);
        float animationProgress = Mathf.InverseLerp(directionAngle, finalAngle, currentAngle);

        return animationProgress;
    }

    // private void OnDrawGizmosSelected()
    // {
    //     // Change color to differentiate selection
    //     Gizmos.color = Color.yellow;

    //     // Draw a wireframe box around the object
    //     Gizmos.DrawWireCube(transform.position, boxSize);
    // }
}
