using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay"); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
