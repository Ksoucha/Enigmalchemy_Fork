using Unity.VisualScripting;
using UnityEngine;

public class Book : IInteractable
{
    [SerializeField] private GameObject page;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject onHover;
    [SerializeField] private GameObject[] toDisable;

    [SerializeField] private LayerMask interactible = -1;

    // we don't need to do it every frame for hovering
    private void Update()
    {
        //if (onHover != null)
        //{
        //    if (onHover.activeSelf != hover)
        //        onHover.SetActive(hover);
        //}
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
