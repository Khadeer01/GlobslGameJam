using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    
    public void PlayGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game"); 
        Application.Quit();
    }
}
