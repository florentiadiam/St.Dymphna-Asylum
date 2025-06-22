using UnityEngine;
using UnityEngine.SceneManagement;

//If button is pressed, return to main menu
public class BackButtonController : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
