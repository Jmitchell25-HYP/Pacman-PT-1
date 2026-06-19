using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Pacmover : MonoBehaviour
{
    
   
    public Rigidbody AX;
    private float movementX;
    private float movementY;
    public bool isMoving;

    public int pacLives = 3;
    public int ghostsConsumed;
    public float speed = 0;

    






    void Start()
    {
        AX.GetComponent<Rigidbody>();


    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        AX = GetComponent<Rigidbody>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {  Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        AX.AddForce(movement * speed);
        AX.AddForce(movement);
    }



    void Update()
    {

       

        if (pacLives < 3)
        {
            Console.WriteLine("You Suck");
            SceneManager.LoadScene(pacLives);
            return;

        }
        else if (ghostsConsumed > 3)
        {
            Console.WriteLine("You've completed the game");
            SceneManager.LoadScene(ghostsConsumed);
            return;
        }
        else
        {
            Console.WriteLine("Three more ghosts to go");
            
        }




    }
}