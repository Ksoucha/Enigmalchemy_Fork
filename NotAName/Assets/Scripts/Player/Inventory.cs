using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Inventory Settings")]
    public List<PickupController> pickedUpItems = new List<PickupController>();
    public Camera playerCamera;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode pickKey = KeyCode.E;
    public float interactRange = 5f;
    public float pickupRange = 3f;

    private void Update()
    {
        HandlePickup();
        HandleInteraction();
    }

    private void HandlePickup()
    {
        foreach (var pickup in FindObjectsOfType<PickupController>())
        {
            pickup.AttemptPickup(playerCamera, pickupRange);
        }
    }

    private void HandleInteraction()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (UserInput.Instance.InteractInput)
            {
                if (interactable != null)
                {
                    AttemptInteraction(interactable);
                }
            }
            else if (interactable != null)
            {
                interactable.Hover();
            }
        }
    }

    public void AddItem(PickupController item)
    {
        pickedUpItems.Add(item);
        Debug.Log($"Added : {item.name}");
    }

    private void AttemptInteraction(IInteractable interactable)
    {
        foreach (var item in pickedUpItems)
        {
            if (interactable.CanInteract(item))
            {
                interactable.Interact();
            }
        }

    }
}