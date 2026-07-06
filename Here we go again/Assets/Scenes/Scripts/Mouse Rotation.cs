using UnityEngine;
using UnityEngine.InputSystem;
public class MouseRotation : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform playerCamera;
    public float sensX;
    public float sensY;
    private Rigidbody rb;


    private float xRotation = 0f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse Look
        float mouseX = Input.GetAxisRaw("Horizontal");
        float mouseY = Input.GetAxisRaw("Vertical");

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    

}
