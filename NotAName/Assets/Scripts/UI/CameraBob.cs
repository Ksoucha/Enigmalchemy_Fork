using UnityEngine;

public class CameraBob : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Mathf.Sin(Time.time * speed) * range * Time.deltaTime);
        transform.Rotate(Vector3.up, Mathf.Sin(Time.time * speed) * range * Time.deltaTime);
    }
}
