using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayEasy()
    {
        SceneManager.LoadScene("EasyLevel");
    }

    public void PlayHard()
    {
        SceneManager.LoadScene("HardLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

