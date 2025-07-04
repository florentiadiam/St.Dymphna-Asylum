using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth= 100;       // The player's max health
    public int totalLives= 2;        // Total number of lives the player has (first in the easy level)

    private int currentHealth;        // Current health in this life
    private int currentLives;         // Remaining lives

    // Event to notify UI when lives change
    public delegate void OnLivesChanged(int lives);
    public static event OnLivesChanged onLivesChanged;

    void Start()
    {
        // Initialize lives and health
        currentLives= totalLives;
        currentHealth= maxHealth;

        // Notify the UI about the initial number of lives
        onLivesChanged?.Invoke(currentLives);
    }

    // Call this method to apply damage to the player
    public void TakeDamage(int amount)
    {
        currentHealth-=amount;
        Debug.Log("Player took damage. New health: "+currentHealth);

    //if his health reaches 0, loose one life
        if (currentHealth<=0)
        {
            LoseLife();
        }
    }

    // Handle losing a life and check for Game Over
    void LoseLife()
    {
        currentLives--;

        // Notify the UI
        onLivesChanged?.Invoke(currentLives);

        //if the player still has remaining lives, full his bar health again
        if (currentLives>0)
        {
            currentHealth = maxHealth;
        }
        else
        {
            Die();
        }
    }

    // Handle final death and show game over screen
    void Die()
    {

        // Try to find and show the Game Over UI
        GameOverManager gameOver = GameObject.FindObjectOfType<GameOverManager>();
        if (gameOver!= null)
        {
            gameOver.ShowGameOver();
        }
        else
        {
            Debug.LogWarning("GameOverManager not found in scene.");
        }
    }

    // Getters for health and lives
    public int GetCurrentHealth() => currentHealth;
    public int GetCurrentLives() => currentLives;
}
