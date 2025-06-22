using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  //pause menu UI panel
    private bool isPaused=false;  // Tracks whether the game is currently paused

    void Update()
    {
        // Prevent pausing if the game is already over
        if (GameOverManager.isGameOver)
            return;

        // Toggle pause menu when Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    // Resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);     // Hide pause menu
        Time.timeScale= 1f;              // Unpause time
        isPaused= false;

        // Lock and hide cursor for gameplay
        Cursor.lockState= CursorLockMode.Locked;
        Cursor.visible= false;
    }

    // Pause the game
    public void Pause()
    {
        pauseMenuUI.SetActive(true);      // Show pause menu
        Time.timeScale= 0f;              // Pause time
        isPaused= true;

        // Unlock and show cursor for UI interaction
        Cursor.lockState= CursorLockMode.None;
        Cursor.visible= true;
    }

    // Restart the current level
    public void Restart()
    {
        Time.timeScale= 1f;              // Ensure time is unpaused
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Load the main menu scene
    public void LoadMainMenu()
    {
        Time.timeScale= 1f;
        SceneManager.LoadScene("MainMenu");
    }

    // Quit the game 
    public void ExitGame()
    {
        Application.Quit();
    }
}
