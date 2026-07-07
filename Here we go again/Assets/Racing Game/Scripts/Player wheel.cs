using UnityEngine;
using UnityEngine.InputSystem;

public class Playerwheel : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float reverseSpeed = 10f;
    public float TurnSpeed = 100f;
    public float brakeDrag = 5f;

    public float steeringInput = 0f;
    private Vector3 velocity = Vector3.zero;

    private InputAction joystickThrottle;
    private InputAction KeyboardThrottle;
    private InputAction joystickBrake;
    private InputAction KeyboardBrake;
    private InputAction steeringAction;

    void OnEnable()
    {
        //Set up joystick and keyboard as seperate actions
        joystickThrottle = new InputAction(type: InputActionType.Value, binding: "<Joystick>/z");
        KeyboardThrottle = new InputAction(type: InputActionType.Value, binding: "<Keyboard>/m");

        joystickBrake = new InputAction(type: InputActionType.Value, binding: "Joystick>/rz");
        KeyboardBrake = new InputAction(type: InputActionType.Value, binding: "<Keyboard>/s");

        steeringAction = new InputAction(type: InputActionType.Value);
        steeringAction.AddBinding("<Joystick>/stick/x");
        steeringAction.AddCompositeBinding("1DAxis")
        .With("negative", "<Keyboard>/a")
        .With("positive", "<Keyboard>/d");

        joystickThrottle.Enable();
        KeyboardThrottle.Enable();
        KeyboardBrake.Enable();
        joystickBrake.Enable();
        steeringAction.Enable();
            
    }

    void Update()
    {
        // Joystick pedals: reutrn 1 when idle, 0 when fully pressed
        float rawJoyThrottle = joystickThrottle.ReadValue<float>();
        float rawJoyBrake = joystickBrake.ReadValue<float>();

        // Invert Joystick values if the pedal is actually pressed
        float joyThrottle = rawJoyThrottle < 0.99f ? 1f - rawJoyThrottle : 0f;
        float joyBrake = rawJoyBrake < 0.99f ? 1f - rawJoyBrake : 0f;

        // Keyboard returns 0 or 1
        float keyThrottle = KeyboardThrottle.ReadValue<float>();
        float keyBrake = KeyboardBrake.ReadValue<float>();

        // Combine both - use whichever input is stronger
        float throttleInput = Mathf.Max(joyThrottle, keyThrottle);
        float brakeInput = KeyboardBrake.ReadValue<float>();
        steeringInput = steeringAction.ReadValue<float>();

        Vector3 moveDirection = Vector3.zero;

        if (throttleInput > 0.1f)
        {
            moveDirection = transform.forward * throttleInput * moveSpeed;

        }
        else if (brakeInput > 0.1f)
        {
            moveDirection = -transform.forward * brakeInput * reverseSpeed;
            
        }
        else
        {
            // slow down when no input
            velocity = Vector3.Lerp(velocity, Vector3.zero, brakeDrag * Time.deltaTime);
        }

        if (moveDirection != Vector3.zero)
        {
            velocity = moveDirection;
        }

        transform.Translate(velocity * Time.deltaTime, Space.World);

        float turn = steeringInput * TurnSpeed * Time.deltaTime;
        transform.Rotate(0f, turn, 0f);









    }






































}
