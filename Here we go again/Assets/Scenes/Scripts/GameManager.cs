using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager 
{
    public GameObject pauseMenu;

    private bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }


            
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);

        Time.timeScale = 1;

        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);

        Time.timeScale = 0;

        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }


}
