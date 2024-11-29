using System.Collections;
using UnityEngine;

public class InterractWithOrb : ExamineObject
{
    [Header("Only For Orbs Enigme")]
    public Transform objectToRotate; 
    public float targetPositionUnits = 2f;
    public Transform transformTargetedPos;
    public float transitionSpeed = 2f;
    public Transform cameraBaseTransform;
    public Transform linkedCircle;

    public override void StartExamination()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        base.playerObject.GetComponent<PlayerMovement>().enabled = false;
        camObject.GetComponent<PlayerCam>().enabled = false;
        transform.rotation = currentRotation;

        StartCoroutine(SlideCameraToObject());
    }

    public override void StopExamination()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerObject.GetComponent<PlayerMovement>().enabled = true;
        camObject.GetComponent<PlayerCam>().enabled = true;
        Transform cameraTransform = camObject.transform;
        cameraTransform.position = cameraBaseTransform.position;
    }

    private IEnumerator SlideCameraToObject()
    {
        Transform cameraTransform = camObject.transform;

        Vector3 targetPosition = transformTargetedPos.position + Vector3.up * 2f;

        Quaternion targetRotation = Quaternion.Euler(90f, 0f, 0f);

        Vector3 initialPosition = cameraTransform.position;
        Quaternion initialRotation = cameraTransform.rotation;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * transitionSpeed;

            cameraTransform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            cameraTransform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);

            yield return null;
        }

        cameraTransform.position = targetPosition;
        cameraTransform.rotation = targetRotation;
    }

    public override void Examine()
    {
        Vector3 deltaMouse = Input.mousePosition - base.lastMousePosition;
        float rotationSpeed = 0.2f;

        objectToRotate.Rotate(Vector3.up, -deltaMouse.x * rotationSpeed, Space.World);
        linkedCircle.rotation = objectToRotate.rotation;

        lastMousePosition = Input.mousePosition;
    }
}
