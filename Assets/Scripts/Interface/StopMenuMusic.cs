using UnityEngine;

public class StopMenuMusic : MonoBehaviour
{
    void Start()
    {
        // Find the object named "MenuMusic" and stop just its audio
        GameObject menuMusic = GameObject.Find("MenuMusic");

        if (menuMusic != null)
        {
            AudioSource music = menuMusic.GetComponent<AudioSource>();
            if (music != null)
            {
                music.Stop(); // Stops menu music without affecting level music or sound controls
            }
        }
    }
}

