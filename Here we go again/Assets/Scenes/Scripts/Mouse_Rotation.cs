using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Mouse_Rotation : MonoBehaviour
{ 
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform playerCamera;
    [SerializeField] private float sensitivity = 2f;
    float mouseY;
    float _speed;

    private float xRotation = 0f;
    private Rigidbody rb;
    private Vector2 m_lookAmt;
    private Vector3 _direction;

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        _direction = context.ReadValue<Vector2>();
    }
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    

    void Update()
    {
        transform.Translate(_direction * (_speed * Time.deltaTime));
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
 