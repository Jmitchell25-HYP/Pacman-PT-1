using UnityEngine;
using UnityEngine.InputSystem;
public class MouseRotation : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float Sensitivity = 0.1f;

    private Vector2 lookInput;
    private float xRotation = 0f;
    public float moveSpeed = 5f;
    private Vector2 moveInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        float mouseX = lookInput.x * Sensitivity;
        float mouseY = lookInput.y * Sensitivity;

        // Camera up / down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Player  left / right
        playerBody.Rotate(Vector3.up * mouseX);










    }













}
