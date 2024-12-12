using UnityEngine;

public class TutorialArrow : MonoBehaviour
{

    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private float amplitude = 2.0f;

    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + Vector3.up * Mathf.Sin(Time.time * speed) * amplitude;
        transform.Rotate(Vector3.right, Time.deltaTime * rotationSpeed);
    }
}
