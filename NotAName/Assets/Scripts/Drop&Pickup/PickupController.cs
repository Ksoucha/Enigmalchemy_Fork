using UnityEngine;

public class PickupController : MonoBehaviour
{
    [Header("Scripts and Objects reference")]
    public Transform player;
    public NeedItemToInteract objectToInterract; 
    public Inventory inventory;                
    public KeyCode pickKey = KeyCode.E;        
    public float pickUpRange = 3f;              
    public float interactRange = 5f;           

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= pickUpRange && Input.GetKeyDown(pickKey))
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        inventory.AddItem(this);

        gameObject.SetActive(false);
    }

    public void InteractWithObject()
    {
        float distanceToObject = Vector3.Distance(player.position, objectToInterract.transform.position);
        if (distanceToObject <= interactRange)
        {
            objectToInterract.Interact();
        }
    }
}