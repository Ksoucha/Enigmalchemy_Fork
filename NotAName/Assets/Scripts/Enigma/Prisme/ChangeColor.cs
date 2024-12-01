using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Transform player; 
    public Material targetMaterial;  
    public float maxDistance = 2f; 
    public float minDistance = 1f; 

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        float t = Mathf.InverseLerp(maxDistance, minDistance, distance);

        Color currentColor = Color.HSVToRGB(t, 1f, 1f);

        targetMaterial.SetColor("_Color", currentColor);
    }
}