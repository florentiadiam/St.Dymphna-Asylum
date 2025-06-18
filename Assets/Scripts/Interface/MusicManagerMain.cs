using UnityEngine;

public class MusicManagerMain : MonoBehaviour
{
    private void Awake()
    {
        // Don’t destroy this object when loading a new scene
        DontDestroyOnLoad(gameObject);

        // Avoid duplicate music objects if one already exists
        if (FindObjectsOfType<MusicManagerMain>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
