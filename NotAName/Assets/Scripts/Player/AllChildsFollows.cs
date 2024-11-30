using UnityEngine;

public class AllChildsFollows : MonoBehaviour
{
    void Update()
    {
        foreach (Transform child in transform) 
        {
            child.position = transform.position;
            child.rotation = transform.rotation;
            child.localScale = transform.localScale;
        }
    }
}
