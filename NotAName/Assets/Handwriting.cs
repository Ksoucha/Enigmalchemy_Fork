using TMPro;
using UnityEngine;

public class Handwriting : MonoBehaviour
{
    [SerializeField] private string text;

    private int currentFrame = 0;

    [SerializeField]
    private float timeBeforeStart = 1.0f;
    private float timeElapsed = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        timeElapsed = 0.0f;
        this.GetComponent<TextMeshProUGUI>().text = "";
        currentFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeBeforeStart)
        {
            currentFrame++;

            if (currentFrame % 3 == 0 && currentFrame / 3 <= text.Length)
            {
                this.GetComponent<TextMeshProUGUI>().text = text.Substring(0, currentFrame / 3);
            }
        }

    }
}
