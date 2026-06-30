using UnityEngine;

public class Ghosts : MonoBehaviour
{
    public Rigidbody A;
    bool GhostCollsion;
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
            Debug.Log("The player hasn't yet been destoryed");
            GhostCollsion = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }




}
