using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform Orientation;

    float xRotation;
    float yRotation;

    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        // This is for the mouse Input
        float mouseX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Vertical") * Time.deltaTime   * sensY;
        // yRotation adds the assignment
        yRotation += mouseX;
        // xRotation removes the assignment
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        // rotating cam and Orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);

    }
}
