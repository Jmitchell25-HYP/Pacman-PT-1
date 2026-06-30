using System;
using System.Collections;
using UnityEngine;

public class ghostSpawner : MonoBehaviour
{
    public int GhostSpawned = 8;
    public bool isGhostSpawning;
    public bool isSpawning;
    public bool isSpawned;
    public float spawnTime;
    public Rigidbody LP;
    public float GhostMovement;
    public GameObject spawner;


   

    public enum GhostColours
    {
        Red,
        Green,
        Blue,
        Magenta,
        Yellow,
        Pink,
        Silver,
        Orange



    }


    void Start()
    {
        LP = GetComponent<Rigidbody>();



    }

    
    void Update()
    {   // These lines of code check if the spawn time is accurate

        if (isSpawned)
        {
            

        }


        if (spawnTime < 0)
        {
            Console.WriteLine("Spawn time is delayed!");
            // The spawner starts off false as the GameObject activates or deactivates locally
            spawner.SetActive(false);
            spawnTime += Time.deltaTime;

        }
        else if (spawnTime > 0)
        {   // Then it becomes true in the second if statement
            Console.WriteLine("Spawn time was too fast!");
            spawner.SetActive(true);
        }
        else
        {    //Then returns false in else
            Console.WriteLine("Spawn time is accurate!");
            spawner.SetActive(false);

        }

      
        


    }
}
