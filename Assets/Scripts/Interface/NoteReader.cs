using UnityEngine;
using UnityEngine.UI;

public class NoteReader : MonoBehaviour
{
    public GameObject noteUI;         // image note
    public GameObject promptUI;       // text that says "Press 5 to read the note"
    private bool isPlayerNear= false;

    void Update()
    {
        if (isPlayerNear&&Input.GetKeyDown(KeyCode.Alpha5))
        {
            noteUI.SetActive(!noteUI.activeSelf); // Toggle note
        }
    }

    // triggers only when the player is near 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear= true;

            if (promptUI!= null)
                promptUI.SetActive(true); // Show the "press 5" prompt
        }
    }

    //disable it
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear=false;

            noteUI.SetActive(false);      // Hide note
            if (promptUI != null)
                promptUI.SetActive(false); // Hide prompt
        }
    }
}
