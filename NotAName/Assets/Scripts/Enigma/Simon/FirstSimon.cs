using System.Collections;
using UnityEngine;

public class FirstSimon : SteleSolved
{
    public GameObject translateOne;
    public GameObject translatePosOne;
    public GameObject translateTwo;
    public GameObject translatePosTwo;
    public float translateTime;

    [SerializeField]
    private AudioClip correctSound;

    public override void ResolvedLogic()
    {
        translateOne.GetComponent<AudioSource>().clip = correctSound;
        StartCoroutine(MoveToPosition(translateOne, translatePosOne.transform.position, translateTime));
        translateOne.GetComponent<AudioSource>().Play();

        translateTwo.GetComponent<AudioSource>().clip = correctSound;
        StartCoroutine(MoveToPosition(translateTwo, translatePosTwo.transform.position, translateTime));
        translateTwo.GetComponent<AudioSource>().Play();
    }

    private IEnumerator MoveToPosition(GameObject obj, Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = obj.transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            obj.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = targetPosition;
    }
}

