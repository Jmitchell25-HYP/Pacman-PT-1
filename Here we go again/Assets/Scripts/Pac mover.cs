using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class Pacmover : MonoBehaviour
{   
    public Rigidbody AX;
    public float speed = 1;
    public float movementX;
    public float movementY;
    public bool ispowerUp;
    int powerUpTime = 8;
    public bool isGhostSpawned;
    public int ghostsEaten = 0;
    int ghostsSpawned = 6;
   
    void Start()
    {
        AX = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Onmove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void FixedUpdate()
    {   
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        AX.AddForce(movement * speed);
        string[] gameText = { "This will happen" };
        double timeCounter = Math.Floor(ghostsSpawned / Time.deltaTime);
       
      


    }

    void Applied()
    {
        switch (powerUpTime)
        {
            case 1:
                Console.WriteLine("Power up is Activated");
                break;
            case 2:
                Console.WriteLine("Power is deactivated");
                break;

        }


        
    }

    




}
