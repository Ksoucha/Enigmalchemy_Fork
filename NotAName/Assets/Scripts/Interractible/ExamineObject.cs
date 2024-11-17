using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class ExamineObject : MonoBehaviour
{
    public Transform offset;
    GameObject playerObject;
    GameObject camObject;
    public KeyCode pickKey = KeyCode.E;
    public KeyCode examineKey = KeyCode.Mouse0;
    public float pickUpRange = 3f;
    public Transform player;
    public bool isExamining = false;
    public Canvas _canva;
    private Vector3 lastMousePosition;
    private bool inRange = false;


    //List of position and rotation of the interactble objects 
    private Vector3 originalPosition;
    private Quaternion originalRotation;



    void Start()
    {
        _canva.enabled = false;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        playerObject = GameObject.Find("Player");
        camObject = GameObject.Find("PlayerCam");
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= pickUpRange) inRange = true;
        else inRange = false;

        if (Input.GetKeyDown(pickKey) && inRange)
        {
            ToggleExamination();
            if (isExamining) StartExamination();
            else
            {
                StopExamination();
                NonExamine();
            }
        }

        if (Input.GetKey(examineKey) && isExamining)
        {
            _canva.enabled = false;
            Examine(); 
        }
        else if (!isExamining && inRange) _canva.enabled = true;
        else _canva.enabled = false;
    }

    public void ToggleExamination()
    {
        isExamining = !isExamining;
    }

    void StartExamination()
    {
        lastMousePosition = Input.mousePosition;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerObject.GetComponent<PlayerMovement>().enabled = false;
        camObject.GetComponent<PlayerCam>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Collider>().enabled = false;
        transform.position = offset.position;
    }

    void StopExamination()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerObject.GetComponent<PlayerMovement>().enabled = true;
        camObject.GetComponent<PlayerCam>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Collider>().enabled = true;
    }

    void Examine()
    {
        // move object with mouse
        Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
        float rotationSpeed = 0.2f;
        transform.Rotate(deltaMouse.x * rotationSpeed * Vector3.down, Space.World);
        transform.Rotate(deltaMouse.y * rotationSpeed * Vector3.left, Space.World);
        lastMousePosition = Input.mousePosition;
    }


    void NonExamine()
    {
        transform.position = Vector3.Lerp(transform.position, originalPosition, 0.2f);
        transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, 0.2f);
    }

}
