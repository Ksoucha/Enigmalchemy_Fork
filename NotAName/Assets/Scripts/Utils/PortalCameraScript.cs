using UnityEngine;

public class PortalCameraScript : MonoBehaviour
{
    public Transform linkedPortal; 
    public Camera portalCamera;   
    public Transform player;  

    void LateUpdate()
    {

        Quaternion portalRotationDifference = linkedPortal.rotation * Quaternion.Inverse(transform.rotation);
        Quaternion rotationAdjustment = Quaternion.Euler(0, 180f, 0);
        portalCamera.transform.rotation = portalRotationDifference * rotationAdjustment * player.rotation;

        portalCamera.transform.position = linkedPortal.position;
    }
}
