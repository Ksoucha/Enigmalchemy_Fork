using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput Instance { get; private set; }
    private PlayerInput playerInput;
    private InputAction movement;
    private InputAction view;
    private InputAction jump;
    private InputAction sprint;
    private InputAction crouch;
    private InputAction interact;
    private InputAction inspect;
    private InputAction pause;

    public Vector2 MovementInput { get; private set; }
    public Vector2 CameraInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool SprintInput { get; private set; }
    public bool CrouchInput { get; private set; }
    public bool InteractInput { get; private set; }
    public bool InspectInput { get; private set; }
    public bool PauseInput { get; private set; }

    public float CameraSensitivity { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerInput = GetComponent<PlayerInput>();

        SetupInputActions();
    }

    private void Update()
    {
        MovementInput = movement.ReadValue<Vector2>();
        CameraInput = view.ReadValue<Vector2>();
        JumpInput = jump.WasPressedThisFrame();
        SprintInput = sprint.IsPressed();
        CrouchInput = crouch.IsPressed();
        InteractInput = interact.WasPressedThisFrame();
        InspectInput = inspect.WasPressedThisFrame();
        PauseInput = pause.WasPressedThisFrame();
    }

    private void SetupInputActions()
    {
        movement = playerInput.actions["Movement"];
        view = playerInput.actions["Camera"];
        jump = playerInput.actions["Jump"];
        sprint = playerInput.actions["Sprint"];
        crouch = playerInput.actions["Crouch"];
        interact = playerInput.actions["Interact"];
        inspect = playerInput.actions["Inspect"];
        pause = playerInput.actions["Pause"];
    }

    private void UpdateInputActions()
    {
        movement.Enable();
        view.Enable();
        jump.Enable();
        sprint.Enable();
        crouch.Enable();
        interact.Enable();
        inspect.Enable();
        pause.Enable();
    }
}
