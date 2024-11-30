using UnityEngine;

public class AllChildsFollows : MonoBehaviour
{
    void Update()
    {
        foreach (Transform child in transform) 
        {
            child.position = transform.position;
            child.localScale = transform.localScale;
        }
    }
}
