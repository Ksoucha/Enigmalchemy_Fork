using UnityEngine;

public class PortalCameraScript : MonoBehaviour
{
    public Transform linkedPortal;
    public Camera portalCamera;
    public Transform cameraRotation;
    public Transform cameraPosY;

    public Transform playerCamera;


    void Update()
    {
        // portalCamera.transform.position = new Vector3(portalCamera.transform.position.x, cameraPosY.position.y, portalCamera.transform.position.z);
    }
    void LateUpdate()
    {
        // Calculate angle from player to self
        Vector3 playerToPortal = transform.position - playerCamera.position;

        // Apply that angle to the other portal
        portalCamera.transform.rotation = Quaternion.LookRotation(playerToPortal, Vector3.up);

        // Set the camera's position in the other portal's space to the player's position in this portal's space
        portalCamera.transform.position = new Vector3(portalCamera.transform.position.x, playerCamera.position.y, portalCamera.transform.position.z);

        // Quaternion portalRotationDifference = linkedPortal.rotation * Quaternion.Inverse(transform.rotation) * Quaternion.Euler(0, 0.5f, 0);
        // Debug.Log(portalRotationDifference);
        // Quaternion rotationAdjustment = Quaternion.Euler(0, 180f, 0);

        // // Set the camera's rotation in the other portal's space to the average of the default rotation and the player rotation
        // portalCamera.transform.rotation = (portalRotationDifference) * rotationAdjustment * cameraRotation.rotation;
        // // portalCamera.transform.rotation = portalRotationDifference * rotationAdjustment * cameraRotation.rotation;
    }
}
