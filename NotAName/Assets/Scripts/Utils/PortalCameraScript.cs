using UnityEditor;
using UnityEngine;

public class PortalCameraScript : MonoBehaviour
{
    public Transform linkedPortal;
    public Camera portalCamera;
    public Transform cameraRotation;
    public Transform cameraPosY;

    public Transform playerCamera;

    [SerializeField] private Vector3 area;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool drawGizmos;

    void LateUpdate()
    {
        if (linkedPortal == null) return;

        // if (drawGizmos)
        // {
        //     // Debug.Log("Player Camera: " + playerCamera.position);
        //     // Debug.Log("Area X: (" + (-area.x + offset.x + transform.position.x) + ", " + (area.x + offset.x + transform.position.x) + ")");
        //     // Debug.Log("Area Y: (" + (-area.y + offset.y + transform.position.y) + ", " + (area.y + offset.y + transform.position.y) + ")");
        //     // Debug.Log("Area Z: (" + (-area.z + offset.z + transform.position.z) + ", " + (area.z + offset.z + transform.position.z) + ")");
        // }

        // Vector3 playerToPortal = transform.position - playerCamera.position;
        // portalCamera.transform.rotation = Quaternion.LookRotation(playerToPortal, Vector3.up);
        // portalCamera.transform.position = new Vector3(portalCamera.transform.position.x, playerCamera.position.y, portalCamera.transform.position.z);

        if (playerCamera.position.y > (transform.position.y - area.y / 2) + offset.y && playerCamera.position.y < (transform.position.y + area.y / 2) + offset.y)
        {
            // Debug.Log("In Y : " + (playerCamera.position.x > ((transform.position.x - area.x / 2) + offset.x)) + " " + (playerCamera.position.x < ((transform.position.x + area.x / 2) + offset.x)));
            if (playerCamera.position.x > (transform.position.x - area.x / 2) + offset.x && playerCamera.position.x < (transform.position.x + area.x / 2) + offset.x)
            {
                // Debug.Log("In X");
                if (playerCamera.position.z > (transform.position.z - area.z / 2) + offset.z && playerCamera.position.z < (transform.position.z + area.z / 2) + offset.z)
                {
                    // Debug.Log("In Z");
                    portalCamera.gameObject.SetActive(true);
                    Vector3 playerToPortal = transform.position - playerCamera.position;
                    portalCamera.transform.rotation = Quaternion.LookRotation(playerToPortal, Vector3.up);
                    portalCamera.transform.position = new Vector3(portalCamera.transform.position.x, playerCamera.position.y, portalCamera.transform.position.z);
                }
                else
                {
                    portalCamera.gameObject.SetActive(false);
                }
            }
            else
            {
                portalCamera.gameObject.SetActive(false);
            }
        }
        else
        {
            portalCamera.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        if (!drawGizmos) return;

        Gizmos.color = new Color(0.5f, 0.0f, 0.5f, 0.8f);
        Gizmos.DrawWireCube(transform.position + offset, area);
    }
}
