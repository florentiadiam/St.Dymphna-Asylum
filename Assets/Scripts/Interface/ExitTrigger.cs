using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    private bool triggered=false;

    //Called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered and trigger hasn't already happened
        if (!triggered&&other.CompareTag("Player"))
        {
            //if the trigger has happened
            triggered=true;

            // Find the EscapeManager in the scene
            EscapeManager escapeManager= FindObjectOfType<EscapeManager>();
            if (escapeManager!= null)
            {
                // Call the escape logic
                escapeManager.TriggerEscape();
            }
            else
            {
                // Log a warning if no EscapeManager is found
                Debug.LogWarning("EscapeManager not found in the scene.");
            }
        }
    }
}
