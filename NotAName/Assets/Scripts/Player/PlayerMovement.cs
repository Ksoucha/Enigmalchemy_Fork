using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    bool readyToJump;
    // [Header("Keybinds")]
    // public KeyCode jumpKey = KeyCode.Space;
    // public KeyCode crounchKey = KeyCode.LeftControl;
    // public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

    Rigidbody rb;
    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        air,
        crounching
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        startYScale = transform.localScale.y;
    }
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.7f + 0.2f, whatIsGround);
        MyInput();
        StateHandler();
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 10;
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(transform.position, transform.position + Vector3.down * (playerHeight * 0.5f + 0.2f));
    // }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = UserInput.Instance.MovementInput.x;
        verticalInput = UserInput.Instance.MovementInput.y;
        if (UserInput.Instance.JumpInput && readyToJump && grounded)
        {

            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        if (UserInput.Instance.CrouchInput && transform.localScale.y == startYScale)
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
        if (!UserInput.Instance.CrouchInput && transform.localScale.y != startYScale)
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }

    }
    private void StateHandler()
    {
        RaycastHit hit;
        if (UserInput.Instance.CrouchInput)
        {
            state = MovementState.crounching;
            moveSpeed = crouchSpeed;
        }
        if (grounded && UserInput.Instance.SprintInput)
        {
            Physics.Raycast(transform.position, Vector3.down, out hit, playerHeight * 0.5f + 0.2f, whatIsGround);
            if (hit.collider != null)
            {
                float angle = Mathf.Abs(hit.transform.rotation.x) * Mathf.Rad2Deg;
                if (angle >= 10f && angle <= 13f)
                    moveSpeed = sprintSpeed * 3f;
                else
                    moveSpeed = sprintSpeed;
            }
        }
        else if (grounded)
        {
            Physics.Raycast(transform.position, Vector3.down, out hit, playerHeight * 0.5f + 0.2f, whatIsGround);
            if (hit.collider != null)
            {
                float angle = Mathf.Abs(hit.transform.rotation.x) * Mathf.Rad2Deg;
                if (angle >= 10f && angle <= 13f)
                    moveSpeed = walkSpeed * 3f;
                else
                    moveSpeed = walkSpeed;
            }
            state = MovementState.walking;
        }
        else
        {
            state = MovementState.air;
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
