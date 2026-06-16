using System;
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
        if (spawnTime < 0)
        {
            Console.WriteLine("Spawn time is delayed!");
        }
        else if (spawnTime > 0)
        {
            Console.WriteLine("Spawn time was too fast!");
        }
        else
        {
            Console.WriteLine("Spawn time is accurate!");

        }

      
        


    }
}
