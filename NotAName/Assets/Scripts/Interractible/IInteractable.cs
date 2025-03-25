using UnityEngine;

public abstract class IInteractable : MonoBehaviour 
{
    public abstract bool CanInteract(Pickup item);
    public abstract void Interact();
    public abstract void Hover();

    protected bool isInteracting = false;
    public bool isHovering = false;
}