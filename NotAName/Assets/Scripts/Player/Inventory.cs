using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Inventory : MonoBehaviour
{
    [Header("Inventory Settings")]
    public static int itemSlot = 7;
    public Pickup[] pickedUpItems;
    public Camera playerCamera;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode pickKey = KeyCode.E;
    public float interactRange = 5f;
    public float pickupRange = 3f;

    private IInteractable currentHoverItem;

    private void Awake()
    {
        pickedUpItems = new Pickup[itemSlot];
    }

    private void FixedUpdate()
    {
        // by merging pickup and interacable together, we don't need to do 2 raycast
        // to do similar action
        HandleInteraction();
    }

    private void HandleInteraction()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            Pickup pickup = hit.collider.GetComponent<Pickup>();

            if (UserInput.Instance.InteractInput)
            {
                if (pickup != null)
                {
                    Debug.Log("Attempt to Pick Up!" + Vector3.Distance(pickup.transform.position, playerCamera.transform.position));
                }

                if (interactable != null)
                {
                    AttemptInteraction(interactable);
                }
                // Since the original game has two different range for pick up and interact, we simply just check the distance
                // after doing the raycast
                else if (pickup != null && Vector3.Distance(pickup.transform.position, playerCamera.transform.position) <= pickupRange)
                {
                    Debug.Log("Pick Up!");
                    PickUp(pickup);
                }    
            }
            else if (interactable != null && currentHoverItem == null)
            {
                currentHoverItem = interactable;
                // if the book, is not hovering, we toggle the hover
                if (!currentHoverItem.isHovering)
                {
                    currentHoverItem.Hover();
                }
            }

            if (interactable == null && currentHoverItem != null)
            {
                if (currentHoverItem.isHovering)
                {
                    currentHoverItem.Hover();
                    currentHoverItem = null;
                }
            }
        }
    }

    public void AddItem(Pickup item)
    {
        for (int i = 0; i < itemSlot; i++)
        {
            if (pickedUpItems[i] == null)
            {
                pickedUpItems[i] = item;
                Debug.Log($"Added : {item.name}");
                break;
            }
        }
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

    // by moving pick up logic to inventory, only player inventory need to contain the code
    // and not the item itself
    // it will save up performance and space
    private void PickUp(Pickup item)
    {
        AddItem(item);
        item.gameObject.SetActive(false);
    }
}