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

        float playerCamY = playerCamera.position.y;
        float portalOffsetYMinus = (transform.position.y - area.y / 2) + offset.y;
        float portalOffsetYPlus = (transform.position.y + area.y / 2) + offset.y;
        float playerCamX = playerCamera.position.x;
        float portalOffsetXMinus = (transform.position.x - area.x / 2) + offset.x;
        float portalOffsetXPlus = (transform.position.x + area.x / 2) + offset.x;
        float playerCamZ = playerCamera.position.z;
        float portalOffsetZMinus = (transform.position.z - area.z / 2) + offset.z;
        float portalOffsetZPlus = (transform.position.z + area.z / 2) + offset.z;

        float portalCamZ = portalCamera.transform.position.z;
        float portalCamX = portalCamera.transform.position.x;

        portalCamera.gameObject.SetActive(false);

        if (playerCamY > portalOffsetYMinus && playerCamY < portalOffsetYPlus)
        {
            if (playerCamX > portalOffsetXMinus && playerCamX < portalOffsetXPlus)
            {
                if (playerCamZ > portalOffsetZMinus && playerCamZ < portalOffsetZPlus)
                {
                    portalCamera.gameObject.SetActive(true);
                    Vector3 playerToPortal = transform.position - playerCamera.position;
                    portalCamera.transform.rotation = Quaternion.LookRotation(playerToPortal, Vector3.up);
                    portalCamera.transform.position = new Vector3(portalCamX, playerCamY, portalCamZ);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!drawGizmos) return;

        Gizmos.color = new Color(0.5f, 0.0f, 0.5f, 0.8f);
        Gizmos.DrawWireCube(transform.position + offset, area);
    }
}
