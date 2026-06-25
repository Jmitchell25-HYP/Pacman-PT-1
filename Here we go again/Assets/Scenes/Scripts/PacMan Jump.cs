using UnityEngine;

public class PacManJump : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy body"))
        {
            Debug.Log("Death");
        }
        

    }
}
