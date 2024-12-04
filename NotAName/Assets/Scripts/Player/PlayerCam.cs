using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    Vector2 offset;

    void Start()
    {
        offset = UserInput.Instance.CameraInput;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = UserInput.Instance.CameraInput.x * Time.deltaTime * (UserInput.Instance.CameraSensitivity / 5.5f);
        float mouseY = UserInput.Instance.CameraInput.y * Time.deltaTime * (UserInput.Instance.CameraSensitivity / 5.5f);

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(transform.position, transform.forward * 5);
    // }
}
