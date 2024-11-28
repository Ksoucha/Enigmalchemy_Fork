using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject cursor;

    [SerializeField] private List<GameObject> menuItems = new List<GameObject>();
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip selectSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var menuItem in menuItems)
        {
            Button button = menuItem.GetComponent<Button>();
        }
    }

    public void OnSelect()
    {
        Debug.Log("Selected");
    }

    public void OnDeselect()
    {
        Debug.Log("Deselected");
    }

    public void OnSelectChange()
    {
        audioSource.clip = selectSound;
        audioSource.Play();
    }
}
