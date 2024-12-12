using UnityEngine;

public class ButtonStele : MonoBehaviour, IInteractable, IGlowing
{
    public bool isGood = false;
    public bool isEnabled = false;
    public bool solved = false;
    private Material material;


    [SerializeField] private GameObject[] highlight;
    [SerializeField] private LayerMask interactible;
    private bool hover = false;

    private void Update()
    {
        if (hover == false)
        {
            foreach (GameObject obj in highlight)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            hover = false;
        }
    }

    public void Hover()
    {
        if (!isEnabled && !solved)
        {
            foreach (GameObject obj in highlight)
            {
                obj.SetActive(true);
            }
            hover = true;
        }
    }

    public virtual bool CanInteract(PickupController item)
    {
        if (!isEnabled && !solved)
        {
            return true;
        }
        return false;
    }

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    public virtual void GlowingMethod()
    {
        // material.color = Color.green;
        Color emissionColor = Color.green * 3;

        // material.EnableKeyword("_EMISSION");
        material.SetFloat("_EmissiveExposureWeight", 0);
    }

    public virtual void UnGlowingMethod()
    {
        Color emissionColor = Color.green * -10;

        // material.EnableKeyword("_EMISSION");
        material.SetFloat("_EmissiveExposureWeight", 1);
        this.isEnabled = false;
    }
    public virtual void Interact()
    {
        GlowingMethod();
        this.isEnabled = true;

        AudioSource audio = this.GetComponent<AudioSource>();

        if (audio != null)
        {
            audio.Play();
        }
    }


}
