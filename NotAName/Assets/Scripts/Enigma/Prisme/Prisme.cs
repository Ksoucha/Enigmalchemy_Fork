using UnityEngine;

public class Prisme : ExamineObject
{
    public GameObject interactableObject; 
    public Rolling rolling;
    public LayerMask interactableLayer;   

    public override void StartExamination()
    {
        base.StartExamination();
        transform.position = offset.position;  
    }

    public override void StopExamination()
    {
        base.StopExamination();
    }

    public override void Examine()
    {
        base.Examine();

        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject == interactableObject)
                {
                    Interact(hitObject); 
                }
            }
        }
    }

    public void Interact(GameObject hitObject)
    {
        rolling.StartRolling();
        hitObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public override void NonExamine()
    {
        base.NonExamine();
        Debug.Log("[Prisme] NonExamine - Reset position and rotation for object: " + gameObject.name);
    }
}
