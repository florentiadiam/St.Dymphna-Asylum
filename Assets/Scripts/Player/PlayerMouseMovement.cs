using UnityEngine;

public class PlayerMouseMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public Rigidbody rb;

    void Update()
    {
        // Κίνηση μπροστά
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 forward = transform.forward * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + forward);
        }

        // Περιστροφή με το ποντίκι
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, mouseX, 0);
    }
}
