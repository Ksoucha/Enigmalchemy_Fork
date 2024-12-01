using UnityEngine;
using UnityEngine.UI;

public class InteractableUIManager : MonoBehaviour
{
    public Camera playerCamera;
    public float interactRange = 5f;
    public RawImage cursorInterract;
    public RawImage cursorClassic;

    private IInteractable currentInteractable;

    private void Update()
    {
        CheckForInteractable();
    }

    private void CheckForInteractable()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                if (currentInteractable != interactable)
                {
                    ShowInteractUI();
                    currentInteractable = interactable;
                }
                return;
            }
        }

        HideInteractUI();
        currentInteractable = null;
    }

    private void ShowInteractUI()
    {
        if (cursorInterract != null && cursorClassic != null)
        {
            cursorInterract.enabled = true;  
            cursorClassic.enabled = false;  
        }
    }

    private void HideInteractUI()
    {
        if (cursorInterract != null && cursorClassic != null)
        {
            cursorInterract.enabled = false; 
            cursorClassic.enabled = true;    
        }
    }
}
