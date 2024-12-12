using Unity.VisualScripting;
using UnityEngine;

public class DollsComeHere : MonoBehaviour, IInteractable
{

    private Vector3 startScale;

    [SerializeField]
    private float scaleSpeed = 1f;

    [SerializeField]
    private float amplitude = .3f;


    void Start()
    {
        startScale = this.transform.localScale;
    }

    public void Hover()
    {

    }

    void Update()
    {
        this.transform.localScale = startScale + Vector3.one * Mathf.Sin(Time.time * scaleSpeed) * amplitude;
    }
    public bool CanInteract(PickupController item)
    {
        return true;
    }

    public void Interact()
    {
        this.gameObject.SetActive(false);
    }
}
