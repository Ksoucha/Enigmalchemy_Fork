using System.Collections;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform linkedPortal; 
    public float teleportCooldown = 1f;  
    public float safeDistance = 2f;  
    private bool isTeleporting = false;  

    private void OnTriggerEnter(Collider other)
    {
        if (isTeleporting || !other.CompareTag("Player")) return;

        StartCoroutine(Teleport(other.transform));
    }

    private IEnumerator Teleport(Transform obj)
    {
        isTeleporting = true;

        Vector3 relativePosition = transform.InverseTransformPoint(obj.position);
        Vector3 newPosition = linkedPortal.TransformPoint(relativePosition);

        Vector3 portalDirection = (linkedPortal.position - transform.position).normalized; 
        newPosition += portalDirection * safeDistance;

        Quaternion relativeRotation = Quaternion.Inverse(transform.rotation) * obj.rotation;
        Quaternion newRotation = linkedPortal.rotation * relativeRotation;

        obj.position = newPosition;
        obj.rotation = newRotation;

        foreach (Transform child in obj)
        {
            Vector3 childRelativePosition = transform.InverseTransformPoint(child.position);
            Vector3 childNewPosition = linkedPortal.TransformPoint(childRelativePosition);
            childNewPosition += portalDirection * safeDistance;  

            Quaternion childRelativeRotation = Quaternion.Inverse(transform.rotation) * child.rotation;
            Quaternion childNewRotation = linkedPortal.rotation * childRelativeRotation;

            child.position = childNewPosition;
            child.rotation = childNewRotation;
        }

        yield return new WaitForSeconds(teleportCooldown);

        isTeleporting = false;
    }
}