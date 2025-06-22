using UnityEngine;

// Ensure the GameObject has a Rigidbody component
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed= 5f;
    public float strafeSpeed= 3f; 
    public float mouseSensitivity= 3f;
    public Animator animator;

    private Rigidbody rb;
    private float rotationY= 0f;

    public bool inputEnabled= true; 

    void Start()
    {
        // Get Rigidbody component and prevent unwanted physics rotation
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation= true;

        //Lock and hide the cursor for first-person control
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
    }

    void Update()
    {
        // Disable movement if input is off or game is over
        if (!inputEnabled||GameOverManager.isGameOver)
            return;

        // Rotate player horizontally based on mouse input
        float mouseX=Input.GetAxis("Mouse X")*mouseSensitivity;
        rotationY+= mouseX;
        transform.rotation=Quaternion.Euler(0, rotationY, 0);

        // Check if any movement keys are pressed
        bool isMoving=Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D);

        // Update the animation state
        if (animator!= null)
            animator.SetBool("isRunning", isMoving);
    }

    void FixedUpdate()
    {
        // Disable movement if input is off or game is over
        if (!inputEnabled||GameOverManager.isGameOver)
            return;

        Vector3 inputDirection = Vector3.zero;

        // Determine movement direction based on input
        if (Input.GetKey(KeyCode.W))
            inputDirection+= transform.forward;
        if (Input.GetKey(KeyCode.A))
            inputDirection-= transform.right;
        if (Input.GetKey(KeyCode.D))
            inputDirection+= transform.right;

        // Move the player using Rigidbody for physics-based movement
        Vector3 movement= inputDirection.normalized* moveSpeed;
        rb.MovePosition(rb.position+movement*Time.fixedDeltaTime);
    }
}
