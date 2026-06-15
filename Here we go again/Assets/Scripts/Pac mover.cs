using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class Pacmover : MonoBehaviour
{
    public Rigidbody AX;
    public float speed = 1;
    public float movementX;
    public float movementY;
    public bool Is_Able_To_Phase_Through;
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

    }

    




}
