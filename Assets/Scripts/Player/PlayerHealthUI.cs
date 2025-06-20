using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;

    [Header("Health Bar")]
    public Image healthBarFill;                 // Health bar fill image
    public TextMeshProUGUI healthText;          // Text showing current 

    [Header("Blood Overlay")]
    public GameObject bloodOverlay;             // UI image or panel shown when health is low

    [Header("Lives UI")]
    public Image[] hearts;                      // Heart icons in the UI
    public Sprite fullHeart;                    // Full heart sprite
    public Sprite emptyHeart;                   // Empty heart sprite

    void OnEnable()
    {
        // Subscribe to lives change event
        PlayerHealth.onLivesChanged += UpdateHearts;
    }

    void OnDisable()
    {
        // Unsubscribe to avoid errors
        PlayerHealth.onLivesChanged -= UpdateHearts;
    }

    void Update()
    {
        // Update health bar fill based on current health ratio
        float ratio = (float)playerHealth.GetCurrentHealth() / playerHealth.maxHealth;
        healthBarFill.fillAmount = ratio;

        // Update the health text 
        healthText.text = playerHealth.GetCurrentHealth() + " / " + playerHealth.maxHealth;

        // Enable blood overlay if health is below 40%
        bloodOverlay.SetActive(ratio < 0.4f);
    }

    // Update the hearts when notified by event
    void UpdateHearts(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Show full heart if i < lives, otherwise show empty heart
            hearts[i].sprite = (i < lives) ? fullHeart : emptyHeart;
        }
    }
}
