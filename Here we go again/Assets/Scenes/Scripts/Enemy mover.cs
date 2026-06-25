using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class Enemymover : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
  

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    { 
        if (player!= null)
        {
            agent.SetDestination(player.position);
        }

    }

}



