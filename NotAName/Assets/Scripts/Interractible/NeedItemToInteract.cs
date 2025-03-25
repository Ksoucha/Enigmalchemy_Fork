using UnityEngine;

public class NeedItemToInteract : IInteractable
{
    [Header("Required Item")]
    public Pickup requiredItem;
    public override bool CanInteract(Pickup item)
    {
        Debug.Log(item);
        return item == requiredItem;
    }

    public override void Interact()
    {
        Debug.Log($"{gameObject.name} activé !");
        gameObject.SetActive(false);
    }

    public override void Hover()
    {

    }
}