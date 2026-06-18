using UnityEngine;
using UnityEngine.InputSystem;

public class MouseRotation : MonoBehaviour
{
    [SerializeField] public float sensitivity = 100f;
    [SerializeField] private Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        //Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 mouseInput = Mouse.current.delta.ReadValue();

        float mouseX = mouseInput.x * sensitivity * Time.deltaTime;
        float mouseY = mouseInput.y * sensitivity * Time.deltaTime;

        // Calculate vertical rotation (pitch) and clamp it
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        //Apply camera rotation (up and down)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Apply horizontal rotation to the player
        if (playerBody != null)
        {
            playerBody.Rotate(Vector3.up * mouseX);

        }
        else
        {
            transform.Rotate(Vector3.up * mouseX);
        }



    }

    

}
