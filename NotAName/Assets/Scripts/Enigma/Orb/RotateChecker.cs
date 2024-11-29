using System.Collections;
using UnityEngine;

public class RotateChecker : MonoBehaviour
{
    [Header("Circle to check here (A = GoodRota, B = Interractible)")]
    public Transform objectA; 
    public Transform objectB; 
    public float tolerance = 7f; 
    public float checkInterval = 2f;

    public InterractWithOrb interractWithOrb;

    [Header("Orbs to move")]
    public Transform movingObject1;
    public Transform targetPosition1;
    public Vector3 initialPosition1; 

    public Transform movingObject2; 
    public Transform targetPosition2; 
    public Vector3 initialPosition2;

    private Coroutine checkRoutine;
    private Coroutine moveRoutine;

    [Header("Success object ")]
    public GameObject successGameObjectToAppear;

    void Start()
    {
        initialPosition1 = movingObject1.position; 
        initialPosition2 = movingObject2.position; 

        checkRoutine = StartCoroutine(CheckRotationPeriodically());
    }

    IEnumerator CheckRotationPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkInterval);
            CheckRotation();
        }
    }

    void CheckRotation()
    {
        float rotationAY = NormalizeAngle(objectA.eulerAngles.y);
        float rotationBY = NormalizeAngle(objectB.eulerAngles.y);

        if (Mathf.Abs(rotationAY - rotationBY) <= tolerance)
        {
            Debug.Log("Current rota is good");
            interractWithOrb.pickKey = KeyCode.None;
            interractWithOrb.StopExamination();
            successGameObjectToAppear.SetActive(true);

            if (moveRoutine != null)
                StopCoroutine(moveRoutine);
            moveRoutine = StartCoroutine(MoveBothObjectsToTargets());
        }
        else
        {
            Debug.Log("Les rotations diffèrent.");
            ResetObjectsPositions();
        }
    }

    IEnumerator MoveBothObjectsToTargets()
    {
        Vector3 startPosition1 = movingObject1.position;
        Vector3 endPosition1 = targetPosition1.position;

        Vector3 startPosition2 = movingObject2.position;
        Vector3 endPosition2 = targetPosition2.position;

        float elapsedTime = 0f;

        while (elapsedTime < checkInterval)
        {
            movingObject1.position = Vector3.Lerp(startPosition1, endPosition1, elapsedTime / checkInterval);
            movingObject2.position = Vector3.Lerp(startPosition2, endPosition2, elapsedTime / checkInterval);

            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        movingObject1.position = endPosition1;
        movingObject2.position = endPosition2;
    }

    void ResetObjectsPositions()
    {
        if (moveRoutine != null)
        {
            StopCoroutine(moveRoutine); 
        }

        movingObject1.position = initialPosition1;
        movingObject2.position = initialPosition2;
    }

    float NormalizeAngle(float angle)
    {
        while (angle > 180f) angle -= 360f;
        while (angle < -180f) angle += 360f;

        return angle;
    }

    void OnDisable()
    {
        if (checkRoutine != null)
        {
            StopCoroutine(checkRoutine);
        }

        if (moveRoutine != null)
        {
            StopCoroutine(moveRoutine);
        }
    }
}
