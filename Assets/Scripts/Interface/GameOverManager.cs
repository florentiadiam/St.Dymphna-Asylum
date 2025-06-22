using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;           // UI shown when game is over
    public static bool isGameOver= false;  // Tracks game over state
    public GameObject GameOverUI;           

    void Start()
    {
        // Hide game over UI and reset game over state
        gameOverUI.SetActive(false);
        isGameOver= false;
    }

    
    public void ShowGameOver()
    {
        Time.timeScale= 0f;               // Pause the game
        gameOverUI.SetActive(true);        // Show UI
        isGameOver= true;

        // Unlock and show cursor for UI interaction
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Disable player controls
        GameObject player= GameObject.FindGameObjectWithTag("Player");
        if (player!= null)
        {
            PlayerMovement movement= player.GetComponent<PlayerMovement>();
            if (movement!= null)
                movement.inputEnabled = false;
        }
    }

    // Restart the current scene
    public void TryAgain()
    {
        Time.timeScale= 1f;
        isGameOver= false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Load the main menu scene
    public void LoadMainMenu()
    {
        Time.timeScale= 1f;
        isGameOver= false;
        SceneManager.LoadScene("MainMenu");
    }

    // Quit the game
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game closed.");
    }

    // Alternate way to trigger game over without disabling movement
    public void TriggerGameOver()
    {
        isGameOver=true;
        gameOverUI.SetActive(true);
        Time.timeScale= 0f;

        // Show cursor
        Cursor.lockState= CursorLockMode.None;
        Cursor.visible= true;
    }
}
