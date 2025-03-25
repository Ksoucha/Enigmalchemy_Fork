using Unity.VisualScripting;
using UnityEngine;

public class DollsComeHere : IInteractable
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

    public override void Hover()
    {

    }

    void Update()
    {
        this.transform.localScale = startScale + Vector3.one * Mathf.Sin(Time.time * scaleSpeed) * amplitude;
    }
    public override bool CanInteract(Pickup item)
    {
        return true;
    }

    public override void Interact()
    {
        this.gameObject.SetActive(false);
    }
}
