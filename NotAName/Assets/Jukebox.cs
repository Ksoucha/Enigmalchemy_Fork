using UnityEngine;

public class Jukebox : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip music;
    [SerializeField] private float volume = 0.9f;
    private bool toggle = false;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !toggle)
        {
            audioSource.volume = volume;
            audioSource.clip = music;
            audioSource.Play();
            toggle = true;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
