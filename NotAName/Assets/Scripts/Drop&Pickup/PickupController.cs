using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour
{
    [Header("References")]
    public Inventory inventory;
    private void PickUp()
    {
        inventory.AddItem(this);
        gameObject.SetActive(false);
    }

    public void AttemptPickup(Camera playerCamera, float pickupRange)
    {
        if (UserInput.Instance.InteractInput)
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, pickupRange))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    PickUp();
                }
            }
        }
    }
}