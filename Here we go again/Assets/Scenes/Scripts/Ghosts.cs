using UnityEngine;
using System.Collections;


public class Ghosts : MonoBehaviour
{
    public Rigidbody A;
    bool GhostCollsion;
    string text = "Pac Man is dead";
    void Start()
    {
        A = GetComponent<Rigidbody>();  
    }

  
    void Update()
    {
        if (GhostCollsion == true)
        {
            Debug.Log("Player has been destroyed");
            GhostCollsion = false;
        }
        else
        {
            Debug.Log("The player hasn't yet been destroyed");
          
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PAC MAN"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Pac Man has been killed");
        }

    }








}
