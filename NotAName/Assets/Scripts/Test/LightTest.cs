using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class LightTest : MonoBehaviour
{
    [Header("Path")]
    public Transform[] points;
    public int currentTarget = 1;
    public float speed = .1f;
    public float waitTime;
    public bool goingForward = true;

    [Header("Debug")]
    public bool drawPath = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = points[0].position;
        StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FollowPath()
    {
        while (true)
        {
            if (transform.position == points[currentTarget].position)
            {
                if (currentTarget == points.Length - 1)
                {
                    goingForward = false;
                    yield return new WaitForSeconds(waitTime);
                }
                else if (currentTarget == 0)
                {
                    goingForward = true;
                    yield return new WaitForSeconds(waitTime);
                }
                currentTarget += goingForward ? 1 : -1;
            }
            transform.position = Vector3.MoveTowards(transform.position, points[currentTarget].position, speed * Time.deltaTime);
            yield return null;
        }
    }

    void OnDrawGizmos()
    {
        if (!drawPath)
            return;
        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(points[i].position, .1f);
            if (i < points.Length - 1)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(points[i].position, points[i + 1].position);
            }
        }
    }
}
