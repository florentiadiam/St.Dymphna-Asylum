using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SelectDifficulty");
    }

  public void HowToPlay()
{
    SceneManager.LoadScene("GuideScene");
}

 public void Story()
    {
        
    SceneManager.LoadScene("StoryScene");

    }
    public void Exit()
    {
        Application.Quit();
    }
}
