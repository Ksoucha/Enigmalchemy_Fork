using UnityEngine;

public class TeleportInteract : IInteractable
{
    public Transform locationTeleport;
    public GameObject targetTeleport;

    public override bool CanInteract(Pickup item)
    {
        return true;
    }

    public override void Interact()
    {
        targetTeleport.transform.position = locationTeleport.transform.position;
    }

    public override void Hover()
    {

    }
}
