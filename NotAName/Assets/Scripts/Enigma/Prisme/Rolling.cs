using System.Collections;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    public Transform finalPos;
    public float moveDuration = 2f;
    private bool isMoving = false;
    private bool alreadyUsed = false;
    void Start()
    {
    }

    public void StartRolling()
    {
        if (!isMoving && !alreadyUsed)
        {
            GetComponent<AudioSource>().Play();
            alreadyUsed = true;
            StartCoroutine(RollToPosition());
        }
    }

    private IEnumerator RollToPosition()
    {
        isMoving = true;
        Vector3 startPos = transform.position;
        float startTime = Time.time;

        while (Time.time - startTime < moveDuration)
        {
            float elapsedTime = Time.time - startTime;
            float t = elapsedTime / moveDuration;
            transform.position = Vector3.Lerp(startPos, finalPos.position, t);

            transform.Rotate(Vector3.forward * 360 * (Time.deltaTime / moveDuration), Space.Self);

            yield return null;
        }

        transform.position = finalPos.position;
        isMoving = false;
    }
}
