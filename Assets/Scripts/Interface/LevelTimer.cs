using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float timeLimit=120f;      // Total time for the level in seconds
    public TMP_Text timerText;          //UI text element
    private float currentTime;          // Tracks remaining time
    private bool isTimeRunning= true;  
    public GameOverManager gameOverManager; // Reference to GameOverManager to trigger game over

    void Start()
    {
        // Initialize timer to the set limit
        currentTime=timeLimit;
    }

    void Update()
    {
        if (isTimeRunning)
        {
            // Decrease time by deltaTime each frame
            currentTime-=Time.deltaTime;

            // If time reaches 0 stop the timer and end the level
            if (currentTime<= 0)
            {
                currentTime= 0;
                isTimeRunning=false;
                EndLevel();
            }

            //Update the timer UI every frame
            UpdateTimerUI();
        }
    }

    // Format the time and update the UI text
    void UpdateTimerUI()
    {
        int minutes=Mathf.FloorToInt(currentTime / 60);
        int seconds=Mathf.FloorToInt(currentTime % 60);
        timerText.text=$"{minutes:00}:{seconds:00}";
    }

    // Called when time runs out
    void EndLevel()
    {
        Debug.Log("Time's up!");
        gameOverManager.TriggerGameOver(); // Triggers game over state
    }
}
