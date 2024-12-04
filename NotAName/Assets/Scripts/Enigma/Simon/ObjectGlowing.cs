using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GlowObject : MonoBehaviour, IGlowing
{
    public Transform player;

    public float maxDistance = 5f;
    public float minDistance = 2f;

    public void GlowingMethod()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        float t = Mathf.InverseLerp(maxDistance, minDistance, distanceToPlayer);

        float emissionIntensity = Mathf.Lerp(0f, 900f, t);

        emissionIntensity = Mathf.Max(0f, emissionIntensity);

        GetComponent<Light>().intensity = emissionIntensity;
    }

    public void UnGlowingMethod()
    {
    }

    void Update()
    {
        GlowingMethod();
    }
}
