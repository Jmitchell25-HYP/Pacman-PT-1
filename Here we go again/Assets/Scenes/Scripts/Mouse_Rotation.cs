using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse_Rotation : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform playerCamera;
    [SerializeField] Transform cameraPivot;
    [SerializeField] private float sensitivity = 2f;
    float mouseY;

    private float xRotation = 0f;
    private Rigidbody rb;
    private Vector2 lookInput;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    


        private void Update()
        {
            // Mouse X rotates player
            transform.Rotate(Vector3.up * lookInput.x * sensitivity);

            // Mouse Y rotates camera
            xRotation -= lookInput.y * sensitivity;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);

            cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);



        } 
      
    private void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }
    void FixedUpdate()
    {
        // WASD Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection =
            transform.right * horizontal +
            transform.forward * vertical;

        rb.linearVelocity = new Vector3(
            moveDirection.x * moveSpeed,
            rb.linearVelocity.y,
            moveDirection.z * moveSpeed
        );
    }
}
 