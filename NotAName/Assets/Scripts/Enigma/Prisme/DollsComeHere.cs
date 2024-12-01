using UnityEngine;

public class DollsComeHere : MonoBehaviour, IInteractable
{
    public bool CanInteract(PickupController item)
    {
        return true;
    }

    public void Interact()
    {
        this.gameObject.SetActive(false);
    }
}
