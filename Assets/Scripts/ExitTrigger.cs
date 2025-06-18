using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;

            EscapeManager escapeManager = FindObjectOfType<EscapeManager>();
            if (escapeManager != null)
            {
                escapeManager.TriggerEscape();
            }
            else
            {
                Debug.LogWarning("EscapeManager not found in the scene.");
            }
        }
    }
}
