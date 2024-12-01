using UnityEngine;

public class Page : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cursor;

    void Start()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        cursor.SetActive(false);
    }

    void Update()
    {
        if (UserInput.Instance.InteractInput || UserInput.Instance.PauseInput)
        {
            cursor.SetActive(true);
            this.gameObject.SetActive(false);
            this.gameObject.transform.parent.gameObject.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
