using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    

    public void RestartGame()
    {        
        SceneManager.LoadScene("GamePlay");
    }

    public void GoToMainMenu()
    {       
        SceneManager.LoadScene("MainMenu"); 
    }
}
