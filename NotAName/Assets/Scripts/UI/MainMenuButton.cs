using UnityEngine;

public class MainMenuButton : MonoBehaviour
{

    [SerializeField] private Transform lightPosition;
    [SerializeField] private Transform settingsPosition;
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSelect()
    {
        cursor.transform.position = lightPosition.position;
    }

    public void OnDeselect()
    {
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void Settings()
    {
        cam.GetComponent<Animator>().SetBool("IsOnSettings", true);
        cursor.transform.position = settingsPosition.position;
    }

    public void Play()
    {
        cam.GetComponent<Animator>().SetTrigger("FadeOut");
        Invoke("LoadScene", 1.0f);
    }

    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

}
