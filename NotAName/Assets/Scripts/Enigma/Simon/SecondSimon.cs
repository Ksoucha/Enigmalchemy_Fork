using UnityEngine;

public class SecondSimon : SteleSolved
{
    public GameObject dispear;
    public GameObject appear;
    [SerializeField] private AudioSource audioSource;


    public override void ResolvedLogic()
    {
        dispear.SetActive(false);
        appear.SetActive(true);
        audioSource.Play();
    }
}
