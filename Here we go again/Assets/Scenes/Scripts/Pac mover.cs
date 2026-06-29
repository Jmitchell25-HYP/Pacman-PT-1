using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
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
        winTextObject.gameObject.SetActive(false);
    }

    void Update()
    {
        if (score >= 17)
        {
            winTextObject.gameObject.SetActive(true);
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();

        
    }

    private void FixedUpdate()
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

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
  

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

    }

}