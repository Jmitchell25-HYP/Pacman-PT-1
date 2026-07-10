using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathManager 
{
    [SerializeField] private GameObject deathScreenPanel;
    

    private void Die()
    { // Activate the Death Screen
        deathScreenPanel.SetActive(true);

        Time.timeScale = 0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void RestartGame()
    { // Unpause time before reloading
        Time.timeScale = 1f;
        
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }














}
