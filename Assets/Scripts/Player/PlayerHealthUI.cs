using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;

    [Header("Health Bar")]
    public Image healthBarFill;                 // Health bar fill image
    public TextMeshProUGUI healthText;          // Text showing current / max health

    [Header("Blood Overlay")]
    public GameObject bloodOverlay;             // UI image or panel shown when health is low

    [Header("Lives UI")]
    public Image[] hearts;                      // Heart icons in the UI
    public Sprite fullHeart;                    // Full heart sprite
    public Sprite emptyHeart;                   // Empty (lost) heart sprite

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
        // Update health bar fill
        float ratio = (float)playerHealth.GetCurrentHealth() / playerHealth.maxHealth;
        healthBarFill.fillAmount = ratio;

        // Update health text
        healthText.text = playerHealth.GetCurrentHealth() + " / " + playerHealth.maxHealth;

        // Enable blood overlay if health < 40%
        bloodOverlay.SetActive(ratio < 0.4f);
    }

    // Update the hearts (lives) when notified by event
    void UpdateHearts(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = (i < lives) ? fullHeart : emptyHeart;
        }
    }
}
