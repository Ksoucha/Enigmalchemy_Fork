using Unity.VisualScripting;
using UnityEngine;

public class Book : IInteractable
{
    [SerializeField] private GameObject page;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject onHover;
    [SerializeField] private GameObject[] toDisable;

    [SerializeField] private LayerMask interactible = -1;

    private void Update()
    {
    }

    public override void Hover()
    {
        if (onHover != null)
        {
            isHovering = !isHovering;
            onHover.SetActive(isHovering);
        }
    }

    public override bool CanInteract(Pickup item)
    {
        return true;
    }

    public override void Interact()
    {
        isInteracting = !isInteracting;
        foreach (GameObject obj in toDisable)
        {
            obj.SetActive(false);
        }

        canvas.SetActive(isInteracting);
        page.SetActive(isInteracting);
    }
}
