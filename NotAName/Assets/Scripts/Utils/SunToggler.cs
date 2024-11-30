using UnityEngine;

public class SunToggler : MonoBehaviour
{
    [SerializeField] private Vector2 area;
    [SerializeField] private Transform player;
    [SerializeField] private float intensity;
    [SerializeField] private float defaultIntensity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultIntensity = this.GetComponent<Light>().intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > transform.position.x - area.x / 2 && player.position.x < transform.position.x + area.x / 2 &&
            player.position.z > transform.position.z - area.y / 2 && player.position.z < transform.position.z + area.y / 2)
        {

            this.GetComponent<Light>().intensity = intensity;
        }
        else
        {

            this.GetComponent<Light>().intensity = defaultIntensity;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(area.x, 0, area.y));
    }
}
