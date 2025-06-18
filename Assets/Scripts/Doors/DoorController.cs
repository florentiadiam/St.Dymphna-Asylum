using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f;
    public float speed = 3f;
    public KeyCode openKey = KeyCode.T;
    public float interactRange = 3f;

    public GameObject doorPromptUI; // 👈 drag your TMP UI prompt here

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isOpen = false;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));

        if (doorPromptUI != null)
            doorPromptUI.SetActive(false); // hide at start
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        // Show/hide the UI prompt based on distance
        if (doorPromptUI != null)
            doorPromptUI.SetActive(distance <= interactRange && !isOpen);

        // Toggle door when close enough and key is pressed
        if (Input.GetKeyDown(openKey) && distance <= interactRange)
        {
            isOpen = !isOpen;

            if (doorPromptUI != null)
                doorPromptUI.SetActive(false); // hide after open
        }

        Quaternion targetRotation = isOpen ? openRotation : closedRotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * speed);
    }
}
