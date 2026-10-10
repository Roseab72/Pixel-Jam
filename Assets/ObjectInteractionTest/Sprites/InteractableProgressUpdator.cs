using UnityEngine;

/// <summary>
/// Listens for a completed interaction and updates a progress data value.
/// </summary>
public class InteractableProgressUpdator : MonoBehaviour
{
    /// <summary>
    /// The interactable component that triggers the update.
    /// </summary>
    [SerializeField]
    MouseInteractable interactableComponent;
    /// <summary>
    /// The id of the progress data value to be updated when the interaction is completed.
    /// </summary>
    [SerializeField]
    string progressDataID;
    /// <summary>
    /// The new value of the progress data once the interaction is completed. True or false.
    /// </summary>
    [SerializeField]
    bool updatedValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (interactableComponent == null)
        {
            Debug.LogWarning("Interactable Progress Updator 'interactable component' is not set.");
            return;
        }

        interactableComponent.InteractionCompleted.AddListener(
            () => PlayerProgressData.Instance.UpdateProgress(progressDataID, updatedValue));
    }
}
