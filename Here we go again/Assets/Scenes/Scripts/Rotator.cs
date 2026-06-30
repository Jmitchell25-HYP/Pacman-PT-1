using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {

    }


    private void FixedUpdate()
    {
        transform.Rotate(0,0,rotateSpeed); 
    }

}
