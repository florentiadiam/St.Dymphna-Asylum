using UnityEngine;
using UnityEngine.SceneManagement;

//Difficulty scene controller
public class MenuController : MonoBehaviour
{
    //if the player presses the play easy button then load the easy level sceene 
    public void PlayEasy()
    {
        SceneManager.LoadScene("EasyLevel");
    }

    //if the player pressed the play hard button then load the hard level scene
    public void PlayHard()
    {
        SceneManager.LoadScene("HardLevel");
    }

    //if player presses the quit button then quit
    public void QuitGame()
    {
        Application.Quit();
    }
}

