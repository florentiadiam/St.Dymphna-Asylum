using UnityEngine;
using UnityEngine.UI;

public class LevelMusicController : MonoBehaviour
{

    public AudioSource levelMusic;
    public Button toggleButton;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;
    private bool musicOn = true;

    // Called once when the scene starts
    void Start()
    {
        // If a toggle button exists in the scene, configure it
        if (toggleButton != null)
        {
            // Register the toggle event listener
            toggleButton.onClick.AddListener(ToggleMusic);

            // Display the correct icon based on current state
            UpdateIcon();
        }
    }

    // Toggles the music on or off and updates the icon
    void ToggleMusic()
    {
        // Flip the music state
        musicOn = !musicOn;

        // Mute or unmute the audio source accordingly
        levelMusic.mute = !musicOn;

        // Update the toggle icon to reflect the change
        UpdateIcon();
    }

    // Changes the button icon to match the current music state
    void UpdateIcon()
    {
        if (toggleButton != null)
        {
            toggleButton.GetComponent<Image>().sprite = musicOn ? soundOnIcon : soundOffIcon;
        }
    }
}
