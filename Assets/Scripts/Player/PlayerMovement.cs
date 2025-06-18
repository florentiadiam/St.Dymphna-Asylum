using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float strafeSpeed = 3f;
    public float mouseSensitivity = 3f;
    public Animator animator;

    private Rigidbody rb;
    private float rotationY = 0f;

    public bool inputEnabled = true; // NEW: toggle movement externally (e.g. game over)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!inputEnabled || GameOverManager.isGameOver)
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0, rotationY, 0);

        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

        if (animator != null)
            animator.SetBool("isRunning", isMoving);
    }

    void FixedUpdate()
    {
        if (!inputEnabled || GameOverManager.isGameOver)
            return;

        Vector3 inputDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            inputDirection += transform.forward;
        if (Input.GetKey(KeyCode.A))
            inputDirection -= transform.right;
        if (Input.GetKey(KeyCode.D))
            inputDirection += transform.right;

        Vector3 movement = inputDirection.normalized * moveSpeed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
