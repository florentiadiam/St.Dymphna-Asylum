using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    
    public AudioSource musicSource;
    public Button toggleMusicButton;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;
    private bool musicOn= true;
    private Image buttonImage;
    private static MusicController instance;

    //Called before Start()
    private void Awake()
    {
        // Destroy duplicate instances if one already exists (because there are multiple audios)
        if (instance!=null&&instance!=this)
        {
            Destroy(gameObject);
            return;
        }

        // Keep this instance across scene loads
        instance=this;
        DontDestroyOnLoad(gameObject);

        // Subscribe to scene load events to handle music logic
        SceneManager.sceneLoaded+=OnSceneLoaded;
    }

    
    void Start()
    {
        // Attempt to find and connect the toggle button
        SetupButton();

        //Update icon based on music state
        UpdateIcon();

        // Start music if it's not already playing and music is enabled
        if (musicSource!=null && !musicSource.isPlaying&& musicOn)
        {
            musicSource.loop= true;
            musicSource.Play();
        }
    }

    // Called automatically every time a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reconnect toggle button in new scene
        SetupButton();
        UpdateIcon();

        // stop menu music when entering the game level
        if (scene.name=="EasyLevel" || scene.name=="HardLevel")
        {
            if (musicSource!= null)
                musicSource.Stop();
        }
        else
        {
            // Resume music in all other scenes if enabled
            if (musicSource!=null&&!musicSource.isPlaying && musicOn)
            {
                musicSource.loop= true;
                musicSource.Play();
            }
        }
    }

    //find the toggle button and set up the click event
    private void SetupButton()
    {
        GameObject buttonObj = GameObject.Find("SoundToggleButton");

        if (buttonObj != null)
        {
            toggleMusicButton = buttonObj.GetComponent<Button>();
            buttonImage = buttonObj.GetComponent<Image>();

            toggleMusicButton.onClick.RemoveAllListeners();
            toggleMusicButton.onClick.AddListener(ToggleMusic);
            toggleMusicButton.interactable = true;
        }
        else
        {
            // No button in this scene — silent fallback
            toggleMusicButton = null;
            buttonImage = null;
        }
    }

    // Toggles music on/off and updates the button icon
    public void ToggleMusic()
    {
        musicOn = !musicOn;

        if (musicSource != null)
            musicSource.mute = !musicOn;

        UpdateIcon();
    }

    // Updates the button icon to match current music state
    private void UpdateIcon()
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = musicOn ? soundOnIcon : soundOffIcon;
        }
    }
}
