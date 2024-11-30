using UnityEngine;

public class PortalCameraScript : MonoBehaviour
{
    public Transform linkedPortal; 
    public Camera portalCamera;   
    public Transform cameraRotation;
    public Transform cameraPosY;  

    void Update()
    {
        portalCamera.transform.position = new Vector3(portalCamera.transform.position.x, cameraPosY.position.y, portalCamera.transform.position.z);
    }
    void LateUpdate()
    {
        Quaternion portalRotationDifference = linkedPortal.rotation * Quaternion.Inverse(transform.rotation);
        Quaternion rotationAdjustment = Quaternion.Euler(0, 180f, 0);
        portalCamera.transform.rotation = portalRotationDifference * rotationAdjustment * cameraRotation.rotation;
    }
}
