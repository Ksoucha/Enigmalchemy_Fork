using Unity.VisualScripting;
using UnityEngine;

public class Book : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject page;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject onHover;
    [SerializeField] private GameObject[] toDisable;

    [SerializeField] private LayerMask interactible = -1;

    private bool hover = false;
    private void Update()
    {
        if (onHover != null)
        {
            if (hover == false)
                onHover.SetActive(false);
            else
                hover = false;
        }
    }

    public void Hover()
    {
        onHover.SetActive(true);
        hover = true;
    }

    public bool CanInteract(PickupController item)
    {
        return true;
    }

    public void Interact()
    {
        foreach (GameObject obj in toDisable)
        {
            obj.SetActive(false);
        }
        canvas.SetActive(true);
        page.SetActive(true);
    }
}
