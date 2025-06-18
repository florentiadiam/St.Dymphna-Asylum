using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool isGameOver = false;
    public GameObject GameOverUI;
    void Start()
    {
        gameOverUI.SetActive(false);
        isGameOver = false;
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        isGameOver = true;

        // Show cursor so player can click UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Disable player input
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
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game closed.");
    }
    
 public void TriggerGameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None; // Ξεκλείδωσε τον κέρσορα
        Cursor.visible = true;                  // Κάνε τον κέρσορα ορατό
    }
}
