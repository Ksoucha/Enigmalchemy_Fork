using UnityEngine;

public class Book : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject page;
    [SerializeField] private GameObject canvas;



    public bool CanInteract(PickupController item)
    {
        return true;
    }

    public void Interact()
    {
        canvas.SetActive(true);
        page.SetActive(true);
    }
}
