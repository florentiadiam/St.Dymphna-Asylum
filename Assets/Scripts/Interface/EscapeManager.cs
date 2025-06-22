using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeManager : MonoBehaviour
{
    public GameObject escapeUI;         //UI to show when the player escapes
    public static bool hasEscaped= false; //Tracks if the player has escaped

    void Start()
    {
        // Hide escape UI at the beginning
        if (escapeUI!= null)
            escapeUI.SetActive(false);

        hasEscaped = false;
    }

    // Call this when the player escapes the level
    public void TriggerEscape()
    {
        hasEscaped=true;

        // Pause the game
        Time.timeScale= 0f;

        // Show the escape UI
        if (escapeUI!= null)
            escapeUI.SetActive(true);

        // Unlock and show the cursor for UI interaction
        Cursor.lockState= CursorLockMode.None;
        Cursor.visible= true;

        // Disable player movement
        GameObject player=GameObject.FindGameObjectWithTag("Player");
        if (player!= null)
        {
            PlayerMovement movement= player.GetComponent<PlayerMovement>();
            if (movement!= null)
                movement.inputEnabled=false;
        }
    }

    // If player presses the button "Try again" restart the current level
    public void TryAgain()
    {
        Time.timeScale=1f;
        hasEscaped=false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // If the player presses "Try hard level" toggle between Easy and Hard levels depending on current scene
    public void TryHardLevel()
    {
        Time.timeScale=1f;
        hasEscaped=false;

        string currentScene=SceneManager.GetActiveScene().name;

        if (currentScene=="EasyLevel")
        {
            // If currently in EasyLevel, switch to HardLevel
            SceneManager.LoadScene("HardLevel");
        }
        else if (currentScene=="HardLevel")
        {
            // If currently in HardLevel, switch to EasyLevel
            SceneManager.LoadScene("EasyLevel");
        }
        else
        {
            Debug.LogWarning("TryHardLevel() called from unknown scene: " + currentScene);
        }
    }


    // If the player presses "Load the main menu" go back to main menu scene
    public void LoadMainMenu()
    {
        Time.timeScale=1f;
        hasEscaped=false;
        SceneManager.LoadScene("MainMenu");
    }

    //If the player presses "Exit game" then quit
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game closed.");
    }
}
