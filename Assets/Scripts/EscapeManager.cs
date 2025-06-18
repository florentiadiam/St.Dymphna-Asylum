using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeManager : MonoBehaviour
{
    public GameObject escapeUI;
    public static bool hasEscaped = false;

    void Start()
    {
        if (escapeUI != null)
            escapeUI.SetActive(false);

        hasEscaped = false;
    }

    public void TriggerEscape()
    {
        hasEscaped = true;
        Time.timeScale = 0f;

        if (escapeUI != null)
            escapeUI.SetActive(true);

        // Ενεργοποίηση κέρσορα για το UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Απενεργοποίηση ελέγχου παίκτη
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerMovement movement = player.GetComponent<PlayerMovement>();
            if (movement != null)
                movement.inputEnabled = false;
        }
    }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        hasEscaped = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TryHardLevel()
    {
        Time.timeScale = 1f;
        hasEscaped = false;
        SceneManager.LoadScene("HardLevel"); // Βεβαιώσου ότι υπάρχει στο Build Settings
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        hasEscaped = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game closed.");
    }
}
