using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class ExamineObject : MonoBehaviour, IInteractable
{
    public Transform offset;
    protected GameObject playerObject;
    protected GameObject camObject;
    public KeyCode pickKey = KeyCode.E;
    public KeyCode examineKey = KeyCode.Mouse0;
    public float pickUpRange = 3f;
    public Transform player;
    public bool isExamining = false;
    public Canvas _canva;
    protected Vector3 lastMousePosition;
    private bool inRange = false;
    public Transform spawn;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    protected Quaternion currentRotation;
    private bool isDragging = false; 

    void Start()
    {
        _canva.enabled = false;
        playerObject = GameObject.Find("Player");
        camObject = GameObject.Find("PlayerCam");
        transform.position = spawn.position;
        transform.rotation = spawn.rotation;
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        currentRotation = transform.rotation;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        inRange = distanceToPlayer <= pickUpRange;

        if (UserInput.Instance.InteractInput && inRange)
        {
            ToggleExamination();
            if (isExamining)
                StartExamination();
            else
            {
                StopExamination();
                NonExamine();
            }
        }

        if (isExamining)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Input.mousePosition;
                isDragging = true;
            }

            if (Input.GetMouseButton(0) && isDragging)
            {
                Examine();
            }

            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                isDragging = false;

                currentRotation = transform.rotation;
            }
        }
        else if (!isExamining && inRange)
        {
            _canva.enabled = true;
        }
        else
        {
            _canva.enabled = false;
        }
    }

    public void ToggleExamination()
    {
        isExamining = !isExamining;
    }

    public virtual void StartExamination()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerObject.GetComponent<PlayerMovement>().enabled = false;
        camObject.GetComponent<PlayerCam>().enabled = false;
        GetComponent<Collider>().enabled = false;
        transform.position = offset.position;

        transform.rotation = currentRotation;
    }

    public virtual void StopExamination()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerObject.GetComponent<PlayerMovement>().enabled = true;
        camObject.GetComponent<PlayerCam>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }

    public virtual void Examine()
    {
        Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
        float rotationSpeed = 0.2f;

        transform.Rotate(deltaMouse.x * rotationSpeed * Vector3.down, Space.World);
        transform.Rotate(deltaMouse.y * rotationSpeed * Vector3.left, Space.World);

        lastMousePosition = Input.mousePosition;
    }

    public virtual void NonExamine()
    {
        transform.position = spawn.position;
        transform.rotation = originalRotation;

        currentRotation = originalRotation;
    }

    public bool CanInteract(PickupController item)
    {
        return false;
    }

    public void Interact()
    {
        Debug.Log("U can't WTF");
    }
}
