using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GlowObject : MonoBehaviour, IGlowing
{
    public Transform player;

    public float maxDistance = 5f;
    public float minDistance = 2f;

    [SerializeField] private bool printStatus;

    public void GlowingMethod()
    {
        Vector3 flatPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 flatPlayerPos = new Vector3(player.position.x, 0, player.position.z);

        float distanceToPlayer = Vector3.Distance(flatPlayerPos, flatPos);
        if (printStatus) Debug.Log("GlowingMethod called. Distance to player: " + distanceToPlayer);

        float t = Mathf.InverseLerp(maxDistance, minDistance, distanceToPlayer);

        float emissionIntensity = Mathf.Lerp(0f, 500f, t);

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
