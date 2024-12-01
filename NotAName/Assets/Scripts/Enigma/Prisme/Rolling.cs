using System.Collections;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    public Transform finalPos;
    public float moveDuration = 2f;
    private bool isMoving = false;

    void Start()
    {
    }

    public void StartRolling()
    {
        if (!isMoving)
        {
            GetComponent<AudioSource>().Play();
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

            transform.Rotate(Vector3.right * 360 * (Time.deltaTime / moveDuration), Space.World);

            yield return null;
        }

        transform.position = finalPos.position;
        isMoving = false;
    }
}
