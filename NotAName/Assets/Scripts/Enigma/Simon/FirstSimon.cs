using System.Collections;
using UnityEngine;

public class FirstSimon : SteleSolved
{
    public GameObject translateOne;
    public GameObject translatePosOne;
    public GameObject translateTwo;
    public GameObject translatePosTwo;
    public float translateTime;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float falloffSpeed = 0.1f;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume = .8f;
    [SerializeField] private AudioClip lastMusicClip;
    [SerializeField] private float lastVolume = .8f;

    public override void ResolvedLogic()
    {
        if (translateOne != null)
        {
            StartCoroutine(MoveToPosition(translateOne, translatePosOne.transform.position, translateTime));
            translateOne.GetComponent<AudioSource>().Play();
        }

        if (translateTwo != null)
        {
            StartCoroutine(MoveToPosition(translateTwo, translatePosTwo.transform.position, translateTime));
            translateTwo.GetComponent<AudioSource>().Play();
        }

        if (audioSource != null)
        {
            StartCoroutine(ReduceVolume(audioSource, falloffSpeed));
        }
    }

    private IEnumerator ReduceVolume(AudioSource source, float speed)
    {
        while (source.volume > 0)
        {
            source.volume -= speed * Time.deltaTime;
            yield return null;
        }
        source.Stop();
        yield return new WaitForSeconds(0.5f);
        source.clip = audioClip;
        source.volume = volume;
        yield return new WaitForSeconds(0.5f);
        source.Play();
        yield return new WaitForSeconds(60.0f * 4.0f);
        StartCoroutine(VerifyPlaying(source, audioClip));
    }

    private IEnumerator VerifyPlaying(AudioSource source, AudioClip clip)
    {
        while (source.isPlaying)
        {
            yield return new WaitForSeconds(1.0f);
        }
        source.Stop();
        source.clip = lastMusicClip;
        source.volume = lastVolume;
        yield return new WaitForSeconds(4.0f);

        source.Play();
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

