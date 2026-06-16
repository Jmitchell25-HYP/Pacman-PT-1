using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class Pacmover : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Rigidbody AX;
    public bool isPacMoving;
    public float travelspeed = 3.5f;
    public int ghostsEaten;
    public bool isPacInvisible;
    public int PowerUpTime = 8;
    public int timeLasted;

    public Transform orientation;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;


    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    








    void Start()
    {
        
        AX = GetComponent<Rigidbody>();
        AX.position = transform.position;
        AX.freezeRotation = true;
    
    }

    private void Update()
    {
        // This is for Ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f );


        MyInput();

        //Handling Drag
        if (grounded)
            AX.linearDamping = groundDrag;
        else
            AX.linearDamping = 0;


    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        MovePac();
    }


    private void MovePac()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        AX.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        MovePac();
    }
    



   

    void Amplifying()
    {

    }

    void PacMan()
    {

    }


    




}
