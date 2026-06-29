using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
public class Pacmover : MonoBehaviour
{
    public float playerSpeed;
    public float sprintSpeed = 4f;
    public float walkSpeed = 2f;
    public float mouseSensitivity = 3f;
    public float jumpHeight = 3f;
    public bool isMoving = false;
    public bool isSprinting = false;
    public float yRot;
   

    private Animator anim;
    public Rigidbody MTX;
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;

    void Start()
    {
        MTX = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        winTextObject.SetActive(false);
    }

    void Update()
    {
        if (score >= 15)
        {
            winTextObject.SetActive(true);
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

}