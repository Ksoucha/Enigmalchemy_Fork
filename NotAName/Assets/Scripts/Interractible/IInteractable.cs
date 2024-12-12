using UnityEngine;

public interface IInteractable
{
    bool CanInteract(PickupController item);
    void Interact();

    void Hover();
}