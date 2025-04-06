using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private InteractableObjects currentInteractable;

    public bool CanInteract = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<InteractableObjects>())
        {
            currentInteractable = other.GetComponent<InteractableObjects>();
            Debug.Log("Press E to interact");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<InteractableObjects>())
        {
            currentInteractable = null;
        }
    }

    void Update()
    {
        if (CanInteract && currentInteractable != null && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))) // Press "E" to interact
        {
            currentInteractable.Interact();
        }
    }
}
