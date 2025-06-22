using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle= 90f;          // the angle that the door will open in degrees
    public float speed= 3f;               // Speed of door rotation
    public KeyCode openKey=KeyCode.T;    // Key to open the door
    public float interactRange= 7f;       // Max distance for interaction

    public GameObject doorPromptUI;        //UI prompt shown when player is near the door

    private Quaternion closedRotation;     //Original rotation of the door
    private Quaternion openRotation;       //Target rotation when door is open
    private bool isOpen= false;           //Tracks door state
    private Transform player;              //Reference to the player

    void Start()
    {
        // Find the player by tag
        player=GameObject.FindGameObjectWithTag("Player").transform;

        // Set initial and target rotations of the door
        closedRotation=transform.rotation;
        openRotation=Quaternion.Euler(transform.eulerAngles+new Vector3(0, openAngle, 0));

        // Hide the door prompt at the beginning
        if (doorPromptUI!= null)
            doorPromptUI.SetActive(false);
    }

    void Update()
    {
        // Calculate distance from player to door
        float distance=Vector3.Distance(player.position, transform.position);

        // Show the prompt if player is close and door is not already open
        if (doorPromptUI!= null)
            doorPromptUI.SetActive(distance<= interactRange&& !isOpen);

        // Toggle door open/close when player presses the key and is in range
        if (Input.GetKeyDown(openKey)&&distance<= interactRange)
        {
            isOpen=!isOpen;

            // Hide the prompt after interaction
            if (doorPromptUI != null)
                doorPromptUI.SetActive(false);
        }

        // Smoothly rotate door to target rotation (open or closed)
        Quaternion targetRotation=isOpen?openRotation:closedRotation;
        transform.rotation=Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime*speed);
    }
}
