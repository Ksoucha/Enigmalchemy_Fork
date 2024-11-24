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

        yield return new WaitForSeconds(teleportCooldown);

        isTeleporting = false;
    }
}