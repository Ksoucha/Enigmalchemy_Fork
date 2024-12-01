using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{

    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject lore;
    [SerializeField] private GameObject cursor;

    private float timeElapsed = 0.0f;
    private float wait = 5.0f;

    private bool switched = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cursor.SetActive(false);
        credits.SetActive(false);
        lore.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (!switched && timeElapsed >= wait && (UserInput.Instance.InteractInput || UserInput.Instance.PauseInput))
        {
            credits.SetActive(true);
            credits.GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
            switched = true;

            // Animate a fade in
            lore.SetActive(false);
        }
        if (switched)
        {
            if (credits.GetComponent<RawImage>().color.a < 1)
            {
                credits.GetComponent<RawImage>().color = new Color(1, 1, 1, credits.GetComponent<RawImage>().color.a + 0.1f);
            }
            else
            {
                if (UserInput.Instance.InteractInput || UserInput.Instance.PauseInput)
                {
                    Application.Quit();
                }
            }
        }
    }
}
