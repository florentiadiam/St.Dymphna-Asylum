using UnityEngine;

public class PlayerMouseMovement : MonoBehaviour
{
    public float moveSpeed= 5f;
    public float rotationSpeed= 100f;
    public Rigidbody rb;

    void Update()
    {
        // forward movement with w
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 forward = transform.forward* moveSpeed*Time.deltaTime;
            rb.MovePosition(rb.position+forward);
        }

        // rotation with the mouse
        float mouseX=Input.GetAxis("Mouse X")*rotationSpeed*Time.deltaTime;
        transform.Rotate(0, mouseX, 0);
    }
}
