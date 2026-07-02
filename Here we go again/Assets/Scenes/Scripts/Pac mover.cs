using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Pacmover : MonoBehaviour
{
   

    private Animator anim;
    public Rigidbody MTX;
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;
    public GameObject pauseMenu;
    private bool isPaused = false;
    

    void Start()
    {
        MTX = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        // Calls this false in the start function
        winTextObject.gameObject.SetActive(false);
    }

    void Update()
    {
        if (score >= 16)
        {   // Calls this true in the Update function
            winTextObject.gameObject.SetActive(true);
            Time.timeScale = 0;
        }


        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();

        
    }

  
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
  

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

    }

    
  

}