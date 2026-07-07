using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse_Rotation : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;
    float xRotation = 0f;
    [SerializeField] Transform playerCamera;
    public Rigidbody rb;
    public float movementSpeed = 5f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void FixedUpdate()
    {
        var gamepad = Gamepad.current;
       

        if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            
        }

        Vector2 move = gamepad.leftStick.ReadValue();
        Vector3 moveDir = transform.right * move.x + transform.forward * move.y;
        rb.linearVelocity = new Vector3(moveDir.x * movementSpeed, rb.linearVelocity.y, moveDir .z * movementSpeed);    

    }
}
 