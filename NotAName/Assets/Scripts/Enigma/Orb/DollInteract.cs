using UnityEngine;

public class DollInteract : MonoBehaviour, IInteractable
{
    public Rolling lastRolling;
    public bool CanInteract(PickupController item)
    {
        return true;
    }

    public void Interact()
    {
        this.gameObject.SetActive(false);
        lastRolling.StartRolling();
    }
}
