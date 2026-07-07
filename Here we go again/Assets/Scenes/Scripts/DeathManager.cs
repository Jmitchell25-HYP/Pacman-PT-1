using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject deathScreenCanvas;

    // Show the death screen
    public void ShowDeathScreen()
    {
        deathScreenCanvas.SetActive(true);
        //Pause the game
        Time.timeScale = 1f;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quitgame()
    {
        Application.Quit(1);
    }

}
