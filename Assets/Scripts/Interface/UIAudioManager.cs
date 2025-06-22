using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager instance;  
    public AudioSource audioSource;          // AudioSource used to play UI sounds
    public AudioClip clickSound;             // Sound played on UI click

    void Awake()
    {
        // Implement Singleton pattern
        if (instance==null)
        {
            instance=this;
            DontDestroyOnLoad(gameObject);   // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject);             // Destroy duplicate instance
        }
    }

    // Play the click sound through the audio source
    public void PlayClick()
    {
        if (clickSound!=null && audioSource!=null)
        {
            audioSource.PlayOneShot(clickSound); // Play sound without interrupting others
        }
    }
}
