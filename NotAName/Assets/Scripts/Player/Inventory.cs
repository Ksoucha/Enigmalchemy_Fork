using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<PickupController> pickedUpItems;
    public KeyCode interractKey = KeyCode.E;
    [Header("Some range")]
    public float interactRange;
    private Transform player;
    void Start()
    {
        pickedUpItems = new List<PickupController>();
        player = GetComponent<Transform>();
    }

    void Update()
    {
        if(Input.GetKeyDown(interractKey))
            pickedUpItems.ForEach(x => {x.InteractWithObject();});
    }

    public void AddItem(PickupController c)
    {
        pickedUpItems.Add(c);
    }
}
