using UnityEngine;

public class NeedItemToInteract : MonoBehaviour, IInteractable
{
    [Header("Required Item")]
    public PickupController requiredItem;
    public bool CanInteract(PickupController item)
    {
        return item == requiredItem;
    }

    public void Interact()
    {
        Debug.Log($"{gameObject.name} activé !");
        gameObject.SetActive(false);
    }
}