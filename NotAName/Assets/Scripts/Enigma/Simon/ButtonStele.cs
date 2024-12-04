using UnityEngine;

public class ButtonStele : MonoBehaviour, IInteractable, IGlowing
{
    public bool isGood = false;
    public bool isEnabled = false;
    public bool solved = false;
    private Material material;

    private Color x938572 = new Color(0.576f, 0.521f, 0.447f);

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
        material.color = Color.green;
        Color emissionColor = Color.green * 3;

        // material.EnableKeyword("_EMISSION");
        material.SetFloat("_EmissiveExposureWeight", 0);
    }

    public virtual void UnGlowingMethod()
    {
        material.color = x938572;
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
