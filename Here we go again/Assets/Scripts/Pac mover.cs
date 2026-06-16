using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Pacmover : MonoBehaviour
{
    public bool moveUP;
    public bool moveDown;
    public bool moveLeft;
    public bool moveRight;

    public bool wallUp;
    public bool wallDown;
    public bool wallLeft;
    public bool wallRight;
    public Rigidbody AX;

    public float speed = 0.5f;

    public Vector3 Up;
    public Vector3 Down;
    public Vector3 Left;
    public Vector3 Right;






    void Start()
    {
        Up = new Vector3(0, speed, 0);
        Down = new Vector3(0, -speed, 0);
        Right = new Vector3(speed, 0, 0);
        Left = new Vector3(-speed, 0, 0);
        


    }

    void Update()
    {






    }
}