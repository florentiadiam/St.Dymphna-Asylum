using UnityEngine;

public enum PowerUpType { Speed, Invisibility, CameraSwitch, Flashlight }

public class PowerUpPickup : MonoBehaviour
{
    public PowerUpType type;
    private bool isPlayerInRange = false;
    private GameObject player;

    public GameObject promptText; // The UI prompt

    void Start()
    {
        if (promptText != null)
            promptText.SetActive(false); // Hide prompt initially
    }

void Update()
{
    if (!isPlayerInRange || player == null)
        return;

    if (promptText != null)
        promptText.SetActive(true);

    if ((type == PowerUpType.CameraSwitch && Input.GetKeyDown(KeyCode.Alpha3)) ||
        (type == PowerUpType.Invisibility && Input.GetKeyDown(KeyCode.Alpha2)) ||
        (type == PowerUpType.Speed && Input.GetKeyDown(KeyCode.Alpha1)) ||
        (type == PowerUpType.Flashlight && Input.GetKeyDown(KeyCode.Alpha4)))
    {
        player.GetComponent<PlayerPowerUp>().AddPowerUp(type);
        Debug.Log("Power-up collected: " + type);

        if (promptText != null)
            promptText.SetActive(false);

      
    }
}


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            player = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            player = null;

            if (promptText != null)
                promptText.SetActive(false); // Hide prompt when player leaves
        }
    }
}
