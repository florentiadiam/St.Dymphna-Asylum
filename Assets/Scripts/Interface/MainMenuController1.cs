using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    //if player presses the play button then load the select difficulty scene
    public void Play()
    {
        SceneManager.LoadScene("SelectDifficulty");
    }

    //if the player presses the How to play button then load the guide scene 
    public void HowToPlay()
    {
        SceneManager.LoadScene("GuideScene");
    }

    //if the player presses the story button the load the story scene
    public void Story()
    {
        
    SceneManager.LoadScene("StoryScene");

    }

    //if the player presses the exit button then quit
    public void Exit()
    {
        Application.Quit();
    }
}
