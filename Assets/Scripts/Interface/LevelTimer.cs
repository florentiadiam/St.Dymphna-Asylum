using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float timeLimit = 120f; // Συνολικός χρόνος πίστας (σε δευτερόλεπτα)
   public TMP_Text timerText;         // UI Text για εμφάνιση του χρόνου
    private float currentTime;
    private bool isTimeRunning = true;
    public GameOverManager gameOverManager; 

    void Start()
    {
        currentTime = timeLimit; // Αρχικοποίηση του χρόνου
    }

    void Update()
    {
        if (isTimeRunning)
        {
            currentTime -= Time.deltaTime; // Μείωσε τον χρόνο ανά frame

            if (currentTime <= 0)
            {
                currentTime = 0;
                isTimeRunning = false;
                EndLevel(); // Τέλος πίστας αν τελειώσει ο χρόνος
            }

            UpdateTimerUI(); // Ενημέρωσε το UI
        }
    }

    void UpdateTimerUI()
    {
        // Μετατροπή χρόνου σε λεπτά:δευτερόλεπτα
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
  void EndLevel()
    {
        Debug.Log("Time's up!");
        gameOverManager.TriggerGameOver(); // Καλεί το GameOver
    }
}
