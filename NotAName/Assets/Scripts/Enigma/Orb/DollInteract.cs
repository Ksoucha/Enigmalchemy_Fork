using UnityEngine;

public class DollInteract : IInteractable
{
    public Rolling lastRolling;
    public override bool CanInteract(Pickup item)
    {
        return true;
    }

    public override void Interact()
    {
        this.gameObject.SetActive(false);
        lastRolling.StartRolling();
    }

    public override void Hover()
    {

    }
}
