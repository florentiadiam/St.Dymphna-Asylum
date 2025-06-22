using UnityEngine;

// Enum representing different types of power-ups
public enum PowerUpType { Speed, Invisibility, CameraSwitch, Flashlight }

public class PowerUpPickup : MonoBehaviour
{
    public PowerUpType type;              
    private bool isPlayerInRange=false; // Tracks if player is within pickup range
    private GameObject player;            

    public GameObject promptText;         // UI prompt shown when player is near

    void Start()
    {
        // Hide the interaction prompt at the beginning
        if (promptText!= null)
            promptText.SetActive(false);
    }

    void Update()
    {
        // If player is not in range, do nothing
        if (!isPlayerInRange || player==null)
            return;

        // Show prompt while player is in range
        if (promptText!= null)
            promptText.SetActive(true);

        // Check input based on power-up type
        if ((type==PowerUpType.CameraSwitch&& Input.GetKeyDown(KeyCode.Alpha3)) ||
            (type==PowerUpType.Invisibility && Input.GetKeyDown(KeyCode.Alpha2)) ||
            (type==PowerUpType.Speed&& Input.GetKeyDown(KeyCode.Alpha1)) ||
            (type==PowerUpType.Flashlight && Input.GetKeyDown(KeyCode.Alpha4)))
        {
            // Give the power-up to the player
            player.GetComponent<PlayerPowerUp>().AddPowerUp(type);
            Debug.Log("Power-up collected: " + type);

            // Hide prompt after pickup
            if (promptText != null)
                promptText.SetActive(false);

            
        }
    }

    //Detect when the player enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange= true;
            player= other.gameObject;
        }
    }

    // Detect when the player leaves the trigger zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange= false;
            player= null;

            // Hide prompt when player exits the area
            if (promptText!= null)
                promptText.SetActive(false);
        }
    }
}
