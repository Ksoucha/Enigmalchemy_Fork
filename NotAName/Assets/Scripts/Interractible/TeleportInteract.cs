using UnityEngine;

public class TeleportInteract : MonoBehaviour, IInteractable
{
    public Transform locationTeleport;
    public GameObject targetTeleport;

    public bool CanInteract(PickupController item)
    {
        return true;
    }

    public void Interact()
    {
        targetTeleport.transform.position = locationTeleport.transform.position;
    }

    public void Hover()
    {

    }
}
