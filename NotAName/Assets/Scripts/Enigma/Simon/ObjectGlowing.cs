using UnityEngine;

public class GlowObject : MonoBehaviour, IGlowing
{
    public Transform player;

    public float maxDistance = 5f;
    public float minDistance = 2f;
    public Material material;

    public void GlowingMethod()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        float t = Mathf.InverseLerp(maxDistance, minDistance, distanceToPlayer);

        Color color = Color.Lerp(Color.black, Color.green, t);
        material.color = color;

        float emissionIntensity = Mathf.Lerp(-10f, 4f, t);

        emissionIntensity = Mathf.Max(0f, emissionIntensity);

        Color emissionColor = color * emissionIntensity;

        material.EnableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", emissionColor);
    }

    public void UnGlowingMethod()
    {
    }

    void Update()
    {
        GlowingMethod();
    }
}
