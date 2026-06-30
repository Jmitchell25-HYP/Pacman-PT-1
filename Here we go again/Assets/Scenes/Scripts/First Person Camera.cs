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
    {    // This checks how the cursor should behave
        Cursor.lockState = CursorLockMode.Locked;
        // This determines if whether the hardware pointer is visbile or not
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        // This is for the mouse Input
        float mouseX = Input.GetAxisRaw("mouseX") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("mouseY") * Time.deltaTime   * sensY;
        // yRotation adds the assignment
        yRotation += mouseX;
        // xRotation removes the assignment
        xRotation -= mouseY;
        // Mathf.clamp clamps the given value between a range defined by the given minimum integer and maximum integer values.
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        // rotating cam and Orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);

    }
}
